using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class playerMovement : NetworkBehaviour
{
    public CharacterController controller;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float speed = 12f;
    public float sprint = 24f;
    float speedReset;

    
    public float staminaMax = 100f;
    public float stamina;
    public float staminaTimerMax = 3f;
    public float staminaTimerTime = 0f;
  
    public RectTransform image;

    public Transform groundCheck;
    public float groundDistance = 0.46f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    public bool canRegenStamina = true;



    //Camera Stuff
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    public GameObject cam;

    float xRotation = 0f;

    bool cursorLockMode = true; 


    void Start(){
        if(hasAuthority){
            cam.SetActive(true);
        }else{
            cam.SetActive(false);
        }        

        speedReset = speed;
        stamina = staminaMax;
        Cursor.lockState = CursorLockMode.Locked;
    }
    [Client]
    public void staminaLevelUp(){
        staminaMax+=10;
    }
    [Client] 
    void Update()
    {
        if(!hasAuthority){return;}

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);

        cam.GetComponent<Transform>().transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y <0)
        {
            velocity.y=-2f;
        }

        image.sizeDelta = new Vector2((stamina/staminaMax)*390, 45);

        if(Input.GetButton("Sprint") &&  isGrounded && stamina > 0){
            if(Input.GetButton("Horizontal")|| Input.GetButton("Vertical"))
            {
            speed=sprint;
            stamina -= 5*Time.deltaTime;}
            canRegenStamina=false;
        }else
        {
            speed = speedReset;
            
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump")&&isGrounded&& stamina>jumpHeight*2 ){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            stamina-=jumpHeight*2;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (stamina<=0){canRegenStamina=false;stamina=0f;}
        if(stamina>staminaMax){stamina=staminaMax;}
        if(stamina<=staminaMax&&isGrounded)
        {  
             if (canRegenStamina){
            stamina += staminaMax*Time.deltaTime/100;
            
            }else
            {
                if(staminaTimerTime<staminaTimerMax){
                    staminaTimerTime+=Time.deltaTime;
                }else{
                    canRegenStamina = true;
                    staminaTimerTime = 0f;
                    if(stamina <= 0){stamina=1;}
                }
            }
            
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            if (cursorLockMode){
                Cursor.lockState = CursorLockMode.None;
                cursorLockMode = false;
            }else{
                Cursor.lockState = CursorLockMode.Locked;
                cursorLockMode = true;
            }
        }
    }
}
