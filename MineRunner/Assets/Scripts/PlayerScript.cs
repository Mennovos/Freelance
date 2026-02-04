using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Transform Cam;
    private Vector3 Movement;

    private Controls Controls;

    private Rigidbody Rb;
   // private Animator Anim;
    private void Awake()
    {
       // Anim = GetComponent<Animator>();
        Controls = new Controls();
        Controls.Player.Enable();

        Controls.Player.Move.performed += OnMove;
        Controls.Player.Move.canceled += OnMove;

        Rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        Movement.x = context.ReadValue<Vector2>().x;
        Movement.z = context.ReadValue<Vector2>().y;
        bool Walking = input.sqrMagnitude > 0.01f;
        //Anim.SetBool("CanWalk", Walking);
    }
    private void Update()
    {
        transform.Translate(Movement * Speed * Time.deltaTime);
    }

}
