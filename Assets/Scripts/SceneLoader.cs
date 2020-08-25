using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameOverScene() {
        SceneManager.LoadScene(1);
    }

    public void LoadGameplayScene() {
        SceneManager.LoadScene(0);
    }
}
