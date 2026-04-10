using System;
using UnityEngine;

namespace Core.SaveSystem.Data
{
    /// <summary>
    /// Структура для хранения всех сохраняемых данных
    /// </summary>
    [Serializable]
    public struct Struct
    {
        // Позиция робота
        public Vector3 robotPosition;
        
        // Вращение робота
        public Quaternion robotRotation;
        
        // Заряд батареи
        public float batteryCharge;
        
        // Выполненные задания (квесты)
        public bool[] completedTasks;
        
        // Текущий активный чекпоинт
        public int currentCheckpointIndex;
        
        // Дополнительные данные можно добавлять по мере необходимости
    }
}