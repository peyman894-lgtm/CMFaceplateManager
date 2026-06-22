# ControlMaestro Faceplate Addon

A C# WinForms rewrite of the legacy Wizcon `STR_Indication.exe` addon, ported to integrate with ControlMaestro 2018 (CM2018).

## Development Environment Setup

### Option 1: Visual Studio Community (Easiest) ⭐

For WinForms faceplates and DLL integration, this is by far the easiest route.

**Install:**

[Visual Studio Community 2022](https://visualstudio.microsoft.com/vs/community/)

During installation select:
- **.NET desktop development** workload

**Create the project:**

1. Create New Project
2. **Windows Forms App (.NET Framework)**
3. Target Framework: **4.8**
4. Build Target: **x86**

> ⚠️ The build target **must** be x86 — `Wizpro.dll` and `WIZ5API.dll` are 32-bit DLLs and will fail to load under a 64-bit (`Any CPU`/`x64`) build.

**Advantages:**
- ✅ Drag-and-drop GUI designer
- ✅ Easy debugging
- ✅ Excellent DLL support
- ✅ Better than VS Code for WinForms



## Architecture

```
ControlMaestro Runtime
        |
        | writes
        v
    INDICATOR
        |
        v
FaceplateManager.exe
        |
        | reads INDICATOR continuously
        |
        +--> Open AnalogFaceplate(Tag1)
        |
        +--> Open AnalogFaceplate(Tag2)
        |
        +--> Open AnalogFaceplate(Tag3)
```



`FaceplateManager.exe` continuously polls the `INDICATOR` tag written by ControlMaestro. Whenever the tag changes, the manager opens the corresponding analog faceplate window for the relevant tag, mirroring the behavior of the original legacy Wizcon addon.

## Requirements

- Windows 10/11
- ControlMaestro 2018 installed locally (for `Wizpro.dll` / `WIZ5API.dll`)
- Visual Studio Community 2022 with .NET desktop development workload
- .NET Framework 4.8

## Related Documentation

- CM2018 API reference (`CMMkClient`, `CMGetGateVal`, `CMPutGateVal`, `CMGetGateRawValue`, `CMCook`, `CMRunMacroByName`, etc.)
- CM2018 Toolkit API reference



# 🛠️ Visual Studio Setup Guide — C# WinForms with 32-bit DLL Support

This guide walks through installing **Visual Studio** with the components needed to build
a **C# WinForms** application (.NET Framework) that interoperates with **32-bit (x86) native DLLs**
(e.g. `WIZPro.dll`, `WIZ5API.dll`, or any legacy unmanaged DLL).

---

## 📋 Prerequisites

| Requirement | Details |
|---|---|
| OS | Windows 10 (64-bit) or Windows 11 |
| Disk space | ~10–15 GB free (for VS + workloads) |
| RAM | 8 GB minimum, 16 GB recommended |
| Internet | Required for installer download |
| Permissions | Local Administrator account |

---

## 📥 Step 1 — Download Visual Studio Installer

1. Open your browser and go to:
   👉 https://visualstudio.microsoft.com/downloads/

2. Choose your edition:
   - **Community** — Free for individuals, open-source, and small teams ✅ (recommended)
   - **Professional** — Paid, for commercial use
   - **Enterprise** — Paid, for large teams

3. Click **Free download** under Community (or your chosen edition).

4. Save the file `VisualStudioSetup.exe` to your Downloads folder.

---

## ▶️ Step 2 — Run the Installer

1. Double-click `VisualStudioSetup.exe`.
2. If prompted by User Account Control (UAC), click **Yes**.
3. The **Visual Studio Installer** bootstrapper will launch and download a small setup engine (~5 MB).
4. Wait for the installer window to open — it will show a list of available **Workloads**.

---

## 🧩 Step 3 — Select the Required Workload

> ⚠️ This is the most important step. Choose the wrong workload and key tools will be missing.

In the **Workloads** tab:

1. ✅ Check **".NET desktop development"**

   This single workload installs everything needed:
   - C# language support
   - Windows Forms (WinForms) designer
   - .NET Framework 4.8 targeting pack
   - MSBuild tools

   ![Workload selection illustration]

2. Optionally also check:
   - **"Desktop development with C++"** — only if you need to build or debug the native DLLs themselves

---

## 🔧 Step 4 — Verify Individual Components (x86 / 32-bit Support)

1. While still in the installer, click the **"Individual components"** tab at the top.
2. Use the search box to find and confirm the following are checked:

   | Component | Why it is needed |
   |---|---|
   | `.NET Framework 4.8 targeting pack` | Required to target .NET Framework 4.8 |
   | `.NET Framework 4.8 SDK` | Build tools for .NET Framework projects |
   | `C# and Visual Basic Roslyn compilers` | Core C# compiler |
   | `NuGet package manager` | Dependency management |
   | `Windows 10 SDK (10.0.xxxxx)` | Windows API headers (useful for P/Invoke work) |

   > These are usually selected automatically by the workload — just verify they are checked.

---

## 💾 Step 5 — Choose Installation Location

1. At the bottom of the installer, click the **"Installation locations"** tab.
2. Set your preferred path (default: `C:\Program Files\Microsoft Visual Studio\2022\Community`).
3. Ensure the drive has at least **10 GB free**.

---

## 🚀 Step 6 — Install

1. Click the **Install** button (bottom right).
2. The installer will download and install all selected components.
3. ⏱️ This typically takes **10–30 minutes** depending on your internet speed.
4. When complete, click **Launch** to open Visual Studio.

---

## 🆕 Step 7 — Create a New WinForms Project

1. On the Visual Studio start screen, click **"Create a new project"**.
2. In the search box, type: `winforms`
3. Select **"Windows Forms App (.NET Framework)"**
   > ⚠️ Make sure it says **(.NET Framework)** — NOT (.NET 6/7/8). You need .NET Framework for legacy DLL compatibility.
4. Click **Next**.
5. Fill in:
   - **Project name**: e.g. `FaceplateManager`
   - **Location**: your working folder
   - **Framework**: `.NET Framework 4.8`
6. Click **Create**.

---

## ⚙️ Step 8 — Configure Project Platform to x86 (32-bit)

This is **critical** when using 32-bit native DLLs. A 64-bit process cannot load a 32-bit DLL.

1. In the top toolbar, click the **platform dropdown** (it shows `Any CPU` by default).
2. Click **"Configuration Manager…"**
3. In the **Active solution platform** dropdown, click `<New…>`
4. Select **`x86`** and click **OK**.
5. Close Configuration Manager.
6. The toolbar should now show **`x86`** as the active platform.

**Alternatively via Project Properties:**

1. Right-click the project in Solution Explorer → **Properties**.
2. Go to the **Build** tab.
3. Set **Platform target** to **`x86`**.
4. Save (`Ctrl+S`).

---

## 📦 Step 9 — Add the 32-bit DLL to Your Project

1. Copy your `.dll` file(s) (e.g. `WIZPro.dll`, `WIZ5API.dll`) into the project folder
   (same folder as your `.csproj` file, or a subfolder like `lib\`).

2. In **Solution Explorer**, click **"Show All Files"** (toolbar icon at the top of Solution Explorer).

3. Right-click the DLL file → **"Include In Project"**.

4. Select the DLL in Solution Explorer, then in the **Properties** panel (F4) set:
   - **Build Action**: `Content`
   - **Copy to Output Directory**: `Copy always`

   This ensures the DLL lands next to your `.exe` in the `bin\x86\Debug\` folder at build time.

---

## 🔗 Step 10 — Declare P/Invoke Signatures in C#

To call functions from the unmanaged DLL, use `DllImport`:

```csharp
using System.Runtime.InteropServices;

internal static class NativeMethods
{
    // Example: calling a function from a 32-bit DLL
    [DllImport("WIZPro.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public static extern int CMOpenServer(string serverName);

    [DllImport("WIZ5API.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public static extern int CMGetGateStr(int gateId, StringBuilder value, int bufLen);
}
```

> 💡 If you are unsure of the calling convention, start with `StdCall` (most common for legacy Win32 DLLs).
> Use `Cdecl` if you get `AccessViolationException` or stack corruption.

---

## ✅ Step 11 — Build and Test

1. Press **`Ctrl+Shift+B`** to build.
2. Verify there are no errors in the **Error List** panel.
3. Check that the output folder (`bin\x86\Debug\`) contains:
   - Your `.exe`
   - The `.dll` file(s)
4. Press **`F5`** to run with the debugger attached.

---

## 🐛 Common Issues and Fixes

| Problem | Cause | Fix |
|---|---|---|
| `BadImageFormatException` | Project is `Any CPU` or `x64` but DLL is 32-bit | Set platform target to **x86** (Step 8) |
| `DllNotFoundException` | DLL not in output directory | Set Copy to Output = **Copy always** (Step 9) |
| `EntryPointNotFoundException` | Wrong function name or decoration | Check the exported name with `dumpbin /exports yourfile.dll` in Developer Command Prompt |
| `AccessViolationException` | Wrong calling convention | Try switching `StdCall` ↔ `Cdecl` in `DllImport` |
| WinForms designer not available | Wrong project type (.NET 6+ selected) | Re-create project as **.NET Framework** (Step 7) |

---

## 🗂️ Recommended Project Structure

```
YourProject/
├── lib/
│   ├── WIZPro.dll          ← 32-bit native DLL
│   └── WIZ5API.dll         ← 32-bit native DLL
├── Forms/
│   ├── MainForm.cs
│   └── AnalogFaceplate.cs
├── NativeMethods.cs        ← All DllImport declarations
├── Program.cs
└── YourProject.csproj
```

---

## 📚 References

- [Visual Studio Downloads](https://visualstudio.microsoft.com/downloads/)
- [WinForms Documentation (.NET Framework)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/)
- [P/Invoke — DllImport Guide](https://learn.microsoft.com/en-us/dotnet/standard/native-interop/pinvoke)
- [Platform Target Configuration](https://learn.microsoft.com/en-us/visualstudio/ide/how-to-configure-projects-to-target-platforms)

---

## 🏷️ Version Info

| Tool | Version used in this guide |
|---|---|
| Visual Studio | 2022 Community (v17.x) |
| .NET Framework | 4.8 |
| Target platform | x86 (32-bit) |
| OS | Windows 10 / 11 (64-bit) |

---

*Maintained as part of the FaceplateManager SCADA migration project.*
