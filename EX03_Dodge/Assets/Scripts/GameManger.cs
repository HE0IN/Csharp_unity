using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//실습 연습문제9 - 닷지게임 향상
//1. 적군(스판너) : ~5초까지는 1개 설치
//   ~10초까지는 2개, ~15초 3개, ~20초이상은 4개
//2. Life Count시스템
//   라이프카운트 : 3개로 설정
//   Unity UI : 왼쪽 위에 "Life:3" Text로 표현하기
//   총알에 맞을 때는 Life Count -1 까기, 0이 되면 종료
//3. 랜덤 위치에 5초마다 노란색 큐브 아이템을 드랍한다.
//   아이템을 먹으면, Life Count +1한다.

public class GameManger : MonoBehaviour
{
    public GameObject gameoverText; //활성화/비활성화 제어
    public Text timeText; //Text 컴포넌트 링크
    public Text recordText;
    public Text lifeText;

    public GameObject bulletSpawner1;
    public GameObject bulletSpawner2;
    public GameObject bulletSpawner3;
    public GameObject bulletSpawner4;

    private float surviveTime; //생존시간
    private bool isGameover; //게임오버 상태
    public int lifeCount = 3;

    void Start()
    {
        //초기화
        surviveTime = 0f;
        isGameover = false;
        lifeCount = 3;
        //게임 오버 텍스트를 비활성화
        gameoverText.SetActive(false);
        //적군 비활성화
        bulletSpawner2.SetActive(false);
        bulletSpawner3.SetActive(false);
        bulletSpawner4.SetActive(false);
        //게임시작 사운드 재생
        SoundManager soundManager = FindObjectOfType<SoundManager>();
        if(soundManager != null) {
            soundManager.PlaySound("game_start");
        }
        //배경음악 재생
        BGManager bgManager = FindObjectOfType<BGManager>();
        if(bgManager != null) {
            bgManager.playStart();
        }
    }

    public void EndGame() {
        //게임 종료 상태로 설정
        isGameover = true;
        //게임 오버 텍스트를 활성화
        gameoverText.SetActive(true);
        //배경음악 중지
        BGManager bgManager = FindObjectOfType<BGManager>();
        if(bgManager != null) {
            bgManager.playEnd();
        }
        //게임종료 사운드 재생
        SoundManager soundManager = FindObjectOfType<SoundManager>();
        if(soundManager != null) {
            soundManager.PlaySound("game_end");
        }

        //저장된 최고기록을 파일에서 가져오기
        float bestTime = PlayerPrefs.GetFloat("BestTime"); //기본값은 0
        if(surviveTime > bestTime) { //최고기록 갱신
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", surviveTime); //생존시간을 최고기록으로 저장
        }
        recordText.text = "Best Time:" + Mathf.Round(bestTime);
    }

    void Update() //매 페이임마다 호출됨. 0.033초마다
    {
        if(!isGameover) { //게임오버 상태가 아니라면
            //생존시간 갱신
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
            lifeText.text = "Life: " + lifeCount;

            //생존시간 5초이상
            if(surviveTime > 5.0f ) {
                bulletSpawner2.SetActive(true);
            }
            if(surviveTime > 10.0f) {
                bulletSpawner3.SetActive(true);
            }
            if(surviveTime > 15.0f) {
                bulletSpawner4.SetActive(true);
            }

        } else {
            //게임오버 상태라면
            if(Input.GetKeyDown(KeyCode.R)) {
                //SampleScene을 다시 로딩(불러오기)한다.
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
