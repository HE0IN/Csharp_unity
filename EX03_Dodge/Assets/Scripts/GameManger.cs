using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject gameoverText; //활성화/비활성화 제어
    public Text timeText; //Text 컴포넌트 링크
    public Text recordText;

    private float surviveTime; //생존시간
    private bool isGameover; //게임오버 상태

    void Start()
    {
        //초기화
        surviveTime = 0f;
        isGameover = false;
        //게임 오버 텍스트를 비활성화
        gameoverText.SetActive(false);
    }

    public void EndGame() {
        //게임 종료 상태로 설정
        isGameover = true;
        //게임 오버 텍스트를 활성화
        gameoverText.SetActive(true);

        //저장된 최고기록을 파일에서 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime"); //기본값은 0
        if(surviveTime > bestTime) { //최고기록 갱신
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", surviveTime); //생존시간을 최고기록으로 저장
        }
        recordText.text = "Best Time:" + Mathf.Round(bestTime);
    }

    void Update()
    {
        if(!isGameover) { //게임오버 상태가 아니라면
            //생존시간 갱신
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        } else {
            //게임오버 상태라면
            if(Input.GetKeyDown(KeyCode.R)) {
                //SampleScene을 다시 로딩(불러오기)한다.
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
