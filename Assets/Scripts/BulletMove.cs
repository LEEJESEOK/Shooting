using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //�ӵ�
    public float speed = 7;
    void Start()
    {
        
    }

    void Update()
    {
        //��� ���� �ö󰡰� �ϰ� �ʹ�.
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
