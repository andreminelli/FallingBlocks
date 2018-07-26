using UnityEngine;

public class Screen
{
    public static Vector2 HalfWorldUnits =>
        new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
}
