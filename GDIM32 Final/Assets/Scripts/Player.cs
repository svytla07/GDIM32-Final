using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Transform orientation; 

   
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Debug.DrawRay(transform.position, orientation.forward * 2f, Color.blue);
        Debug.DrawRay(transform.position, orientation.right * 2f, Color.red);

        Vector3 movement = orientation.forward * vertical + orientation.right * horizontal;
        

        transform.Translate(movement.normalized * _moveSpeed * Time.deltaTime, Space.World);
    }
}
