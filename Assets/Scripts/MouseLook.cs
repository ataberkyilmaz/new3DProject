using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float Yrotation = 0f;
    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        Yrotation -= mouseY;
        Yrotation = Mathf.Clamp(Yrotation, -90f, 90f);
        
        //moving camera up and down 
        transform.localRotation = Quaternion.Euler(Yrotation,0f,0f);
        
        //moving body right to left
        playerBody.Rotate(Vector3.up * mouseX);
        
    }
}
