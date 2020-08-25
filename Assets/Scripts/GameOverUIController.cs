using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreField;
    //[SerializeField] ScoreController scoreController;


    // Start is called before the first frame update
    void Start()
    {
        var score = ScoreController.GetInstance().playerScore;
        scoreField.text = $"Final Score: {score}";
        ScoreController.GetInstance().resetScoreToZero();
    }
}
