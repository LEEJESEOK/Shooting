using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //부딪힌 놈이 Bullet이면 비활성화
        if (other.gameObject.name.Contains("Bullet"))
        {
            GameObject player = GameObject.Find("Player");
            PlayerFire pf = player.GetComponent<PlayerFire>();
            pf.ResetBullet(other.gameObject);
        }
        //그렇지 않으면 부딪힌 놈을 파괴하자
        else
            Destroy(other.gameObject);
    }
}
