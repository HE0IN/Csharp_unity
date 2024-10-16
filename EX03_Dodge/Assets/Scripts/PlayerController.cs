using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRididbody;//�̵��� ����� ������ٵ� ������Ʈ
    public float speed = 8f; //�̵� �ӷ�
    public GameObject vfxBoom = null;  //���� ����Ʈ ������

    void Start(){
        playerRididbody = GetComponent<Rigidbody>();
    }

    void Update(){
        //������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal"); //-1.0 ~ 1.0
        float zInput = Input.GetAxis("Vertical"); //-1.0 ~ 1.0
        //Debug.Log("xInput:"+xInput+", zInput:"+zInput);

        //���� �̵��ӵ��� �Է°��� �̵� �ӵ��� ����� ����
        float xSpeed = xInput * speed; //-8f ~ 8f
        float zSpeed = zInput * speed; //-8f ~ 8f

        //Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3 (xSpeed, 0f, zSpeed);
        //Rigidbody�� �ӵ��� ����(������ �ӵ��� ����� ���ο� �ӵ��� ��� �ݿ�,��������)
        playerRididbody.velocity = newVelocity;  //�ӵ� = �Ÿ� / �ð�
    }
    public void Die() { //�浹�� ����Ǵ� �ڵ�

        //FindObjectOfType : ���� �����ϴ� GameManger Ÿ���� ������Ʈ�� ã�ƿ���
        GameManger gameManger = FindObjectOfType<GameManger>();
        if(gameManger != null) {
            if(gameManger.lifeCount == 1) { //������ �����̸�, ��������
                //�÷��̾� ���ӿ�����Ʈ ��Ȱ��ȭ
                gameObject.SetActive(false);
                gameManger.EndGame();
                //���� VFX ���
                Instantiate(vfxBoom, transform.position, transform.rotation );

                //���� ���
                SoundManager soundManager = FindObjectOfType<SoundManager>();
                if(soundManager != null) {
                    soundManager.PlaySound("explosion");
                }
            } else {
                gameManger.lifeCount -= 1;
            }
        }


        //gameObject : �����, �ڱ� ���ӿ�����Ʈ
        //transform : �����, �ڱ� Ʈ������ ������Ʈ
        //������ ������Ʈ���� ��� �� public link�� GetComponent�� ���� �����´�.
        //playerRididbody = gameObject.GetComponent<Rigidbody>();
        //CapsuleCollider colider = gameObject.GetComponent<CapsuleCollider>();
        //PlayerController script = gameObject.GetComponent<PlayerController>();
    }
}
