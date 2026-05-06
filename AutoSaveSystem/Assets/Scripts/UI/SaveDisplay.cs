using UnityEngine;
using UnityEngine.UI;
using Core.SaveSystem;
using Core.SaveSystem.Data;
using TMPro; 

public class SaveDisplay : MonoBehaviour
{
    [Header("UI элементы")]
    public TextMeshProUGUI saveInfoText;
    public string defaultText = "Нет сохранений";
    
    void Start()
    {
        UpdateSaveInfo();
    }
    
    public void UpdateSaveInfo()
    {
        if (!SaveGameHandler.HasSave())
        {
            saveInfoText.text = defaultText;
            return;
        }
        
        Struct saveData = SaveGameHandler.LoadFromFile();
        
        // Формируем текст
        string info = $"Последнее сохранение:\n";
        info += $"Позиция: X:{saveData.robotPosition.x:F1} Y:{saveData.robotPosition.y:F1} Z:{saveData.robotPosition.z:F1}\n";
        info += $"Батарея: {saveData.batteryCharge:F0}%\n";
        
        if (saveData.completedTasks != null && saveData.completedTasks.Length > 0)
        {
            int completed = 0;
            foreach (bool task in saveData.completedTasks)
                if (task) completed++;
            info += $"Выполнено заданий: {completed}/{saveData.completedTasks.Length}";
        }
        
        saveInfoText.text = info;
    }
    
    // Можно обновлять после ручного сохранения
    private void OnEnable()
    {
        if (SaveManager.Instance != null)
        {
            // Подписка на событие (нужно будет добавить в SaveManager)
        }
    }
}