using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f; //최소 생성 주기
    public float spawnRateMax = 3.0f; //최대 생성 주기

    private Transform target; //발사할 대상(Player)
    private float spawnRate; //생성 주기
    private float timeAfterSpawn; //최근 생성 시점에서 지난 시간

    void Start() {
        timeAfterSpawn = 0; //최근 생성 이후의 시간을 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); //생성 시간을 랜덤 설정
        target = GameObject.Find("Player").transform;
        
        //씬(계층뷰)에서 게임오브젝트를 찾는 방법
        GameObject player = GameObject.Find("Player"); //속도 느림.
        GameObject player2 = GameObject.FindWithTag("Player");
        //특정 컴퍼넌트를 포함한 게임오브젝트 찾기
        GameObject player3 = FindObjectOfType<PlayerController>().gameObject;
        //public link : 단점 - 게임오브젝트 소멸시에 링크가 깨짐.
        //public GameObject player4;
    }

    void Update() // 매 프레임마다 실행되는 함수 예)30fps = 0.033밀리초마다 수행
    {
        //deltaTime : 한 프레임마다 들어온 시간, FPS가 달라져도 일정한 시간 간격을 유지하려고.
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn > spawnRate) {
            //탄알 생성 시점이 옴.
            timeAfterSpawn = 0; //누적된 시간을 리셋해 줌.

            //프리팹으로부터 탄알을 동적 생성하여 씬뷰(계층뷰)에 생성한다.
            GameObject bullet = Instantiate(bulletPrefab, transform.position,
                transform.rotation);
            //탄알이 타겟을 향해 바라보도록(forward z+방향을 조정) 한다.
            bullet.transform.LookAt(target);

            //다음 탄알 생성 시간 랜덤 설정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
