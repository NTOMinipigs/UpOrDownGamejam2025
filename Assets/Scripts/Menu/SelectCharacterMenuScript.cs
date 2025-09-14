using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.GameCore;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace MenuNamespace
{
    /// <summary>
    /// Скрипт карусели выбора персонажа
    /// </summary>
    public class SelectCharacterMenuScript : MonoBehaviour
    { 
        

    [Header("Characters List")]
    public List<CharacterData> characters = new();
    
    [Header("UI References")]
    public Image characterImage;
    public TextMeshProUGUI characterNameText;
    public Button selectButton;
    public MenuProxyObject menuProxyObject;
    
    [Header("Animation Settings")]
    public float swipeDuration = 0.3f;
    public LeanTweenType easeType = LeanTweenType.easeOutBack;
    
    private int currentIndex = 0;
    private bool isAnimating = false;
    
    void Start()
    {
        UpdateCharacterDisplay();
        
        selectButton.onClick.AddListener(SelectCharacter);
        

    }
    
    void UpdateCharacterDisplay()
    {
        if (characters.Count == 0) return;
        
        CharacterData currentCharacter = characters[currentIndex];
        
        characterImage.sprite = currentCharacter.characterSprite;
        characterNameText.text = currentCharacter.characterName;
        
    }
    
    public void SwipeLeft()
    {
        if (isAnimating) return;

        MusicManager.Singleton.Audios["button"].Play();
        StartCoroutine(AnimateSwipe(-1));
    }
    
    public void SwipeRight()
    {
        if (isAnimating) return;

        MusicManager.Singleton.Audios["button"].Play();
        StartCoroutine(AnimateSwipe(1));
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    
    IEnumerator AnimateSwipe(int direction)
    {
        isAnimating = true;
        
        // Анимация ухода текущего персонажа
        LeanTween.scale(characterImage.gameObject, Vector3.zero, swipeDuration / 2)
            .setEase(easeType);
        
        yield return new WaitForSeconds(swipeDuration / 2);
        
        // Меняем индекс
        currentIndex = (currentIndex + direction + characters.Count) % characters.Count;
        UpdateCharacterDisplay();
        
        // Сбрасываем scale для анимации появления
        characterImage.transform.localScale = Vector3.zero;
        
        // Анимация появления нового персонажа
        LeanTween.scale(characterImage.gameObject, Vector3.one, swipeDuration / 2)
            .setEase(easeType);
        
        
        yield return new WaitForSeconds(swipeDuration / 2);
        
        isAnimating = false;
    }
    
    void SelectCharacter()
    {
        menuProxyObject.characterPrefab = characters[currentIndex].characterPrefab;
        StartGame();
    }
    }
}