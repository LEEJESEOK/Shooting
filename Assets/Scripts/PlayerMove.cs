using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //속도
    public float speed = 20;

    //프로펠러
    public GameObject propeller;

    void Start()
    {

    }

    void Update()
    {
        //GameManager의 상태가 플레이 상태라면..
        if (GameManager.instance.state != (int)GameManager.GAMESTATE.PLAYING)
            return;

        //1. 사용자의 입력을 받아서
        float h = Input.GetAxis("Horizontal"); // A :-1, D : 1, 누르지 않으면 0
        float v = Input.GetAxis("Vertical");   // S :-1, W : 1, 누르지 않으면 0      

        //2. 방향을 정하고
        Vector3 dirH = transform.right * h;
        //Vector3.right * h = (1, 0, 0) * h = (h, 0, 0)
        Vector3 dirV = transform.up * v;
        //Vector3.up * v = (0, 1, 0) * v = (0, v, 0)
        Vector3 dir = dirH + dirV;
        //dir�� ũ�⸦ 1�� �Ѵ�.
        dir.Normalize();

        //3. 그 방향으로 움직이고 싶다.
        //P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;

        //transform.Translate(dir * speed * Time.deltaTime);
        RotatePropeller();

    }

    void RotatePropeller()
    {
        //프로펠러를 회전시켜라 (회전의 z값을 변경)
        propeller.transform.Rotate(0, 0, 10);
    }
}
