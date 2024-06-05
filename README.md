# BasicWindowsService
A windows service example using C#

# Executing

1. Open windows terminal in administrator mode and run the commands below (changing details for your folders):
```
X:\> cd C:\Windows\Microsoft.NET\Framework64\{.NET SDK FOLDER - i.e v4.0.30319}
```
1.1. then
```
X:{.NET SDK FOLDER}\> InstallUtil.exe C:\{PATH_TO_PROJ}\WindowsServiceTutorial\obj\Debug\WindowsServiceTutorial.exe
```

2. From keyboard: "Windows Start" + R (execute window)
2.1 Type "services.msc" <enter>
2.2 Locate your service named "WinSerTut.Personalizado" and start it.

3. Check project directory, search for "Logs" folder.
4. Your generated log file might be there.
