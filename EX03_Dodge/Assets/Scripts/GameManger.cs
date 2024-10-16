using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//�ǽ� ��������9 - �������� ���
//1. ����(���ǳ�) : ~5�ʱ����� 1�� ��ġ
//   ~10�ʱ����� 2��, ~15�� 3��, ~20���̻��� 4��
//2. Life Count�ý���
//   ������ī��Ʈ : 3���� ����
//   Unity UI : ���� ���� "Life:3" Text�� ǥ���ϱ�
//   �Ѿ˿� ���� ���� Life Count -1 ���, 0�� �Ǹ� ����
//3. ���� ��ġ�� 5�ʸ��� ����� ť�� �������� ����Ѵ�.
//   �������� ������, Life Count +1�Ѵ�.

public class GameManger : MonoBehaviour
{
    public GameObject gameoverText; //Ȱ��ȭ/��Ȱ��ȭ ����
    public Text timeText; //Text ������Ʈ ��ũ
    public Text recordText;
    public Text lifeText;

    public GameObject bulletSpawner1;
    public GameObject bulletSpawner2;
    public GameObject bulletSpawner3;
    public GameObject bulletSpawner4;

    private float surviveTime; //�����ð�
    private bool isGameover; //���ӿ��� ����
    public int lifeCount = 3;

    void Start()
    {
        //�ʱ�ȭ
        surviveTime = 0f;
        isGameover = false;
        lifeCount = 3;
        //���� ���� �ؽ�Ʈ�� ��Ȱ��ȭ
        gameoverText.SetActive(false);
        //���� ��Ȱ��ȭ
        bulletSpawner2.SetActive(false);
        bulletSpawner3.SetActive(false);
        bulletSpawner4.SetActive(false);
        //���ӽ��� ���� ���
        SoundManager soundManager = FindObjectOfType<SoundManager>();
        if(soundManager != null) {
            soundManager.PlaySound("game_start");
        }
        //������� ���
        BGManager bgManager = FindObjectOfType<BGManager>();
        if(bgManager != null) {
            bgManager.playStart();
        }
    }

    public void EndGame() {
        //���� ���� ���·� ����
        isGameover = true;
        //���� ���� �ؽ�Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);
        //������� ����
        BGManager bgManager = FindObjectOfType<BGManager>();
        if(bgManager != null) {
            bgManager.playEnd();
        }
        //�������� ���� ���
        SoundManager soundManager = FindObjectOfType<SoundManager>();
        if(soundManager != null) {
            soundManager.PlaySound("game_end");
        }

        //����� �ְ����� ���Ͽ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime"); //�⺻���� 0
        if(surviveTime > bestTime) { //�ְ��� ����
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", surviveTime); //�����ð��� �ְ������� ����
        }
        recordText.text = "Best Time:" + Mathf.Round(bestTime);
    }

    void Update() //�� �����Ӹ��� ȣ���. 0.033�ʸ���
    {
        if(!isGameover) { //���ӿ��� ���°� �ƴ϶��
            //�����ð� ����
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int)surviveTime;
            lifeText.text = "Life: " + lifeCount;

            //�����ð� 5���̻�
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
            //���ӿ��� ���¶��
            if(Input.GetKeyDown(KeyCode.R)) {
                //SampleScene�� �ٽ� �ε�(�ҷ�����)�Ѵ�.
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
