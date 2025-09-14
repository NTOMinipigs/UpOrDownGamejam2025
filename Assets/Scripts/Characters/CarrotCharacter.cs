using UnityEngine;

namespace Characters
{
    public class CarrotCharacter : AbstractCharacter
    {
        void Start()
        {
            SetRigidbody();
        }
        
        public override void UseAbility()
        {
            throw new System.NotImplementedException();
        }
    }
}