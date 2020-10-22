namespace Funbites.UnityUtils.Editor
{
    using Sirenix.OdinInspector;
    using Sirenix.OdinInspector.Editor;
    using System.Collections.Generic;
    using UnityEditor;
    //TODO: Remove those Addressables references or make Android Build outside of UnityUtils
    using UnityEditor.AddressableAssets;
    using UnityEditor.AddressableAssets.Settings;
    using UnityEngine;

    public class AndroidBuildTool : OdinEditorWindow
    {

        private static string ProductName;

        [MenuItem("Tools/Funbites/Android Build Tools")]
        private static void OpenWindow()
        {
            GetWindow<AndroidBuildTool>().Show();
        }

        protected override void Initialize()
        {
            base.Initialize();
            ProductName = PlayerSettings.companyName + "_" + PlayerSettings.productName;
            keystorePassKey = ProductName + "_ANDROID_BUILD_TOOLS_KEYSTORE_PASS";
            keyaliasNameKey = ProductName + "_ANDROID_BUILD_TOOLS_KEYALIAS_NAME";
            keyaliasPassKey = ProductName + "_ANDROID_BUILD_TOOLS_KEYALIAS_PASS";
            currentVersionKey = ProductName + "_ANDROID_BUILD_TOOLS_CURRENT_VERSION";
        }

        [ShowInInspector]
        private bool isDevelopmentBuild = true;

        private static string keystorePassKey;
        [ShowInInspector]
        private string keystorePass {
            get {
                return EditorPrefs.GetString(keystorePassKey, "keystorepass");
            }
            set {
                EditorPrefs.SetString(keystorePassKey, value);
            }
        }

        private static string keyaliasNameKey;
        [ShowInInspector]
        private string keyaliasName {
            get {
                return EditorPrefs.GetString(keyaliasNameKey, "keyaliasname");
            }
            set {
                EditorPrefs.SetString(keyaliasNameKey, value);
            }
        }

        private static string keyaliasPassKey;
        [ShowInInspector]
        private string keyaliasPass {
            get {
                return EditorPrefs.GetString(keyaliasPassKey, "keyaliaspass");
            }
            set {
                EditorPrefs.SetString(keyaliasPassKey, value);
            }
        }

        private static string currentVersionKey;
        [ShowInInspector]
        private string currentVersion {
            get {
                return EditorPrefs.GetString(currentVersionKey, "0.1");
            }
            set {
                EditorPrefs.SetString(currentVersionKey, value);
            }
        }

        [ShowInInspector]
        private bool buildAppBundle = true;
        [ShowInInspector, HideIf(nameof(buildAppBundle))]
        private bool splitApplicationBinary = true;
        [ShowInInspector]
        private bool runAfterBuild = true;


        [ShowInInspector]
        private bool useAddressables = true;
        [ShowInInspector, ShowIf(nameof(useAddressables))]
        private bool clearAddressables = true;



        
        [Button]
        private void Build()
        {
            PlayerSettings.Android.keystorePass = keystorePass;
            PlayerSettings.Android.keyaliasName = keyaliasName;
            PlayerSettings.Android.keyaliasPass = keyaliasPass;
            if (useAddressables)
            {
                if (clearAddressables)
                {
                    AddressableAssetSettings.CleanPlayerContent(
                        AddressableAssetSettingsDefaultObject.Settings.ActivePlayerDataBuilder);
                }
                AddressableAssetSettings.BuildPlayerContent();
            }
            EditorUserBuildSettings.buildAppBundle = buildAppBundle;
            if (!buildAppBundle)
            {
                PlayerSettings.Android.useAPKExpansionFiles = splitApplicationBinary;
            }

            // Get filename.
            List<string> scenes = new List<string>();
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (scene.enabled)
                    scenes.Add(scene.path);
            }
            //string[] levels = new string[] { "Assets/_GUDE_SCENES/InitialScene.unity", "Assets/_GUDE_SCENES/WebLoader.unity", "Assets/_GUDE_SCENES/Story_For_Test.unity", "Assets/_GUDE_SCENES/Story_For_Game.unity" };
            string fileName = $"Builds/Gude_{PlayerSettings.Android.bundleVersionCode.ToString()}_{(isDevelopmentBuild ? "dev" : "prod")}.{(buildAppBundle?"aab":"apk")}";
            BuildOptions options = BuildOptions.None;
            if (runAfterBuild)
            {
                options |= BuildOptions.AutoRunPlayer;
            }
            if (isDevelopmentBuild)
            {
                options |= BuildOptions.Development;
                options |= BuildOptions.ConnectWithProfiler;
                options |= BuildOptions.AllowDebugging;
                options |= BuildOptions.EnableDeepProfilingSupport;
            }

            // Build player.
            BuildPipeline.BuildPlayer(scenes.ToArray(), fileName, BuildTarget.Android, options);
            PlayerSettings.bundleVersion = currentVersion + "." + PlayerSettings.Android.bundleVersionCode.ToString();
            if (!isDevelopmentBuild)
            {
                PlayerSettings.Android.bundleVersionCode += 1;
            }
        }
    }
}