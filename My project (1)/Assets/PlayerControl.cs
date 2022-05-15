using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    CharacterController characterController;
    public Camera cam;

    public float Speed = 10f;
    public float JumpForce = 300f;
    public float gravity = -9.8f;


    //что бы эта переменна€ работала добавьте тэг "Ground" на вашу поверхность земли
    private bool _isGrounded;
    //private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        //cam = GetComponent<Camera>();
        //_rb = GetComponent<Rigidbody>();
    }

    // обратите внимание что все действи€ с физикой 
    // необходимо обрабатывать в FixedUpdate, а не в Update
    void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }

    private void MovementLogic()
    {
        /*
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        transform.Rotate(0, moveHorizontal * Speed * Time.fixedDeltaTime * 25.0f, 0);

        Vector3 forward = transform.TransformDirection(Vector3.forward);

        characterController.Move(moveVertical * forward * Time.fixedDeltaTime * Speed * 1.0f);
        */
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                //_rb.AddForce(Vector3.up * JumpForce);

                // ќбратите внимание что € делаю на основе Vector3.up 
                // а не на основе transform.up. ≈сли персонаж упал или 
                // если персонаж -- шар, то его личный "верх" может 
                // любое направление. ¬лево, вправо, вниз...
                // Ќо нам нужен скачек только в абсолютный вверх, 
                // потому и Vector3.up
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        transform.Rotate(0, Input.GetAxis("Horizontal") * speed_rotation * Time.deltaTime * 50, 0);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float currentSpeed = spees * Input.GetAxis("Vertical");
        characterController.SimpleMove(forward * currentSpeed * Time.deltaTime * 1000);
        */

        float deltaX = Input.GetAxis("Horizontal") * Speed;
        float deltaZ = Input.GetAxis("Vertical") * Speed;

        float MouseY = Input.GetAxis("Mouse Y") * Speed * 100 * Time.deltaTime;

        transform.Rotate(0, deltaX * Time.deltaTime * 35.0f, 0);

        //if (cam != null)
        //    cam.transform.Rotate(MouseY * Time.deltaTime * 1000.0f, 0, 0);

        Vector3 movement = new Vector3(0, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, Speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
  
        characterController.Move(movement);
    }
}
