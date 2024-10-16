using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //오디오 클립(mp3,wav)
    public AudioClip game_start;
    public AudioClip game_end;
    public AudioClip explosion;
    public AudioClip fire;
    public AudioClip item_pick_up;

    //오디오 소스(컴포넌트)
    private AudioSource audioSource;

    public void PlaySound(string soundName) {
        audioSource = GetComponent<AudioSource>();
        if(soundName.Equals("game_start")) {
            audioSource.clip = game_start;
        } else if(soundName.Equals("game_end")) {
            audioSource.clip = game_end;
        } else if(soundName.Equals("explosion")) {
            audioSource.clip = explosion;
        } else if(soundName.Equals("fire")) {
            audioSource.clip = fire;
        } else if(soundName.Equals("item_pick_up")) {
            audioSource.clip = item_pick_up;
        }

            audioSource.loop = false; //반복 재생 안함
            audioSource.Play(); //재생 시작
        }
}
