using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] GameObject[] healthBags;

    [SerializeField] public int health = 100;

    [SerializeField] bool CourotinePerfoming = false;
    
    // Start is called before the first frame update
    void Start()
    {
        ChangeBag();
        healthText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag ==  "HealLarge")
        {
            StartCoroutine("UpdateHealth", +50);
        }
        else if (other.tag == "HealMedium")
        {
            StartCoroutine("UpdateHealth", +30);
        }
        else if (other.tag == "HealSmall")
        {
            StartCoroutine("UpdateHealth", +10);
        }
    }

    public void ChangeHealth(int damage)
    {
        if (!CourotinePerfoming) StartCoroutine("UpdateHealth", damage);

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        if (Change < 0 ) CourotinePerfoming = true;

        for (int i = 0; i != Mathf.Abs(Change); i++)
        {
            health += MathF.Sign(Change);
            healthText.text = health.ToString();

            ChangeBag();
            health = Mathf.Clamp(health, 0, 100);
            if (health == 100 || health == 0) StopCoroutine("UpdateHealth");

            yield return new WaitForSeconds(0.03f);
        }

        yield return new WaitForSeconds(7f);
        CourotinePerfoming = false;
    }
}
