using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 worldPos;
        if (Physics.Raycast(mouseRay, out RaycastHit raycastHit))
        {
            worldPos = raycastHit.point;
            transform.position = worldPos;
            Debug.Log(worldPos);
        }
    }
}