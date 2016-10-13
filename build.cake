#addin nuget:?package=Cake.FileHelpers&version=1.0.3.2
#addin nuget:?package=Cake.Xamarin&version=1.3.0.3
//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var version = EnvironmentVariable("APPVEYOR_BUILD_VERSION") ?? Argument("version", "0.0.9999");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var solution = "./src/Iconize.sln";
var nuspec = new List<FilePath> {
	{ new FilePath("./nuget/Xam.Plugin.Iconize.nuspec") },
	{ new FilePath("./nuget/Xam.FormsPlugin.Iconize.nuspec") },
	{ new FilePath("./nuget/Xam.Plugin.Iconize.EntypoPlus.nuspec") },
	{ new FilePath("./nuget/Xam.Plugin.Iconize.FontAwesome.nuspec") },
	{ new FilePath("./nuget/Xam.Plugin.Iconize.Ionicons.nuspec") },
	{ new FilePath("./nuget/Xam.Plugin.Iconize.Material.nuspec") },
	{ new FilePath("./nuget/Xam.Plugin.Iconize.Meteocons.nuspec") },
	{ new FilePath("./nuget/Xam.Plugin.Iconize.SimpleLineIcons.nuspec") },
	{ new FilePath("./nuget/Xam.Plugin.Iconize.Typicons.nuspec") },
	{ new FilePath("./nuget/Xam.Plugin.Iconize.WeatherIcons.nuspec") }
};

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
		MSBuild(solution, settings =>
			settings.SetConfiguration(configuration));
    }
    else
    {
		// Use XBuild
		XBuild(solution, settings =>
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
		Version = version,
		Verbosity = NuGetVerbosity.Detailed,
		OutputDirectory = "./build/nuget/",
		BasePath = "./",
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