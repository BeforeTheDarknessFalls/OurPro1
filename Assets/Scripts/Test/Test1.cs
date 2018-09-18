using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Test();
    }
	private void Test()
    {
        string map1 = LoadManager.Instance.LoadMap("map1",Define.mapUrl);
        Map map = new Map();
        MapNode mn = new MapNode();
        mn.xPoint = 0;
        mn.xPoint = 0;
        map.createPoint = mn;
        for (int i = 0; i < map1.Length; i++)
        {
            map.mapData.Add(byte.Parse(map1[i].ToString()));
        }
        map.mapXCount = 100;
        map.mapYCount = 100;
        MapManager.Insatnce.CreateMap(map);
    }


	// Update is called once per frame
	void Update () {
		
	}
}
