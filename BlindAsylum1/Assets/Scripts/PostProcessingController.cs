using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    public PostProcessVolume postProcessingVolume;
    void Start()
    {
        postProcessingVolume.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
