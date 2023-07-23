using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject obj;

    public Transform player;
    public float mouseSens = 2f;
    public float cameraVerticalRotation = 0f;
    bool lockedCursor = true;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;  
    }

    // Update is called once per frame
    void Update()
    {
        
        //Check mouse Input
        float inputX = Input.GetAxis("Mouse X")*mouseSens;
        float inputY = Input.GetAxis("Mouse Y") * mouseSens;
        //Rotate camera
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        //Y axis
        player.Rotate(Vector3.up * inputX);
        obj.transform.rotation = transform.rotation;
    }
}
