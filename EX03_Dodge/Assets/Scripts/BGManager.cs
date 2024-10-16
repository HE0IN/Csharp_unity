using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    //오디오 클립(mp3,wav)
    public AudioClip backgroundMusic;
    //오디오 소스(컴포넌트)
    private AudioSource audioSource;

    public void playStart()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; //반복 재생
        audioSource.Play(); //재생 시작
    }
    public void playEnd() {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop(); //재생 중지
    }

}
