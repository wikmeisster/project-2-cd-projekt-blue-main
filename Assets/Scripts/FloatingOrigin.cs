// FloatingOrigin.cs
// Written by Peter Stirling
// 11 November 2010
// Uploaded to Unify Community Wiki on 11 November 2010
// Updated to Unity 5.x particle system by Tony Lovell 14 January, 2016
// fix to ensure ALL particles get moved by Tony Lovell 8 September, 2016
// URL: http://wiki.unity3d.com/index.php/Floating_Origin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Camera))]
public class FloatingOrigin : MonoBehaviour
{
    [SerializeField] private float threshold = 100.0f;
    [SerializeField] private LevelLayoutGenerator layoutGenerator;

    void LateUpdate()
    {
        Vector3 cameraPosition = gameObject.transform.position;
        cameraPosition.y = 0f;

        if (cameraPosition.magnitude > threshold)
        {

            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                foreach (GameObject g in SceneManager.GetSceneAt(i).GetRootGameObjects())
                {
                    g.transform.position -= cameraPosition;
                }
            }

            Vector3 originDelta = Vector3.zero - cameraPosition;
            layoutGenerator.updateSpawnOrigin(originDelta);
            Debug.Log("recentering, origin delta = " + originDelta);
        }

    }
}
