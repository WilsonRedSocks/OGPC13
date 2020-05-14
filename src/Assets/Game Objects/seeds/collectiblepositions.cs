using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;

public class collectiblepositions : MonoBehaviour
{
    public GameObject seed;

    public List<Vector3> seeds;

    void Awake()
    {
        //gameObject.tag = "seed creator";
        //positions = positions.OrderBy(x => 5).ToList();
        for (int i = 0; i < 10; i++)
        {
            Instantiate(seed, seeds[i], Quaternion.identity);
        }

    }
}