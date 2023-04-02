using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {
    [SerializeField] TMP_Text scoreDisplay;

    public static ScoreManager instance;
    public int score { get; private set; } = 0;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        UpdateScoreDisplay();
    }

    public void AddScore(int score) {
        this.score += score;

        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay() {
        scoreDisplay.text = score.ToString();
    }
}
