using UnityEngine;

public class Difficulty : MonoBehaviour {

    static float SecondsToMaxDifficulty = 20f;

    public static bool SpawnEnabled { get; private set; } = true;

    public static float GetDifficultyPercent()
        => Mathf.Clamp01(Time.timeSinceLevelLoad / SecondsToMaxDifficulty);

    public static void EnableSpawn(bool enabled)
        => SpawnEnabled = enabled;
}
