using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    public class DamageVingette : MonoBehaviour
    {
        private float _fadeDuration = 0.2f;
        private Image vingette;
        public static DamageVingette Instance { private set; get; }

        void Start()
        {
            Instance = this;
            vingette = GetComponent<Image>();
        }
        
        public IEnumerator FadeScreen()
        {
            vingette.color = new Color(255, 255, 255, 0);
            float fadeStartAt = Time.time;
            while (Time.time - fadeStartAt < _fadeDuration)
            {
                vingette.color = new Color(255, 255, 255, (Time.time - fadeStartAt) / _fadeDuration);
                yield return null;
            }

            vingette.color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(1f);

            fadeStartAt = Time.time;
            while (Time.time - fadeStartAt < _fadeDuration)
            {
                vingette.color = new Color(255, 255, 255, 1 - (Time.time - fadeStartAt) / _fadeDuration);
                yield return null;
            }
            vingette.color = new Color(255, 255, 255, 0);
        }
        
    }
}