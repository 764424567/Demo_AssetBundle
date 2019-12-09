using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadBundles : MonoBehaviour
{
    GameObject go;
    //GameObject[] go2;
    public Text m_text;
    public Text m_TextHelp;
    string bundleName = "";
    string bundleNameOld = "";
    bool isRedo = false;

    void Start()
    {
        //StartCoroutine(Load());
    }

    IEnumerator Load2()
    {
        string bundleNameNew = m_text.text + ".unity3d";
        if (bundleNameNew == bundleNameOld || m_text.text == "") { isRedo = true; }
        else { isRedo = false; }

        if (isRedo == false)
        {
            m_TextHelp.text = "";
            string StrName = "http://192.168.241.1:8080/ABs/" + m_text.text + ".unity3d";
            WWW www = new WWW(StrName);
            yield return www;
            AssetBundle bundle = www.assetBundle;
            bundleNameOld = bundle.name;
            string ModelName = m_text.text + ".prefab";
            AssetBundleRequest request = bundle.LoadAssetAsync(ModelName, typeof(GameObject));
            go = Instantiate(request.asset as GameObject, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
            yield return request;
            www.Dispose();
        }
        else
        {
            if (m_text.text == "")
            {
                m_TextHelp.text = "资源文件不存在";
            }
            else
            {
                m_TextHelp.text = "资源文件重复加载";
            }
        }

    }

    IEnumerator Load()
    { 
        if (isRedo == false)
        {
            string StrName = "http://192.168.241.1:8080/ABs/" + m_text.text + ".unity3d";
            //string StrName2 = "http://192.168.241.1:8080/ABs/cube.unity3d";
            //从远程服务器上进行下载和加载
            WWW www = new WWW(StrName);
            //从本地文件中加载
            //WWW www = new WWW("file://D:/Frank/UnityProject/Demo-1/Assets/ABs/cube01.unity3d");
            yield return www;
            AssetBundle bundle = www.assetBundle;
            string bundleName2 = m_text.text + ".unity3d";
            if (bundleName2 == bundleName)
            {
                m_TextHelp.text = "资源文件重复加载";
                isRedo = true;
            }
            else
            {
                isRedo = false;
            }
            bundleName = bundle.name;
            if (bundle == null)
            {
                m_TextHelp.text = "资源文件不存在";
            }
            else
            {
                string ModelName = m_text.text + ".prefab";
                AssetBundleRequest request = bundle.LoadAssetAsync(ModelName, typeof(GameObject));
                //AssetBundleRequest request2 = bundle.LoadAllAssetsAsync();
                //for (int i = 0; i < request2.allAssets.Length; i++)
                //{
                //    go2[i]=Instantiate(request2.allAssets[i], new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
                //}
                go = Instantiate(request.asset as GameObject, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
                yield return request;
            }
            www.Dispose();
        }
    }

    public void ButtonOnClick_Load()
    {
        StartCoroutine(Load2());
    }
}
