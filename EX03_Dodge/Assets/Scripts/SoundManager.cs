using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //����� Ŭ��(mp3,wav)
    public AudioClip game_start;
    public AudioClip game_end;
    public AudioClip explosion;
    public AudioClip fire;
    public AudioClip item_pick_up;

    //����� �ҽ�(������Ʈ)
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

            audioSource.loop = false; //�ݺ� ��� ����
            audioSource.Play(); //��� ����
        }
}
