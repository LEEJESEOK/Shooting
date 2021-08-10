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
    public GameObject btnRetry;

    void Start()
    {
        //최고점수 UI 갱신
        bestScoreUI.text = "최고점수 : " + ScoreManager.instance.bestScore;

        //GameOver Text 크기 0 -> 1
        iTween.MoveTo(gameOver, iTween.Hash("x", Screen.width, "time", .5f, "easetype", iTween.EaseType.easeOutBack));
        iTween.MoveTo(gameOver, iTween.Hash("x", Screen.width * .5f, "time", .5f, "easetype", iTween.EaseType.easeOutBack, "delay", .5f));
        iTween.ScaleTo(gameOver, iTween.Hash("x", 1.5f, "y", 1.5f, "z", 1.5f, "time", .5f, "easetype", iTween.EaseType.easeOutQuart, "delay", 1.5f));
        iTween.ScaleTo(gameOver, iTween.Hash("x", 1, "y", 1, "z", 1, "time", .5f, "easetype", iTween.EaseType.easeOutQuart, "delay", 2f, "oncompletetarget", gameObject, "oncomplete", "OnCompleteAni"));
        //버튼 크기 0 -> 1
        iTween.ScaleTo(btnRetry, iTween.Hash("x", 1, "y", 1, "z", 1, "time", .5f, "easetype", iTween.EaseType.easeOutBounce, "delay", 2.5f));

        SoundManager.instance.PlayBGM(SoundManager.BGM_SOUND_TYPE.BGM_RESULT);
    }

    public void OnClickRetry()
    {
        //GameScene으로 전환
        SceneManager.LoadScene("GameScene");
    }

    void OnCompleteAni()
    {
        //최고점수 크기 0 -> 1
        iTween.ScaleTo(bestScoreUI.gameObject, iTween.Hash("x", 1, "y", 1, "z", 1, "time", .5f, "easetype", iTween.EaseType.easeOutBounce));
    }
}
