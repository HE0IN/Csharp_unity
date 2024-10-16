using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 30f;

    void Update()
    {
        //메소드 오버로딩(메소드이름을 동일하게 사용하고, 매개변수의 개수와 타입을 다르게함)
        //메소드 오버라이딩(부모클래스의 메소드를 자식클래스에서 재정의함)
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
