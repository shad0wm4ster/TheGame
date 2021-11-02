using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //requires a component of rigidbody to function

public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //gets a movement vector
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //gets a rotational vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //gets a rotational vector for the camera
    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    //run on a fixed time physics
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //perform movement based on velocity variable
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); //move the rigidbody to player pos + velocity vector, basically the movement
        }
    }

    //perform rotation
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
