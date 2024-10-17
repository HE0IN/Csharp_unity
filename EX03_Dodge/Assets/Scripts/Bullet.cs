using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f; 
    private Rigidbody bulletRigidbody;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        //리지드바디의 속도값 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.velocity = transform.forward * speed;
        
        //게임오브젝트 소멸(파괴) : 비활성화와는 다른 것, 씬에서 아예 사라지는 것.
        //Destroy( gameObject, 3f ); //3초후에 소멸
    }
    //충돌처리 메소드
    //일반 충돌: 힘이 가해지는 물리적 충돌
    void OnCollisionEnter(Collision collision) { //충돌 시작
        //Debug.Log("OnCollisionEnter");
    }
    void OnCollisionStay(Collision collision) { //충돌 지속중
        //Debug.Log("OnCollisionStay");
    }
    void OnCollisionExit(Collision collision) { //충돌 종료
       // Debug.Log("OnCollisionExit");
    }

    //트리거 충돌: 힘이 가해지지 않는 논리적 충돌
    void OnTriggerEnter(Collider other) {
        //Debug.Log("OnTriggerEnter");
        if(other.tag == "Wall") {
            //탄알이 소멸되도록 한다.
            Destroy(gameObject, 0.1f);
        }
        else if(other.tag == "Player") {
            //Die()함수 호출
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null) {
                playerController.Die();
            }
            //탄알이 소멸되도록 한다.
            Destroy(gameObject, 0.1f);
        }
    }
    void OnTriggerStay(Collider other) {
        //Debug.Log("OnTriggerStay");
    }
    void OnTriggerExit(Collider other) {
       // Debug.Log("OnTriggerExit");
    }

    void Update()
    {
        
    }

    //Vector3의 축약된 표현
    //Vector3 forward = new Vector3(0f, 0f, 1f);
    //Vector3 back = new Vector3(0f, 0f, -1f);
    //Vector3 right = new Vector3(0f, 0f, 1f);
    //Vector3 left = new Vector3(0f, 0f, -1f);
    //Vector3 up = new Vector3(0f, 1f, 0f);
    //Vector3 down = new Vector3(0f, -1f, 0f);
}
