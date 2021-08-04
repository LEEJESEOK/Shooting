using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    //����ð�
    float currTime;
    //�ı��ð�
    public float destroyTime = 3;
    void Start()
    {
        
    }

    void Update()
    {
        //����ð��� �帣��
        currTime += Time.deltaTime;
        //�����帣�½ð��� �ı��ð����� Ŀ����
        if(currTime > destroyTime)
        {
            //���� �ı��ض�
            Destroy(gameObject);
        }
    }
}
