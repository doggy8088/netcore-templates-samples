# 示範各種不同 dotnet new 自訂範本的專案

請先複製本專案回去，參考這篇文章來完成實作練習。

```sh
cd /d C:\Projects
git clone https://github.com/doggy8088/netcore-template-templates.git
cd netcore-template-templates
```

## 基本範本語法 (`01-basic-template`)

1. 安裝範本

    ```sh
    cd 01-basic-template
    dotnet new -i ./
    ```

2. 測試執行

    ```sh
    pushd .
    cd /d %TEMP%
    dotnet new sample01 -n c1
    popd
    ```

3. 移除範本 (移除時必須使用絕對路徑)

    ```sh
    dotnet new -u C:\Projects\netcore-template-templates\01-basic-template
    ```

## 忽略特定檔案或資料夾 (`02-ignore-files`)

1. 安裝範本

    ```sh
    cd 02-ignore-files
    dotnet new -i ./
    ```

2. 測試執行

    ```sh
    pushd .
    cd /d %TEMP%
    dotnet new sample02 -n c2
    popd
    ```

3. 移除範本 (移除時必須使用絕對路徑)

    ```sh
    dotnet new -u C:\Projects\netcore-template-templates\02-ignore-files
    ```

## 建立後自動還原套件 (`03-restore-on-create`)

1. 安裝範本

    ```sh
    cd 03-restore-on-create
    dotnet new -i ./
    ```

2. 測試執行

    ```sh
    pushd .
    cd /d %TEMP%
    dotnet new sample03 -n c3
    popd
    ```

3. 移除範本 (移除時必須使用絕對路徑)

    ```sh
    dotnet new -u C:\Projects\netcore-template-templates\03-restore-on-create
    ```

## 自動加入 NuGet 套件 (`04-add-package-reference`)

1. 安裝範本

    ```sh
    cd 04-add-package-reference
    dotnet new -i ./
    ```

2. 測試執行

    ```sh
    pushd .
    cd /d %TEMP%
    dotnet new sample04 -n c4
    popd
    ```

3. 移除範本 (移除時必須使用絕對路徑)

    ```sh
    dotnet new -u C:\Projects\netcore-template-templates\04-add-package-reference
    ```

## 使用 NuGet 套件封裝多個專案範本

1. 將所有專案移至 `templates` 目錄下

2. 加入 `Duotify.Templates.Samples.3.1.csproj` 專案檔

    ```xml
    <Project Sdk="Microsoft.NET.Sdk">

    <PropertyGroup>
        <PackageType>Template</PackageType>
        <PackageVersion>1.0</PackageVersion>
        <PackageId>Duotify.Templates.Samples.3.1</PackageId>
        <Title>Duotify Templates</Title>
        <Authors>Will 保哥</Authors>
        <Description>Templates to use when creating an application for Duotify Inc.</Description>
        <PackageTags>dotnet-new;templates;duotify</PackageTags>
        <TargetFramework>netstandard2.0</TargetFramework>
        <IncludeContentInPack>true</IncludeContentInPack>
        <IncludeBuildOutput>false</IncludeBuildOutput>
        <ContentTargetFolders>content</ContentTargetFolders>
    </PropertyGroup>

    <ItemGroup>
        <Content Include="templates\**\*" Exclude="templates\**\bin\**;templates\**\obj\**" />
        <Compile Remove="**\*" />
    </ItemGroup>

    </Project>
    ```

3. 產生 NuGet 套件

    ```sh
    dotnet pack
    ```

4. 安裝 `Duotify.Templates.Samples.3.1` 套件

    ```sh
    dotnet new -i bin\Debug\Duotify.Templates.Samples.3.1.1.0.0.nupkg
    ```

5. 測試透過專案範本建立專案

    ```sh
    pushd .
    cd %temp%
    dotnet new sample01 -n c1
    dotnet new sample02 -n c2
    dotnet new sample03 -n c3
    dotnet new sample04 -n c4
    popd
    ```

6. 移除 `Duotify.Templates.Samples.3.1` 套件

    ```sh
    dotnet new -u Duotify.Templates.Samples.3.1
    ```

## 相關連結

- Microsoft Docs
  - [dotnet new 命令 - .NET Core CLI](https://docs.microsoft.com/zh-tw/dotnet/core/tools/dotnet-new)
  - [dotnet new 的自訂範本](https://docs.microsoft.com/zh-tw/dotnet/core/tools/custom-templates)
  - [教學課程：建立專案範本](https://docs.microsoft.com/zh-tw/dotnet/core/tutorials/cli-templates-create-item-template)
- [dotnet/templating GitHub repo Wiki](https://github.com/dotnet/templating/wiki)
  - [Available templates for dotnet new](https://github.com/dotnet/templating/wiki/Available-templates-for-dotnet-new)
- [ASP.NET Core 內建專案範本原始碼](https://github.com/dotnet/aspnetcore/tree/master/src/ProjectTemplates)
- [.NET Template Samples](https://github.com/dotnet/dotnet-template-samples)
- [template.json schema at the JSON Schema Store](http://json.schemastore.org/template)
- [dotnet-tools](https://github.com/natemcmaster/dotnet-tools)
  - A list of tool extensions for .NET Core Command Line (dotnet CLI), aka '.NET Core global tools'.
