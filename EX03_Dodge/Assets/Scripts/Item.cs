using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //Ʈ���� �浹: ���� �������� �ʴ� ���� �浹
    void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter");
        if(other.tag == "Player") {
            //FindObjectOfType : ���� �����ϴ� GameManger Ÿ���� ������Ʈ�� ã�ƿ���
            GameManger gameManger = FindObjectOfType<GameManger>();
            if(gameManger != null) {
                gameManger.lifeCount += 1;

                //���� ���
                SoundManager soundManager = FindObjectOfType<SoundManager>();
                if(soundManager != null) {
                    soundManager.PlaySound("item_pick_up");
                }
            }

            //�������� �Ҹ�ǵ��� �Ѵ�.
            Destroy(gameObject, 0.1f);
        }
    }
}
