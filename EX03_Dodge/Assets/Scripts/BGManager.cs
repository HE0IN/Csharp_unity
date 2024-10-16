using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    //����� Ŭ��(mp3,wav)
    public AudioClip backgroundMusic;
    //����� �ҽ�(������Ʈ)
    private AudioSource audioSource;

    public void playStart()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true; //�ݺ� ���
        audioSource.Play(); //��� ����
    }
    public void playEnd() {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop(); //��� ����
    }

}
