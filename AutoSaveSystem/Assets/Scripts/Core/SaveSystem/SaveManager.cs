using System.Collections.Generic;
using UnityEngine;
using Core.SaveSystem.Data;
using Core.SaveSystem.Interfaces;

namespace Core.SaveSystem
{
    /// <summary>
    /// Главный менеджер сохранений.
    /// Управляет всеми объектами, которые реализуют ISaveable.
    /// </summary>
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance { get; private set; }

        /// <summary>
        /// Список всех зарегистрированных сохраняемых объектов
        /// </summary>
        private List<ISaveable> _saveableObjects = new List<ISaveable>();

        private void Awake()
        {
            // Синглтон
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
            // при старте игры пробуем загрузить сохранение
            LoadGame();
        }

        /// <summary>
        /// Зарегистрировать объект в системе сохранений
        /// </summary>
        public void RegisterSaveable(ISaveable saveable)  // ISaveable, не Isaveable!
        {
            if (!_saveableObjects.Contains(saveable))
            {
                _saveableObjects.Add(saveable);
                Debug.Log($"[SaveManager] Зарегистрирован: {saveable.GetType().Name}");
            }
        }

        /// <summary>
        /// Отменить регистрацию объекта
        /// </summary>
        public void UnregisterSaveable(ISaveable saveable)  // ISaveable, не Isaveable!
        {
            if (_saveableObjects.Contains(saveable))
            {
                _saveableObjects.Remove(saveable);
                Debug.Log($"[SaveManager] Отменена регистрация: {saveable.GetType().Name}");  // Debug, не Dubug!
            }
        }

        /// <summary>
        /// Сохранить игру
        /// </summary>
        public void SaveGame()
        {
            // Создаём новый контейнер для данных
            Struct saveData = new Struct();

            // Просим каждый зарегистрированный объект заполнить данные
            foreach (ISaveable saveable in _saveableObjects)
            {
                saveable.OnSave(saveData);
            }

            // Передаём данные на запись в файл
            SaveGameHandler.SaveToFile(saveData);

            Debug.Log("[SaveManager] Игра сохранена");
        }

        /// <summary>
        /// Загрузить игру
        /// </summary>
        public void LoadGame()
        {
            // Загружаем данные из файла
            Struct loadedData = SaveGameHandler.LoadFromFile();

            // Просим каждый зарегистрированный объект восстановиться из данных
            foreach (ISaveable saveable in _saveableObjects)
            {
                saveable.OnLoad(loadedData);
            }

            Debug.Log("[SaveManager] Игра загружена");
        }

        /// <summary>
        /// Проверить, есть ли сохранение
        /// </summary>
        public bool HasSave()
        {
            return SaveGameHandler.HasSave();
        }

        /// <summary>
        /// Удалить сохранение
        /// </summary>
        public void DeleteSave()
        {
            SaveGameHandler.DeleteSave();
            Debug.Log("[SaveManager] Сохранение удалено");
        }
    }
}