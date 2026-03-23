using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool shouldFaceMoveDirection = false;

    private Vector2 moveInput;


    [SerializeField] private float Speed;
    [SerializeField] private Transform Cam;
    private Vector3 Movement;

    private Controls Controls;

    private Rigidbody Rb;
    private Animator Anim;
    private bool attacking;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
        Controls = new Controls();
        Controls.Player.Enable();

        Controls.Player.Move.performed += OnMove;
        Controls.Player.Move.canceled += OnMove;
        Controls.Player.Punch.performed += Punch;
        Controls.Player.Kick.performed += Kick;


        Rb = GetComponent<Rigidbody>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        Movement.x = context.ReadValue<Vector2>().x;
        Movement.z = context.ReadValue<Vector2>().y;
        bool Walking = input.sqrMagnitude > 0.01f;
        Anim.SetBool("Walking", Walking);
    }
    public void Punch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Anim.SetTrigger("Punching");
        }
    }
    public void Kick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Anim.SetTrigger("Kicking");
        }
    }

    void Update()
    {
        transform.Translate(Movement * Speed * Time.deltaTime);

        //Vector3 forward = cameraTransform.forward;
        //Vector3 right = cameraTransform.right;

        //forward.y = 0;
        //right.y = 0;

        //forward.Normalize();
        //right.Normalize();

        //Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;
     

        //if (shouldFaceMoveDirection && moveDirection.sqrMagnitude > 0.001f)
        //{
        //    Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
        //}

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(10);
        }
    }
    // Credits Jasperr
}
