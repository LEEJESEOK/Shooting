using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    //현재점수
    public int currScore;   

    //최고저무
    public int bestScore;   

    void Awake()
    { 
        if(instance == null)
        {
            instance = this;

            //최고점수를 불러온다.
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
        //가져온 컴포넌트의 currScore값을 증가시키자
        currScore += addValue;

        //현재점수 UI 갱신
        GameManager.instance.UpdateCurrScore(currScore);

        //만약에 현재점수가 최고점수보다 커지면
        if(currScore > bestScore)
        {
            //최고점수를 현재점수로 갱신
            bestScore = currScore;
            //최고점수 UI도 갱신
            GameManager.instance.UpdateBestScore(bestScore);
            //최고점수를 저장한다.
            PlayerPrefs.SetInt("best_score", bestScore);
        }
    }
}
