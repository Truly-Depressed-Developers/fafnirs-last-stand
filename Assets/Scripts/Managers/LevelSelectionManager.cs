using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour {
    [SerializeField] GameObject _levelDisplayPrefab;
    [SerializeField] GameObject _levelSelectionContentPane;
    [SerializeField] List<LevelInfo> _levels;

    void Awake() {
        foreach(LevelInfo level in _levels) {
            GameObject levelDisplay = Instantiate(_levelDisplayPrefab);
            TMP_Text name = levelDisplay.transform.GetChild(0).GetComponent<TMP_Text>();
            Image preview = levelDisplay.transform.GetChild(1).GetComponent<Image>();
            TMP_Text hiScore = levelDisplay.transform.GetChild(2).GetComponent<TMP_Text>();

            name.text = level.name;
            preview.sprite = level.sprite;
            hiScore.text = $"High score: {level.scoreToUnlock}";

            levelDisplay.transform.parent = _levelSelectionContentPane.transform;
        }
    }

    public void LoadLevel() {
        SceneManager.LoadScene(1);
    }
}
