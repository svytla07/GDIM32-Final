using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Transform orientation; 

    private Rigidbody _rb;

    void Awake()
    {
        Application.targetFrameRate = 144; 
        QualitySettings.vSyncCount = 0; 
        _rb = GetComponent<Rigidbody>(); 
    }

   
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Debug.DrawRay(transform.position, orientation.forward * 2f, Color.blue);
        Debug.DrawRay(transform.position, orientation.right * 2f, Color.red);

        Vector3 movement = orientation.forward * vertical + orientation.right * horizontal;
        

        transform.Translate(movement.normalized * _moveSpeed * Time.deltaTime, Space.World);
    }
}
