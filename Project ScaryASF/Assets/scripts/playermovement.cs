using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float movespeed = 5f;
    public float jump = 2f;
    public float gravspeed = 2f;
    public float mousesensitivity = 2.0f;
    public float pitchRange = 60.0f;

    public float sprintspeed = 10f;
    public float sprintmaxtime = 3000f;
    public float sprintcooldown;
    public stanamabar sprintbar;

    static public bool haslight = false;
    public bool lighton = false;
    private Light flashlight;

    private bool canrun = true;
    private float sprinttime = 900f;

    private float forwardinput;
    private float strafeinput;
    private bool jumping;
    private float walkspeed;

    private float terminalveloc = 53f;
    private float verticalveloc;

    private float rotatecamra;
    private Camera firstpersoncam;
    private CharacterController charactercontrol;


    // Start is called before the first frame update
    void Awake()
    {
        charactercontrol = GetComponent<CharacterController>();
        firstpersoncam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        walkspeed = movespeed;
        flashlight = GetComponentInChildren<Light>();

        //sprintbar.setMax(sprintmaxtime);
    }

    // Update is called once per frame
    void Update()
    {
        sprinting();
        forwardinput = Input.GetAxisRaw("Vertical");
        strafeinput = Input.GetAxisRaw("Horizontal");
        jumping = Input.GetButtonDown("Jump");
        Movement();
        CameraMovement();
        JumpNGrav();
        lightfunc();
    }

    void Movement()
    {
        Vector3 direction = (transform.forward * forwardinput
                            + transform.right * strafeinput).normalized
                             * movespeed * Time.deltaTime;
        direction += Vector3.up * verticalveloc * Time.deltaTime;
        charactercontrol.Move(direction);
    }


    void CameraMovement()
    {
        float rotateYaw = Input.GetAxis("Mouse X") * mousesensitivity;
        transform.Rotate(0, rotateYaw, 0);

        rotatecamra += -Input.GetAxis("Mouse Y") * mousesensitivity;

        rotatecamra = Mathf.Clamp(rotatecamra, -pitchRange, pitchRange);
        firstpersoncam.transform.localRotation = Quaternion.Euler(rotatecamra, 0, 0);
    }

    void JumpNGrav()
    {
        if (charactercontrol.isGrounded)
        {
            if (verticalveloc < 0.0f)
            {
                verticalveloc = -2f;
            }

            if(jumping)
            {
                verticalveloc = Mathf.Sqrt(jump * -2f * Physics.gravity.y);
            }
        }
        else
        {
            if(verticalveloc < terminalveloc)
            {
                float gravemulti = 1;
                if (charactercontrol.velocity.y < -1)
                {
                    gravemulti = gravspeed;

                }
                verticalveloc += Physics.gravity.y * gravemulti * Time.deltaTime;
            }
        }
    }

    /*async */void sprinting()
    {
        if (Input.GetKey(KeyCode.LeftShift) && sprinttime > 0 && canrun == true)
        {
            
            movespeed = sprintspeed;
            sprinttime--;
            
        }
        else if (sprinttime == 0 && sprintcooldown == 0 && canrun == true)
        {

            //sprintcooldown = 500;
            //await sprintwaiting(5000);
            canrun = false;
        }
        else
        {
            movespeed = walkspeed;
            if (sprinttime < sprintmaxtime)
            {
                sprinttime++;
            }
            if(sprintcooldown > 0)
            {
                sprintcooldown--;

            }
            else if(canrun == false && sprintcooldown == 0)
            {
                canrun = true;
            }

        }

        //sprintbar.setstanama(sprinttime);
    }
    void lightfunc()
    {
        if (haslight == false || lighton == false)
        {
            flashlight.enabled = false;

        }
        if (Input.GetButtonDown("Fire1") && haslight == true && lighton == false)
        {
            lighton = true;
            Debug.Log("lights on");
        }

        else if (Input.GetButtonDown("Fire1") && lighton == true)
        {
            lighton = false;

        }

        if (haslight == true && lighton == true)
        {
            flashlight.enabled = true;
        }
    }

    /*private static async Task sprintwaiting(int milliseconds)
    {
        await Task.Run(() => Thread.Sleep(milliseconds));
    }*/
}
