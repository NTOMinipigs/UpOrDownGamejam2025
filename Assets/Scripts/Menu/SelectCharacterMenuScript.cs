using System.Collections;
using System.Collections.Generic;
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
        
        StartCoroutine(AnimateSwipe(-1));
    }
    
    public void SwipeRight()
    {
        if (isAnimating) return;

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
        PlayerPrefs.SetInt("SelectedCharacter", currentIndex);
        Debug.Log("Выбран персонаж: " + characters[currentIndex].characterName);
        
        // Здесь можно перейти к следующей сцене или показать подтверждение
    }
    }
}