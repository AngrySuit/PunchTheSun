using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] public int health = 100;
    
    
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        StartCoroutine("UpdateHealth",damage);

        if (health < 0)
        {
            print("Dead");
            health = 100;
        }
    }

    private IEnumerator UpdateHealth(int Change)
    {
        for (int i = 0; i != Change; i++)
        {
            health--;
            healthText.text = health.ToString() ;

            yield return new WaitForSeconds(0.03f);
        }
    }
}
