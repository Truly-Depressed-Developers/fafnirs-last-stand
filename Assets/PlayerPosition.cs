using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerPosition : MonoBehaviour
{
    public static PlayerPosition Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
}
