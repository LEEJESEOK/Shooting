using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{

    // 최고점수 UI
    public Text bestScoreUI;
    public GameObject gameOver;

    void Start()
    {
        //최고점수 UI 갱신
        bestScoreUI.text = "최고점수 : " + ScoreManager.instance.bestScore;

        //GameOver Text 크기 0 -> 1
        iTween.ScaleTo(gameOver, iTween.Hash("x", 1, "y", 1, "z", 1, "time", 2, "easetype", iTween.EaseType.easeInOutBack));
        //최고점수 크기 0 -> 1
        iTween.ScaleTo(bestScoreUI.gameObject, iTween.Hash("x", 1, "y", 1, "z", 1, "time", 2, "easetype", iTween.EaseType.easeInOutBack));
        
    }

    public void OnClickRetry()
    {
        //GameScene으로 전환
        SceneManager.LoadScene("GameScene");
    }
}
