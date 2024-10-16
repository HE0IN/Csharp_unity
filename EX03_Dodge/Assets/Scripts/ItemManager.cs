using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public float timeItemSpawn = 5.0f;
    public GameObject itemPrefab; //프리팹으로 링크

    public GameObject[] itemSpawnPos;

    void Update()
    {
        timeItemSpawn -= Time.deltaTime;
        if(timeItemSpawn < 0) { //5초가 지남
            
            timeItemSpawn = 5f; //5초후로 다시 리셋

            spawnItem();
        }

    }
    void spawnItem() {
        //0부터 3까지 랜덤 인덱스 생성
        int index = Random.Range(0, 3);
        Vector3 pos = itemSpawnPos[index].transform.position;

        //프리팹으로부터 아이템을 생성
        GameObject item = Instantiate(itemPrefab, pos,
            transform.rotation);
    }
}
