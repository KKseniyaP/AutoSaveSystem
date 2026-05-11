using UnityEngine;
using Core.SaveSystem;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance { get; private set; }

    private Vector3 lastCheckpointPosition;
    private Quaternion lastCheckpointRotation;
    private bool hasCheckpoint = false;
    private GameObject player;

    [Header("Отслеживание переворота")]
    [SerializeField] private float upsideDownThreshold = 0f; // если меньше 0 - переворот
    [SerializeField] private bool checkForUpsideDown = true;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        FindPlayer();
    }

    private void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) player = GameObject.Find("Robot");
    }

    private void Update()
    {
        if (!checkForUpsideDown) return;

        if (player == null) FindPlayer();

        if (player != null)
        {
            // Отслеживание переворота через Vector3.Dot
            float upDot = Vector3.Dot(player.transform.up, Vector3.up);

            // Если робот перевернулся
            if (upDot < upsideDownThreshold)
            {
                Debug.Log($"Робот перевернут! Dot = {upDot}. Загружаем сохранение...");

                // Загружаем последнее сохранение
                if (SaveManager.Instance != null)
                {
                    SaveManager.Instance.LoadGame();
                }

                // Телепортируем на чекпоинт
                RespawnPlayer();
            }
        }
    }

    /// <summary>
    /// Вызывается из CheckpointTrigger при активации чекпоинта
    /// </summary>
    public void RegisterCheckpoint(int index, Vector3 position, Quaternion rotation)
    {
        lastCheckpointPosition = position;
        lastCheckpointRotation = rotation;
        hasCheckpoint = true;
        Debug.Log($"Чекпоинт {index} зарегистрирован! Позиция: {position}, Поворот: {rotation.eulerAngles}");
    }

    /// <summary>
    /// Вызови этот метод, когда робот умирает или перевернулся
    /// </summary>
    public void RespawnPlayer()
    {
        if (!hasCheckpoint)
        {
            Debug.LogWarning("Нет сохранённого чекпоинта!");
            return;
        }

        if (player == null) FindPlayer();

        if (player != null)
        {
            // Телепортация в сохранённую позицию
            player.transform.position = lastCheckpointPosition;
            player.transform.rotation = lastCheckpointRotation;

            // Сброс скорости
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            Debug.Log($"Игрок телепортирован на чекпоинт: {lastCheckpointPosition}");
        }
    }

    public Vector3 GetLastCheckpointPosition() => lastCheckpointPosition;
    public Quaternion GetLastCheckpointRotation() => lastCheckpointRotation;
    public bool HasCheckpoint() => hasCheckpoint;
}