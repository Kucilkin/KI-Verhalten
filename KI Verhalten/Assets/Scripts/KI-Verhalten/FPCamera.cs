using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCamera : MonoBehaviour
{
    public float MouseSensitivity;  //Mouse Sensitivity. The higher the faster the Camera Movement

    public Transform PlayerRotation;    //Transform of Player. Important for getting their rotation

    private float mouseX;   //Horizontal mouse variable
    private float mouseY;   //vertical mouse variable
    private float verticalRotation; //Rotation value for vertcal Movement

    void Update()
    {
        CameraRotation();   //Constantly adjusts Camera rotation
    }

    /// <summary>
    /// Method responsible for adjusting Camera rotation
    /// </summary>
    public void CameraRotation()
    {
        mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;   /*Gets mouse input on X and Y Axis and multiplies it with sensitivity
                                                                 Saves it to its variable afterwards*/
        mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        verticalRotation -= mouseY;     //Decrementing Vertical Rotation Value because incrementing inverts Movement
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 90f);
        transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0); //Setting the Rotation on Y Axis (Player shouldn't rotate here)

        PlayerRotation.Rotate(Vector3.up * mouseX);     //Setting Rotation on X Axis (Player should be turning as well)
    }
}
