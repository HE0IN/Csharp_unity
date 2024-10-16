using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        // 두 점 사이의 거리 구하기
        float distance = GetDistance(2, 2, 5, 5);
        Debug.Log(distance);
    }

    //피타고라스의 정리에 의해 두점의 거리를 구한다.
    float GetDistance(float x1, float y1, float x2, float y2) {
        float x_delta = x1 - x2;
        float y_delta = y1 - y2;
        float distance = Mathf.Sqrt(x_delta * x_delta + y_delta * y_delta);
        return distance;
    }

}
