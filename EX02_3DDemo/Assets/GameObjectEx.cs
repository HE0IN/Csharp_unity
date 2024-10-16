using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectEx : MonoBehaviour {
    //Start()함수 이전에 초기화 코드가 필요할때 사용.
    void Awake() {
        Debug.Log("Awake Called.");
    }
    //Update()함수가 호출된 후에 호출됨(후처리-카메라 Fellow)
    void LateUpdate() {
        // Debug.Log("LateUpdate Called.");
    }

    //스크립트 시작시 한번만 호출
    void Start() {
        Debug.Log("Hello Unity!");
    }

    int count = 0;

    //매 프레임마다 호출 ex)30fps  1초에 30번 호출됨.
    // 1000ms / 30 = 0.033초마다 한번 호출
    //주의! 시간이 오래걸리는 코드를 넣으면 속도가 느려짐!
    void Update() {
        //Debug.Log("Update Count:" + this.count++);
    }
}