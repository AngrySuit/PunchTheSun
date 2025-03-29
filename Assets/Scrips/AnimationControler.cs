using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControler : MonoBehaviour
{

    [SerializeField] Animator animright;
    [SerializeField] PlayerAttack pa;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pa.charging)
        {
            animright.SetBool("ChargingAnim", true);
            animright.SetFloat("ChargeAnim", pa.charge);
        }
        
    }


    public void TrowPunch()
    {
        animright.SetBool("ChargingAnim", false);
        animright.SetFloat("ChargeAnim", pa.charge);
    }




}
