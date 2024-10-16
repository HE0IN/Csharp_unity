using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public GameObject gameoverText; //Ȱ��ȭ/��Ȱ��ȭ ����
    public Text timeText; //Text ������Ʈ ��ũ
    public Text recordText;

    private float surviveTime; //�����ð�
    private bool isGameover; //���ӿ��� ����

    void Start()
    {
        //�ʱ�ȭ
        surviveTime = 0f;
        isGameover = false;
        //���� ���� �ؽ�Ʈ�� ��Ȱ��ȭ
        gameoverText.SetActive(false);
    }

    public void EndGame() {
        //���� ���� ���·� ����
        isGameover = true;
        //���� ���� �ؽ�Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        //����� �ְ����� ���Ͽ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime"); //�⺻���� 0
        if(surviveTime > bestTime) { //�ְ��� ����
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", surviveTime); //�����ð��� �ְ������� ����
        }
        recordText.text = "Best Time:" + Mathf.Round(bestTime);
    }

    void Update()
    {
        if(!isGameover) { //���ӿ��� ���°� �ƴ϶��
            //�����ð� ����
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
        } else {
            //���ӿ��� ���¶��
            if(Input.GetKeyDown(KeyCode.R)) {
                //SampleScene�� �ٽ� �ε�(�ҷ�����)�Ѵ�.
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
