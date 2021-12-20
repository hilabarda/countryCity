using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerNumber
{
    Player1,
    player2
}

public class playerControler : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10;
    [SerializeField]
    private float rotateSpeed = 75;
    [SerializeField]
    private float jumpForce = 5;
    [SerializeField]
    private PlayerNumber myPlayer;

    [SerializeField]
    private KeyCode keyJump = KeyCode.Space;
    [SerializeField]
    private KeyCode keyJump2 = KeyCode.J;
    [SerializeField]
    private float distanceFromGround = 0.1f;
    [SerializeField]
    private LayerMask groundLayer;


    private const string VERTICAL_AXIS = "Vertical";
    private const string HORIZPNTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS2 = "Vertical2";
    private const string HORIZPNTAL_AXIS2 = "Horizontal2";

    private float vInput;
    private float hInput;
    private Rigidbody rb;
    private bool canJump = false;
    private BoxCollider BoxCollider;

    private GameManager gameManager;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        BoxCollider = GetComponent<BoxCollider>();
        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void Update()
    {
        if(myPlayer == PlayerNumber.Player1)
        {
            vInput = Input.GetAxis(VERTICAL_AXIS) * moveSpeed;
            hInput = Input.GetAxis(HORIZPNTAL_AXIS) * rotateSpeed;
            if (Input.GetKeyDown(keyJump))
            {
                canJump = true;
            }
        }

        if(myPlayer == PlayerNumber.player2)
        {
            vInput = Input.GetAxis(VERTICAL_AXIS2) * moveSpeed;
            hInput = Input.GetAxis(HORIZPNTAL_AXIS2) * rotateSpeed;
            if (Input.GetKeyDown(keyJump2))
            {
                canJump = true;
            }
        }
      
        
    }



    private void FixedUpdate()
    {
        if (canJump && IsGrounded())
        {
            canJump = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        Vector3 rotation = Vector3.up * hInput;
        Quaternion angelRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        rb.MovePosition(transform.position + transform.forward * vInput * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * angelRot);
    }

    private bool IsGrounded()
    {
        Vector3 boxBottom =
            new Vector3(BoxCollider.center.x, BoxCollider.bounds.min.y, BoxCollider.center.z);

        bool isGrounded = Physics.CheckCapsule(BoxCollider.bounds.center, boxBottom, distanceFromGround,
            groundLayer, QueryTriggerInteraction.Ignore);

        return isGrounded;
    }



}
