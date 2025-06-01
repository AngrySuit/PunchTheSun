using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.Mathematics;
public class PlayerAttack : MonoBehaviour
{
    // Declares Components 
    [SerializeField] GameObject HayMaker;
    [SerializeField] Transform PunchLocation;
    [SerializeField] Transform Orient;
    [SerializeField] Image ChargeBar;
    [SerializeField] AnimationControler animc;

    // Declares Variables
    public bool charging = false;
    public float charge = 0;
    int chargeSpeed = 45;
    int baseDamage = 45;

    // Fecteces the bar
    private void Awake() => ChargeBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, charge);

    private void Update()
    {
        ChargeUp();
    }

    //Checks if the player is holding down the button
    public void OnFire(InputAction.CallbackContext attack)
    {
        if (attack.performed)
        {
            charging = true;
        }
        if (attack.canceled)
        {
            TrowHayMaker();   
        }
    }

    
    private void ChargeUp()
    {
        if (charging && charge < 100)
        {
            charge += chargeSpeed * Time.deltaTime;
            ChargeBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, charge);
        }
    }

    // Instatiate the attack holding damage relative to charge
    private void TrowHayMaker()
    {

        charging = false;

        animc.TrowPunch();

        GameObject Hay = Instantiate(HayMaker, PunchLocation.position, Orient.rotation);
        Hay.GetComponentInChildren<DealDamage>().SetDamage(Mathf.RoundToInt(baseDamage * (charge / 100)));
        Hay.GetComponent<Transform>().localScale = new Vector3(1.5f, 1.5f, ((1.5f * (charge / 100) + 0.5f)));


        charge = 0;

        ChargeBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, charge);


        Destroy(Hay, 0.3f);

    }

}
