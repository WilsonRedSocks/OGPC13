using UnityEngine;

public class Look : MonoBehaviour
{
    //crosshair
    public Texture2D crosshair;

    //create player object
    public CharacterController player;

    //define the x axis variable
    private float Xaxis = 0;

    //main menu
    public GameObject pause;
    public GameObject hud;

    //create the player vector3
    Vector3 rotation = new Vector3(0, 0, 0);

    //start function
    void Start()
    {
        //lock the mouse cursor to center screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.ForceSoftware);
    }

    void Update()
    {
        //menu check
        if(Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("test");
            pause.SetActive(true);
            hud.SetActive(false);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        //create the float for the mouse x axis
        Xaxis += Input.GetAxis("Mouse X");

        //update the player vector3
        rotation.y = Xaxis;

        //add the x axis rotation to the player
        player.transform.rotation = Quaternion.Euler(0, Xaxis, 0); //this sets the players heading in order to match the camera code
    }
}
