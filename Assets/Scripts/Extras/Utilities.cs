using UnityEngine;

public static class Utilities
{
    public static Vector2 ScreenToWorld(Vector3 screenPosition, Camera camera)
    {
        screenPosition.z = camera.nearClipPlane;
        return camera.ScreenToWorldPoint(screenPosition );
    }
}
