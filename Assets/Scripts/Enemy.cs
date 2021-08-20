using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //속도
    public float speed = 4;
    //타겟
    GameObject target;
    //방향
    Vector3 dir;

    //모양들...
    // public GameObject model1;
    // public GameObject model2;
    // public GameObject model3;
    // public GameObject model4;
    public GameObject[] models = new GameObject[4];

    //폭발공장
    public GameObject exploFactory;

    int modelIdx;

    float currHP;
    public float maxHP;
    public Image hpUI;


    void Start()
    {
        //0, 1, 2, 3 이 나오는 랜덤값을 뽑자
        modelIdx = Random.Range(0, models.Length);
        // //만약에 0이 나오면 model1 활성화
        // if(modelIdx == 0)
        // {
        //     model1.SetActive(true);
        // }
        // //그렇지 않고 1이 나오면 model2 활성화
        // else if(modelIdx == 1)
        // {
        //     model2.SetActive(true);
        // }
        // else if (modelIdx == 2)
        // {
        //     model3.SetActive(true);
        // }
        // else if (modelIdx == 3)
        // {
        //     model4.SetActive(true);
        // }
        models[modelIdx].SetActive(true);
        maxHP = modelIdx * 20 + 20;
        currHP = maxHP;

        //0 ~ 9
        int rand = Random.Range(0, 10);

        //만약에 rand가 3보다 작으면
        if (rand < 3)
        {
            //방향을 아래로
            dir = Vector3.down;
        }
        //그렇지 않으면
        else
        {
            //방향을 플레이어로
            //방향을 플레이어를 향하게
            //0. Player를 찾자
            target = GameObject.Find("Player");

            //만약에 target의 값이 null이 아니라면
            if (target != null)
            {
                //1. 타겟(target)을 향하는 방향을 구하고
                dir = target.transform.position - transform.position;
                //dir의 크기를 1로 만든다.(정규화)
                dir.Normalize();
            }
        }
    }
    void Update()
    {
        //2. 그 방향으로 움직이고 싶다.
        transform.position += dir * speed * Time.deltaTime;
        //transform.Translate(dir * speed * Time.deltaTime);
    }

    //누군가와 (물리적인)충돌할 때 호출되는 함수
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet"))
        {
            currHP -= 20;
            hpUI.fillAmount = currHP / maxHP;
            if (currHP <= 0)
            {
                //점수 올려주자
                ChangeScore();
            }


            GameObject player = GameObject.Find("Player");
            PlayerFire pf = player.GetComponent<PlayerFire>();
            pf.ResetBullet(collision.gameObject);
        }

        //폭발효과 보여주자
        CreateExploEffect();

        if(collision.gameObject.name.Contains("Player"))
            Destroy(gameObject);

        // //1. 부딪힌 게임 오브젝트 파괴
        // Destroy(collision.gameObject);
        //2. 나의 게임 오브젝트 파괴
        if (currHP <= 0)
            Destroy(gameObject);

    }

    void ChangeScore()
    {
        ScoreManager.instance.AddScore(10 + modelIdx * 10);

        ////ScoreManger 게임 오브젝트를 찾자
        //GameObject smObj = GameObject.Find("ScoreManager");
        ////찾은 게임 오브젝트에서 ScoreM 컴포넌트를 가져오자
        //ScoreM sm = smObj.GetComponent<ScoreM>();
        ////찾은 컴포넌트의 기능 중 AddScore를 실행
        //sm.AddScore(10 + modelIdx * 10);
    }

    void CreateExploEffect()
    {
        //폭발공장에서 폭발효과 만든다.
        GameObject explo = Instantiate(exploFactory);
        //만들어진 폭발 효과를 enemy(나 자신)의 위치에 놓는다.
        explo.transform.position = transform.position;
        //만들어진 폭발효과에서 ParticleSystem 컴포넌트를 가져온다.
        ParticleSystem ps = explo.GetComponent<ParticleSystem>();
        //가져온 컴포넌트의 기능 중 Play를 실행
        ps.Play();
        //3초 있다가 폭발효과를 파괴하자
        Destroy(explo, 3);
    }


    //누군가와 (물리적 충돌이 없는)트리거 충돌일 때 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        //0. 만약에 부딪힌 게임 오브젝트의 이름이
        //   DestroyZone을 포함하고 있지 않으면
        if (other.gameObject.name.Contains("DestroyZone") == false)
        {
            //1. 부딪힌 게임 오브젝트 파괴
            Destroy(other.gameObject);
        }
        //2. 나의 게임 오브젝트 파괴
        Destroy(gameObject);
    }
}
