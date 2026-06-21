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
