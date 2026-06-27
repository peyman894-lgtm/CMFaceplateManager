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

# CMFaceplateManager

A C# Windows Forms HMI client application that integrates with **ControlMaestro (CM)** industrial automation / SCADA systems. The application monitors a CM tag called `INDICATOR`, and whenever an operator selects an instrument from the CM HMI, it automatically opens a live analog faceplate window for that instrument — displaying the process value, alarm limits, and operator controls.

---

## Table of contents

- [Overview](#overview)
- [Prerequisites](#prerequisites)
- [Project structure](#project-structure)
- [Architecture and call hierarchy](#architecture-and-call-hierarchy)
  - [Entry point](#entry-point--programcs)
  - [CMApi — ControlMaestro gateway](#cmapi--cmapics)
  - [FaceplateManager — window orchestrator](#faceplatemanager--faceplatemanagercs)
  - [AnalogFaceplate — instrument window](#analogfaceplate--analogfaceplatencs)
  - [TagLookup — configuration reader](#taglookup--taglookupcs)
  - [VerticalBar — process bar control](#verticalbar--barcontrolcs)
- [Tag naming conventions](#tag-naming-conventions)
- [Configuration file — Regler_UTL.csv](#configuration-file--regler_utlcsv)
- [Building and running](#building-and-running)
- [Dependencies](#dependencies)

---

## Overview

CMFaceplateManager runs invisibly in the system tray — there is no main window. It polls a single CM string tag (`INDICATOR`) every 500 ms. When the CM HMI operator clicks on an instrument, CM writes that instrument's tag name (e.g. `PT_9200_70_1`) into the `INDICATOR` tag. CMFaceplateManager detects the change and opens a faceplate window for that instrument automatically.

Each faceplate window then polls the instrument's live process value and its four alarm limits once per second, and gives the operator buttons to activate/deactivate MOS (Manual Override/Setpoint) and to open the CM trend chart — all without the operator needing to interact with CMFaceplateManager directly.

---

## Prerequisites

| Requirement | Detail |
|---|---|
| .NET Framework | 4.8 |
| Visual Studio | 2019 or later (x86 build configuration) |
| ControlMaestro | Installed on the same machine |
| `Wizpro.dll` | Provided by CM installation; must be on the system `PATH` or in the output directory |
| `WIZ5API.dll` | Provided by CM installation; required for macro execution |

The project must be compiled as **x86** (32-bit) because `Wizpro.dll` and `WIZ5API.dll` are 32-bit native libraries.

---

## Project structure

```
CMFaceplateManager/
│
├── Program.cs                  # Entry point — connects to CM, starts FaceplateManager
├── CMApi.cs                    # All P/Invoke calls to Wizpro.dll and WIZ5API.dll
├── FaceplateManager.cs         # Monitors INDICATOR tag; opens/focuses faceplate windows
├── AnalogFaceplate.cs          # Faceplate form logic — polling, display, button handlers
├── AnalogFaceplate.Designer.cs # WinForms designer-generated control layout
├── AnalogFaceplate.resx        # Form resource file
├── BarControl.cs               # Custom VerticalBar control with setpoint markers
├── VerticalProgressBar.cs      # Thin wrapper around ProgressBar for vertical orientation
├── TagLookup.cs                # Reads Regler_UTL.csv and looks up tag metadata
├── Regler_UTL.csv              # Instrument configuration: ranges, units, alarm visibility
└── CMFaceplateManager.csproj   # Project file (targets .NET 4.8, platform x86)
```

---

## Architecture and call hierarchy

```
Program.cs
  └─ CMApi.Connect()                         # register client with CM
  └─ FaceplateManager.Start()
       └─ [Timer 500 ms] WatchTimer_Tick()
            └─ CMApi.ReadString("INDICATOR") # read active tag name from CM
                 └─ CMApi.GetGateId()  ──►  CMGetGateId()   [Wizpro.dll]
                 └─ CMGetGateStr()     ──►  CMGetGateStr()  [Wizpro.dll]
            └─ OpenOrFocusFaceplate(tagName)
                 └─ new AnalogFaceplate(tagName)
                      └─ FormCreate()
                           ├─ LoadTagMetadata()
                           │    └─ TagLookup(csvPath)     # parse Regler_UTL.csv
                           └─ ReadAndShowValue()
                      └─ [Timer 1000 ms] PollTimer_Tick()
                           └─ ReadAndShowValue()
                                ├─ CMApi.ReadAnalog(TagName)
                                │    └─ GetGateId()  ──►  CMGetGateId()  [Wizpro.dll]
                                │    └─ CMGetGateVal() ►  CMGetGateVal() [Wizpro.dll]
                                ├─ CMApi.ReadAnalog(TagName + "_SPHH")
                                ├─ CMApi.ReadAnalog(TagName + "_SPH")
                                ├─ CMApi.ReadAnalog(TagName + "_SPL")
                                └─ CMApi.ReadAnalog(TagName + "_SPLL")

  Button handlers (operator actions):
       MOS_SETClick / MOS_SET1Click    → CMApi.RunMacro(TagName + "_OSS")
       MOS_RESETClick / MOS_RESET1Click → CMApi.RunMacro(TagName + "_OSR")
       ChartClick                       → CMApi.RunMacro(TagName + "_CH")
            └─ CMRunMacroByName()  ──►  CMRunMacroByName() [WIZ5API.dll]
```

---

### Entry point — `Program.cs`

`Program.Main()` does three things before showing anything:

1. Calls `CMApi.Connect()`. If connection fails it shows an error dialog and exits — nothing else runs without a CM connection.
2. Creates a `FaceplateManager` and calls `Start()`.
3. Calls `Application.Run(new ApplicationContext())` with no main form. The process lives as long as the `ApplicationContext` is alive; closing any faceplate window does **not** exit the application.

On exit, `CMApi.Disconnect()` is called via `Application.ApplicationExit` to deregister the client from CM.

---

### CMApi — `CMApi.cs`

The single static gateway to ControlMaestro. All communication with CM goes through this class. It wraps the CM client API exposed by `Wizpro.dll` and `WIZ5API.dll` via P/Invoke.

**Key members:**

| Member | Description |
|---|---|
| `Hook` | Byte handle returned by `CMMkClient`; passed to every subsequent CM API call |
| `Connect()` | Calls `CMMkClient("FaceplateManager", ...)` to register this process as a CM client |
| `Disconnect()` | Calls `CMRmClient(Hook)` to cleanly deregister |
| `ReadAnalog(tagName)` | Resolves the tag to a GateId, then reads the current double value via `CMGetGateVal` |
| `ReadString(tagName)` | Resolves the tag to a GateId, then reads the current string value via `CMGetGateStr` (mode 11) |
| `RunMacro(macroName)` | Executes a named CM macro via `CMRunMacroByName` in `WIZ5API.dll` |
| `GetGateId(tagName)` *(private)* | Calls `CMGetGateId` to resolve a tag name to its numeric GateId |

**Native functions declared:**

| Function | DLL | Purpose |
|---|---|---|
| `CMMkClient` | `Wizpro.dll` | Register a new CM client; returns a `Hook` byte |
| `CMRmClient` | `Wizpro.dll` | Deregister a CM client |
| `CMGetGateId` | `Wizpro.dll` | Resolve a tag name string to a numeric GateId |
| `CMGetGateVal` | `Wizpro.dll` | Read an analog (double) value by GateId |
| `CMGetGateStr` | `Wizpro.dll` | Read a string value by GateId |
| `CMRunMacroByName` | `WIZ5API.dll` | Execute a CM macro by name |

---

### FaceplateManager — `FaceplateManager.cs`

Runs a background `Timer` every 500 ms and watches the CM string tag `INDICATOR`.

**Logic:**

1. Reads the current value of `INDICATOR` via `CMApi.ReadString("INDICATOR")`.
2. If the value is empty, or hasn't changed since the last tick, does nothing.
3. If the value has changed, calls `OpenOrFocusFaceplate(tagName)`:
   - If a non-disposed `AnalogFaceplate` for that tag already exists in `_openFaceplates`, brings it to the front.
   - Otherwise creates a new `AnalogFaceplate`, stores it in `_openFaceplates`, and shows it.
4. When a faceplate is closed, its `FormClosed` event removes it from `_openFaceplates`.

Multiple faceplates for different instruments can be open simultaneously.

---

### AnalogFaceplate — `AnalogFaceplate.cs`

The main operator window for a single instrument tag. Created with a `tagName` string and self-contained from that point on.

**Lifecycle:**

| Event | Action |
|---|---|
| `FormCreate` | `LoadTagMetadata()` then initial `ReadAndShowValue()`, then starts 1 s poll timer |
| `PollTimer_Tick` | `ReadAndShowValue()` — runs every 1000 ms |
| `FormClosed` | Stops and disposes the poll timer |

**`LoadTagMetadata()`**

Looks up the tag in `Regler_UTL.csv` via `TagLookup` and configures:

- `ProcessBar.Minimum` and `ProcessBar.Maximum` (engineering range)
- `valueFormat` — C# numeric format string derived from the CSV `Format` column (e.g. `"0.0"`, `"##0.00"`)
- Visibility of the four alarm limit labels (`SPHH`, `SPH`, `SPL`, `SPLL`)
- `Description` label text and `Span` label text (range string)
- `PrcTag` label (the instrument's process tag name)

**`ReadAndShowValue()`**

Makes five `CMApi.ReadAnalog()` calls per cycle:

| Call | Tag read |
|---|---|
| 1 | `TagName` — live process value |
| 2 | `TagName + "_SPHH"` — high-high alarm limit |
| 3 | `TagName + "_SPH"` — high alarm limit |
| 4 | `TagName + "_SPL"` — low alarm limit |
| 5 | `TagName + "_SPLL"` — low-low alarm limit |

Results are displayed in the numeric label (`Anz_0_X`), the `VerticalBar` (`ProcessBar`), and the four setpoint labels. If any call throws, the display shows `"ERR"` in red and logs to the debug output.

**Operator button handlers:**

| Button | Handler | CM action |
|---|---|---|
| MOS activate (startup) | `MOS_SETClick` | `RunMacro(TagName + "_OSS")` |
| MOS deactivate (startup) | `MOS_RESETClick` | `RunMacro(TagName + "_OSR")` |
| MOS activate (maintenance) | `MOS_SET1Click` | `RunMacro(TagName + "_OSS")` |
| MOS deactivate (maintenance) | `MOS_RESET1Click` | `RunMacro(TagName + "_OSR")` |
| Chart | `ChartClick` | `RunMacro(TagName + "_CH")` |

MOS access is password-protected in the UI: the operator must type `MOS` into the hidden `MOS_PASS` text box before the MOS panel becomes visible.

**UI-only buttons (no CM calls):**

| Button | Action |
|---|---|
| `<` (LO) | Move window to left edge of screen |
| `>` (RO) | Move window to right edge of screen |
| 🔓 / 🔒 (Pin) | Toggle `TopMost` — keeps faceplate above other windows |
| Setpoints | Toggle between process value view and alarm setpoint view |
| Close view | Close the faceplate window |

---

### TagLookup — `TagLookup.cs`

Parses `Regler_UTL.csv` at construction time and provides keyed lookups by CM tag name (the `Prefix` column in the CSV, which matches the `TagName` passed from CM).

**Methods exposed:**

| Method | Returns |
|---|---|
| `Description(tagName)` | Instrument description string |
| `Range(tagName)` | Display range string, e.g. `"0 - 100 %"` |
| `TAG(tagName)` | Process tag identifier |
| `LR(tagName)` | Low range (minimum) as string |
| `HR(tagName)` | High range (maximum) as string |
| `Format(tagName)` | Format string, e.g. `"4.1"` (digits before and after decimal) |
| `ShowHH(tagName)` | Whether to display the SPHH alarm label |
| `ShowH(tagName)` | Whether to display the SPH alarm label |
| `ShowL(tagName)` | Whether to display the SPL alarm label |
| `ShowLL(tagName)` | Whether to display the SPLL alarm label |

---

### VerticalBar — `BarControl.cs`

A custom `Control` that draws a vertical filled bar with optional setpoint marker lines. Used as `ProcessBar` in the faceplate.

**Properties:**

| Property | Description |
|---|---|
| `Minimum` / `Maximum` | Engineering range for the bar |
| `Value` | Current process value (integer) |
| `BarColor` | Fill color of the bar (default: `LimeGreen`) |
| `SPHH` / `SPH` / `SPL` / `SPLL` | Nullable int positions for alarm limit lines |

Alarm limit lines are drawn as horizontal colored lines across the bar: red for HH and LL, yellow for H and L.

---

## Tag naming conventions

All derived tag names are constructed by appending a fixed suffix to the base instrument tag name. This convention is systematic and assumed to be consistent across all instruments in the CM configuration.

| Suffix | Meaning | Used in |
|---|---|---|
| *(none)* | Live process value | `ReadAndShowValue()` |
| `_SPHH` | High-high alarm setpoint | `ReadAndShowValue()` |
| `_SPH` | High alarm setpoint | `ReadAndShowValue()` |
| `_SPL` | Low alarm setpoint | `ReadAndShowValue()` |
| `_SPLL` | Low-low alarm setpoint | `ReadAndShowValue()` |
| `_OSS` | MOS activate macro | `MOS_SETClick` / `MOS_SET1Click` |
| `_OSR` | MOS deactivate macro | `MOS_RESETClick` / `MOS_RESET1Click` |
| `_CH` | Open CM trend chart macro | `ChartClick` |

Example — for tag `PT_9200_70_1`:

```
PT_9200_70_1        → process value
PT_9200_70_1_SPHH   → high-high alarm limit
PT_9200_70_1_SPH    → high alarm limit
PT_9200_70_1_SPL    → low alarm limit
PT_9200_70_1_SPLL   → low-low alarm limit
PT_9200_70_1_OSS    → MOS activate macro
PT_9200_70_1_OSR    → MOS deactivate macro
PT_9200_70_1_CH     → trend chart macro
```

---

## Configuration file — Regler_UTL.csv

Located in the same directory as the executable. Parsed by `TagLookup` at faceplate creation time.

**Columns:**

| Column | Type | Description |
|---|---|---|
| `TAG` | String | Instrument process tag identifier |
| `Description` | String | Human-readable instrument description |
| `from` | Integer | Engineering range minimum |
| `to` | Integer | Engineering range maximum |
| `Format` | Float-string | Display format, e.g. `4.1` means 4 digits total, 1 decimal place |
| `Unit` | String | Engineering unit (e.g. `bar`, `°C`, `%`) |
| `Alarm` | String | Alarm visibility flags (which of HH/H/L/LL are active) |
| `Type` | Integer | Instrument type code |
| `Prefix` | String | CM tag name — used as the lookup key |

The `Prefix` column must match the tag names written into the `INDICATOR` tag by the CM HMI.

---

## Building and running

1. Open `CMFaceplateManager.sln` in Visual Studio.
2. Set the build configuration to **Debug | x86** or **Release | x86**.
3. Ensure `Wizpro.dll` and `WIZ5API.dll` are available to the output directory (either copy them there or ensure the CM installation directory is on the system `PATH`).
4. Ensure `Regler_UTL.csv` is in the same directory as the compiled executable, or update the path in `AnalogFaceplate.cs` → `LoadTagMetadata()`.
5. Build and run. The application connects to CM on startup — CM must be running on the same machine.

> **Note:** The application will show a connection error dialog and exit immediately if CM is not running or the `Wizpro.dll` client registration fails.

---

## Dependencies

| Dependency | Source | Notes |
|---|---|---|
| `Wizpro.dll` | ControlMaestro installation | P/Invoke; 32-bit native |
| `WIZ5API.dll` | ControlMaestro installation | P/Invoke; 32-bit native; macro execution |
| .NET Framework 4.8 | Microsoft | No NuGet packages required |
| `Regler_UTL.csv` | Project directory | Instrument configuration; must be present at runtime |

No third-party NuGet packages are used. All CM integration is through the native DLLs via P/Invoke.

*Maintained as part of the FaceplateManager SCADA migration project.*
