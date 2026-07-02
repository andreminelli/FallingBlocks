using UnityEngine;

public static class BackgroundClipMask
{
    private static SpriteMask createdMask;
    private static Sprite maskSprite;

    public static void EnsureCreated()
    {
        if (createdMask != null)
        {
            return;
        }

        var scrollingBackground = Object.FindAnyObjectByType<BackgroundScrolling>();
        if (scrollingBackground == null)
        {
            return;
        }

        var backgroundRenderer = scrollingBackground.GetComponent<Renderer>();
        if (backgroundRenderer == null)
        {
            return;
        }

        var bounds = backgroundRenderer.bounds;
        var maskObject = new GameObject("BackgroundClipMask");
        maskObject.transform.position = bounds.center;
        maskObject.transform.localScale = new Vector3(bounds.size.x, bounds.size.y, 1f);

        createdMask = maskObject.AddComponent<SpriteMask>();
        createdMask.sprite = GetMaskSprite();
    }

    private static Sprite GetMaskSprite()
    {
        if (maskSprite != null)
        {
            return maskSprite;
        }

        var texture = new Texture2D(1, 1, TextureFormat.RGBA32, false);
        texture.SetPixel(0, 0, Color.white);
        texture.Apply();

        maskSprite = Sprite.Create(texture, new Rect(0f, 0f, 1f, 1f), new Vector2(0.5f, 0.5f), 1f);
        return maskSprite;
    }
}
