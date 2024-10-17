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
        //������ٵ��� �ӵ��� = ���� ���� * �̵� �ӷ� 
        //transform.up Y+����
        bulletRigidbody.velocity = transform.up * speed;
    }
    
    //Ʈ���� �浹: ���� �������� �ʴ� ���� �浹
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Wall") {
            //ź���� �Ҹ�ǵ��� �Ѵ�.
            Destroy(gameObject, 0.1f);
        }
        else if(other.tag == "Enemy") {
            //Die()�Լ� ȣ��
            BulletSpawner bulletSpawner = other.GetComponent<BulletSpawner>();
            if(bulletSpawner != null) {
                bulletSpawner.Die();
            }

            //ź���� �Ҹ�ǵ��� �Ѵ�.
            Destroy(gameObject, 0.1f);
        }
    }
}
