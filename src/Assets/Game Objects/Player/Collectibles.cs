using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    [SerializeField]public static int seedscollected;
    public Camera cam;
    public Text seedscollectedtext;
    public Texture2D pointer;
    
    public void Update()
    {
        if (Input.GetButton("Use"))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 10f))
            {
                GameObject objecthit = hit.transform.gameObject;
                if (objecthit.tag == "Seed")
                {
                    Destroy(objecthit);
                    seedscollected++;
                }
            }
        }
        seedscollectedtext.text = seedscollected.ToString();
        if (seedscollected >= 10)
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.ForceSoftware);
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(3);
        }
    }
}
