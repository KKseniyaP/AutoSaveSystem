using UnityEngine;
using Core.SaveSystem;

public class ManualSaveButton : MonoBehaviour
{
    public SaveDisplay saveDisplay;
    
    public void OnSaveButtonClicked()
    {
        SaveManager.Instance.SaveGame();
        
        if (saveDisplay != null)
            saveDisplay.UpdateSaveInfo();
       
        Debug.Log("Игра сохранена!");
    }
}