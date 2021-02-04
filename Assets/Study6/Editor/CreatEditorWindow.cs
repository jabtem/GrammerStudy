//using System.Collections;
//using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
 
    EditorWindow는 => public class EditorWindow : ScriptableObject
    ScriptableObject를 상속하고 있으므로 EditorWindow 오브젝트를 Asset으로 저장할 수 있다.
    이왕이면 dll로 저장해두는게...보안적으로 좋을듯?

*/

public class CreatEditorWindow : EditorWindow
{
    [MenuItem("Dev/CreatEditorWindow")]
    static void SaveWindow()
    {
        // 물론 여기서 다른 윈도우도 저장 가능하다...CreatEditorWindow 만 바꾸면...
        AssetDatabase.CreateAsset(CreateInstance<CreatEditorWindow>(), "Assets/Study6/CreatEditorWindow.asset");
        AssetDatabase.Refresh();
    }

    // 인스펙터(어셈블리 브라우저)에 동기화 속성으로 프로퍼티 표시
    [SerializeField]
    string text;

    [SerializeField]
    bool boolean;
}