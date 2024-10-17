using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //gameObject,transform�� �����
    public Transform spwanPos;
    public GameObject bulletPrefab; //������ ź���� ���� ������
    private float timeAfterSpawn;
    public float spawnRateTime = 2.0f;

    void Start() {
        timeAfterSpawn = 0f;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(Input.GetMouseButtonDown(0)) // 0�� ���콺 ���� ��ư
        {
            if(timeAfterSpawn > spawnRateTime) {
                timeAfterSpawn = 0f;

                //���������κ��� ź�� ���� ����
                GameObject bullet = Instantiate(bulletPrefab, spwanPos.position,
                transform.rotation);
            }
        }
    }
}
