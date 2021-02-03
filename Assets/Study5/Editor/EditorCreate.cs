using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//인스펙터 수정을위한 네임스페이스
using UnityEditor;


[CanEditMultipleObjects]//다중선택을 가능하게함
[CustomEditor(typeof(AutoMove))]
public class EditorCreate : Editor
{
    AutoMove[] selectObj;

    //인스펙터의 기본프레임을 커스텀프레임으로 덮어씌움
    public override void OnInspectorGUI()
    {

        //DrawDefaultInspector();//기존걸로 복구

        //내가 클릭한 컴퍼넌트의 대상
        AutoMove autoM = (AutoMove)target;

        //필드명바꿈
        autoM.moveSpeed = EditorGUILayout.FloatField("aaaaa", autoM.moveSpeed);
        autoM.testNum = EditorGUILayout.IntField("bbbbb", autoM.testNum);

        EditorGUILayout.LabelField("ccccc", autoM.instance.ToString());

        if(GUILayout.Button("Origin Point"))
        {
            autoM.OriginSet();
        }

        EditorGUILayout.HelpBox("안녕하세요", MessageType.Warning);


        //다음에오는 버튼은 해당세팅으로 정렬됨
        //EditorGUILayout.BeginVertical();
        EditorGUILayout.BeginHorizontal();

        // 클릭된 오브젝트의 이름을 보여준다.(만들어진 순서로 스텍에 쌓임)
        if (GUILayout.Button("Show name +"))
        {
            for (int i = 0; i < selectObj.Length; i++)
            {
                Debug.Log(selectObj[i].name);
            }
        }

        // 오브젝트의 이름을 반대로 보여준다.
        if (GUILayout.Button("Show name -"))
        {
            for (int i = selectObj.Length - 1; i >= 0; i--)
            {
                Debug.Log(selectObj[i].name);
            }
        }
        //정렬후 항상 End를 마지막에 적어줘야한다
        //EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();


        if(GUI.changed)
        {
            EditorUtility.SetDirty(target);
            Debug.Log("changed");
        }
    }
    //클릭됬을때 계속호출됨
    void OnEnable()
    {
        selectObj = ToGetObj(targets);
        Debug.Log(selectObj.Length);
    }
    
    AutoMove[] ToGetObj(Object[] objs)
    {
        AutoMove[] _selectObj = new AutoMove[objs.Length];

        for(int i = 0; i<objs.Length; i++)
        {
            _selectObj[i] = objs[i] as AutoMove;
        }
        //배열 이름을 전달
        return _selectObj;
    }
}
