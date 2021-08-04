using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public Text bestScoreUI;

    void Start()
    {
        bestScoreUI.text = "최고점수 : " + ScoreManager.instance.bestScore;
    }

    public void OnClickRetry()
    {
        //GameScene���� ��ȯ
        SceneManager.LoadScene("GameScene");
    }
}
