using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kuroneko.UtilityDelivery
{
    public static class StaticHelper
    {
        public static WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        public static RaycastHit2D emptyRaycastHit2D = new RaycastHit2D();
        
    private const float FPS = 24;

    public static void AddOnce<T>(this HashSet<T> list, T item)
    {
        if (item != null && !list.Contains(item))
            list.Add(item);
    }
    
    public static void AddOnce<T>(this List<T> list, T item)
    {
        if (item != null && !list.Contains(item))
            list.Add(item);
    }
    
    public static void SetActiveFast(this GameObject gameObject, bool active)
    {
        if (gameObject.activeSelf == active)
            return;

        gameObject.SetActive(active);
    }

    public static bool BelongsToLayerMask(this GameObject gameObject, LayerMask layerMask)
    {
        return ((1 << gameObject.layer) & layerMask) != 0;
    }

    public static T[] Copy<T>(this List<T> list)
    {
        if (list == null)
            return Array.Empty<T>();
        int count = list.Count;
        T[] array = new T[count];
        for (int i = 0; i < count; ++i)
            array[i] = list[i];
        return array;
    }

    public static float GetFrameInSeconds(int frame)
    {
        float frameSecond = 1 / FPS;
        return frame * frameSecond;
    }
    
    public static float GetFrameInSeconds(int frame, float sampleRate)
    {
        if (sampleRate == 0)
            return 0;
        float frameSecond = 1 / sampleRate;
        return frame * frameSecond;
    }

    public static void SetLayerRecursively(this GameObject gameObject, int layerMask)
    {
        gameObject.layer = layerMask;
        foreach (Transform child in gameObject.transform)
        {
            SetLayerRecursively(child.gameObject, layerMask);
        }
    }

    public static bool BelongsToLayerMask(int layer, int layerMask)
    {
        return (layerMask & (1 << layer)) > 0;
    }

    public static Vector3 DirectionToObject(this Transform transformA, Transform transformB)
    {
        return (transformB.position - transformA.position).normalized;
    }
    
    public static Vector3 DirectionToPoint(this Transform transform, Vector3 point)
    {
        return (point - transform.position).normalized;
    }
    
    public static float DistanceToObject(this Transform transformA, Transform transformB)
    {
        float distance = Vector3.Distance(transformA.position, transformB.position);
        return distance;
    }
    
    public static float DistanceToPoint(this Transform transform, Vector3 point)
    {
        float distance = Vector3.Distance(transform.position, point);
        return distance;
    }

    /// <summary>
    /// Draws a gizmo rectangle
    /// </summary>
    /// <param name="center">Center.</param>
    /// <param name="size">Size.</param>
    /// <param name="color">Color.</param>
    public static void DrawGizmoRectangle(Vector2 center, Vector2 size, Color color)
    {
        Gizmos.color = color;

        Vector3 v3TopLeft = new(center.x - size.x/2, center.y + size.y/2, 0);
        Vector3 v3TopRight = new(center.x + size.x/2, center.y + size.y/2, 0);
        Vector3 v3BottomRight = new(center.x + size.x/2, center.y - size.y/2, 0);
        Vector3 v3BottomLeft = new(center.x - size.x/2, center.y - size.y/2, 0);

        Gizmos.DrawLine(v3TopLeft,v3TopRight);
        Gizmos.DrawLine(v3TopRight,v3BottomRight);
        Gizmos.DrawLine(v3BottomRight,v3BottomLeft);
        Gizmos.DrawLine(v3BottomLeft,v3TopLeft);
    }

    /// <summary>
    /// Draws a debug ray in 2D and does the actual raycast
    /// </summary>
    /// <returns>The raycast hit.</returns>
    /// <param name="rayOriginPoint">Ray origin point.</param>
    /// <param name="rayDirection">Ray direction.</param>
    /// <param name="rayDistance">Ray distance.</param>
    /// <param name="mask">Mask.</param>
    /// <param name="color">Color.</param>
    /// <param name="drawGizmo">Draw gizmo or not</param>
    public static RaycastHit2D RayCast(Vector2 rayOriginPoint, Vector2 rayDirection, float rayDistance, LayerMask mask, Color color,bool drawGizmo=false)
    {	
        if (drawGizmo) 
        {
            Debug.DrawRay (rayOriginPoint, rayDirection * rayDistance, color);
        }
        return Physics2D.Raycast(rayOriginPoint,rayDirection,rayDistance,mask);		
    }
        public static int GetLayerMaskByName(string _layerName)
        {
            int layer = LayerMask.NameToLayer(_layerName);
            return 1 << layer;
        }
    } 
}
