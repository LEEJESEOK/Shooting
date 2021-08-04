using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    //�ӵ�
    public float speed = 0.5f;
    void Start()
    {
        
    }

    void Update()
    {
        //������ �ӵ��� ����� ��ũ�� �ϰ� �ʹ�.
        //1. MeshRenderer ������Ʈ ��������
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        //2. ������ ������Ʈ���� Material�� ��������
        Material mat = mr.material;
        //3. ������ Material�� offset�� ����
        //P = P0 + vt
        mat.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
    }
}
