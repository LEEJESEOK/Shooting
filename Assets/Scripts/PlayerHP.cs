using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    // Current HP
    float currHP;

    // Max HP
    public float maxHP = 100;

    // HP UI - Image component
    public Image hpUI;

    // Start is called before the first frame update
    void Start()
    {
        currHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            Damaged(20);
        }
    }

    public void Damaged(float damage)
    {
        currHP -= damage;
        print("현재 체력 : " + currHP);

        // HP UI의 fillAmount를 currHP로 변경
        hpUI.fillAmount = currHP / maxHP;

        if (currHP <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("ResultScene");
        }
    }
}
