using System.Collections;
using GameCore;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace.Ending
{
    /// <summary>
    /// Менеджер концовки
    /// </summary>
    public class Ending : MonoBehaviour
    {
        /// <summary>
        /// Прокси объект концовки
        /// </summary>
        private EndingProxyObject _endingProxyObject;


        private float _fadeDuration = 1f;

        # region UI

        [SerializeField] private Image fade;

        [SerializeField] private GameObject goodEnding;
        [SerializeField] private GameObject badEnding;

        [SerializeField] private TextMeshProUGUI distressedCount;
        [SerializeField] private TextMeshProUGUI time;
        [SerializeField] private HorizontalLayoutGroup lives;

        # endregion


        void Start()
        {
            // Ставим прокси объект
            _endingProxyObject = EndingProxyObject.Instance;

            // Останавливаем музыку
            StartCoroutine(MusicManager.Singleton.Audios["WindBeer"].Stop(fadeEffect: true));
            StartCoroutine(MusicManager.Singleton.Audios["SnowBeer"].Stop(fadeEffect: true));

            if (_endingProxyObject.endingType == EndingProxyObject.EndingType.Good) GoodEnding();
            if (_endingProxyObject.endingType == EndingProxyObject.EndingType.Bad) StartCoroutine(BadEnding());
            StartCoroutine(FadeScreen());
        }

        /// <summary>
        /// Метод хорошей концовки
        /// </summary>
        void GoodEnding()
        {
            MusicManager.Singleton.Audios["AloneField"].Play();

            goodEnding.SetActive(true);
            distressedCount.text = _endingProxyObject.distressedCount.ToString();
            time.text = (Time.time - _endingProxyObject.gameStartedAt).ToString("0.00");
            // Убираем сердца
            for (int i = 0; i < 3 - _endingProxyObject.lives; i++)
                lives.transform.GetChild(i).gameObject.SetActive(false);
        }

        /// <summary>
        /// Метод плохой концовки
        /// </summary>
        IEnumerator BadEnding()
        {
            badEnding.SetActive(true);
            yield return new WaitForSeconds(2f);
            StartCoroutine(MusicManager.Singleton.Audios["SnowBeer"].PlayWithFadeEffect());
        }

        /// <summary>
        /// Убрать затемнение
        /// </summary>
        /// <returns></returns>
        public IEnumerator FadeScreen()
        {
            fade.color = new Color(0, 0, 0, 255);

            float fadeStartAt = Time.time;
            while (Time.time - fadeStartAt < _fadeDuration)
            {
                fade.color = new Color(0, 0, 0, 1 - (Time.time - fadeStartAt) / _fadeDuration);
                yield return null;
            }

            fade.color = new Color(0, 0, 0, 0);
        }
    }
}