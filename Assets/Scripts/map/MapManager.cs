using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class MapManager : MonoBehaviour {

    private static MapManager instance;
    public static MapManager Insatnce
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("MapManager").AddComponent<MapManager>();
            }
            return instance;
        }
    }

    public Dictionary<MapNode, MapPointMessage> nowMapMessage = new Dictionary<MapNode, MapPointMessage>();
    public Map nowMap;



    public void CreateMap(Map map)
    {
        nowMapMessage.Clear();
        nowMap = map;
        for (short i = 0; i < map.mapXCount; i++)
        {
            for (short j = 0; j < map.mapYCount; j++)
            {
                MapNode node = new MapNode();
                node.xPoint = i;
                node.yPoint = j;
                MapPointMessage temp = new MapPointMessage();
                temp.xPoint = i;
                temp.yPoint = j;
                temp.xposition = (i- map.mapXCount/2)*10;
                temp.yposition = (j - map.mapYCount / 2) * 10;
                int index = i * map.mapYCount + j;
                if(index>= map.mapData.Count)
                {
                    temp.textureID = 0;
                }
                else
                {
                    temp.textureID = map.mapData[index];
                }
                
                nowMapMessage.Add(node, temp);
            }
        }
        SceneAction.OnUpDateMap();
    }
    
}
public enum MapType
{
    grass0=0, //草地1 茂盛
    grass1,   //草地2 
    grass2,   //草地3 稀疏

}

public struct MapNode
{
    public short xPoint;
    public short yPoint;
}

public class MapPointMessage
{
    public short xPoint;
    public short yPoint;
    public short mapId;
    public byte textureID;
    public bool isCanMove;
    public float xposition;
    public float yposition;
    //...
}

public class Map
{
    public MapNode createPoint;
    public List<byte> mapData=new List<byte>();
    public short mapXCount;
    public short mapYCount;
    
}