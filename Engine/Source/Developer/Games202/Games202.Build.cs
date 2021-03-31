// Copyright Epic Games, Inc. All Rights Reserved.
using System.IO;
using UnrealBuildTool;

public class Games202 : ModuleRules
{
	public Games202(ReadOnlyTargetRules Target) : base(Target)
	{
		var EngineDir = Path.GetFullPath(Target.RelativeEnginePath);
		PrivateIncludePaths.AddRange(
			new string[] {
					EngineDir + "/Source/ThirdParty/OpenGL/include",
					EngineDir + "/Source/Developer/Games202/Public",
				// ... add other private include paths required here ...
			}
			);

		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"Assimp",
				"OpenGL",
			}
		);

		AddEngineThirdPartyPrivateStaticDependencies(Target, "OpenGL");

	}
}
