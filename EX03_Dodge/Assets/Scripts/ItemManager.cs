using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public float timeItemSpawn = 5.0f;
    public GameObject itemPrefab; //���������� ��ũ

    public GameObject[] itemSpawnPos;

    void Update()
    {
        timeItemSpawn -= Time.deltaTime;
        if(timeItemSpawn < 0) { //5�ʰ� ����
            
            timeItemSpawn = 5f; //5���ķ� �ٽ� ����

            spawnItem();
        }

    }
    void spawnItem() {
        //0���� 3���� ���� �ε��� ����
        int index = Random.Range(0, 3);
        Vector3 pos = itemSpawnPos[index].transform.position;

        //���������κ��� �������� ����
        GameObject item = Instantiate(itemPrefab, pos,
            transform.rotation);
    }
}
