//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var version = EnvironmentVariable("APPVEYOR_BUILD_VERSION") ?? Argument("version", "3.2.0.0-beta");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var solution = "./src/Iconize.sln";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
	.Does(() =>
{
	CleanDirectories("./artifacts/");

	CleanDirectories("./**/bin");
	CleanDirectories("./**/obj");
});

Task("Restore")
	.IsDependentOn("Clean")
	.Does(() =>
{
	MSBuild(solution, settings => settings
		.SetConfiguration(configuration)
		.SetVerbosity(Verbosity.Minimal)
		.UseToolVersion(MSBuildToolVersion.VS2017)
		.SetMSBuildPlatform(MSBuildPlatform.x86)
		.SetPlatformTarget(PlatformTarget.MSIL)
		.SetMaxCpuCount(0)
		.WithTarget("restore"));
});

Task("Build")
	.IsDependentOn("Restore")
	.Does(() =>
{
	MSBuild(solution, settings => settings
		.SetConfiguration(configuration)
		.SetVerbosity(Verbosity.Minimal)
		.UseToolVersion(MSBuildToolVersion.VS2017)
		.SetMSBuildPlatform(MSBuildPlatform.x86)
		.SetPlatformTarget(PlatformTarget.MSIL)
		.SetMaxCpuCount(0)
		.WithTarget("build"));
});

Task("Pack")
	.IsDependentOn("Build")
	.Does(() =>
{
	MSBuild(solution, settings => settings
		.SetConfiguration(configuration)
		.SetVerbosity(Verbosity.Minimal)
		.UseToolVersion(MSBuildToolVersion.VS2017)
		.SetMSBuildPlatform(MSBuildPlatform.x86)
		.SetPlatformTarget(PlatformTarget.MSIL)
		.SetMaxCpuCount(0)
		.WithTarget("pack"));
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
	.IsDependentOn("Pack");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);