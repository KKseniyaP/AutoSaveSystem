using UnityEngine;
using System.Collections;
using TMPro;

public class FloatingNotification : MonoBehaviour
{
    private TextMeshProUGUI textMesh; // если используешь TextMeshPro
    // private Text textMesh; // раскомментируй, если используешь обычный Text
    
    public float displayDuration = 2f;
    
    void Awake()
    {
        // Находим текстовый компонент
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    
    public void Show(string message = "Сохранено!")
    {
        StartCoroutine(ShowAndHide(message));
    }
    
    IEnumerator ShowAndHide(string message)
    {
        textMesh.text = message;
        gameObject.SetActive(true);
        
        yield return new WaitForSeconds(displayDuration);
        
        gameObject.SetActive(false);
    }
}