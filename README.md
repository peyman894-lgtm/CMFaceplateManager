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



# Installing Visual Studio 2022 for C# WinForms Development

This guide explains how to install **Visual Studio Community 2022**, **C#**, and **.NET Desktop Development** tools required for creating **Windows Forms (WinForms)** applications.

---

## Prerequisites

* Windows 10 or Windows 11
* Internet connection
* Administrator privileges

---

## Step 1: Download Visual Studio Community 2022

Download Visual Studio Community from:

https://visualstudio.microsoft.com/vs/community/

Click **Download Visual Studio Community**.

Run:

```text
vs_Community.exe
```

---

## Step 2: Launch the Installer

After the installer starts, Visual Studio Installer will open.

If Visual Studio is already installed:

1. Open **Visual Studio Installer**
2. Locate **Visual Studio Community 2022**
3. Click **Modify**

---

## Step 3: Install the Required Workload

In the **Workloads** tab:

### Desktop & Mobile

Enable:

```text
☑ .NET desktop development
```

This workload installs:

* C# Compiler
* .NET SDK
* Windows Forms Designer
* WPF Designer
* Debugger
* Project Templates

---

## Step 4: Verify Included Components

When **.NET desktop development** is selected, Visual Studio automatically installs:

```text
.NET SDK
.NET Runtime
Windows Forms
WPF
C#
Visual Basic
MSBuild Tools
```

No additional configuration is normally required.

---

## Step 5: Install

Click:

```text
Modify
```

or

```text
Install
```

depending on your installation state.

Wait for the installation to complete.

Typical installation time:

```text
10 - 30 minutes
```

depending on internet speed and system performance.

---

## Step 6: Start Visual Studio

Launch:

```text
Visual Studio 2022
```

---

## Step 7: Create a WinForms Project

Click:

```text
Create a new project
```

Search for:

```text
windows forms
```

Select:

```text
Windows Forms App (.NET)
```

Click:

```text
Next
```

---

## Step 8: Configure the Project

Example settings:

```text
Project Name: MyFirstWinForms
Location: C:\Projects\MyFirstWinForms
```

Click:

```text
Next
```

---

## Step 9: Select .NET Version

Choose one of:

```text
.NET 8.0 (Recommended)
```

or

```text
.NET 9.0
```

Click:

```text
Create
```

---

## Step 10: Verify the WinForms Designer

Visual Studio should generate:

```text
Form1.cs
Form1.Designer.cs
Program.cs
```

A blank form should appear in the Designer window.

If you can drag controls from the Toolbox onto the form, WinForms is installed correctly.

---

## Step 11: Test the Installation

Open `Form1.cs`.

Double-click the form to create the `Load` event.

Add the following code:

```csharp
private void Form1_Load(object sender, EventArgs e)
{
    MessageBox.Show("Hello WinForms!");
}
```

Run the application:

```text
F5
```

Expected result:

```text
Hello WinForms!
```

---

## Step 12: Verify .NET SDK Installation

Open Command Prompt and run:

```cmd
dotnet --version
```

Example output:

```text
8.0.xxx
```

This confirms that the .NET SDK is installed correctly.

---

## Recommended Project Type for Legacy DLLs

For industrial software and legacy DLLs such as:

* Wizpro.dll
* ControlMaestro SDK
* Older SCADA integrations

consider using:

```text
Windows Forms App (.NET Framework 4.8)
```

instead of the latest .NET version.

Many legacy DLLs were developed for the .NET Framework and may work more reliably with .NET Framework 4.8.

---

## Troubleshooting

### "No templates found"

Ensure that:

```text
.NET desktop development
```

is installed in Visual Studio Installer.

### WinForms template missing

Open Visual Studio Installer:

```text
Visual Studio Installer
    → Modify
    → Workloads
    → .NET desktop development
```

and verify that the workload is checked.

### Verify installation from command line

```cmd
dotnet --list-sdks
```

This should display one or more installed SDK versions.

---

## References

* https://visualstudio.microsoft.com/
* https://dotnet.microsoft.com/
* https://learn.microsoft.com/dotnet/desktop/winforms/

---

Happy Coding!


# ControlMaestro WinForms Project Setup

This document describes the recommended Visual Studio project configuration for developing Windows Forms applications that use the **ControlMaestro SDK (Wizpro.dll)**.

## Requirements

* Visual Studio 2022 Community (or later)
* .NET Framework 4.8
* ControlMaestro Runtime
* Wizpro.dll (32-bit version)

---

# Why x86?

`Wizpro.dll` is a **32-bit DLL**.

A 32-bit DLL can only be loaded by a 32-bit process.

Therefore, the application **must be built as x86**.

If the application is built as:

```text id="w6w1qz"
Any CPU
```

or

```text id="6yqzpd"
x64
```

the application may fail with errors such as:

```text id="o13x5n"
BadImageFormatException
```

or

```text id="4b0av3"
Unable to load DLL 'Wizpro.dll'
```

---

# Create the Project

## Step 1

Open Visual Studio.

Select:

```text id="w6dk7y"
Create a new project
```

---

## Step 2

Search for:

```text id="i63z0u"
Windows Forms App (.NET Framework)
```

Select the template and click:

```text id="50c3nh"
Next
```

---

## Step 3

Enter:

```text id="d5eh5l"
Project Name
Location
Solution Name
```

Click:

```text id="v4cv9n"
Create
```

---

# Configure .NET Framework

Open:

```text id="8e6iq6"
Project
→ Properties
→ Application
```

Verify:

```text id="v8uivn"
Target Framework:
.NET Framework 4.8
```

---

# Configure Platform Target

Open:

```text id="7gx6ia"
Project
→ Properties
→ Build
```

Set:

```text id="uws0t2"
Platform target: x86
```

Disable:

```text id="lp3m8e"
Prefer 32-bit
```

if the option is visible.

Expected configuration:

```text id="r2qpcw"
Configuration: Debug
Platform target: x86
```

and

```text id="cwzqjf"
Configuration: Release
Platform target: x86
```

---

# Configuration Manager

Open:

```text id="s1m7d9"
Build
→ Configuration Manager
```

Verify:

```text id="6oqm5o"
Active solution platform = x86
```

If x86 does not exist:

```text id="z2vks5"
New...
→ x86
→ Copy settings from Any CPU
```

Click:

```text id="h7l7wo"
OK
```

---

# Add Wizpro.dll

Create a project folder:

```text id="ukep5s"
<ProjectRoot>
│
├── Bin
│   └── Wizpro.dll
│
├── Forms
├── Classes
└── Program.cs
```


ControlMaestroTest
│
├── Bin
│   └── Wizpro.dll
│
├── Forms
│   └── MainForm.cs
│
├── Classes
│   └── CMClient.cs
│
├── Program.cs
│
├── App.config
│
└── ControlMaestroTest.csproj
```

---

# Common Errors

## BadImageFormatException

Cause:

```text id="xt1ehq"
64-bit application loading 32-bit DLL
```

Solution:

```text id="mqoik4"
Build Target = x86
```

---

## DLL Not Found

Cause:

```text id="6kzgt6"
Wizpro.dll not copied to output folder
```

Solution:

```text id="7olz3r"
Copy to Output Directory = Copy if newer
```

---

## Access Violation

Cause:

```text id="0x0u7l"
Incorrect P/Invoke declaration
Wrong calling convention
Incorrect parameter types
```

Solution:

Verify all imported function signatures against the ControlMaestro SDK documentation.

---

# Recommended for ControlMaestro Development

For maximum compatibility with legacy SCADA systems:

```text id="whh2es"
Framework: .NET Framework 4.8
Platform: x86
Visual Studio: 2022 Community
Runtime: ControlMaestro Runtime running
```

This configuration is the safest choice when integrating with legacy 32-bit ControlMaestro components and Wizpro.dll.
