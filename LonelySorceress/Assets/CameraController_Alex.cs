using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_Alex : MonoBehaviour
{
    Vector2 mouseLook; //stores where the mouse is currently looking at
    Vector2 smoothVector;

    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject character;

    void Start()
    {
        character = this.transform.parent.gameObject;
    }
 
    void Update()
    {
        RotateCamera();

    }

    void RotateCamera()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing)); // multiplies mouseDelta with sensitivity + smoothing

        smoothVector.x = Mathf.Lerp(smoothVector.x, mouseDelta.x, 1f / smoothing);
        smoothVector.y = Mathf.Lerp(smoothVector.y, mouseDelta.y, 1f / smoothing);

        mouseLook += smoothVector;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -80f, 80f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);


    }
}

