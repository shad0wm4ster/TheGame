using UnityEngine;

[RequireComponent(typeof(PlayerMotor))] //requires a component of playermotor to function

public class PlayerController : MonoBehaviour
{
    [SerializeField] //to show the value in inspection mode even though the var is private
    private float speed = 5f; //determining the moving speed
    [SerializeField]
    private float looksensitivity = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //calc movement vel. as a 3D vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xMov;
        Vector3 _moveVertical = transform.forward * _zMov;

        //final movement vector
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed; //normalized to set the value of the vector as 1 and not get different movement speed

        //method for applying movement
        motor.Move(_velocity);

        //calculate rotation as 3D vector(turning around)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * looksensitivity; //rotation movement, using move sensitivity

        //method for applying rotation
        motor.Rotate(_rotation);

        //calculate camera rotation as 3D vector
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * looksensitivity; //rotation movement, using move sensitivity

        //method for applying camera rotation
        motor.RotateCamera(_cameraRotation);
    }
}
