using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTaker : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int defense;

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
