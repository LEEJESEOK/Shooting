using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    //속도
    public float speed = 0.5f;
    void Start()
    {
        
    }

    void Update()
    {
        //일정한 속도로 배경을 스크롤 하고 싶다.
        //1. MeshRenderer 컴포넌트 가져오자
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        //2. 가져온 컴포넌트에서 Material을 가져오자
        Material mat = mr.material;
        //3. 가져온 Material의 offset을 변경
        //P = P0 + vt
        mat.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
    }
}
