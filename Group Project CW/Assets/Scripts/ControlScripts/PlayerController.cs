using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] protected Camera playerCamera;

    protected float mouseX;
    protected float mouseY;
    protected float mouseSensitivity = 1000f;
    float horzAxis;
    float vertAxis;

    protected float xRot;
    protected float yRot;
    float moveSpeed = 12f;
    Vector3 velocity;
    float gravity = -9.8f;
    float jumpHeight = 3f;
    float groundDistance = 0.3f;
    bool isGrounded;
    bool jumpTrigger;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        GetInputs();
        CheckGrounded();
        CheckJumpTrigger();
        PlayerLook();
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.G))
        {
            print("Works on the playercontrolelr script");
        }
    }

    void GetInputs()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        horzAxis = Input.GetAxis("Horizontal");
        vertAxis = Input.GetAxis("Vertical");
        jumpTrigger = Input.GetButtonDown("Jump");
    }

    void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = 0f;
        }
        else if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
    }

    void CheckJumpTrigger()
    {
        if (jumpTrigger && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void PlayerLook()
    {
        // Look up and down
        yRot -= mouseY * mouseSensitivity * Time.deltaTime;
        yRot = Mathf.Clamp(yRot, -85, 85);
        playerCamera.transform.localRotation = Quaternion.Euler(yRot, 0f, 0f);

        // Look left and right
        xRot = mouseX * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * xRot); 
    }

    void MovePlayer()
    {
        Vector3 move = (transform.right * horzAxis) + (transform.forward * vertAxis);
        controller.Move(move * moveSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
}
