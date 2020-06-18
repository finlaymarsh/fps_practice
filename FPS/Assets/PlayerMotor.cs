
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Gets a movement vector
    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }

    // Runs every physics iteration
    void FixedUpdate ()
    {
        PreformMovement();
        PreformRotation();

    }

    void PreformMovement ()
    {
        if (velocity != Vector3.zero)
        {
            // Preforms physics and collision checks
            rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
        }
    }

    public void Rotate (Vector3 _rotation)
    {
        rotation = _rotation;
    }

    void PreformRotation ()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation));
        if (cam != null)
        { 
                cam.transform.Rotate(-cameraRotation);  
        }
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }
}
