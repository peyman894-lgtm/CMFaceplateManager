Option 1: Visual Studio Community (Easiest) ⭐
For WinForms faceplates and DLL integration, this is by far the easiest route.
Install:
Visual Studio Community 2022
During installation select:
.NET desktop development
Then:
Create New Project↓Windows Forms App (.NET Framework)↓Target Framework 4.8↓Build Target = x86
Advantages:
✅ Drag-and-drop GUI designer
✅ Easy debugging
✅ Excellent DLL support
✅ Better than VS Code for WinForms
<img width="1204" height="892" alt="image" src="https://github.com/user-attachments/assets/2c155aec-c1bb-4efb-b858-eeff47a42caa" />


The architecture should be:
ControlMaestro Runtime        |        | writes        v    INDICATOR        |        vFaceplateManager.exe        |        | reads INDICATOR continuously        |        +--> Open AnalogFaceplate(Tag1)        |        +--> Open AnalogFaceplate(Tag2)        |        +--> Open AnalogFaceplate(Tag3)
<img width="919" height="800" alt="image" src="https://github.com/user-attachments/assets/ea7c0ac1-4eb6-4233-bc1e-87ae7af2250c" />
