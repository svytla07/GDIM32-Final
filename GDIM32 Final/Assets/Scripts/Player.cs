using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Transform orientation; 

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = orientation.forward * vertical + orientation.right * horizontal;
        

        transform.Translate(movement.normalized * _moveSpeed * Time.deltaTime, Space.World);
    }
}
