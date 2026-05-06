using UnityEngine;
using Core.SaveSystem;
using Core.SaveSystem.Data;
using Core.SaveSystem.Interfaces;

public class RobotState : MonoBehaviour, ISaveable
{
    [Header("Параметры робота")]
    public float batteryCharge = 100f;
    
    private void Start()
    {
        SaveManager.Instance?.RegisterSaveable(this);
    }
    
    private void OnDestroy()
    {
        SaveManager.Instance?.UnregisterSaveable(this);
    }
    
    public void OnSave(Struct data)
    {
        data.robotPosition = transform.position;
        data.robotRotation = transform.rotation;
        data.batteryCharge = batteryCharge;
    }
    
    public void OnLoad(Struct data)
    {
        transform.SetPositionAndRotation(data.robotPosition, data.robotRotation);
        batteryCharge = data.batteryCharge;
    }
}