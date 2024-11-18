using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerInput input;
    private InputAction moveAction;
    private InputAction lookAction;

    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float movementForce;

    [SerializeField] private float lookSens;

    float xRotation, yRotation;

    [SerializeField] float cameraTopClampAngle;
    [SerializeField] float cameraBottomClampAngle;

    Vector2 inputVal;

    //Vector2 lastInputVals; // Used for acceleration/decelaration

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInput>();

        moveAction = input.actions.FindAction("Move");
        lookAction = input.actions.FindAction("Look");

        Cursor.visible = false; // Hide cursor
    }

    void Update()
    {
        PlayerInput();
        PlayerLook();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerInput()
    {
        inputVal = moveAction.ReadValue<Vector2>();
    }

    private void PlayerMove()
    {

        /*Vector2 lerpInputVals = Vector2.Lerp(lastInputVals, inputVal, acceleration * Time.deltaTime); //Interpolate input Values to create acceleration/decelaration

        lastInputVals = lerpInputVals;*/

        Vector3 move = new(
            inputVal.x,
            0,
            inputVal.y);
        move = transform.TransformDirection(move);

        rb.AddForce(movementForce * Time.fixedDeltaTime * move);
    }

    void PlayerLook()
    {
        Vector2 inputVal = lookAction.ReadValue<Vector2>(); //Get input axes

        // Usage of properties negates need for conversion of Quaternion angles to Euler

        //Vector3 eulerRotation = transform.localEulerAngles; // Convert Quaternion to Euler (degrees)
        //Vector3 cameraEulerRotation = cameraTransform.localEulerAngles; // Convert Quaternion to Euler (degrees)

        yRotation += (inputVal.x * Time.deltaTime * lookSens); // Add axis input to angle and adjust
        transform.localRotation = Quaternion.Euler(0, yRotation, 0); // Rotate entire player around y axis

        xRotation -= (inputVal.y * Time.deltaTime * lookSens); // Add axis input to angle and adjust
        xRotation = Mathf.Clamp(xRotation, -cameraBottomClampAngle, cameraTopClampAngle); //Clamp camera rotation
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0); // Rotate camera around x axis
    }
}
