using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Struct
{
    public Vector3 position;
    public Quaternion rotation;
    public float batteryLevel;
    public List<string> completedTasks;

    public Struct()
    {
        position = Vector3.zero;
        rotation = Quaternion.identity;
        batteryLevel = 100f;
        completedTasks = new List<string>();
    }
}