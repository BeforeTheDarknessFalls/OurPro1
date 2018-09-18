using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : MonoBehaviour {

    private void Awake()
    {
        father = transform.Find("Map");
        OnInit();
    }

    Transform father;

    private void OnUpDateShowMap()
    {
        int count = MapManager.Insatnce.nowMapMessage.Count;
        CheckImgNum(count);
        StartCoroutine("PinZhuangMap");
    }

    Rect allRect = new Rect(0,0,10,10);
    IEnumerator PinZhuangMap()
    {
        int index = 0;
        foreach (MapPointMessage item in MapManager.Insatnce.nowMapMessage.Values)
        {
            Image img = father.GetChild(index).GetComponent<Image>();
            Texture2D t2 = MapTexture.Insatnce.GetMapTexture(item.textureID);
            img.overrideSprite = Sprite.Create(t2, new Rect(0, 0, t2.width, t2.height), Vector2.zero);
            img.SetNativeSize();
            img.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(10,10);
            img.transform.localPosition = new Vector2(item.xposition,item.yposition);
            img.gameObject.SetActive(true);
            index++;
            yield return 0;
        }
        
    }


    private void CheckImgNum(int count)
    {
        if (father.childCount == count) return;
        if(father.childCount < count)
        {
            for (int i = father.childCount; i < count; i++)
            {
                Image temp = new GameObject("m" + i).AddComponent<Image>();
                temp.GetComponent<RectTransform>().rect.Set(0,0,10,10);
                //temp.overrideSprite = MapTexture.Insatnce.GetMapTexture();
                temp.transform.SetParent(father);
                temp.gameObject.SetActive(false);
            }
            return;
        }
        for (int i = father.childCount-1; i >= count; i--)
        {
            GameObject.Destroy(father.GetChild(i).gameObject);
        }

    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    void OnInit()
    {
        SceneAction._updateMap += OnUpDateShowMap;
    }
    void OnOver()
    {
        SceneAction._updateMap -= OnUpDateShowMap;
    }

    private void OnDestroy()
    {
        OnOver();
    }
}
