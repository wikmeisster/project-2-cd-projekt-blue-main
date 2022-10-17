using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExit : MonoBehaviour
{
    public float delay = 5f;
    
    public delegate void ExitAction();
    public static event ExitAction OnSectionExited;

    private bool exited = false;

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("nnn");
        if (other.tag == "Car")
        {
            
            if (!exited)
            {
                exited = true;
                OnSectionExited();
                StartCoroutine(WaitAndDeactivate());
            }


        }
    }

    IEnumerator WaitAndDeactivate()
    {
        yield return new WaitForSeconds(delay);

        Destroy(transform.root.gameObject);

    }
}
