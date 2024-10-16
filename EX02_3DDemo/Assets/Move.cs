using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    void Start() {
        //transform : 자신의 transform 콤퍼넌트
        //gameObject : 자신의 GameObject 객체
        Debug.Log("transform:" + transform.position); //(0,4,0)

        //transform.position = new Vector3(10, 4, 0); //x좌표 10으로 이동
    }

    void Update() {
        //순차적인 이동
        //Time.deltaTime : FPS에 한 프레임의 시간
        //                30 FPS이면 0.033ms 값이다.
        //                60 FPS이면 0.016ms 
        //게임마다 Frame Rate이 다르더라도, 일정한 수치만큼 값을 줄 수가 있다.
        //                     방향                     크기
        //transform.Translate( new Vector3(1, 0, 0) * Time.deltaTime );
        // 오일러 각 회전 : 한번에 한 축에 대해서만 회전 가능
        //transform.Rotate( new Vector3( 10, 0, 0 ) * Time.deltaTime );
        // 여러축으로 일시에 회전하려면 퀀터니언 Vector4를 사용해야 한다.
        // 짐벌락 현상 발생

        //퀀터니언 각 회전
        //  오일러 각(3차원)을 퀀터니언 각(4차원)으로 변환 함수
        //transform.rotation = Quaternion.Euler(45 * Time.deltaTime, 45 * Time.deltaTime, 0)
        //                        * transform.rotation;

        //키보드 입력에 따른 게임오브젝트 이동
        if (Input.GetKey(KeyCode.LeftArrow)) {//-X 방향
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) { //+X 방향
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow)) { //+Y 방향
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
            // z축 중심으로 1초에 180도 회전
            transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)) { //-Y 방향
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
            // z축 중심으로 1초에 -180도 회전
            transform.Rotate(new Vector3(0, 0, -180) * Time.deltaTime);
        }
    }
}