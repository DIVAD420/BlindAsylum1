using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBottleItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Used Pills");
            Destroy(gameObject);
        }
    }
}
