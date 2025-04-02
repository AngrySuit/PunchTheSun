using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    int damage;

    private void OnTriggerEnter(Collider other)
    {
       if (other.tag == "Enemy" || other.tag == "Destructable")
       {
           other.GetComponent<HitTaker>().TakeDamage(damage);
       }
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}
