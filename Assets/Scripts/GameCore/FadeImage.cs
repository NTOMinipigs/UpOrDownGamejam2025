using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    public class FadeImage : MonoBehaviour
    {
        private float _fadeDuration = 0.1f;
        private Image fadeImage;
        public static FadeImage Instance { private set; get; }

        void Start()
        {
            Instance = this;
            fadeImage = GetComponent<Image>();
        }
        
        public IEnumerator FadeScreen()
        {
            fadeImage.color = new Color(0, 0, 0, 0);
            float fadeStartAt = Time.time;
            while (Time.time - fadeStartAt < _fadeDuration)
            {
                fadeImage.color = new Color(0, 0, 0, (Time.time - fadeStartAt) / _fadeDuration);
                yield return null;
            }

            fadeImage.color = new Color(0, 0, 0, 1);
            yield return new WaitForSeconds(1f);

            fadeStartAt = Time.time;
            while (Time.time - fadeStartAt < _fadeDuration)
            {
                fadeImage.color = new Color(0, 0, 0, 1 - (Time.time - fadeStartAt) / _fadeDuration);
                yield return null;
            }
            fadeImage.color = new Color(0, 0, 0, 0);
        }
        
    }
}