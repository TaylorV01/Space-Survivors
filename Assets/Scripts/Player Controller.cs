using UnityEngine;

[RequireComponent(typeof(player_motor))]
public class player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private player_motor motor;

    void Start()
    {
        motor = GetComponent <player_motor>();
    }

    void Update()
    {
        //Velocidad de movimiento en un vector 3d
        float xMov = Input.GetAxisRaw("Horizontal");
        float yMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * yMov;

        //Vector de movimiento final
        Vector3 velocity = (movHorizontal +  movVertical).normalized * speed;


        //Aplicar el movimiento
        motor.Move(velocity);


        //Rotacion del personaje solo para girar a los lados 

        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        //Aplicar rotacion 
        motor.Rotate(_rotation);

        //Rotacion de la camara personaje 

        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3( _xRot,0f, 0f) * lookSensitivity;

        //Aplicar rotacion 
        motor.RotateCamera(_cameraRotation);
    }
}
