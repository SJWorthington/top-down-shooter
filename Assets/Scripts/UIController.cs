using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreField;
    [SerializeField] TextMeshProUGUI healthField;
    [SerializeField] TextMeshProUGUI newWaveHeadingField;
    [SerializeField] TextMeshProUGUI newWaveCounterField;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerStatus.onHealthChanged += updateHealthField;
        ScoreController.OnScoreChanged += updateScoreField;
    }

    private void updateHealthField(int health) {
        healthField.text = health.ToString();
    }

    private void updateScoreField(int score) {
        scoreField.text = score.ToString();
    }
}
