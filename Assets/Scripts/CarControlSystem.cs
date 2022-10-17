using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class CarControlSystem : MonoBehaviour
{
    [SerializeField] public WheelCollider[] frontWheelsColliders;
    [SerializeField] public WheelCollider[] backWheelsColliders;
    [SerializeField] public GameObject[] frontWheelInstances;
    [SerializeField] public GameObject[] backWheelInstances;
    [SerializeField] private float steerPower = 50;
    private Rigidbody car;
    private float motorTorque;
    private float airDrag;

    private void Start()
    {
        car = GetComponent<Rigidbody>();
        car.centerOfMass = new Vector3(car.centerOfMass.x, car.centerOfMass.y - 0.5f, car.centerOfMass.z);
        for (int i = 0; i < frontWheelsColliders.Length; i++)
        {
            Vector3 position;
            Quaternion rotation;
        }

        for (int i = 0; i < backWheelsColliders.Length; i++)
        {
            Vector3 position;
            Quaternion rotation;
        }
    }


    void FixedUpdate()
    {
        SpeedLimitControl(150);

        //front wheel control 
        for (int i = 0; i < frontWheelsColliders.Length; i++)
        {
            frontWheelsColliders[i].steerAngle = Input.GetAxis("Horizontal") * steerPower;
        }

        // backWheel control 
        for (int i = 0; i < backWheelsColliders.Length; i++)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                backWheelsColliders[i].motorTorque = motorTorque * 5;
                car.drag = 0.01f;
            }
            else
            {
                backWheelsColliders[i].motorTorque = motorTorque;
            }
        }
    }


    void SpeedLimitControl(float limit)
    {
        float speed = car.velocity.magnitude * 3.6f;

        if (speed >= 150f)
        {
            car.drag = 0.5f;
            motorTorque = 0;
        }
        else
        {
            car.drag = 0.01f;
            motorTorque = 1000;
        }
    }
}