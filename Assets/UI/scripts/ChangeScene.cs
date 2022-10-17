using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void LoadScene(string TargetScene)
    {
        SceneManager.LoadScene(TargetScene, LoadSceneMode.Single);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
