using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility
{
    public static Vector3 SetX(Vector3 vec, float v)
    {
        vec = new Vector3(v, vec.y, vec.z);
        return vec;
    }
    public static Vector3 SetY(Vector3 vec, float v)
    {
        vec = new Vector3(vec.x, v, vec.z);
        return vec;
    }
    public static Vector3 SetZ(Vector3 vec, float v)
    {
        vec = new Vector3(vec.x, vec.y, v);
        return vec;
    }

    public static float SnapValue(float v, float snapV, float range)
    {
        if (v < snapV + range && v > snapV - range) return snapV;
        return v;
    }
    public static float TowardZero(float v, float increment)
    {
        if (v < 0) return SnapValue(v + increment, 0, increment);
        if (v > 0) return SnapValue(v - increment, 0, increment);
        return 0;
    }

    public static float Slerp(float startValue, float endValue, float t)
    {
        return Mathf.Lerp(startValue, endValue, Mathf.Pow(t,2));
    }
}
