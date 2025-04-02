using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject HayMaker;
    [SerializeField] Transform PunchLocation;
    [SerializeField] Transform Orient;
    [SerializeField] Image ChargeBar;
    [SerializeField] AnimationControler animc;


    public bool charging;
    public float charge;
    int ChargeSpeed = 45;
    

    // Start is called before the first frame update4




    private void Update()
    {
        ChargeUp();
    }

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
            charge += ChargeSpeed * Time.deltaTime;
            ChargeBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, charge);
        }
    }

    private void TrowHayMaker()
    {

        charging = false;

        animc.TrowPunch(); 

        GameObject Hay = Instantiate(HayMaker, PunchLocation.position, Orient.rotation);
        Hay.GetComponent<Transform>().localScale = new Vector3(1.5f, 1.5f, ((1.5f * (charge / 100) + 0.5f)));

        charge = 0;

        ChargeBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, charge);


        Destroy(Hay, 0.3f);

    }

}
