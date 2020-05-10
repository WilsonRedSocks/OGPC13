using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //create the public transforms
    public Transform player;
    public new Transform camera;

    //create camera
    public Camera maincamera;

    //create the current x value
    private float currentx = 0f;

    //create the current y value
    private float currenty = 0f;

    //create the camera direction from the player
    private Vector3 direction;
    public Vector3 firstPerson;
    public Vector3 headAndShoulders;
    public Vector3 fullBody;

    //create the camera position
    private Vector3 cameraraydirection;
    private float cameradist;

    //create the quaternion for the rotation addition to the camera after pointing where the player points
    private Quaternion addrot = Quaternion.Euler(0, 0, 0);

    //create the camera shoulder variable
    bool rightcam = false;
    
    //run at start
    private void Start()
    {
        //define the transform as the camera
        camera = transform;
        //define the main camera
        maincamera = Camera.main;
        //flip the z distance of the camera
        direction.z *= -1f;
        headAndShoulders.z *= -1f;
        fullBody.z *= -1f;
        firstPerson.z *= -1f;
        //set direction
        direction = firstPerson;
        //flip the x distance of the camera if on right shoulder
        if (rightcam)
            direction.x *= -1;
        //define the camera distance from the player
        cameradist = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
        cameradist = Mathf.Sqrt(cameradist * cameradist + direction.z * direction.z);
    }

    //function for the axis updates
    public void Update()
    {
        if(Time.timeScale != 0f)
        {
            currentx += Input.GetAxis("Mouse X");//add the delta mouse movement to currentx
            currenty += Input.GetAxis("Mouse Y");//add the delta mouse movement to currenty
            currenty = Mathf.Clamp(currenty, -20, 60);
            addrot = Quaternion.Euler(-currenty, 0, 0);
            //camerachange();
        }
    }

    //update for camera movement
    public void LateUpdate()
    {
        if(Time.timeScale != 0)
        {
            //quaternion for the rotation of the camera
            Quaternion rotation = Quaternion.Euler(-currenty, currentx, 0);
            //position the camera
            camera.position = player.position + rotation * direction; //this sets the camera position as opposed to moving the camera which will make adding an offset easier
            //camera faces the same direction as the player
            camera.rotation = player.rotation * addrot; //this approach to coding will work better than lookat because the axis will always be parallel to the player
        }
    }
    /*
    //create a function that checks for a camera mode change
    public void camerachange()
    {
        //set the camera change clock
        if(Input.GetButtonDown("Camera Change"))
        {
            Debug.Log("switch");
            if (direction == firstPerson)
            {
                direction = headAndShoulders;
            }
            else if(direction == headAndShoulders)
            {
                direction = fullBody;
                maincamera.fieldOfView = 50f;
            }
            else
            {
                direction = firstPerson;
                maincamera.fieldOfView = 30f;
            }
        }
    }/**/
}