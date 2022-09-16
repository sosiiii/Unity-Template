using System.Collections;
using UnityEngine;

public static class MonoBehaviorExtensions
{
    public static CoroutineHandle RunCoroutine(this MonoBehaviour owner, IEnumerator coroutine)
    {
        return new CoroutineHandle(owner, coroutine);
    }
}