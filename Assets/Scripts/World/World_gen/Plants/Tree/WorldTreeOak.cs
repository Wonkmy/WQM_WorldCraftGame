using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 橡树
/// </summary>
public class WorldTreeOak : WorldTree {

    /// <summary>
    /// 创建橡树
    /// </summary>
    /// <param name="pos"></param>
    public override void Create(float x ,float y,float z)
    {
        GameObject newtrunk = null;
        GameObject newleaves1 = null;
        GameObject newleaves2 = null;
        GameObject newleaves3 = null;
        GameObject newleaves4 = null;
        GameObject newleaves5 = null;


        List<GameObject> trunks = new List<GameObject>();
        for (int i = 0; i < 5; i++)//树干生成的位置计算
        {
            //newtrunk = Instantiate(trunk, pos + new Vector3(0, i, 0), trunk.transform.rotation);
            newtrunk = Instantiate(trunk, new Vector3(x, y, z)+ new Vector3(0, i, 0), trunk.transform.rotation);

            trunks.Add(newtrunk);
        }
        for (int i = 1; i < 3; i++)//树枝生成的位置计算
        {
            //if (i == 2) return;
            for (int j = 1; j < 4; j++)
            {
                //if (j == 3 || j == 4) return;
                newleaves1 = Instantiate(leaves, trunks[j + 1].transform.position - new Vector3(i, 0, 0), leaves.transform.rotation);
                newleaves2 = Instantiate(leaves, trunks[j + 1].transform.position + new Vector3(i, 0, 0), leaves.transform.rotation);
                newleaves3 = Instantiate(leaves, trunks[j + 1].transform.position + new Vector3(0, 0, i), leaves.transform.rotation);
                newleaves4 = Instantiate(leaves, trunks[j + 1].transform.position - new Vector3(0, 0, i), leaves.transform.rotation);
                newleaves5 = Instantiate(leaves, trunks[trunks.Count-1].transform.position + new Vector3(0, 1, 0), leaves.transform.rotation);
            }
        }
    }
}
