using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachingDownLoadExample : MonoBehaviour
{

    //번들을 받을 서버의 URL(주소)
    public string bundleURL;

    //번들의 버전 (Version)
    public int version;

    // Use this for initialization
    //[System.Obsolete]
    void Start()
    {

        //코루틴 함수(시간 지연함수)를 사용하여 DownloadAndCache() 함수를 실행
        StartCoroutine(this.DownloadAndCache());

    }

    //[System.Obsolete]
    IEnumerator DownloadAndCache()
    {
        //cache 폴더에 AssetBundle 을 담아야 하므로 캐싱 시스템이 준비될때까지 기달림
        while (!Caching.ready)
        {
            yield return null;
        }

        /* 새 WWW 변수를 만들고  WWW.LoadFromCacheOrDownload(URL, 버전) 함수를 통하여 에셋번들을 다운로드하여
         * cache 폴더에 저장.
         * 
         * WWW.LoadFromCacheOrDownload() 함수를 사용하면 우선 cache 폴더에 같은 버전의 에셋 번들이 있는지 확인하여
         * 있는 경우 호출하고 없는 경우 URL로부터 다운로드 한다.
         */

        WWW www = WWW.LoadFromCacheOrDownload(this.bundleURL, this.version);

        //www에 값이 쓰이기까지 시간이 걸린다. (cache 참조 -> 서버접속하여 다운) 값이 쓰이기까지 기다리자.
        yield return www;

        //에러 검출 방법
        if (www.error != null)
        {
            Debug.Log("fail :(");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
