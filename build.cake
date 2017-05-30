//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var version = EnvironmentVariable("APPVEYOR_BUILD_VERSION") ?? Argument("version", "2.0.0.0-beta");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var solution = "./src/Iconize.sln";
var nuspec = GetFiles("./**/*.nuspec");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Restore-NuGet-Packages")
    .Does(() =>
{
    NuGetRestore(solution);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    if(IsRunningOnWindows())
    {
        // Use MSBuild
        MSBuild(solution, settings => {
            settings.SetConfiguration(configuration);
            settings.MSBuildPlatform = Cake.Common.Tools.MSBuild.MSBuildPlatform.x86;
        });
    }
    else
    {
        // Use DotNetBuild
        DotNetBuild(solution, settings =>
            settings.SetConfiguration(configuration));
    }
});

Task("NuGet")
    .IsDependentOn("Build")
    .Does (() =>
{
    if(!DirectoryExists("./build/nuget/"))
        CreateDirectory("./build/nuget");
        
    NuGetPack(nuspec, new NuGetPackSettings {
        ArgumentCustomization = args=>args.Append("-Properties configuration=" + configuration),
        BasePath = "./",
        OutputDirectory = "./build/nuget/",
        Verbosity = NuGetVerbosity.Detailed,
        Version = version
    });	
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("NuGet");

Task("Clean")
    .Does(() =>
{
    CleanDirectory("./tools/");
    CleanDirectories("./build/");

    CleanDirectories("./**/bin");
    CleanDirectories("./**/obj");
});

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);