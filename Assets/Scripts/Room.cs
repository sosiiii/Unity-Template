using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Room : MonoBehaviour, ISelectable
{
    public void Select()
    {
        Debug.Log("Selected: " + gameObject.name);
    }
}
