using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFace : MonoBehaviour
{

    // From https://www.youtube.com/watch?v=f473C43s8nE //


    public float sensX = 2;
    public float sensY = 2;

    public Transform orient;

    float rotateX;
    float rotateY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        rotateY += mouseX;


        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, -90, 90);

        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);
        orient.rotation = Quaternion.Euler(0, rotateY,0);
        

    }
}
