using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceController : MonoBehaviour
{
    public void ChangeScene(string sceneName) // Must be public
    {
        SceneManager.LoadScene(sceneName);
    }

}
