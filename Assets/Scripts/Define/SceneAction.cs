using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAction {
    public delegate void NullPara();
    public static NullPara _updateMap;
    public static void OnUpDateMap()
    {
        if (_updateMap != null)
        {
            _updateMap();
        }
    }
}
