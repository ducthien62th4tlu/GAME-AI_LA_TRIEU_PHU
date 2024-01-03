using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Ins;

    [Range(0,1)]
    public float musicVolume;
    [Range(0,1)]
    public float soundVolume;

    public AudioSource musicAus;
    public AudioSource soundAus;

    public AudioClip[] backgroundMusic;
    public AudioClip rightSound;
    public AudioClip loseSound;
    public AudioClip winSound;
    public AudioClip playSound;

    private void Awake()
    {
        MakeSingleton();
    }
    // Start is called before the first frame update
    public void Start()
    {
        PlayBackgroundMusic();
    }
    private void Update()
    {
        if (musicAus && soundAus)
        {
            musicAus.volume = soundVolume;
            soundAus.volume = soundVolume;
        }
    }
    public void PlayBackgroundMusic()
    {
        if(musicAus && backgroundMusic != null && backgroundMusic.Length > 0)
        {
            int ranIdx = Random.Range(0, backgroundMusic.Length);
            if (backgroundMusic[ranIdx])
            {
                musicAus.clip = backgroundMusic[ranIdx];
                musicAus.volume = musicVolume;
                musicAus.Play();
            }
        }
    }
    public void PlaySound(AudioClip sound)
    {
        if(soundAus && sound)
        {
            soundAus.PlayOneShot(sound);
            soundAus.volume = soundVolume;
            soundAus.Play();
        }
    }

    public void PlayRightSound()
    {
        PlaySound(rightSound);
    }
    public void PlayWinSound()
    {
        PlaySound(winSound);
    }
    public void PlayLoseSound()
    {
        PlaySound(loseSound);
    }
    public void StopMusic()
    {
        if (musicAus)
        {
            musicAus.Stop();
        }
    }
    public void PlayGame()
    {
        PlaySound(playSound);
    }
    void MakeSingleton()
    {
        if (Ins == null)
        {
            Ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
