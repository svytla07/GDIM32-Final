using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f; // 每秒旋转角度

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A/D
        float v = Input.GetAxisRaw("Vertical");   // W/S

        // A/D 控制旋转
        if (h != 0)
        {
            transform.Rotate(Vector3.up, h * turnSpeed * Time.deltaTime);
        }

        // W/S 控制前后移动
        if (v != 0)
        {
            transform.Translate(Vector3.forward * v * moveSpeed * Time.deltaTime);
        }
<<<<<<< Updated upstream
=======
<<<<<<< HEAD

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movement.x = -1;
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement.x = 1;
        }

        transform.Translate(movement * _moveSpeed * Time.deltaTime);

        // float rotation = Input.GetAxis("Horizontal") * _turnSpeed * Time.deltaTime;
        // transform.Rotate(0, rotation, 0);

        // transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * _mouseSpeed, Input.GetAxis("Mouse X") * _mouseSpeed, 0));
=======
>>>>>>> e3b2960df768d13202395f2cd6f3179de876d419
>>>>>>> Stashed changes
    }
}
