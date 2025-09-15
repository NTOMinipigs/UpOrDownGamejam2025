namespace Characters
{
    /// <summary>
    /// Интерфейс всех персонажей
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// Перемещение персонажа
        /// </summary>
        /// <param name="direction">Направление движения (-1 или 1)</param>
        void Walk(float direction);
        
        /// <summary>
        /// Прыжок персонажа
        /// </summary>
        void Jump();
        
        /// <summary>
        /// Использование способности
        /// </summary>
        void UseAbility();
        
        /// <summary>
        /// Телепортация игрока в точку двери
        /// </summary>
        void Teleport();
    }
}