using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour {

    static LoadManager instance;
    public static LoadManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("LoadMgr").AddComponent<LoadManager>();
            }
            return instance;
        }
    }

    public Object Load(string id,string path)
    {
        Object obj;
        string url = path + id;
        obj = Resources.Load(url);
        if (obj == null)
        {
            Debug.LogError("加载失败："+url);
        }
        return obj;
    }
    public Texture2D LoadTexture(byte id, string path)
    {
        Object obj;
        string url = path+"/" + id;
        obj = Resources.Load(url);
        if (obj == null)
        {
            Debug.LogError("加载失败：" + url);
        }
        return obj as Texture2D;
    }
    public string LoadMap(string id, string path)
    {
        Object obj;
        string url = path+"/" + id;
        Debug.LogError(url);
        obj = Resources.Load(url);
        if (obj == null)
        {
            Debug.LogError("加载失败：" + url);
        }
        TextAsset text= obj as TextAsset;
        Debug.LogError(text.text);
        return text.text.Trim();
    }

}
