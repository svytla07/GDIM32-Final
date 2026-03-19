using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private bool _cameraLocked = true;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

   
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.V)) 
        {
            _cameraLocked = !_cameraLocked;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = !_cameraLocked;
        }

        if (Cursor.lockState != CursorLockMode.Locked) return;

        float sensitivityMultiplier = 1f;

        #if UNITY_WEBGL && !UNITY_EDITOR
        sensitivityMultiplier = 0.1f;
    #endif


       
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        //yRotation = Mathf.Clamp(yRotation, -90f, 90f);
       
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    
    }

}
