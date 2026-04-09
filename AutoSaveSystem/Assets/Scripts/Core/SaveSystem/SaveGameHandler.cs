using UnityEngine;
using System.IO;
using Core.SaveSystem.Data; //используется файл struct

/// <summary>
/// Система загрузки и выгрузки данных через JSON
/// </summary>
public class SaveSystemJSON : MonoBehaviour
{
    private static string savePath => Application.persistentDataPath + "/save.json";

    // ==================== СОХРАНЕНИЕ (СЕРИАЛИЗАЦИЯ) ====================
    public static void SaveData(Transform robotTransform, float batteryCharge, bool[] completedTasks)
    {
        // Создаем объект с данными
        SaveDataJSON saveData = new SaveDataJSON();

        // Позиция
        saveData.positionX = robotTransform.position.x;
        saveData.positionY = robotTransform.position.y;
        saveData.positionZ = robotTransform.position.z;

        // Вращение
        saveData.rotationX = robotTransform.rotation.x;
        saveData.rotationY = robotTransform.rotation.y;
        saveData.rotationZ = robotTransform.rotation.z;
        saveData.rotationW = robotTransform.rotation.w;

        // Батарея и задачи
        saveData.batteryCharge = batteryCharge;
        saveData.completedTasks = completedTasks;

        // Сериализация: объект ? JSON ? файл
        string jsonString = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, jsonString);

        Debug.Log($"? Данные сохранены в JSON: {savePath}");
    }

    // ==================== ЗАГРУЗКА (ДЕСЕРИАЛИЗАЦИЯ) ====================
    public static SaveDataJSON LoadData()
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning("Файл сохранения не найден!");
            return null;
        }

        // Десериализация: файл ? JSON ? объект
        string jsonString = File.ReadAllText(savePath);
        SaveDataJSON saveData = JsonUtility.FromJson<SaveDataJSON>(jsonString);

        Debug.Log($"? Данные загружены из JSON: {savePath}");

        return saveData;
    }

    // Проверка наличия сохранения
    public static bool HasSave() => File.Exists(savePath);

    // Удаление сохранения
    public static void DeleteSave()
    {
        if (File.Exists(savePath)) File.Delete(savePath);
    }
}

/// <summary>
/// Класс для хранения данных (должен быть сериализуемым)
/// </summary>
[System.Serializable]
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
}