using System.Threading;
using UnityEngine;

public class Look : MonoBehaviour
{
    //crosshair
    public Texture2D crosshair;

    //menu
    public menu_script menu;
    public GameObject pausemenu;
    public GameObject hud;

    //create player object
    public CharacterController player;

    //define the x axis variable
    private float Xaxis = 0;

    //create the player vector3
    Vector3 rotation = new Vector3(0, 0, 0);

    //start function
    void Start()
    {
        //lock the mouse cursor to center screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.SetCursor(crosshair, new Vector2(16, 16), CursorMode.ForceSoftware);
    }

    void Update()
    {
        //menu check
        if (Input.GetKey(KeyCode.Escape))
        {
            pausemenu.SetActive(true);
            hud.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            menu.open();
        }
        //create the float for the mouse x axis
        Xaxis += Input.GetAxis("Mouse X");

        //update the player vector3
        rotation.y = Xaxis;

        //add the x axis rotation to the player
        player.transform.rotation = Quaternion.Euler(0, Xaxis, 0); //this sets the players heading in order to match the camera code
    }
}
