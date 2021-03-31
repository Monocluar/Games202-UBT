

using System.IO;
using UnrealBuildTool;

public class OpenGL : ModuleRules
{
    public OpenGL(ReadOnlyTargetRules Target) : base(Target)
    {
        Type = ModuleType.External;

        PublicIncludePaths.Add(Path.Combine(ModuleDirectory, "include"));

        if ((Target.Platform == UnrealTargetPlatform.Win64) ||
            (Target.Platform == UnrealTargetPlatform.Win32))
        {

            PublicSystemLibraries.Add("opengl32.lib");

            PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "lib-vc2019", "glfw3.lib"));

            PublicAdditionalLibraries.Add(Path.Combine(ModuleDirectory, "lib-vc2019", "glfw3dll.lib"));

            //RuntimeDependencies.Add(Path.Combine(ModuleDirectory,"lib-vc2019","glfw3.dll"));
		}


    }
}