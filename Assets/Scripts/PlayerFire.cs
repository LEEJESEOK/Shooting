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
    float currTime = 0;
    //발사시간
    public float fireTime = 1;

    public int[] numbers = new int[10];

    public GameObject[] magazine;
    public List<GameObject> listMagazine;
    public List<GameObject> listMagazineActive;

    public List<int> listNum = new List<int>();

    void Start()
    {
        // for (int i = 0; i < numbers.Length; i++)
        //     numbers[i] = (i + 1) * 10;

        // listNum.Add(10);
        // listNum.Add(20);
        // listNum.Add(30);


        // magazine = new GameObject[20];
        // for (int i = 0; i < magazine.Length; i++)
        // {
        //     magazine[i] = Instantiate(bulletFactory);
        //     magazine[i].SetActive(false);
        // }

        listMagazine = new List<GameObject>();
        for (int i = 0; i < 20; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            listMagazine.Add(bullet);
            listMagazine[i].SetActive(false);
        }
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

    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        listMagazine.Add(bullet);
        listMagazineActive.Remove(bullet);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //     Shuffle();

            int rand = Random.Range(0, 100);
            listNum.Add(rand);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
            listNum.RemoveAt(0);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            listNum.Clear();


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

    void FireBullet(Vector3 pos)
    {
        #region array
        // for (int i = 0; i < magazine.Length; i++)
        // {
        //     if (magazine[i].activeSelf == false)
        //     {
        //         magazine[i].SetActive(true);
        //         magazine[i].transform.position = pos;
        //         break;
        //     }
        // }        
        #endregion

        #region list foreach
        foreach (GameObject bullet in listMagazine)
        {
            if (bullet.activeSelf == false)
            {
                bullet.SetActive(true);
                bullet.transform.position = pos;
                break;
            }
        }
        #endregion


        listMagazine[0].transform.position = pos;
        listMagazineActive.Add(listMagazine[0]);
        listMagazine.RemoveAt(0);

    }

    void CreateBullet()
    {
        #region 총알발사1
        // //2. 총알공장(Prefab)에서 총알을 만든다
        // GameObject bullet = Instantiate(bulletFactory);
        // //만들어진 총알을 총구에 놓는다.
        // bullet.transform.position = firePos.transform.position;

        // GameObject bullet2 = Instantiate(bulletFactory);
        // bullet2.transform.position = firePos2.transform.position;
        #endregion

        FireBullet(firePos.transform.position);
        FireBullet(firePos2.transform.position);

        // //자신한테 붙어있는 AudioSource 컴포넌트 가져오기
        // AudioSource audio = gameObject.GetComponent<AudioSource>();
        // //가져온 컴포넌트의 기능 중 Play 기능을 실행
        // audio.Play();

        SoundManager.instance.PlayEFT(SoundManager.EFT_SOUND_TYPE.EFT_BULLET);
    }
}
