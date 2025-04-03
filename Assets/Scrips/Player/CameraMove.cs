using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    //From "https://www.youtube.com/watch?v=f473C43s8nE"//

    //Holds the transform of the Main Camera//
    public Transform cameraPosition;

    //Update is called once per frame//
    void Update()
    {
        //Sets the cameras Position to the Camera Holder position//
        transform.position = cameraPosition.position;
    }
}
