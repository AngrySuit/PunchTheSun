using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOri : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down);
        Physics.Raycast(transform.position,Vector3.down,out hit);
        transform.rotation = Quaternion.Euler(0, 0, hit.normal.z);
    }
}
