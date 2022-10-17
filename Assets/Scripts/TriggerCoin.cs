using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCoin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
        if (other.tag == "Car")
        {
            
            Destroy(gameObject);


        }
    }
}
