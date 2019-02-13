using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //Represents how fast we walk
    public float MovementSpeed = 3.0f;

    Vector2 mouseAbsolute;
    Vector2 smoothMouse;

    public Vector2 ClampInDegrees = new Vector2(360.0f, 180.0f);
    public Vector2 sensitivity = new Vector2(2, 2);
    public Vector2 smoothing = new Vector2(3, 3);

	// Use this for initialization
	void Start ()
    {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Get forward or back from the camera
        Vector3 Forward = transform.forward * Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime;

        //Get left or right from the camera
        Vector3 Right = transform.right * Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;

        //ensure we're always looking parallel to the ground
        Forward.y = 0;

        //apply the movement to the transform
        transform.position += Forward + Right;

        //Get which direction the mouse has moved since the last frame
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //Apply sensativity
        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));

        //Smooth out the mouse 
        smoothMouse.x = Mathf.Lerp(smoothMouse.x, mouseDelta.x, 1.0f / smoothing.x);
        smoothMouse.y = Mathf.Lerp(smoothMouse.y, mouseDelta.y, 1.0f / smoothing.y);

        //Apply the change in mouse position in comparison to last frame
        mouseAbsolute += smoothMouse;

        //Check for stupidness that we don't extend beyond 1 full rotation
        if (ClampInDegrees.x < 360)
        {

            //Clamp pitch (looking up and down)
            mouseAbsolute.x = Mathf.Clamp(mouseAbsolute.x, -ClampInDegrees.x * 0.5f, ClampInDegrees.x * 0.5f);
        }

        //Check for stupidness that we don't extend beyond 1 full rotation
        if (ClampInDegrees.y < 360)
        {
            //Clamp spinning around
            mouseAbsolute.y = Mathf.Clamp(mouseAbsolute.y, -ClampInDegrees.y * 0.5f, ClampInDegrees.y * 0.5f);
        }

        //Apply the rotation for pitch (looking up and down)
        transform.localRotation = Quaternion.AngleAxis(-mouseAbsolute.y, Vector3.right);

        //Apply the rotation for spinning
        Quaternion yRotation = Quaternion.AngleAxis(mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
        transform.localRotation *= yRotation;
	}
}
