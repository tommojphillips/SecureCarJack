using System.Reflection;
using System.Resources;

// General Information
[assembly: AssemblyTitle("SecureCarJack")]
[assembly: AssemblyProduct("Secure Car Jack")]
[assembly: AssemblyDescription("A mod for My Summer Car that implements the feature to secure the car jack into the trunk of the car.")]
[assembly: AssemblyCompany("Tommo J. Productions")]
[assembly: AssemblyCopyright("Copyright © Tommo J. Productions 2022")]
[assembly: AssemblyTrademark("Azine")]
[assembly: NeutralResourcesLanguage("en-AU")]
[assembly: AssemblyConfiguration("")]

// Version information
[assembly: AssemblyVersion("1.1.158.5")]
//[assembly: AssemblyFileVersion("1.1.158.5")]

public class VersionInfo
{
	public const string lastestRelease = "08.06.2022 10:05 PM";
	public const string version = "1.1.158.5";

    /// <summary>
    /// Represents if the mod has been complied for x64
    /// </summary>
    #if x64
        internal const bool IS_64_BIT = true;
    #else
        internal const bool IS_64_BIT = false;
    #endif
    #if DEBUG
        internal const bool IS_DEBUG_CONFIG = true;
    #else
        internal const bool IS_DEBUG_CONFIG = false;
    #endif
}

