using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GAMESTATE
    {
        READY,
        START,
        PLAYING
    }

    public static GameManager instance;

    // 0: ready
    // 1: start
    // 2: play
    // 3: exit
    public int state;

    float delayTime = 4;
    public Text readyText;

    public GameObject currScoreUI;
    public Text bestScoreText;

    private float currTime = 0f;



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // for (int i = 2; i < 10; i++)
        //     for (int j = 1; j < 10; j++)
        //         print(i + " * " + j + " = " + i * j);

        // for(int j = 0; j < 3; j++)
        //     for(int i = 0; i < 3; i++)

        // 임의 좌표의 구역 찾기(3, 3)
        // int x = 150, y = 250;

        // int posX = x / 100;
        // int offsetX = x % 100;
        // int posY = y / 100;
        // int offsetY = y % 100;

        // print("x, y(" + x + ", " + y + ") : " + (posX + (3 * posY))) ;


        state = (int)GAMESTATE.READY;

        ScoreManager.instance.currScore = 0;
        UpdateBestScore(ScoreManager.instance.bestScore);

        SoundManager.instance.PlayBGM(SoundManager.BGM_SOUND_TYPE.BGM_INGAME);
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;

        switch (state)
        {
            case (int)GAMESTATE.READY:

                delayTime -= Time.deltaTime;
                int remainTime = (int)delayTime;

                readyText.text = remainTime.ToString();

                if (currTime > 3)
                {
                    state = (int)GAMESTATE.START;
                    readyText.text = "Start!";

                    currTime = 0;
                }
                break;

            case (int)GAMESTATE.START:
                if (currTime > 1)
                {
                    state = (int)GAMESTATE.PLAYING;
                    readyText.gameObject.SetActive(false);

                    currTime = 0;
                }

                break;

            case 2:
                break;

            case 3:
                break;
        }
    }


    public void UpdateCurrScore(int currScore)
    {
        Text currSocreText = currScoreUI.GetComponent<Text>();
        currSocreText.text = "점수 : " + currScore;
    }

    public void UpdateBestScore(int bestScore)
    {
        bestScoreText.text = "최고점수 : " + bestScore;
    }

    public bool IsPlaying()
    {
        return state == (int)GAMESTATE.PLAYING;
    }
}