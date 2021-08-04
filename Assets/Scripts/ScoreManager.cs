using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    //��������
    public int currScore;   

    //�ְ�����
    public int bestScore;   

    void Awake()
    { 
        if(instance == null)
        {
            instance = this;

            //�ְ������� �ҷ��´�.
            bestScore = PlayerPrefs.GetInt("best_score");

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddScore(int addValue)
    {
        //������ ������Ʈ�� currSocre ���� ������Ű��
        currScore += addValue;

        //�������� UI ����
        GameManager.instance.UpdateCurrScore(currScore);

        //���࿡ ���������� �ְ��������� Ŀ����
        if(currScore > bestScore)
        {
            //�ְ������� ���������� ����
            bestScore = currScore;
            //�ְ����� UI�� ����
            GameManager.instance.UpdateBestScore(bestScore);
            //�ְ������� �����Ѵ�
            PlayerPrefs.SetInt("best_score", bestScore);
        }
    }
}
