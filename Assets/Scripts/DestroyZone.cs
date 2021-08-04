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
        //ºÎµúÈù³ğÀ» ÆÄ±«ÇÏÀÚ
        Destroy(other.gameObject);
    }
}
