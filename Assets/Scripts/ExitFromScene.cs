using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFromScene : MonoBehaviour
{
    [SerializeField] private string menuSceneName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync(menuSceneName);
        }
    }
}
