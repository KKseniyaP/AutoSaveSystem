<code>
Assets/
├── _Project/
│ ├── Scripts/
│ │ ├── Core/ # Ядро системы (не зависит от конкретного проекта)
│ │ │ ├── SaveSystem/ # Модуль сохранений
│ │ │ │ ├── Data/
│ │ │ │ │ └── SaveData.cs # Структуры данных для сохранения
│ │ │ │ ├── Interfaces/
│ │ │ │ │ └── ISaveable.cs # Интерфейс для сохраняемых объектов
│ │ │ │ ├── SaveManager.cs # Главный менеджер сохранений (синглтон)
│ │ │ │ └── SaveGameHandler.cs # Сериализация/десериализация (JSON/Binary)
│ │ │ └── Checkpoints/ # Модуль чекпоинтов
│ │ │ ├── Checkpoint.cs # Компонент триггерной зоны
│ │ │ └── RespawnManager.cs # Логика восстановления при смерти
│ │ └── GameSpecific/ # Конкретные реализации под проект
│ │ ├── Robot/
│ │ │ ├── RobotState.cs # Состояние робота (АКБ, позиция)
│ │ │ └── RobotRespawn.cs # Поведение при перерождении
│ │ └── Quests/
│ │ ├── QuestData.cs # Данные о квестах
│ │ └── QuestManager.cs # Управление квестами
│ ├── Prefabs/
│ │ └── Checkpoints/
│ │ └── CheckpointZone.prefab # Готовый префаб чекпоинта
│ └── UI/
│ └── Widgets/
│ └── SaveNotification.cs # UI-уведомление о сохранении
├── Scenes/ # Игровые сцены
└── StreamingAssets/ # Файлы сохранений (генерируются в рантайме)
</code>
