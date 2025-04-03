using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{   
    //Gets the animator for the right hand and the player attack script // 

    [SerializeField] Animator animright;
    [SerializeField] PlayerAttack pa;

    // Update is called once per frame
    void Update()
    {
        //Checks if the punch is being Charged              //
        //If so sets bools to play the chraging animation   // 

        if (pa.charging)
        {
            animright.SetBool("ChargingAnim", true);
            animright.SetFloat("ChargeAnim", pa.charge);
        }
        
    }

    public void TrowPunch()
    {
        //Sets bools to play the punching animation//

        animright.SetBool("ChargingAnim", false);
        animright.SetFloat("ChargeAnim", pa.charge);
    }




}
