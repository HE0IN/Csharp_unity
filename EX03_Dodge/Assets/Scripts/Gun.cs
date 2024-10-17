using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //gameObject,transform은 예약어
    public Transform spwanPos;
    public GameObject bulletPrefab; //생성할 탄알의 원본 프리팹
    private float timeAfterSpawn;
    public float spawnRateTime = 2.0f;

    void Start() {
        timeAfterSpawn = 0f;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(Input.GetMouseButtonDown(0)) // 0은 마우스 왼쪽 버튼
        {
            if(timeAfterSpawn > spawnRateTime) {
                timeAfterSpawn = 0f;

                //프리팹으로부터 탄알 동적 생성
                GameObject bullet = Instantiate(bulletPrefab, spwanPos.position,
                transform.rotation);
            }
        }
    }
}
