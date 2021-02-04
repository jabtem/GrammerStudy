using UnityEditor;

public class ProjectSetting
{
    [SettingsProvider]
    static SettingsProvider ProjectSettingGUI()
    {
        //var provider = AssetSettingsProvider.CreateProviderFromAssetPath("Project/WSJ", "ProjectSettings/GraphicsSettings.asset");
        var provider = AssetSettingsProvider.CreateProviderFromAssetPath("Custom/WSJ", "Assets/Study6/CreatEditorWindow.asset");
        return provider;
    }
}
