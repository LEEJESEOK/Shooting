using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    //현재시간
    float currTime;
    //파괴시간
    public float destroyTime = 3;
    void Start()
    {
        
    }

    void Update()
    {
        //현재시간을 흐르게
        currTime += Time.deltaTime;
        //현재흐르는시간이 파괴시간보다 커지면
        if(currTime > destroyTime)
        {
            //나를 파괴해라
            Destroy(gameObject);
        }
    }
}
