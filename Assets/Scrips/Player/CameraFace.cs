using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFace : MonoBehaviour
{

    //From "https://www.youtube.com/watch?v=f473C43s8nE"//

    //Allows for selectible mouse sensitivity//
    public float sensX = 2;
    public float sensY = 2;

    //Holds the trnasform that tell where the player is looking//
    public Transform orient;

    //Holds the rotation values of the player//
    float rotateX;
    float rotateY;

    //Start is called before the first frame update//
    void Start()
    {
        //Locks curesor to the center of the screen//
        //And makes it invisible//
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //Update is called once per frame//
    void Update()
    {
        //Adds your horizontal mouse movement rotateY//
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        rotateY += mouseX;

        //Adds your vertical mouse movement rotateX//
        //And then clamps to stop you from looking backwards//
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        rotateX -= mouseY;
        rotateX = Mathf.Clamp(rotateX, -90, 90);

        //Rotates the Camera to look at where the mouse has made it look//
        //Also rotates orient to track where fowrd is//
        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);
        orient.rotation = Quaternion.Euler(0, rotateY,0);
        

    }
}
