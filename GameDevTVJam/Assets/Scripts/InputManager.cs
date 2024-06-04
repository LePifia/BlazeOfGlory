#define USE_NEW_INPUT_SYSTEM
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance { get; private set; }

    private PlayerInputAction inputActions;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one InputManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        inputActions = new PlayerInputAction();
        inputActions.Player.Enable();
    }


    public Vector2 GetMouseScreenPosition()
    {
#if USE_NEW_INPUT_SYSTEM
        return Mouse.current.position.ReadValue();
#else
        return Input.mousePosition;
#endif
    }

    public bool IsMouseButtonDownThisFrame()
    {
#if USE_NEW_INPUT_SYSTEM
        return inputActions.Player.Click.WasPressedThisFrame();
#else
        return Input.GetMouseButtonDown(0);
#endif
    }

    public bool IsMButtonDownThisFrame()
    {
#if USE_NEW_INPUT_SYSTEM
        return inputActions.Player.OpenMenu.WasPressedThisFrame();

#else
        Input.GetKeyDown(KeyCode.M);
#endif
    }

 


}

