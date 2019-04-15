using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地图管理器（负责初始化各种地图上的事物）
/// </summary>
public class MapManager : MonoBehaviour {

    public WorldTree worldTree;

    /// <summary>
    /// 初始化树
    /// </summary>
    /// <param name="pos"></param>
    public void InitTree(float x,float y,float z)
    {
        worldTree.Create(x, y, z);
    }
    
}
