using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    
    void Start()
    {
        PlayerStatus.onHealthChanged += gameOverCheck;
    }

    private void gameOverCheck(int health) {
        if (health <= 0) {
            sceneLoader.LoadGameOverScene();
        }
    }
}
