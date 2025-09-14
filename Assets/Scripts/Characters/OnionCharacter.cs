using UnityEngine;

namespace Characters
{
    public class OnionCharacter : AbstractCharacter
    {
        void Start()
        {
            Rb = GetComponent<Rigidbody2D>();    
        }
        
        public override void UseAbility()
        {
            throw new System.NotImplementedException();
        }
    }
}