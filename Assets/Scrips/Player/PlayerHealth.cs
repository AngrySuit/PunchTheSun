using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] GameObject[] healthBags;

    [SerializeField] public int health = 100;

    bool CourotinePerfoming = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeBag();
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible") 
        {
            if (other.transform.name == "Bootle Large Collectible")
            {
                StartCoroutine("UpdateHealth", +50);
            }
            else if (other.transform.name == "Bootle Small Collectible")
            {
                StartCoroutine("UpdateHealth", +30);
            }
            else if (other.transform.name == "Cig Collectible")
            {
                StartCoroutine("UpdateHealth", +10);
            }
        }
    }

    public void ChangeHealth(int damage)
    {
        if (!CourotinePerfoming) StartCoroutine("UpdateHealth", damage);
        

        if (health <= 0)
        {
            health = 100;
        }

    }

    private void ChangeBag()
    {
        if (health >= 76)
        {
            foreach (GameObject bag in healthBags)
            {
                if (bag.transform.name == "Health Bag 4")
                {
                    bag.gameObject.SetActive(true);
                }
                else
                {
                    bag.gameObject.SetActive(false);
                }
            }
        }
        else if(health >= 51)
        {
            foreach (GameObject bag in healthBags)
            {
                if (bag.transform.name == "Health Bag 3")
                {
                    bag.gameObject.SetActive(true);
                }
                else
                {
                    bag.gameObject.SetActive(false);
                }
            }
        }
        else if(health >= 26)
        {
            foreach (GameObject bag in healthBags)
            {
                if (bag.transform.name == "Health Bag 2")
                {
                    bag.gameObject.SetActive(true);
                }
                else
                {
                    bag.gameObject.SetActive(false);
                }
            }
        }
        else if(health >= 1)
        {
            foreach (GameObject bag in healthBags)
            {
                if (bag.transform.name == "Health Bag 1")
                {
                    bag.gameObject.SetActive(true);
                }
                else
                {
                    bag.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            foreach (GameObject bag in healthBags)
            {
                if (bag.transform.name == "Health Bag 0")
                {
                    bag.gameObject.SetActive(true);
                }
                else
                {
                    bag.gameObject.SetActive(false);
                }
            }
        }
    }

    private IEnumerator UpdateHealth(int Change)
    {
        CourotinePerfoming = true;

        for (int i = 0; i != Change; i++)
        {
            health += MathF.Sign(Change);
            healthText.text = health.ToString();

            ChangeBag();

            health = Mathf.Clamp(health, 0, 100);

            yield return new WaitForSeconds(0.03f);
        }

        CourotinePerfoming = false;
    }
}
