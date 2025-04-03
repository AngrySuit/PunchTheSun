using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FacePlayer : MonoBehaviour
{
    Transform ptf;



    // Start is called before the first frame update
    void Awake()
    {
        if (transform.tag == "Destructible")
        {
            transform.GetComponent<RotationConstraint>().locked = false;
            transform.GetComponent<RotationConstraint>().rotationAxis = Axis.X;
            transform.GetComponent<RotationConstraint>().rotationAxis = Axis.Z;
        }

        var player = GameObject.FindGameObjectWithTag("Player");

        ptf = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        FaceTarget();
    }


    private void FaceTarget()
    {
        transform.LookAt(ptf);
        float rotation = Mathf.Clamp(transform.rotation.x, -35, 35);
        transform.rotation.eulerAngles.Set(rotation, transform.rotation.y, 0);
    }

}
