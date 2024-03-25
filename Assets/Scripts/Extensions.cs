using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static T GetRandomValue<T>(this T[] arr)
    {
        int randomValue = Random.Range(0, arr.Length);
        return arr[randomValue];
    }
    
    public static T GetRandomValue<T>(this List<T> list)
    {
        int randomValue = Random.Range(0, list.Count);
        return list[randomValue];
    }
}