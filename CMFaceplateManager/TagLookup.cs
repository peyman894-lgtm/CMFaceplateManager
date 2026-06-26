using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CMFaceplateManager
{
    public class TagLookup
    {
        private string csvPath;

        public TagLookup(string csvFilePath)
        {
            csvPath = csvFilePath;
        }

        private string[] FindRow(string prefix)
        {
            var lines = new List<string>();

            using (var fs = new FileStream(csvPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(fs))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    lines.Add(line);
            }

            return lines.Skip(1)
                        .Select(l => l.Split(','))
                        .FirstOrDefault(cols => cols.Last().Trim() == prefix.Trim());
        }

        // TAG,Description,from,to,Format,Unit,Alarm,Type,Prefix
        //  0       1        2   3    4     5     6    7     8

        public string TAG(string prefix)
        {
            var row = FindRow(prefix);
            return row != null ? row[0].Trim() : null;
        }

        public string Description(string prefix)
        {
            var row = FindRow(prefix);
            return row != null ? row[1].Trim() : null;
        }

        public string Range(string prefix)
        {
            var row = FindRow(prefix);
            if (row == null) return null;
            string from = row[2].Trim();
            string to = row[3].Trim();
            string unit = row[5].Trim();
            return $"{from} - {to} {unit}";
        }

        public string HR(string prefix)
        {
            var row = FindRow(prefix);
            return row != null ? row[3].Trim() : null;   // to
        }

        public string LR(string prefix)
        {
            var row = FindRow(prefix);
            return row != null ? row[2].Trim() : null;   // from
        }

        public string Format(string prefix)
        {
            var row = FindRow(prefix);
            return row != null ? row[4].Trim() : null;
        }

        // Alarm string is like "A2200"
        // Position:              A[LL][L][H][HH]
        //                         [1] [2][3][4]
        // Non-zero digit = alarm enabled

        private char AlarmDigit(string[] row, int pos)
        {
            // row[6] = Alarm e.g. "A2200"
            string alarm = row[6].Trim();
            return alarm.Length > pos ? alarm[pos] : '0';
        }

        public bool ShowHH(string prefix)
        {
            var row = FindRow(prefix);
            return row != null && AlarmDigit(row, 4) != '0';   // A xxx 1 — last char
        }

        public bool ShowH(string prefix)
        {
            var row = FindRow(prefix);
            return row != null && AlarmDigit(row, 3) != '0';   // A xx 1 x
        }

        public bool ShowL(string prefix)
        {
            var row = FindRow(prefix);
            return row != null && AlarmDigit(row, 2) != '0';   // A x 1 xx
        }

        public bool ShowLL(string prefix)
        {
            var row = FindRow(prefix);
            return row != null && AlarmDigit(row, 1) != '0';   // A 1 xxx
        }

    }
}