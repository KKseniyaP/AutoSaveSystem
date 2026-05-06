using System;
using UnityEngine;

namespace Core.SaveSystem.Data
{
    /// <summary>
    /// Класс для хранения всех сохраняемых данных
    /// </summary>
    [Serializable]
    public class Struct  // ← было struct, стало class
    {
        public Vector3 robotPosition;
        public Quaternion robotRotation;
        public float batteryCharge;
        public bool[] completedTasks;
        public int currentCheckpointIndex;
    }
}