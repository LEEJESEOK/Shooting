using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //총알공장
    public GameObject bulletFactory;

    // 총구
    public GameObject firePos;
    public GameObject firePos2;

    //현재시간
    float currTime;
    //발사시간
    public float fireTime = 1;

    public int[] numbers = new int[10];


    void Start()
    {
        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = (i + 1) * 10;

    }

    void Shuffle()
    {
            for (int i = 0; i < 100; i++)
            {
                int a = Random.Range(0, numbers.Length);
                int b = Random.Range(0, numbers.Length);
                while (a == b)
                    b = Random.Range(0, numbers.Length);

                swapNumbers(a, b);
            }
    }

    void swapNumbers(int idx1, int idx2)
    {
        int temp = numbers[idx1];
        numbers[idx1] = numbers[idx2];
        numbers[idx2] = temp;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Shuffle();
        }

        if (GameManager.instance.state != (int)GameManager.GAMESTATE.PLAYING)
            return;

        currTime += Time.deltaTime;

        //1. 만약에 사용자가 마우스왼쪽(왼쪽 Ctrl)버튼을 누르면
        if (Input.GetButton("Fire1"))
        {
            //시간을 흐르게 한다
            //만약에 현재 흐르는 시간이 발사시간보다 커지면
            if (currTime > fireTime)
            {
                //총알을 만든다.
                CreateBullet();
                //현재시간을 초기화
                currTime = 0;
            }
        }

        // if (Input.GetButton("Fire1"))
        // {
        //     CreateBullet();
        // }
    }

    void CreateBullet()
    {
        //2. 총알공장(Prefab)에서 총알을 만든다
        GameObject bullet = Instantiate(bulletFactory);
        //만들어진 총알을 총구에 놓는다.
        bullet.transform.position = firePos.transform.position;

        GameObject bullet2 = Instantiate(bulletFactory);
        bullet2.transform.position = firePos2.transform.position;

        //자신한테 붙어있는 AudioSource 컴포넌트 가져오기
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        //가져온 컴포넌트의 기능 중 Play 기능을 실행
        audio.Play();
    }
}
