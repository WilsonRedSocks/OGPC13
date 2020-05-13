using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class collectiblepositions : MonoBehaviour
{
    public List<Vector3> positions;

    public GameObject seed;

    public List<GameObject> seeds;

    
    void Awake()
    {
        DontDestroyOnLoad(transform.root.gameObject);
        positions = positions.OrderBy(x => Random.value).ToList();
        for (int i = 0; i < 10; i++)
        {
            Instantiate(seed, positions[i], Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
