using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] public float _turnSpeed = 5f;
    [SerializeField] public float _moveSpeed = 5f;
    [SerializeField] public float _mouseSpeed = 3.5f;

    void Start()
    {
    

    }

    
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            movement.z = 1;
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement.z = -1;
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -1;
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = 1;
        }

        transform.Translate(movement * _moveSpeed * Time.deltaTime);

        //float rotation = Input.GetAxis("Horizontal") * _turnSpeed * Time.deltaTime;
       // transform.Rotate(0, rotation, 0);

       // transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * _mouseSpeed, Input.GetAxis("Mouse X") * _mouseSpeed, 0));
    }
}
