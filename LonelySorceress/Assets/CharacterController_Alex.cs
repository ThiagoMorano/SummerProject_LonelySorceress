using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_Alex : MonoBehaviour
{
    public float speed = 10.0f;

    public float jumpForce = 100.0f;
    bool isGrounded = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //forwards/backwards

        float translation = Input.GetAxis("Vertical") * speed;

        //left/right
        float straffe = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
            

    }
}
