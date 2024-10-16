using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Ex : MonoBehaviour {
    void Start() {
        //벡터(Vector) : 크기와 방향을 가진 수학적인 수식
        //유니티에서 지원하는 벡터들
        Vector2 v2 = new Vector2(10, 20); //x,y 좌표의 2차원 벡터
        Vector3 v3 = new Vector3(10, 20, 30); //x,y,z 좌표의 3차원 벡터
        Vector4 v4 = new Vector4(10, 20, 30, 40); //x,y,z,w 좌표의 4차원 벡터(퀀터니언 회전)

        Vector3 a = new Vector3(3, 6, 9);
        //벡터의 곱
        a = a * 10; //(30,60,90)
        Debug.Log("벡터의 곱:" + a);
        //벡터의 덧셈과 뺄셈
        Vector3 b = new Vector3(2, 4, 8);
        Vector3 c = new Vector3(3, 6, 9);
        Debug.Log("벡터의 덧셈:" + (b + c)); //(5, 10, 17)
        Debug.Log("벡터의 뺄셈:" + (b - c)); //(-1, -2, -1)
        //벡터의 정규화(normal vector) : 최대 길이가 1인 벡터(0.0 ~ 1.0)
        //방향성만 가진 벡터를 구할 때 사용.
        Vector3 d = new Vector3(3, 3, 3);
        Debug.Log("벡터의 정규화(노멀벡터):" + d.normalized);
        //벡터의 크기(길이)
        Debug.Log("벡터의 크기(길이):" + d.magnitude);
        //벡터의 내적 : 두 벡터사이의 각도를 구할 때
        Vector3 a2 = new Vector3(0, 1, 0);
        Vector3 b2 = new Vector3(1, 0, 0);
        float c2 = Vector3.Dot(a2, b2); //내적은 0
        Debug.Log("벡터의 내적:" + c2);
        //벡터의 외적 : 평면의 직각으로 교차하는 벡터를 구할 때
        Vector3 d2 = Vector3.Cross(a2, b2);//벡터의 외적:(0.00, 0.00, -1.00)
        Debug.Log("벡터의 외적:" + d2);
    }

}
// 구조체 : Vector3는 구조체로 만들어져 있음.
struct Vector3Sample {
    public float x;
    public float y;
    public float z;
}
// 구조체는 변수로만 구성됨.
// 클래스는 변수 + 함수로 구성됨.