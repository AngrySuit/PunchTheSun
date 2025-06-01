using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTaker : MonoBehaviour
{
    // Declaring Variables
    [SerializeField] int health;
    [SerializeField] int defense;

    // Public Function that Attacks can call to do damage
    public void TakeDamage(int Damage)
    {
        health -= Damage - defense;

        if (health <= 0)
        {
            ItemDroper itD = GetComponent<ItemDroper>();
            itD.DropItems();

            Destroy(gameObject);
        }
    }
}
