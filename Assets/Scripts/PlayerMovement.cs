using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character;
    private PlayerInput input;
    private InputAction moveAction;
    private InputAction lookAction;

    [SerializeField] private Transform cameraTransform;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float acceleration;

    [SerializeField] private float lookSens;

    float xRotation, yRotation;

    [SerializeField] float cameraTopClampAngle;
    [SerializeField] float cameraBottomClampAngle;

    Vector2 lastInputVals; // Used for acceleration/decelaration
     
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();

        moveAction = input.actions.FindAction("Move");
        lookAction = input.actions.FindAction("Look");

        Cursor.visible = false; // Hide cursor

    }

    // Update is called once per frame
    void Update() //Keep in Update or move to FixedUpdate?
    {
        PlayerMove();
        PlayerLook();
    }

    void PlayerMove()
    {
        Vector2 inputVal = moveAction.ReadValue<Vector2>();

        Vector2 lerpInputVals = Vector2.Lerp(lastInputVals, inputVal, acceleration * Time.deltaTime); //Interpolate input Values to create acceleration/decelaration

        lastInputVals = lerpInputVals;
        Debug.Log(lerpInputVals);

        Vector3 move = new (
            lerpInputVals.x * movementSpeed * Time.deltaTime,
            0, // To do: Account for gravity.
            lerpInputVals.y * movementSpeed * Time.deltaTime);
        move = transform.TransformDirection(move);

        character.Move(move);

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
