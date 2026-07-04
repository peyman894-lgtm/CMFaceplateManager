using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CMFaceplateManager
{
    public class TasterLookup
    {
        private readonly string csvPath;

        public TasterLookup(string csvFilePath)
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
                        .FirstOrDefault(cols => cols.Length > 1 &&
                                                cols[1].Trim() == prefix.Trim());
        }

        // Type,Prefix,Tag,Description,text upper button,text lower button,Tag upper button,Tag lower button
        //  0     1     2       3              4                 5                6                7

        public string ProcessTag(string prefix)
        {
            var row = FindRow(prefix);
            return row != null && row.Length > 2 ? row[2].Trim() : null;
        }

        public string Description(string prefix)
        {
            var row = FindRow(prefix);
            return row != null && row.Length > 3 ? row[3].Trim() : null;
        }

        public string UpperButtonText(string prefix)
        {
            var row = FindRow(prefix);
            return row != null && row.Length > 4 ? row[4].Trim() : null;
        }

        public string LowerButtonText(string prefix)
        {
            var row = FindRow(prefix);
            return row != null && row.Length > 5 ? row[5].Trim() : null;
        }
    }
}