using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TouchTrail : MonoBehaviour
{

    private InputManager _inputManager;
    private Camera _camera;

    private LineRenderer _lineRenderer;


    private Coroutine _fingerDownCoroutine;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
        _camera = Camera.main;

        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    private void OnEnable()
    {
        _inputManager.OnStartTouch += ShowLineStart; 
        _inputManager.OnEndTouch += ShowLineEnd;
    }
    private void OnDisable()
    {
        _inputManager.OnStartTouch -= ShowLineStart; 
        _inputManager.OnEndTouch -= ShowLineEnd;
    }

    private void ShowLineStart(Vector2 worldPosition, float arg2)
    {
        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, worldPosition);

        _fingerDownCoroutine = StartCoroutine(nameof(ShowLine));
    }
    private void ShowLineEnd(Vector2 worldPosition, float arg2)
    {
        _lineRenderer.SetPosition(1, worldPosition);
        
        StopCoroutine(_fingerDownCoroutine);
        
        _lineRenderer.enabled = false;
    }
    private IEnumerator ShowLine()
    {
        while (true)
        {
            _lineRenderer.SetPosition(1, _inputManager.TouchPosition);
            yield return null;
        }
    }
}
