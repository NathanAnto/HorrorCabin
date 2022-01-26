using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Speeches
{
    public static int missionIndex { get; private set; }

    public static void UpdateIndex() {
        missionIndex++;
    }
}
