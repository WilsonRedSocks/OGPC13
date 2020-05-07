using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class collectiblepositions : MonoBehaviour
{
    public List<Vector3> positions;

    public GameObject seed;

    public List<GameObject> seeds;
    
    void Start()
    {
        positions = positions.OrderBy(x => Random.value).ToList();
        for (int i = 0; i < 10; i++)
        {
            Instantiate(seed, positions[i], Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
