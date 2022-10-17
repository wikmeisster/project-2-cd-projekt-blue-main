using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class TurretControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Texture2D mouseCursor;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Transform Turret;
    [SerializeField] private Camera mainCamera;
    private Time time;

    void Start()
    {
        // Set gun turret cursor
        Vector2 hotSpot = new Vector2(64 / 2f, 64 / 2f);
        CursorMode cursorMode = CursorMode.Auto;
        Cursor.SetCursor(mouseCursor, hotSpot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPos;
            if (Physics.Raycast(mouseRay, out RaycastHit raycastHit))
            {
                worldPos = raycastHit.point;
                Shot(worldPos);
            }
        }
    }

    private void Shot(Vector3 worldPos)
    {
        GameObject bulletTrans = Instantiate(prefabBullet, Turret.position, Turret.rotation);

        bulletTrans.GetComponent<Rigidbody>()
            .AddForce((worldPos - bulletTrans.transform.position).normalized * 100);
    }
}