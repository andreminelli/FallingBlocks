using UnityEngine;

public class Screen
{
    public static Vector2 HalfWorldUnits =>
        new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

    public static float TopWorldY =>
        Camera.main.transform.position.y + Camera.main.orthographicSize;

    // Returns world-space horizontal bounds for gameplay.
    // If a scrolling background renderer exists, clamp to its width to avoid drifting into side margins.
    public static Vector2 HorizontalWorldBounds
    {
        get
        {
            var mainCamera = Camera.main;
            if (mainCamera == null)
            {
                return Vector2.zero;
            }

            var centerX = mainCamera.transform.position.x;
            var halfWidth = mainCamera.aspect * mainCamera.orthographicSize;

            var scrollingBackground = Object.FindAnyObjectByType<BackgroundScrolling>();
            if (scrollingBackground != null)
            {
                var backgroundRenderer = scrollingBackground.GetComponent<Renderer>();
                if (backgroundRenderer != null)
                {
                    centerX = backgroundRenderer.bounds.center.x;
                    halfWidth = Mathf.Min(halfWidth, backgroundRenderer.bounds.extents.x);
                }
            }

            return new Vector2(centerX - halfWidth, centerX + halfWidth);
        }
    }
}
