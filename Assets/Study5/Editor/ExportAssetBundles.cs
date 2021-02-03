using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExportAssetBundles : MonoBehaviour
{
    [MenuItem("Build/Build AssetBundle #%&d")]
    public static void BuildSceneToAssetBundle()
    {
        //번들로 만들씬의 이름과 경로
        string sceneNames = "AssetBundles";

        //pc버전
        BuildPipeline.BuildAssetBundles(sceneNames, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        //안드로이드 버전
        //BuildPipeline.BuildAssetBundles(sceneNames, BuildAssetBundleOptions.None, BuildTarget.Android);
    }

    [MenuItem("CONTEXT/Rigidbody/Double Mass")]
    static void DubleMass(MenuCommand command)
    {
        Rigidbody body = (Rigidbody)command.context;

        body.mass = body.mass * 2;
        Debug.Log("+ Double Rigidbody's Mass to " + body.mass + "from Context Menu");
    }

    [MenuItem("GameObject/MyCategory/Custom Game Object1",false,1)]
    static void CreatCustomGameObject1(MenuCommand menuCommand)
    {
        GameObject go = new GameObject("Custom Game Object");
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);

        Undo.RegisterCreatedObjectUndo(go, "Create" + go.name);
        Selection.activeObject = go;
    }

    [MenuItem("GameObject/MyCategory/Custom Game Object2", false, 12)]
    static void CreatCustomGameObjectEx1(MenuCommand menuCommand)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);

    }
    [MenuItem("GameObject/MyCategory/Custom Game Object2", true)]
    static bool CreateCustomGameObjectCheck()
    {
        if (Selection.activeObject != null)
            return Selection.activeObject.GetType() == typeof(SceneAsset);
        else
            return false;
    }

    [MenuItem("GameObject/MyCategory/Custom Game Object3", false, 15)]
    static void CreatCustomGameObjectEx2(MenuCommand menuCommand)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

    }
}
