using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;
    [SerializeField] private GameObject projectile;
    [SerializeField] private KeyCode shootKey;
    [SerializeField] private AOEIndicator aoeIndicatorScript;
    [SerializeField] private GameObject DecalProjector;

    private float xAxisClamp;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
        Shooting();
        if (Input.GetKey(KeyCode.Q))
        {
            AOE();
        }
        else
        {
            //DecalProjector.SetActive(false);
        }
    }

    private void AOE()
    {
        //DecalProjector.SetActive(true);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            aoeIndicatorScript.AOE(hit);
        }
        
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }


    private void Shooting()
    {
        if (Input.GetKeyDown(shootKey))
        {
            GameObject newObject = Instantiate(projectile);
            newObject.transform.rotation = transform.rotation;
            newObject.transform.position = transform.position + transform.forward;
            
        }
    }
}
