using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    static ScoreController Instance;

    private int _playerScore;

    public int playerScore {
        get { return _playerScore; }
        private set {
            _playerScore = value;
            Debug.Log($"Score is {value}");
            OnScoreChanged?.Invoke(_playerScore);
        }
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        playerScore = 0;
    }

    public static ScoreController GetInstance() {
        return Instance;
    }

    public int getScore() {
        return playerScore;
    }

    //Need to make this a locked function / queue up a stream for it
    //Odds of race conditions are very, very slim, but non-zero
    public void addToPlayerScore(int valueToAdd) {
        playerScore += valueToAdd;
    }

    public void resetScoreToZero() {
        playerScore = 0;
    }

    public static event Action<int> OnScoreChanged;
}
