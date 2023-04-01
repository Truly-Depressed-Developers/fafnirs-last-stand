using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelSelectionManager : MonoBehaviour {
    [SerializeField] GameObject _levelDisplayPrefab;
    [SerializeField] GameObject _levelSelectionContentPane;
    [SerializeField] List<LevelInfo> _levels;

    void Start() {
        foreach(LevelInfo level in _levels) {
            GameObject levelDisplay = Instantiate(_levelDisplayPrefab);
            TMP_Text name = levelDisplay.transform.GetChild(0).GetComponent<TMP_Text>();
            Image preview = levelDisplay.transform.GetChild(1).GetComponent<Image>();
            TMP_Text hiScore = levelDisplay.transform.GetChild(2).GetComponent<TMP_Text>();

            name.text = level.name;
            hiScore.text = $"Score to unlock: {level.scoreToUnlock}";

            levelDisplay.transform.parent = _levelSelectionContentPane.transform;
        }
    }
}
