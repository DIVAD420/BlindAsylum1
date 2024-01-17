using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellcoliderscript : MonoBehaviour
{



    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent(typeof(BoxCollider)); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
