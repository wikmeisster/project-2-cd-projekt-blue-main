using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SpeedCalculation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Text text;
    [SerializeField] private Rigidbody car;

    [SerializeField] private float radius;

    private float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        float speed = car.velocity.magnitude * 3.6f;
        text.text = "Speed: " + speed + " Km/h";
        if (Input.GetKey(KeyCode.Space))
        {
            text.text += " Boosting!";
        }
    }
}