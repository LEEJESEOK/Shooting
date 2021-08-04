using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //�ӵ�
    public float speed = 4;
    //Ÿ��
    GameObject target;
    //����
    Vector3 dir;

    //����..
    public GameObject model1;
    public GameObject model2;
    public GameObject model3;
    public GameObject model4;

    //���߰���
    public GameObject exploFactory;

    int modelIdx;
    void Start()
    {
        //0, 1, 2, 3 �� ������ �������� ����
        modelIdx = Random.Range(0, 4);
        //���࿡ 0�̳����� model1 Ȱ��ȭ
        if(modelIdx == 0)
        {
            model1.SetActive(true);
        }
        //�׷��� �ʰ� 1�̸� model2 Ȱ��ȭ
        else if(modelIdx == 1)
        {
            model2.SetActive(true);
        }
        else if (modelIdx == 2)
        {
            model3.SetActive(true);
        }
        else if (modelIdx == 3)
        {
            model4.SetActive(true);
        }

        //0 ~ 9
        int rand = Random.Range(0, 10);

        //���࿡ rand�� 3���� ������
        if(rand < 3)
        {
            //������ �Ʒ���
            dir = Vector3.down;
        }
        //�׷��� ������
        else
        {
            //������ �÷��̾��
            //������ �÷��̾ ���ϰ�
            //0. Player�� ã��
            target = GameObject.Find("Player");

            //���࿡ target�� ���� null�� �ƴ϶��
            if(target != null)
            {
                //1. Ÿ��(Player)�� ���ϴ� ������ ���ϰ�
                dir = target.transform.position - transform.position;
                //dir�� ũ�⸦ 1�� �����(��ֶ�����, ����ȭ)
                dir.Normalize();
            }
        }
    }
    void Update()
    {
        //2. �� �������� �����̰� �ʹ�.
        transform.position += dir * speed * Time.deltaTime;
        //transform.Translate(dir * speed * Time.deltaTime);
    }

    //�������� (��������)�浹�Ҷ� ȣ��Ǵ� �Լ�
    private void OnCollisionEnter(Collision collision)
    {
        //���࿡ �ε������� Player���
        if(collision.gameObject.name.Contains("Player"))
        {
            //���ȭ������ �̵�
            SceneManager.LoadScene("ResultScene");
        }
        //�׷��� ������
        else
        {
            //���� �÷�����
            ChangeScore();
        }

        //����ȿ�� ��������
        CreateExploEffect();

        //1. �ε��� ���ӿ�����Ʈ �ı�
        Destroy(collision.gameObject);
        //2. ���� ���ӿ�����Ʈ �ı�
        Destroy(gameObject);
    }

    void ChangeScore()
    {
        ScoreManager.instance.AddScore(10 + modelIdx * 10);
        
        ////ScoreManger ���ӿ�����Ʈ�� ã��
        //GameObject smObj = GameObject.Find("ScoreManager");
        ////ã�� ���ӿ�����Ʈ���� ScoreM ������Ʈ�� ��������
        //ScoreM sm = smObj.GetComponent<ScoreM>();
        ////ã�� ������Ʈ�� ����� AddScore�� ����
        //sm.AddScore(10 + modelIdx * 10);
    }

    void CreateExploEffect()
    {
        //���߰��忡�� ����ȿ�� �����.
        GameObject explo = Instantiate(exploFactory);
        //������� ����ȿ���� Enemy(���ڽ�)�� ��ġ�� ���´�.
        explo.transform.position = transform.position;
        //������� ����ȿ������ ParticleSystem ������Ʈ�� �����´�.
        ParticleSystem ps = explo.GetComponent<ParticleSystem>();
        //������ ������Ʈ�� ����� Play�� ����
        ps.Play();
        //3���ִٰ� ����ȿ���� �ı�����
        Destroy(explo, 3);
    }


    //�������� (�������⵹�̾���)Ʈ���� �浹�϶� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        //0. ���࿡ �ε��� ���ӿ�����Ʈ�� �̸���
        //   DestroyZone�� �����ϰ� ����������
        if(other.gameObject.name.Contains("DestroyZone") == false)
        {
            //1. �ε��� ���ӿ�����Ʈ �ı�
            Destroy(other.gameObject);
        }
        //2. ���� ���ӿ�����Ʈ �ı�
        Destroy(gameObject);
    }
}
