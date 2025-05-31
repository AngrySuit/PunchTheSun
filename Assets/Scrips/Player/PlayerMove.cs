using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody rB;
    [SerializeField] Transform orient;

    Vector3 inputVector;

    private void Update()
    {
        ProcessMove();
    }

    public void OnMove(InputAction.CallbackContext moveVector)
    {
        inputVector = moveVector.ReadValue<Vector2>();  
    }

    private void ProcessMove()
    {
        var moventDirection = orient.forward * inputVector.y + orient.right * inputVector.x;
        
        rB.AddRelativeForce(moventDirection.normalized * Time.deltaTime * 1000);

        var maxX = Mathf.Clamp(rB.velocity.x, -20, 20);
        var maxZ = Mathf.Clamp(rB.velocity.z, -20, 20);

        rB.velocity.Set(maxX,rB.velocity.y,maxZ);

        rB.AddRelativeForce(-rB.velocity * 0.6f);

    }
}
