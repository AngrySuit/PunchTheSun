using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    //Holds the damage value of the attack//
    int damage;

    //OnTriggerEnter is called when the colider other enters the trigger// 
    private void OnTriggerEnter(Collider other)
    {
       //Checks if it is coliding with either an enemy or destructable object//
       if (other.tag == "Enemy" || other.tag == "Destructable")
       {
            //If so gets the HitTaker component and makes it damage itself//
           other.GetComponent<HitTaker>().TakeDamage(damage);
       }
    }

    //Setter method for damage// 
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}
