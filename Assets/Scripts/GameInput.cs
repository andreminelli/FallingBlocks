using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public static class GameInput
{
    private const float GamepadDeadzone = 0.2f;

    public static float GetHorizontalMovement()
    {
#if ENABLE_INPUT_SYSTEM
        float keyboardAxis = 0f;
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            if (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed)
            {
                keyboardAxis -= 1f;
            }

            if (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed)
            {
                keyboardAxis += 1f;
            }
        }

        var gamepad = Gamepad.current;
        var gamepadAxis = gamepad != null ? gamepad.leftStick.ReadValue().x : 0f;
        if (Mathf.Abs(gamepadAxis) < GamepadDeadzone)
        {
            gamepadAxis = 0f;
        }

        return Mathf.Clamp(keyboardAxis + gamepadAxis, -1f, 1f);
#else
        return Input.GetAxisRaw("Horizontal");
#endif
    }

    public static bool WasRestartPressedThisFrame()
    {
#if ENABLE_INPUT_SYSTEM
        var keyboardPressed = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
        var gamepadPressed = Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame;
        return keyboardPressed || gamepadPressed;
#else
        return Input.GetKeyDown(KeyCode.Space);
#endif
    }
}
