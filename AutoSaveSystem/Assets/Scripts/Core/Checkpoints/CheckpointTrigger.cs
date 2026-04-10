
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    [Header("Визуальные и звуковые эффекты")]
    public Light checkpointLight;       // ссылка на лампочку
    public ParticleSystem successParticles; // ссылка на систему частиц (искры/конфетти)
    public AudioSource successSound;    // ссылка на звук

    // флаг, чтобы чекпоинт сохранял игру только один раз
    private bool isActivated = false;

    // метод вызывается автоматически, когда кто-то входит в триггер
    private void OnTriggerEnter(Collider other)
    {
        // если чекпоинт еще не активирован и в него въехал именно игрок
        if (!isActivated && other.CompareTag("Player"))
        {
            ActivateCheckpoint();
        }
    }

    private void ActivateCheckpoint()
    {
        isActivated = true; // блокируем повторное срабатывание

        // 1. включаем свет или меняем его цвет на зеленый
        if (checkpointLight != null)
        {
            checkpointLight.color = Color.green;
            checkpointLight.enabled = true;
        }

        // 2. запускаем частицы (если они есть)
        if (successParticles != null)
        {
            successParticles.Play();
        }

        // 3. проигрываем звук (если он есть)
        if (successSound != null)
        {
            successSound.Play();
        }

        // 4. сообщение в консоль
        Debug.Log("Прогресс сохранен! Чекпоинт пройден.");

    }
}