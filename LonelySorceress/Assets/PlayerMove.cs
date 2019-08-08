using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float sprintIncrease;
    [SerializeField] private float crouchDecrease;


    private CharacterController charController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private KeyCode sprintKey;
    [SerializeField] private KeyCode crouchKey;




    private bool isJumping;
    private float adjustedMovementSpeed;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
        
    }



    private void PlayerMovement()
    {
        adjustedMovementSpeed = movementSpeed;

        //Sprint();
        //Crouching();
        
        float horizInput = Input.GetAxis(horizontalInputName) * adjustedMovementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * adjustedMovementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

        JumpInput();

    }

    private void Sprint()
    {
        if (Input.GetKey(sprintKey))
        {
            adjustedMovementSpeed += sprintIncrease;
        }
    }

    private void Crouching()
    {
        if (Input.GetKey(crouchKey))
        {
            charController.height = 1;
        }
        else
        {
            charController.height = 2;
        }


        if (Input.GetKey(crouchKey))
        {
            charController.height = 1;
            adjustedMovementSpeed -= crouchDecrease;
        }

    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
        else if (isJumping)
        {
            float horizInput = Input.GetAxis(horizontalInputName) * adjustedMovementSpeed;
            float vertInput = Input.GetAxis(verticalInputName) * adjustedMovementSpeed;

            Vector3 forwardMovement = transform.forward * vertInput;
            Vector3 rightMovement = transform.right * horizInput;

            charController.Move((forwardMovement + rightMovement) * Time.deltaTime);
        }
    }

   private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {

            

            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }

}
