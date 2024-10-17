using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 4f; 
    private Rigidbody bulletRigidbody;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        //리지드바디의 속도값 = 앞쪽 방향 * 이동 속력 
        //transform.up Y+방향
        bulletRigidbody.velocity = transform.up * speed;
    }
    
    //트리거 충돌: 힘이 가해지지 않는 논리적 충돌
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Wall") {
            //탄알이 소멸되도록 한다.
            Destroy(gameObject, 0.1f);
        }
        else if(other.tag == "Enemy") {
            //Die()함수 호출
            BulletSpawner bulletSpawner = other.GetComponent<BulletSpawner>();
            if(bulletSpawner != null) {
                bulletSpawner.Die();
            }

            //탄알이 소멸되도록 한다.
            Destroy(gameObject, 0.1f);
        }
    }
}
