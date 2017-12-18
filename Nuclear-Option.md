[electron-edge-js issue](https://github.com/agracio/electron-edge-js/issues/4)  

# Nuclear Option: Everything in one directory experiment

1. I created a Hello.Console, just so I could use "Publish to Folder"
2. Referenced Hello.Core.
3. Modified Hello.Console.csproj to include the following;  
```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.0</TargetFramework>
    <PreserveCompilationContext>true</PreserveCompilationContext>
   
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.CodeAnalysis" Version="2.6.1" />
    <PackageReference Include="Microsoft.CSharp" Version="4.4.1" />
    <PackageReference Include="Microsoft.DotNet.InternalAbstractions" Version="1.0.0" />
    <PackageReference Include="Microsoft.Extensions.DependencyModel" Version="2.0.4" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\Hello.Core\Hello.Core.csproj" />
  </ItemGroup>

</Project>
```
4. Publish to folder, which brought in 170 dlls (WOW, just for my little ole app).  All my dlls are there, including Newtonsoft.Json.dll.   I made sure all 170 dlls were in a single folder, by manual copying them.  Don't know if this ultimately has to happen.  The publish puts all the dependencies in a ref folder.  

5. Modified my main.js to look like this;  
```
const electron = require('electron')
const path = require('path')
const url = require('url')
process.env.EDGE_USE_CORECLR = 1;
process.env.EDGE_APP_ROOT = path.join(__dirname, '\\MEF\\Hello.Console\\bin\\Release\\PublishOutput');

var edge = require('electron-edge-js');
// rest of file
```
6. Modified edge.js, because I am a netcoreapp2.0 project.  
```
if (process.env.EDGE_USE_CORECLR && !process.env.EDGE_BOOTSTRAP_DIR && fs.existsSync(path.join(__dirname, 'bootstrap', 'bin', 'Release', 'netcoreapp2.0', 'bootstrap.dll'))) {
    process.env.EDGE_BOOTSTRAP_DIR = path.join(__dirname, 'bootstrap', 'bin', 'Release', 'netcoreapp2.0');
}
```
7. Copied netcoreapp2.0/bootstrap.dll and netcoreapp2.0/EdgeJs.dll into my app directory, and now I have 172 dlls.  

# And it works.

This is actually how I would want to have it work when I publish/install the app in its final form.  Everything side-by-side, with no risk of magic dlls anywhere.  My dlls, Microsofts dlls, third party dlls, edge dlls, etc.
