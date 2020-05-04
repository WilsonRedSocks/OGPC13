using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectibles : MonoBehaviour
{
    [SerializeField]public static int seedscollected;
    public Camera cam;
    public Text seedscollectedtext;

    public void Update()
    {
        if (Input.GetButton("Use"))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100f))
            {
                GameObject objecthit = hit.transform.gameObject;
                if (objecthit.tag == "Seed")
                {
                    Destroy(objecthit);
                    seedscollected++;
                    seedscollectedtext.text = seedscollected.ToString();
                }
            }
        }
    }
}
