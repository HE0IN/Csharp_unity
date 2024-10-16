using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //트리거 충돌: 힘이 가해지지 않는 논리적 충돌
    void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter");
        if(other.tag == "Player") {
            //FindObjectOfType : 씬에 존재하는 GameManger 타입의 오브젝트를 찾아오기
            GameManger gameManger = FindObjectOfType<GameManger>();
            if(gameManger != null) {
                gameManger.lifeCount += 1;

                //사운드 재생
                SoundManager soundManager = FindObjectOfType<SoundManager>();
                if(soundManager != null) {
                    soundManager.PlaySound("item_pick_up");
                }
            }

            //아이템이 소멸되도록 한다.
            Destroy(gameObject, 0.1f);
        }
    }
}
