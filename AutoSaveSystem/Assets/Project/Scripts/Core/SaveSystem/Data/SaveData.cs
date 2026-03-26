using System;
using UnityEngine;

namespace AutoSaveSystem.Core.SaveSystem.Data
{
    [Serializable]
    public class SaveData
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public float BatteryCharge;
        public QuestProgressData[] QuestProgress;
        public string LastCheckpointID;
        public DateTime SaveTime;
    }

    [Serializable]
    public class QuestProgressData
    {
        public string QuestID;
        public bool IsCompleted;
        public int CurrentStage;
    }
}