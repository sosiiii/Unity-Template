using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Optional<T>
{
    [field: SerializeField] public bool Enabled { get;}
    [field: SerializeField] public T Value { get; }

    public Optional(T initialValue)
    {
        Value = initialValue;
        Enabled = true;
    }
}
