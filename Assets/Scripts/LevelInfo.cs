using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="levelinfo", menuName ="Create Level Info")]
public class LevelInfo : ScriptableObject {
    public string stageName;
    public string imageURI;
    public int scoreToUnlock;
}
