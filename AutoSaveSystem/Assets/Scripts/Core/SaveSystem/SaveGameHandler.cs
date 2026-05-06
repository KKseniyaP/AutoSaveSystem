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
			string jsonString = JsonUtility.ToJson(saveData, true);
			File.WriteAllText(savePath, jsonString);
			Debug.Log($"Данные сохранены: {savePath}");
		}

        // ==================== ЗАГРУЗКА (ДЕСЕРИАЛИЗАЦИЯ) ====================
        public static Struct LoadFromFile()
		{
			if (!File.Exists(savePath))
			{
				Debug.Log("Файл сохранения не найден");
				return new Struct();
			}

			string jsonString = File.ReadAllText(savePath);
			Struct saveData = JsonUtility.FromJson<Struct>(jsonString);
			Debug.Log($"Данные загружены: {savePath}");
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