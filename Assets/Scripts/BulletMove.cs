using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    //속도
    public float speed = 7;
    void Start()
    {
        
    }

    void Update()
    {
        //계속 위로 올라가게 하고 싶다.
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
