using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwan : MonoBehaviour
{
    //Enemy공장
    public GameObject enemyFactory;
    //EnemyManager
    public GameObject enemyManager;

    //현재 흐르는 시간
    float currTime = 0;
    //생성시간
    public float createTime = 1;
    void Start()
    {
        createTime = Random.Range(1.0f, 3.0f);
    }
    void Update()
    {
        //만약에 GameManager의 상태가 2(플레이)라면
        if (GameManager.instance.IsPlaying() == false)
            return;

        //0. 현재 시간을 흐르게 한다
        currTime += Time.deltaTime;
        //1. 현재 흐르는 시간이 1초보다 커지면
        if (currTime > createTime)
        {
            //2. Enemy공장에서 Enemy를 만들고
            GameObject enemy = Instantiate(enemyFactory);
            //3. 만들어진 Enemy를 EnemyManager 위치에 놓는다.
            enemy.transform.position = enemyManager.transform.position;
            //4. 현재 흐르는 시간 초기화
            currTime = 0;
            //5. 생성시간을 랜덤한 값(1~3)으로 세팅한다.
            createTime = Random.Range(1.0f, 3.0f);
        }

    }
}
