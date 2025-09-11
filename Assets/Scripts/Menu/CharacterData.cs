using UnityEngine;


namespace MenuNamespace 
{
    
    [System.Serializable]
    public class CharacterData : MonoBehaviour
    {
        public string characterName;
        public Sprite characterSprite;
        public GameObject characterPrefab;
    }
}