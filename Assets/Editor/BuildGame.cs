using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System.IO;

public static class BuildGame
{
    [MenuItem("File/Build Geo Quest (Windows)")]
    public static void BuildFromMenu()
    {
        Build();
    }

    // Used by Unity command line: -executeMethod BuildGame.CommandLineBuild
    public static void CommandLineBuild()
    {
        Build();
        // Let the batch-mode process exit cleanly.
        EditorApplication.Exit(0);
    }

    public static void Build()
    {
        string outputFolder = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "Build", "Geo_Quest");
        Directory.CreateDirectory(outputFolder);

        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = EditorBuildSettingsScene.GetActiveSceneList(EditorBuildSettings.scenes),
            locationPathName = Path.Combine(outputFolder, "Geo_Quest.exe"),
            target = BuildTarget.StandaloneWindows64,
            options = BuildOptions.None
        };

        BuildReport report = BuildPipeline.BuildPlayer(options);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes, output: " + outputFolder);
        }
        else
        {
            Debug.LogError("Build failed with result: " + summary.result);
            EditorApplication.Exit(1);
        }
    }
}
