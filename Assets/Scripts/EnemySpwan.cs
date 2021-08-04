using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwan : MonoBehaviour
{
    //Enemy����
    public GameObject enemyFactory;
    //EnemyManager
    public GameObject enemyManager;
    
    //�����帣�½ð�
    float currTime = 0;
    //�����ð�
    public float createTime = 1;
    void Start()
    {
        createTime = Random.Range(1.0f, 3.0f);
    }
    void Update()
    {
        //���࿡ GameManager�� ���°� 2(�÷���)���
        if(GameManager.instance.state == 2)
        {
            //0. ����ð��� �帮���Ѵ�.        
            currTime += Time.deltaTime;
            //1. �����帣�½ð��� 1�ʺ��� Ŀ����
            if (currTime > createTime)
            {
                //2. Enemy���忡�� Enemy�� �����
                GameObject enemy = Instantiate(enemyFactory);
                //3. ������� Eneny�� EnemyManager��ġ�� ���´�.
                enemy.transform.position = enemyManager.transform.position;
                //4. �����帣�½ð� �ʱ�ȭ
                currTime = 0;
                //5. �����ð��� �����Ѱ�(1~3)���� �����Ѵ�
                createTime = Random.Range(1.0f, 3.0f);
            }
        }
    }
}
