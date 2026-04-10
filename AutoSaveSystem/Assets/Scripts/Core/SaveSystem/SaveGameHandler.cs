using UnityEngine;
using System.IO;
using Core.SaveSystem.Data;

namespace Core.SaveSystem
{
    /// <summary>
    /// Система загрузки и выгрузки данных через JSON
    /// </summary>
    public static class SaveGameHandler
    {
        private static string savePath => Application.persistentDataPath + "/save.json";

        // ==================== СОХРАНЕНИЕ (СЕРИАЛИЗАЦИЯ) ====================
        public static void SaveToFile(Struct saveData)
        {
            // Конвертируем Struct в SaveDataJSON
            SaveDataJSON jsonData = new SaveDataJSON();
            jsonData.positionX = saveData.robotPosition.x;
            jsonData.positionY = saveData.robotPosition.y;
            jsonData.positionZ = saveData.robotPosition.z;
            jsonData.rotationX = saveData.robotRotation.x;
            jsonData.rotationY = saveData.robotRotation.y;
            jsonData.rotationZ = saveData.robotRotation.z;
            jsonData.rotationW = saveData.robotRotation.w;
            jsonData.batteryCharge = saveData.batteryCharge;
            jsonData.completedTasks = saveData.completedTasks;
            jsonData.currentCheckpointIndex = saveData.currentCheckpointIndex;

            // Сериализация: объект → JSON → файл
            string jsonString = JsonUtility.ToJson(jsonData, true);
            File.WriteAllText(savePath, jsonString);

            Debug.Log($"Данные сохранены в JSON: {savePath}");
        }

        // ==================== ЗАГРУЗКА (ДЕСЕРИАЛИЗАЦИЯ) ====================
        public static Struct LoadFromFile()
        {
            if (!File.Exists(savePath))
            {
                Debug.LogWarning("Файл сохранения не найден!");
                return new Struct();
            }

            // Десериализация: файл → JSON → объект
            string jsonString = File.ReadAllText(savePath);
            SaveDataJSON jsonData = JsonUtility.FromJson<SaveDataJSON>(jsonString);

            // Конвертируем SaveDataJSON в Struct
            Struct saveData = new Struct();
            saveData.robotPosition = new Vector3(jsonData.positionX, jsonData.positionY, jsonData.positionZ);
            saveData.robotRotation = new Quaternion(jsonData.rotationX, jsonData.rotationY, jsonData.rotationZ, jsonData.rotationW);
            saveData.batteryCharge = jsonData.batteryCharge;
            saveData.completedTasks = jsonData.completedTasks;
            saveData.currentCheckpointIndex = jsonData.currentCheckpointIndex;

            Debug.Log($"Данные загружены из JSON: {savePath}");

            return saveData;
        }

        // Проверка наличия сохранения
        public static bool HasSave() => File.Exists(savePath);

        // Удаление сохранения
        public static void DeleteSave()
        {
            if (File.Exists(savePath)) 
                File.Delete(savePath);
        }
    }
}