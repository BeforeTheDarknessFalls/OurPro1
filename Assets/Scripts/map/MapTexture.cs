using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTexture : MonoBehaviour {

    private static MapTexture instance;
    public static MapTexture Insatnce
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("MapTexture").AddComponent<MapTexture>();
            }
            return instance;
        }
    }
    
    private Dictionary<byte, Texture2D> mapTexture = new Dictionary<byte, Texture2D>();

    public Texture2D GetMapTexture(byte type)
    {
        if (mapTexture.ContainsKey(type))
        {
            return mapTexture[type];
        }
        Texture2D mapT = LoadManager.Instance.LoadTexture(type, Define.mapTextureUrl);
        mapTexture.Add(type, mapT);
        return mapTexture[type];
    }
    
}
