//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*

    DockArea Class:
    메인프레임 : 탭 관리(SplitWindow, 멀티탭, 독립 윈도우)등 우리가 사용하고 있는 유니티 윈도우의 관리의 기본 기능, 
                 여러 EditorWindow 포함가능.
                 또한 HostView의 역할인 여러 이벤트와 상호작용을 위한 기능과 윈도우의 Update(), OnSelectionChange()
                 등을 실행하기 위한 기능을 가지고있음.
    <=(상속) EditorWindow Class

*/
// EditorWindow를 상속해야 EditorWindow를 만들 수 있다.
// EditorWindow는 우리가 알고있는 윈도우이다.(API 참고...)
// 즉 유니티는 이러한 윈도의 집합체이다.
// GUI 표시 : EditorGUI 클래스로 윈도우에 표시.

// ScriptableWizard는 기능성 윈도우이다.
// GUI 표시 : [public 필드] [Serialize 가능한 필드]로 윈도우에 표시.

// 하나씩 공부 EditorWindow, ScriptableWizard
// IHasCustomMenu 이것은 인터페이스로 컨텍스트 메뉴를 생성해준다.
public class SlotMaker : EditorWindow, IHasCustomMenu
{
    // 인터페이스 함수를 정의함. 이것은 윈도우창에 컨텍스 메뉴를 표현해준.
    public void AddItemsToMenu(GenericMenu menu)
    {
        // 두 번째 인자는 디폴트 메뉴
        menu.AddItem(new GUIContent("CONTEXT MENU1"), true, () => {

            Debug.Log("CONTEXT MENU1");

        });

        menu.AddItem(new GUIContent("CONTEXT MENU2"), false, () => {

            Debug.Log("CONTEXT MENU2");

        });
    }

    //// 이 윈도우는 연속해서 독립된 창으로 계속 생성 됨. (탭 가능)
    //// 트리거 메뉴 추가
    //[MenuItem("Dev/SlotMaker")]
    //static void CreateWindow()
    //{
    //    // 윈도우 만들고...여기서 SlotMaker는 윈도우 이름이다. 즉, 현재 스크립트를 관리하는 윈도우이다.
    //    // using 선언으로 EditorWindow 이거 빼도됨, 여기서 var는 SlotMaker.
    //    var slotMakerWindow = EditorWindow.CreateInstance<SlotMaker>();
    //    // 보여주고(API???)
    //    slotMakerWindow.Show();

    //    // 이런식으로 윈도우의 탭 이름과 아이콘을 변경
    //    var icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Study6/Editor/SlotMaker.png");
    //    slotMakerWindow.titleContent = new GUIContent("바이오하자드", icon);

    //    // 이런식으로 최소 최대 윈도우 크기를 같게하면 사이즈 변경이 안된다.
    //    //slotMakerWindow.maxSize = slotMakerWindow.minSize = new Vector2(300, 500);
    //}

    //// 이 윈도우는 하나만 독립된 창으로 생성 됨. (탭 가능)
    //// 정적 레퍼런스 선언
    //static SlotMaker slotMakerWindow;

    //// 트리거 메뉴 추가.
    //[MenuItem("Dev/SlotMaker")]
    //static void CreateWindow()
    //{
    //    if (!slotMakerWindow)
    //    {
    //        // 윈도우 만들고...여기서 SlotMaker는 윈도우 이름이다. 즉, 현재 스크립트를 관리하는 윈도우이다.
    //        // using 선언으로 EditorWindow 이거 빼도됨
    //        slotMakerWindow = EditorWindow.CreateInstance<SlotMaker>();
    //    }
    //    // 보여주고(API???)
    //    slotMakerWindow.ShowAuxWindow();
    //    //slotMakerWindow.ShowAsDropDown(new Rect(300, 200, 0, 0), new Vector2(700, 500));
    //    /*
    //        Show();             // 기본적인 탭 기능이 포함된 윈도우.
    //        ShowUtility();      // 탭으로 표현되지 않고 항상 우선순위가 높게 보여지는 윈도우. (셋팅창에 쓰임)
    //        ShowPopup();        // 윈도우의 닫기 버튼과 타이틀이 없다. 따라서 닫기 기능을 추가해 줘야한다.
    //                            // 나머진 ShowUtility 와 기능적으로 같다.(아래 OnGUI 참고)
    //        ShowAsDropDown();   // ShowPopup하고 기능적으로 같다 하지만 화면 해상도에 맞춰 생성할 윈도우의 표시 영역을
    //                            // 보정해준다.
    //        ShowAuxWindow();    // ShowUtility하고 기능적으로 같다 하지만 다른 윈도에 Focus를 뺏기면 Destroy 됨.
    //                            // 경우에 따라선 매우 편리한기능이다. 왜냐하면 윈도우를 찾아서 지우는 번거러움이 없음
    //                            // 따라서 간단한 셋팅창을 위한것이라 생각하자.

    //        GetWindow();        // 함수에는 없는 기능(Show~())
    //    */
    //}

    //void OnGUI()
    //{
    //    // 버튼 혹은 Escape키를 눌를때...닫자.
    //    // 잼있다!..GUILayout.Button 이 디폴트 게임 뷰가 아니라 현재 작업중인 EditorWindow 이다.
    //    if (GUILayout.Button("My button") || Event.current.keyCode == KeyCode.Escape)
    //    {
    //        slotMakerWindow.Close();
    //    }
    //}

    //// 이 윈도우는 하나만 독립된 창으로 생성 됨. (탭 가능)
    //// 트리거 메뉴 추가
    //[MenuItem("Dev/SlotMaker")]
    //static void CreateWindow()
    //{
    //    // 윈도우 만들고...여기서 SlotMaker는 윈도우 이름이다. 즉, 현재 스크립트를 관리하는 윈도우이다.
    //    // using 선언으로 EditorWindow 이거 빼도됨, 여기서 var는 SlotMaker.
    //    // GetWindow 이 함수는 현재 윈도우가 존재하면 해당 인스턴스를 가져오고 아니면 해당 윈도우를 만든다. (싱글턴 구조)
    //    // 또한 Show(); 호출의 기능도 가지고 있어서 무지 편리하다.
    //    //var slotMakerWindow = EditorWindow.GetWindow<SlotMaker>();    // 0 그냥 독립적인 단 하나의 윈도우 생성
    //    // 또한 GetWindow 함수는 DockArea에 내부에서 EditorWindow(인스턴스)를 추가(캐쉬)할 수 있다.
    //    // 즉, DockArea에 포함된 EditorWindow에 탭 윈도우로 추가.
    //    //System.Type windowType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow");  // 1
    //    //var slotMakerWindow = EditorWindow.GetWindow<SlotMaker>(windowType);  // 1
    //    //var slotMakerWindow = GetWindow<SlotMaker>(typeof(SceneView));    // 2 SceneView에만 처리시...
    //    var slotMakerWindow = GetWindow<SlotMaker>(typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow"));
    //    /*
    //        = 일반화된 windowType 이름 값 =
    //        Inspector: UnityEditor.InspectorWindow
    //        Project: UnityEditor.ProjectBrowser
    //        Hierarchy: UnityEditor.SceneHierarchyWindow
    //        Scene: UnityEditor.SceneView
    //        Game: UnityEditor.GameView
    //        Console: UnityEditor.ConsoleWindow
    //    */
    //}

    //// 팝업기능 구현
    //// 팝업 기능 객체 생성(인스턴스 생성)
    //// 클래스는 이 스크립트 하단에 제공하고 있음
    //Popup popupContent = new Popup();

    //// 이 윈도우는 하나만 독립된 창으로 생성 됨. (탭 가능)
    //// 트리거 메뉴 추가
    //[MenuItem("Dev/SlotMaker")]
    //static void CreateWindow()
    //{
    //    // 윈도우 만들고...여기서 SlotMaker는 윈도우 이름이다. 즉, 현재 스크립트를 관리하는 윈도우이다.
    //    // using 선언으로 EditorWindow 이거 빼도됨, 여기서 var는 SlotMaker.
    //    // GetWindow 이 함수는 현재 윈도우가 존재하면 해당 인스턴스를 가져오고 아니면 해당 윈도우를 만든다. (싱글턴 구조)
    //    // 또한 Show(); 호출의 기능도 가지고 있어서 무지 편리하다.
    //    var slotMakerWindow = EditorWindow.GetWindow<SlotMaker>();    // 0 그냥 독립적인 단 하나의 윈도우 생성
    //    // 또한 GetWindow 함수는 DockArea에 내부에서 EditorWindow(인스턴스)를 추가(캐쉬)할 수 있다.
    //    // 즉, DockArea에 포함된 EditorWindow에 탭 윈도우로 추가.
    //    //System.Type windowType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow");  // 1
    //    //var slotMakerWindow = EditorWindow.GetWindow<SlotMaker>(windowType);  // 1
    //    //var slotMakerWindow = GetWindow<SlotMaker>(typeof(SceneView));    // 2 SceneView에만 처리시...
    //    //var slotMakerWindow = GetWindow<SlotMaker>(typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow"));
    //    /*
    //        = 일반화된 windowType 이름 값 =
    //        Inspector: UnityEditor.InspectorWindow
    //        Project: UnityEditor.ProjectBrowser
    //        Hierarchy: UnityEditor.SceneHierarchyWindow
    //        Scene: UnityEditor.SceneView
    //        Game: UnityEditor.GameView
    //        Console: UnityEditor.ConsoleWindow
    //    */
    //}

    //void OnGUI ()
    //{
    //    // 현재 작업중인 윈도우에 표시되는 버튼이다.
    //    if (GUILayout.Button ("Popup",GUILayout.Width(128))) {
    //        var activatorRect = GUILayoutUtility.GetLastRect ();
    //        //  PopupWindow(); // ShowPopup 기능 + Popup 
    //        PopupWindow.Show (activatorRect, popupContent);
    //    }
    //}

    //// int형 필드
    //public int aaa;
    //// 위자드에 표시되는 생성할 오브젝트 네임
    //public string objName;

    //// 이 윈도우는 연속해서 독립된 창으로 계속 생성 됨.
    //// 우측 하단에 Create 버튼 생성.(이것또한 윈도우) 또한 클래스의 필드가 표시됨.
    //// 트리거 메뉴 추가
    //[MenuItem("Dev/SlotMaker")]
    //static void CreateWindow()
    //{
    //    // 윈도우 만들고...여기서 SlotWizard는 윈도우 이름이다. 즉, 현재 스크립트를 관리하는 윈도우이다.
    //    // using 선언으로 UnityEditor.ScriptableWizard 이거 빼도됨, 여기서 var는 SlotMaker.
    //    //var slotMakerWindow = UnityEditor.ScriptableWizard.DisplayWizard<SlotMaker>("SlotWizard");
    //    // 버튼을 추가 사용 및 버튼이름 지정. 두 버튼이 모두 사용되야 윈도우가 종료된다.
    //    var slotMakerWindow = UnityEditor.ScriptableWizard.DisplayWizard<SlotMaker>("SlotWizard", "BOX", "Cylinder");
    //}

    ////// 이 함수는 절대 사용하면 안된다. 이유는 ScriptableWizard 는  EditorWindow를 상속하고있다.
    ////// OnGUI 함수를 사용하면 그냥 EditorWindow 표현으로 바뀌기 때문에 모든 필드와 기존 버튼이 사라짐.
    ////void OnGUI()
    ////{
    ////    // 현재 작업중인 윈도우에 표시되는 버튼이다.
    ////    if (GUILayout.Button("Popup", GUILayout.Width(128)))
    ////    {
    ////    }
    ////}

    //// 만야 이 함수를 재정의 하면 이 함수를 통해 GUI를 커스터마이즈할 수 있지만
    //// 다음과 같은 주의사항이 생김.
    //// false 를 반환하면 OnWizardUpdate 가 호출안됨
    //protected override bool DrawWizardGUI ()
    //{
    //    // EditorGUILayout로 GUI 표현해야함 (EditorCreate.cs 참고)
    //    objName = EditorGUILayout.TextField("objName", objName);
    //    aaa = EditorGUILayout.IntField("aaa", aaa);
    //    return true;
    //}

    //// 필드에 수치의 변화가 있으면 호출
    //void OnWizardUpdate ()
    //{
    //    Debug.Log ("하하하");
    //}

    //// Create, BOX 버튼 사용시 호출(이벤트 함수)
    //void OnWizardCreate ()
    //{
    //    // 빈 게임 오브젝트 생성
    //    Transform empty = new GameObject(objName).GetComponent<Transform>();

    //    // 큐브 생성
    //    GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    go.name = objName;

    //    // 자식으로...
    //    go.transform.SetParent(empty, false);
    //    // 컴포넌트도...
    //    empty.gameObject.AddComponent<AudioSource>();

    //}

    //// Cylinder 버튼 사용시 호출(이벤트 함수)
    //void OnWizardOtherButton ()
    //{
    //    // 빈 게임 오브젝트 생성
    //    Transform empty = new GameObject(objName).GetComponent<Transform>();

    //    // 실린더 생성
    //    var go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
    //    go.name = objName;

    //    Debug.Log(go.name);

    //    // 자식으로...
    //    go.transform.SetParent(empty, false);
    //    // 컴포넌트도...
    //    empty.gameObject.AddComponent<AudioSource>();

    //}



    // 여기서 부터 실제 구현부분
    //https://docs.unity3d.com/kr/2018.4/Manual/script-CanvasScaler.html


    // 싱글톤인 슬롯매니저에 열겨형 변수 선언
    SlotManager.eState slotState;
    // 스크롤 할 위치를 지정하기 위함
    private Vector2 scrollPosistion = Vector2.zero;

    // 이미지를 저장 할 배열
    public Sprite[] spriteList = null;
    // 런타임 중에 Animator의 컨트롤러를 변경하는 데 사용할 수 있다.(AnimatorController의 런타임 표현)
    public RuntimeAnimatorController[] animatorList = null;

    // 이미지 카운트(비지니스 변수)
    private int imageCount;

    private float[] slotSpeeds = new float[4];
    // 스핀 타임
    private float[] spinTime = new float[4];

    // 에디터를 표현하기 위한 트리거
    [MenuItem("Dev/SlotMaker")]
    public static void UseSlotMaker()
    {
        // SlotMaker 전용 에디터 생성 
        EditorWindow.GetWindow(typeof(SlotMaker));
    }

    void OnGUI()
    {
        scrollPosistion = EditorGUILayout.BeginScrollView(scrollPosistion);
        if (spriteList == null)
        {
            spriteList = new Sprite[50];
        }
        if (animatorList == null)
        {
            animatorList = new RuntimeAnimatorController[50];
        }
        //EditorGUILayout.BeginHorizontal();
        GUILayout.Label("이미지 수");

        imageCount = EditorGUILayout.IntField(imageCount);


        for (int i = 0; i < imageCount; i++)
        {
            if (i % 3 == 0)
            {
                EditorGUILayout.BeginHorizontal();
            }
            EditorGUILayout.BeginVertical();
            GUILayout.Label(string.Format("{0}번 이미지", i + 1));
            spriteList[i] = (Sprite)EditorGUILayout.ObjectField(spriteList[i], typeof(Sprite), false, GUILayout.Width(70), GUILayout.Height(70));
            animatorList[i] = (RuntimeAnimatorController)EditorGUILayout.ObjectField(animatorList[i], typeof(RuntimeAnimatorController), false);
            EditorGUILayout.EndVertical();
            if (i % 3 == 2)
            {
                EditorGUILayout.EndHorizontal();
            }
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("그림 설정"))
        {
            SetTextures();
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("첫번째 슬롯 속도", GUILayout.Width(110f));
        GUILayout.Label("첫번째 회전 시간", GUILayout.Width(110f));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        slotSpeeds[0] = EditorGUILayout.FloatField(slotSpeeds[0], GUILayout.Width(110f));
        spinTime[0] = EditorGUILayout.FloatField(spinTime[0], GUILayout.Width(110f));
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("두번째 슬롯 속도", GUILayout.Width(110f));
        GUILayout.Label("두번째 회전 시간", GUILayout.Width(110f));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        slotSpeeds[1] = EditorGUILayout.FloatField(slotSpeeds[1], GUILayout.Width(110f));
        spinTime[1] = EditorGUILayout.FloatField(spinTime[1], GUILayout.Width(110f));
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("세번째 슬롯 속도", GUILayout.Width(110f));
        GUILayout.Label("세번째 회전 시간", GUILayout.Width(110f));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        slotSpeeds[2] = EditorGUILayout.FloatField(slotSpeeds[2], GUILayout.Width(110f));
        spinTime[2] = EditorGUILayout.FloatField(spinTime[2], GUILayout.Width(110f));
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("네번째 슬롯 속도", GUILayout.Width(110f));
        GUILayout.Label("네번째 회전 시간", GUILayout.Width(110f));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        slotSpeeds[3] = EditorGUILayout.FloatField(slotSpeeds[3], GUILayout.Width(110f));
        spinTime[3] = EditorGUILayout.FloatField(spinTime[3], GUILayout.Width(110f));
        EditorGUILayout.EndHorizontal();


        if (GUILayout.Button("속도,시간 설정"))
        {
            SetSpeedAndTime();
        }

        EditorGUILayout.EndScrollView();

        GUILayout.Label("나올 그림", GUILayout.Width(110f));
        SlotManager.Instance.state = (SlotManager.eState)EditorGUILayout.EnumPopup(SlotManager.Instance.state);
    }

    void SetTextures()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Slot");
        SlotManager.Instance.slotImageCount = imageCount;
        for (int i = 0; i < objects.Length; i++)
        {
            csSlotComponent component = objects[i].GetComponent<csSlotComponent>();
            component.slotTextureList = new Sprite[imageCount];
            component.controllerList = new RuntimeAnimatorController[imageCount];
            for (int j = 0; j < imageCount; j++)
            {
                component.slotTextureList[j] = spriteList[j];
                component.controllerList[j] = animatorList[j];
            }
        }
    }

    void SetSpeedAndTime()
    {
        SlotManager.Instance.spinTime = spinTime;
        SlotManager.Instance.SlotSpeed = slotSpeeds;
    }

}

// PopupWindowContent 추상 클래스를 상속해야 함.
public class Popup : PopupWindowContent
{
    public override Vector2 GetWindowSize()
    {
        // Popup 윈도우의 픽셀단위??? 크기를 지정.
        return new Vector2(256, 300);
    }

    public override void OnGUI(Rect rect)
    {
        // Popup 윈도우의 제목을 지정. 
        EditorGUILayout.LabelField("팝업 컨텐츠");
    }

    public override void OnOpen()
    {
        // Popup 윈도우가 열리면 호출
        Debug.Log("하이");
    }

    public override void OnClose()
    {
        // Popup 윈도우가 닫히면 호출
        Debug.Log("잘가");
    }
}

