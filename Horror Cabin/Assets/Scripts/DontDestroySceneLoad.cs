using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySceneLoad : MonoBehaviour {
    void Awake() => DontDestroyOnLoad(gameObject);
}
