using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Rotation
    float mouseX;
    float mouseY;
    float cameraX;
    public float lookSpeed;
    public Transform MainCam;

    // Movement
    CharacterController cc; //(OnControllerColliderHit)
    public float moveSpeed;
    float xAxis;
    float zAxis;
    Vector3 axisMovement;

    // Gravity
    public bool isGround;
    float radius;
    public LayerMask groundLayerMask;
    public Transform groundCheck;
    float gravity;
    Vector3 gravityVelocity;
    Vector3 Jumping;

    // Key
    public static bool hasKey;

    // Sounds
    public AudioSource audioSource;
    public AudioClip jumpingSound;
    public AudioClip eatKeySound;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Rotation
        lookSpeed = 150;

        // Movement
        cc = GetComponent<CharacterController>();
        moveSpeed = 5;

        // Gravity
        isGround = false;
        radius = 0.5f;
        gravity = -9.81f;

        // Key
        hasKey = false;
    }

    void Update()
    {
        PlayerRotation();
        Movement();
        PlayerGravity();
        PlayerJumpingFixStuck();
        RespawnLevel();
    }
    void PlayerRotation()
    {
        mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
        transform.Rotate(0, mouseX, 0);
        cameraX -= mouseY;
        cameraX = MyClamp(cameraX, -90, 90);
        MainCam.localRotation = Quaternion.Euler(cameraX, 0, 0);
    }
    void Movement()
    {

        xAxis = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        zAxis = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        axisMovement = transform.forward * zAxis + transform.right * xAxis;

        cc.Move(axisMovement);
    }
    void PlayerJumpingFixStuck()
    {
        Jumping = transform.up * 10;
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            gravityVelocity.y += 5 * EatCola.colaJumpingAbility * EatCola.goldenColaJumpingAbility;
            cc.Move(Jumping * Time.deltaTime);
            audioSource.PlayOneShot(jumpingSound);
        }

    }
    void PlayerGravity()
    {
        if (Physics.CheckSphere(groundCheck.position, radius, groundLayerMask))
        {
            isGround = true;

        }
        else
        {
            isGround = false;
        }

        if (isGround == false)
        {
            gravityVelocity.y += gravity * Time.deltaTime;
        }
        else
        {
            gravityVelocity.y = 0;
        }

        cc.Move(gravityVelocity * Time.deltaTime);

    }
    float MyClamp(float curr, float min, float max)
    {
        if (curr < min)
        {
            return min;
        }
        else if (curr > max)
        {
            return max;
        }
        else
            return curr;
    }
   
    void RespawnLevel()
    {

        if (transform.position.y <= -15)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            Destroy(other.gameObject);
            hasKey = true;
            audioSource.PlayOneShot(eatKeySound);
        }
    } 
}
