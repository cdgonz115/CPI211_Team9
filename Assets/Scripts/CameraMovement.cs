using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private string xInput, yInput;
    [SerializeField] private float mouseSensitivity;

    private float xClamp;
    [SerializeField] private Transform player;

    CursorLockMode locked = CursorLockMode.Locked;
    CursorLockMode free = CursorLockMode.None;

    // Use this for initialization
    void Start()
    {

    }
    private void Awake()
    {
        LockCursorToCenter();
        xClamp=0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }
    private void LockCursorToCenter()
    {
        Cursor.lockState = locked;
    }
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(xInput) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(yInput) * mouseSensitivity * Time.deltaTime;

        xClamp += mouseY;

        if (xClamp > 90.0f)
        {
            xClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xClamp < -90.0f)
        {
            xClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        player.Rotate(Vector3.up * mouseX);
    }
    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
