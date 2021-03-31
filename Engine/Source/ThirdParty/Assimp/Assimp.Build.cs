using System.IO;
using UnrealBuildTool;

public class Assimp : ModuleRules
{
    public Assimp(ReadOnlyTargetRules Target) : base(Target)
    {
        Type = ModuleType.External;

		PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "include"));

        if(Target.Platform == UnrealTargetPlatform.Win64 || Target.Platform == UnrealTargetPlatform.Win32)
		{
			PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "Lib", "assimp-vc142-mtd.lib"));

            //RuntimeDependencies.Add(Path.Combine(ModuleDirectory,"Lib","assimp-vc142-mtd.lib"));
		}
    }
}