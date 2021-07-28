using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public List<AudioClip> list_audioClips = new List<AudioClip>();
    public enum sounds { cannon_20mm, cannon_30mm, engage, explosion_01, hellfire, lockNready, rocket, rotor_highpower, rotor_lowpower,targetlocked,warning,tgtdestroyed};
    private AudioSource audioSource;
    private static SoundManager m_instance;
    public static SoundManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<SoundManager>();
            }
            return m_instance;
        }
    }

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void playAudio(sounds sourcetoplay)
    {
        int num = (int)sourcetoplay;
        audioSource.clip = list_audioClips[num];
        audioSource.Play();               
    }

    public void playOneShotAudio(sounds sourcetoplay, int priority)
    {
        int num = (int)sourcetoplay;
        audioSource.priority = priority;
        audioSource.PlayOneShot(list_audioClips[num]);       
    }

    public void Pause()
    {
        audioSource.Pause();
    }

    public void StopPlay()
    {
        audioSource.Stop();
    }

    public bool isPlaying()
    {  
        return audioSource.isPlaying;
    }    

    

}



