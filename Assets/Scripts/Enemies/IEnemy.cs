namespace Enemies
{
    /// <summary>
    /// Интерфейс всех врагов игрока. Его должен реализовывать каждый класс *Enemy
    /// </summary>
    public interface IEnemy
    {
        /// <summary>
        /// Действие выполняющееся каждый кадр во время погони
        /// </summary>
        void Chase();
        
        /// <summary>
        /// Атака на игрока
        /// </summary>
        void Attack();

        /// <summary>
        /// Действие выполняющееся при попадании игрока в зону видимости 
        /// </summary>
        void VisibilityAreaTrigger();

        /// <summary>
        /// При покидании зоны погони
        /// </summary>
        void OnChaseAreaLeaveTrigger();

        /// <summary>
        /// Возвращение на точку спавна
        /// </summary>
        void ToSpawnPoint();
    }
}