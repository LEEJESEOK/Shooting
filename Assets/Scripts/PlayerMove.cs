using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //�ӵ�
    public float speed = 20;

    //�����緯
    public GameObject propeller;

    void Start()
    {

    }

    void Update()
    {
        //���࿡ GameManager�� ���°��� 2(�÷���) ���
        if (GameManager.instance.state != 2) return;

        //1. ������� �Է��� �޾Ƽ�
        float h = Input.GetAxis("Horizontal"); // A :-1, D : 1, ������ ������ 0
        float v = Input.GetAxis("Vertical");   // S :-1, W : 1, ������ ������ 0      

        //2. ������ ���ϰ�
        Vector3 dirH = transform.right * h;
        //Vector3.right * h = (1, 0, 0) * h = (h, 0, 0)
        Vector3 dirV = transform.up * v;
        //Vector3.up * v = (0, 1, 0) * v = (0, v, 0)
        Vector3 dir = dirH + dirV;
        //dir�� ũ�⸦ 1�� �Ѵ�.
        dir.Normalize();

        //3. �� �������� �����̰� �ʹ�.
        //P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;

        //transform.Translate(dir * speed * Time.deltaTime);
        RotatePropeller();

    }

    void RotatePropeller()
    {
        //�÷��緯�� ȸ�� ���Ѷ� (ȸ���� z���� ��������)
        propeller.transform.Rotate(0, 0, 10);
    }
}
