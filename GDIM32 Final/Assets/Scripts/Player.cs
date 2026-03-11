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
    }
}
