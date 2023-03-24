# File Info Checker

Simple GUI application with folder browser to get basic metadata of images given in selected folder. Basic information includes filename, size, color depth, jpeg compression quality, vertical dpi, horizontal dpi.

![image](https://user-images.githubusercontent.com/76661587/227535915-aca68876-2b01-4a61-b629-a7edea4b1813.png)

# Build

While in a root project folder:
``` sh
  dotnet build --configuration Release
```

# Run

While in a root project folder:
```sh
  .\FileInfoChecker\bin\Release\net7.0-windows\FileInfoChecker.exe 
```
WPF application could not be packed in a single executable file due to its partition to the different dll files. 
