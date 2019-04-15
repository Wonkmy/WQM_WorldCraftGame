using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责世界的生成（各种事物的实际生成的类）
/// </summary>
public class World : MonoBehaviour {
    public Dictionary<int, Block> blocksdic = new Dictionary<int, Block>();
    /// <summary>
    /// 用以柏林噪声采样的X和Z值（柏林噪声返回的是Y值）
    /// </summary>
    private float seedX, seedZ;
    /// <summary>
    /// 地图的最大高度
    /// </summary>
    [SerializeField]
    private int maxHeight = 10;

    /// <summary>
    /// 决定了采样间隔 值越大 采样间隔越小
    /// </summary>
    [SerializeField]
    private float relief = 15.0f;

    public int Width;
    public int depth;

    public Block blockEmpty;
    public List<Block> blocks;
    /// <summary>
    /// 地图管理器
    /// </summary>
    public MapManager mapmanager;

    float y = 0;

    void Awake()
    {

    }

    void Start()
    {
        Init();
    }

    void Init()
    {
        seedX = Random.value * 100f;
        seedZ = Random.value * 100f;
        StartCoroutine(InitWorld());
    }

    /// <summary>
    /// 初始化世界的生成
    /// </summary>
    public IEnumerator InitWorld()
    {
        float y = 0;
        float y1 = 0;
        int id = 0;
        Block b = null;
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < depth; j++)
            {
                float xSample1 = (i + seedX) / relief;
                float zSample1 = (j + seedZ) / relief;
                float noise1 = Mathf.PerlinNoise(xSample1, zSample1);
                y1 = maxHeight * noise1;
                // 为了模仿我的世界的格子风 将每一次计算出来的浮点数值转换到整数值
                y1 = Mathf.Round(y1);
                if (y1 > maxHeight * 0.3f)
                {
                    id = 2;//草地
                    
                }
                else if (y1 > maxHeight * 0.2f)
                {
                    id = 0;//泥土
                }
                else if (y1 > maxHeight * 0.1f)
                {
                    id = 1;//石头
                }

                b = Instantiate(blocks[id], new Vector3(i, y, j), Quaternion.identity);
                float xSample = (b.transform.localPosition.x + seedX) / relief;
                float zSample = (b.transform.localPosition.z + seedZ) / relief;
                float noise = Mathf.PerlinNoise(xSample, zSample);
                y = maxHeight * noise;
                // 为了模仿我的世界的格子风 将每一次计算出来的浮点数值转换到整数值
                y = Mathf.Round(y);
                b.transform.localPosition = new Vector3(b.transform.localPosition.x, y, b.transform.localPosition.z);
                //blocksdic.Add(b.blockId, b);
                b.setBlockUnbreakable(true);
                initenv(b);
            }
            yield return new WaitForSeconds(.1f);
        }
    }

    /// <summary>
    /// 初始化环境生成
    /// </summary>
    /// <returns></returns>
    public void initenv(Block b)
    {
        if (b.blockstyle == BlockStyle.blockStyle.GRASS)
        {
            int index = Random.Range(0, 30);
            if (index == 3 || index == 8)
            {
                int index1 = Random.Range(0, 10);
                if (index1 == 4)
                {
                    mapmanager.InitTree(b.transform.position.x, b.blockUp().y, b.transform.position.z);
                }
            }
        }
    }

    /// <summary>
    /// 创建一个方块
    /// </summary>
    /// <param name="pos"></param>
    public void CreatCubeByPlayer(Block block, Vector3 pos)
    {
        Block newCreatBlock = Instantiate(block, pos, Quaternion.identity);
        newCreatBlock.setBlockUnbreakable(true);
    }
}
