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
        print("Being Called");
        health -= damage;
        healthText.text = health.ToString();

        if (health < 0)
        {
            print("Dead");
            health = 100;
        }
    }

}
