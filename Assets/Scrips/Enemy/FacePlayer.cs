using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FacePlayer : MonoBehaviour
{
    // Declaring Variables
    Transform ptf;

    void Awake()
    {

        // Makes Furniture only Turn Sideways
        if (transform.tag == "Destructible")
        {
            transform.GetComponent<RotationConstraint>().locked = false;
            transform.GetComponent<RotationConstraint>().rotationAxis = Axis.X;
            transform.GetComponent<RotationConstraint>().rotationAxis = Axis.Z;
        }

        // Fetching varialbes 
        var player = GameObject.FindGameObjectWithTag("Player");

        ptf = player.transform;
    }


    void Update()
    {
        FaceTarget();
    }


    private void FaceTarget()
    {
        //Makes the transform face the player
        transform.LookAt(ptf);
        float rotation = Mathf.Clamp(transform.rotation.x, -35, 35);
        transform.rotation.eulerAngles.Set(rotation, transform.rotation.y, 0);
    }

}
