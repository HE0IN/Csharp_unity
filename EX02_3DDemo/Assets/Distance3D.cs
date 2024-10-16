using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance3D : MonoBehaviour {
    private GameObject object1; //ù��° ���� ������Ʈ
    private GameObject object2; //�ι�° ���� ������Ʈ

    void Start() {
        //������ ���ӿ�����Ʈ �̸����� ���ӿ�����Ʈ ã��
        object1 = GameObject.Find("Cube1");
        object2 = GameObject.Find("Cube2");

        if (object1 != null && object2 != null) {
            //���ӿ�����Ʈ1 ��ġ:(0.00, 4.00, 0.00)
            Debug.Log("���ӿ�����Ʈ1 ��ġ:" + object1.transform.position); //Vector3 Ÿ��
            Debug.Log("���ӿ�����Ʈ2 ��ġ:" + object2.transform.position);
        } else {
            Debug.Log("null �Դϴ�.");
        }

        //���ӿ�����Ʈ ���� �Ÿ�
        Vector3 pos1 = object1.transform.position;
        Vector3 pos2 = object2.transform.position;
        Vector3 delta1 = pos1 - pos2;
        float distance = delta1.magnitude;
        Debug.Log("�� ���ӿ�����Ʈ ���� �Ÿ�: " + distance);//�� ���ӿ�����Ʈ ���� �Ÿ�: 10

        float distance2 = Vector3.Distance(pos1, pos2);
        Debug.Log("�� ���ӿ�����Ʈ ���� �Ÿ�: " + distance2);

        //�� ���ͻ����� ����� �̵��Ÿ� ���ϱ�
        Vector3 currentPos = new Vector3(1, 0, 1);
        Vector3 destPos = new Vector3(5, 3, 5);
        //���⺤��
        Vector3 direction = (destPos - currentPos).normalized; //���Ժ���(����1) ���⼺
        //�������� ���� 10��ŭ ���� ��ġ���� �̵��ϱ�
        Vector3 newPos = currentPos + direction * 10;

    }//Start()

}