using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsViewableScript : MonoBehaviour
{
    public Transform Mesh;

    int canSeeLayer = 8;
    int cantSeeLayer = 9;

    public float rememberingTimer = 3f;

    float StopSeeingTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mesh.gameObject.layer == canSeeLayer)
        {
            if(Time.time > StopSeeingTime)
            {
                changeLayer(cantSeeLayer);
            }
        }
    }

    public void CanBeSeen()
    {
        changeLayer(canSeeLayer);
        StopSeeingTime = rememberingTimer + Time.time;
    }
    void changeLayer(int layer)
    {
        Mesh.gameObject.layer = layer;
        foreach (Transform child in Mesh)
        {
            child.gameObject.layer = layer;
        }
    }
}
