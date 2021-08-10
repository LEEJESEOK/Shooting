using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public enum BGM_SOUND_TYPE
    {
        BGM_INGAME,
        BGM_RESULT,
    }
    public enum EFT_SOUND_TYPE
    {
        EFT_BULLET,
        EFT_EXPLOSION,
    }

    public AudioSource audioSourceBGM;
    public AudioSource audioSourceEFT;
    public AudioClip[] bgmAudios;
    public AudioClip[] eftAudios;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGM_SOUND_TYPE type)
    {
        audioSourceBGM.clip = bgmAudios[(int)type];
        audioSourceBGM.Play();
    }

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public void PlayEFT(EFT_SOUND_TYPE type)
    {
        audioSourceEFT.PlayOneShot(eftAudios[(int)type]);
    }
}
