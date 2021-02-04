
// 그냥 using 다 빼봤다...

public class GetWindow : UnityEditor.EditorWindow
{
    // static 선언 안하면 에러
    static string str;

    [UnityEditor.MenuItem("Dev/GetWindow")]
    static void CreateWindow()
    {
        var slotMakerWindow = UnityEditor.EditorWindow.CreateInstance<GetWindow>();
        slotMakerWindow.Show();

        // 런타임 오브젝트 + 에디터에서 사용하는 오브젝트 전부 검색됨 (유용)
        //var sceneViews = UnityEngine.Resources.FindObjectsOfTypeAll<AiCtrl>();    // 실행중 Ctrl + D 로 추가해보자.
        //var sceneViews = UnityEngine.Resources.FindObjectsOfTypeAll<UnityEditor.SceneView> ();
        //var sceneViews = UnityEngine.Resources.FindObjectsOfTypeAll<GetWindow>();
        //var sceneViews = UnityEngine.Resources.FindObjectsOfTypeAll<UnityEditor.EditorWindow>();
        var sceneViews = UnityEngine.Resources.FindObjectsOfTypeAll<SlotMaker>();
        str = sceneViews.Length.ToString();
    }

    void OnGUI()
    {
        UnityEngine.GUILayout.TextField(str);
    }
}
