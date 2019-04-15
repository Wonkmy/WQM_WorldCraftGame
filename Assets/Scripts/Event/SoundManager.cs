using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;
    private AudioSource audiosource;
    void Awake()
	{
        Init();
    }

    /// <summary>
    /// 初始化声音管理器
    /// </summary>
    void Init()
    {
        if (instance == null)
        {
            instance = this;
        }
        audiosource = GetComponent<AudioSource>();
    }

    public void PlaySound(string name)
    {
        AudioClip audioclip = Resources.Load<AudioClip>("/ss/d" + name + ".ogg");
        audiosource.PlayOneShot(audioclip);
    }
}
