using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{

    private InputControls _touchControl;
    private Camera _camera;

    public Action<Vector2, float> OnStartTouch;
    public Action<Vector2, float> OnTouchPressed;
    public Action<Vector2, float> OnEndTouch;
    
    
    public Vector2 TouchPosition => Utilities.ScreenToWorld(_touchControl.Touch.TouchPosition.ReadValue<Vector2>(), _camera);


    private void Awake()
    {
        _touchControl = new InputControls();
        _camera = Camera.main;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        TouchSimulation.Enable();
        _touchControl.Enable();
    }

    private void OnDisable()
    {
        TouchSimulation.Disable();
        _touchControl.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        _touchControl.Touch.TouchPress.started += ctx => StartTouch(ctx);
        _touchControl.Touch.TouchPress.performed += ctx => PressedTouch(ctx);
        _touchControl.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }
    private void StartTouch(InputAction.CallbackContext ctx)
    {
        OnStartTouch?.Invoke(TouchPosition, (float)ctx.startTime);
    }
    private void PressedTouch(InputAction.CallbackContext ctx)
    {
        OnTouchPressed?.Invoke(TouchPosition, (float)ctx.time);
    }
    private void EndTouch(InputAction.CallbackContext ctx)
    {
        OnEndTouch?.Invoke(TouchPosition, (float)ctx.time);
    }
}
