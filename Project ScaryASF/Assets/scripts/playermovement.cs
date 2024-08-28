using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float movespeed = 5f;
    public float jump = 2f;
    public float gravspeed = 2f;
    public float mousesensitivity = 2.0f;
    public float pitchRange = 60.0f;

    private float forwardinput;
    private float strafeinput;
    private bool jumping;

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
    }

    // Update is called once per frame
    void Update()
    {
        forwardinput = Input.GetAxisRaw("Vertical");
        strafeinput = Input.GetAxisRaw("Horizontal");
        Movement();
        CameraMovement();
        JumpNGrav();
    }

    void Movement()
    {
        Vector3 direction = (transform.forward * forwardinput
                            + transform.right * strafeinput).normalized
                             * movespeed * Time.deltaTime;
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
    }
}