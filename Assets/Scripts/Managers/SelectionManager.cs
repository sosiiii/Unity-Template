using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private InputManager _inputManager;
    [SerializeField, Range(0.1f,1f)] private float selectionRadius;
    
    private void Awake()
    {
        _inputManager = InputManager.Instance;
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

    private void ShowLineStart(Vector2 worldPosition, float timeStarted)
    {
        var selectable = GetSelectable(worldPosition);
        selectable?.Select();
    }

    private void ShowLineEnd(Vector2 worldPosition, float timeEnded)
    {
        var selectable = GetSelectable(worldPosition);
        selectable?.Select();
    }

    private ISelectable GetSelectable(Vector2 position)
    {
        var collider = Physics2D.OverlapCircle(position, selectionRadius);
        if (collider == null) return null;
        
        if(!collider.TryGetComponent(out ISelectable selectable))
            return null;
        return selectable;
    }
}
