using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySounds : MonoBehaviour
{

    public AudioClip StartSound;
    public AudioClip EndSound;
    public AudioClip CloseHood;
    private AudioSource Speaker;
    private bool paused = false;

    audio NextPlaying;
    public bool stillPlay;
    // Use this for initialization
    public enum audio
    {
        Hood,
        HoodSecond,
        CloseHood,
        Pause,
        UnPause,
    }
    void Start()
    {
        Speaker = GetComponent<AudioSource>();
        Speaker.clip = StartSound;
        Speaker.loop = false;

    }


    public void playManager(string tag)
    {
        if (paused)
        {
            WhichAudio(audio.UnPause);
        }
        else
        {
            audio stringToEnum = (audio)System.Enum.Parse(typeof(audio), tag);
            WhichAudio(stringToEnum);
        }

    }
    void WhichAudio(audio play)
    {
        switch (play)
        {
            case audio.Hood:
                Speaker.clip = StartSound;
                Speaker.Play();
                NextPlaying = audio.HoodSecond;
                StartCoroutine(WaitTillDone());

                break;
            case audio.HoodSecond:

                Speaker.clip = EndSound;
                Speaker.PlayDelayed(3);
                break;
            case audio.Pause:
                paused = true;
                Speaker.Pause();
                break;
            case audio.UnPause:
                paused = false;
                Speaker.UnPause();
                break;
            case audio.CloseHood:
                Speaker.clip = CloseHood;
                Speaker.PlayDelayed(1);
                stillPlay = false;
                break;
        }

    }




    IEnumerator WaitTillDone()
    {

        yield return new WaitUntil(() => Speaker.clip.length - 1 <= Speaker.time);
        if (stillPlay)
        {
            WhichAudio(NextPlaying);
        }

    }





}
