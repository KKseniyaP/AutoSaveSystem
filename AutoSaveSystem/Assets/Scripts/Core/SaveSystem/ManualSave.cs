using UnityEngine;
using Core.SaveSystem;

public class ManualSave : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveManager.Instance.SaveGame();
            Debug.Log("Ручное сохранение (F5)");
        }
        
        if (Input.GetKeyDown(KeyCode.F9))
        {
            SaveManager.Instance.LoadGame();
            Debug.Log("Ручная загрузка (F9)");
        }
    }
}