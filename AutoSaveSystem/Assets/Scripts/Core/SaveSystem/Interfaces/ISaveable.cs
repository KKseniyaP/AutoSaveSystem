using Core.SaveSystem.Data;
using System.Runtime.InteropServices;

namespace Core.SaveSystem.Interfaces
{
    /// <summary>
    /// Интерфейс для объектов, которые можно сохранять.
    /// Любой класс, реализующий этот интерфейс, сможет участвовать в системе сохранений.
    /// </summary>

    public interface ISaveable
    {
        /// <summary>
        /// Вызывается при сохранении игры.
        /// Нужно заполнить переданную структуру данными объекта.
        /// </summary>
        /// <param name="data">Структура для заполнения</param>
        void OnSave(Struct data);

        /// <summary>
        /// Вызывается при загрузке игры.
        /// Нужно восстановить состояние объекта из переданной структуры.
        /// </summary>
        /// <param name="data">Структура с сохранёнными данными</param>
        void OnLoad(Struct data);
    }
}