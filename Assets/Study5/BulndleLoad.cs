using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulndleLoad : MonoBehaviour
{
    //번들받을 서버주소
    public string bundleURL;

    public int version;

    [System.Obsolete]

    void Start()
    {
        StartCoroutine(this.LoadAssetBundle());
    }

    IEnumerator LoadAssetBundle()
    {
        while(!Caching.ready)
        {
            yield return null;
        }
        WWW www = WWW.LoadFromCacheOrDownload(this.bundleURL, this.version);

        //www에 값이 쓰이기까지 기다림
        yield return www;

        AssetBundle bundle = www.assetBundle;

        for(int i = 0; i < 3; i++)
        {
            AssetBundleRequest request = bundle.LoadAssetAsync("Cube " + (i + 1), typeof(GameObject));
            yield return request;

            /*  다음 코드로도 불러올수 있다. 차이 점은 위의 Async 가 붙어있는 코드의 경우에는 Request에 
             *  불러와야 하며 비동기 형식이기 때문에 무거운 에셋번들을 불러올때 메인 스레드가 멈추는 것을
             *  방지 할 수있다. 대신 코드가 약간 더 무겁다.
             *  GameObject obj = bundle.LoadAsset("Cube " + (i + 1) ) as GameObject;
             * 
             */

            GameObject obj = request.asset as GameObject;

            GameObject Temp = Instantiate(obj) as GameObject;

            Temp.transform.position = new Vector3(-5.0f + (i * 5), 0f, 0f);
        }

        //반드시 언로드해야함 메모리소모나 복수인스턴스방지
        bundle.Unload(false);

        if(www.error !=null)
        {
            Debug.LogError("fail :(");
        }
    }
}
