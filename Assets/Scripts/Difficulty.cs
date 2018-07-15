using UnityEngine;

public class Difficulty : MonoBehaviour {

    static float SecondsToMaxDifficulty = 20f;

    public static float GetDifficultyPercent()
        => Mathf.Clamp01(Time.timeSinceLevelLoad / SecondsToMaxDifficulty);
}
