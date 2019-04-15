using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 树类（所有树类的基类）
/// </summary>
public class WorldTree : MonoBehaviour {
    /// <summary>
    /// 树干预制体
    /// </summary>
    public GameObject trunk;
    /// <summary>
    /// 树枝预制体
    /// </summary>
    public GameObject leaves;

    public virtual void Create(float x,float y,float z)
    {

    }
}
