using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 30f;

    void Update()
    {
        //�޼ҵ� �����ε�(�޼ҵ��̸��� �����ϰ� ����ϰ�, �Ű������� ������ Ÿ���� �ٸ�����)
        //�޼ҵ� �������̵�(�θ�Ŭ������ �޼ҵ带 �ڽ�Ŭ�������� ��������)
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
