using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMode : MonoBehaviour
{
    public float touchRadius;

    public LayerMask findableLayerMask;

    public Transform touchCentre;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] viewableObjects = Physics.OverlapSphere(touchCentre.position, touchRadius, findableLayerMask);

        for(int i = 0; i < viewableObjects.Length; i++)
        {
            if(viewableObjects[i].GetComponent<IsViewableScript>() != null)
            {
                viewableObjects[i].GetComponent<IsViewableScript>().CanBeSeen();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(touchCentre.position, touchRadius);
    }
}
