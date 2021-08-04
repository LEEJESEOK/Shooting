using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //�Ѿ˰���
    public GameObject bulletFactory;

    //�ѱ�
    public GameObject firePos;
    public GameObject firePos2;

    //����ð�
    float currTime;
    //�߻�ð�
    public float fireTime = 1;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.instance.state != 2)
            return;

        //1. ����ڰ� ���콺 ���ʹ�ư(����Ctrl) �� ������
        if (Input.GetButton("Fire1"))
        {
            //�ð��� �帣�� �Ѵ�.
            currTime += Time.deltaTime;
            //���࿡ �����帣�½ð��� �߻�ð����� Ŀ����
            if (currTime > fireTime)
            {
                //�Ѿ��� �����.
                CreateBullet();
                //����ð��� �ʱ�ȭ
                currTime = 0;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            CreateBullet();
        }
    }

    void CreateBullet()
    {
        //2. �Ѿ˰���(Prefab)���� �Ѿ��� �����.
        GameObject bullet = Instantiate(bulletFactory);
        // ������� �Ѿ��� �ѱ��� ���´�.
        bullet.transform.position = firePos.transform.position;

        GameObject bullet2 = Instantiate(bulletFactory);
        bullet2.transform.position = firePos2.transform.position;

        //�ڽ����� �پ��ִ� AudioSource ������Ʈ ��������
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        //������ ������Ʈ�� ����� Play�� ����� ����
        audio.Play();
    }
}
