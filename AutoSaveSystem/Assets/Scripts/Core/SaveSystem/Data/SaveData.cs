using System;
using UnityEngine;

namespace Core.SaveSystem.Data
{
    /// <summary>
    /// Класс для JSON сериализации
    /// </summary>
    [Serializable]
    public class SaveDataJSON
    {
        public float positionX;
        public float positionY;
        public float positionZ;

        public float rotationX;
        public float rotationY;
        public float rotationZ;
        public float rotationW;

        public float batteryCharge;
        public bool[] completedTasks;
        public int currentCheckpointIndex;
    }
}