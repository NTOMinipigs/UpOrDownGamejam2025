using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Мендежер музыки, обращаться к нему по любому поводу
/// </summary>
public class MusicManager : MonoBehaviour
{
    public static MusicManager Singleton { get; private set; }
    /// <summary>
    /// Список MusicLoops заготовленных заранее
    /// </summary>
    public Dictionary<string, AudioLoop> AudioLoops = new();

    /// <summary>
    /// Список аудио треков присутствующих в игре
    /// Ключи для Audio генерируются автоматически, и называются так же как и AudioClip на сцене в unity
    /// См. на сцене GameObject Music и Sounds!
    /// </summary>
    public readonly Dictionary<string, Audio> Audios = new();

    private void Awake()
    {
        Singleton = this;
    }

    public void Start()
    {
        
        // Добавляем все известные музыкальные треки в список аудио
        foreach (AudioSource audioSource in GameObject.Find("Music").GetComponentsInChildren<AudioSource>())
        {
            Audios[audioSource.name] = new Audio(audioSource);
        }
        
        // Добавляем все известные звуки в список аудио
        foreach (AudioSource audioSource in GameObject.Find("Sounds").GetComponentsInChildren<AudioSource>())
        {
            Audios[audioSource.name] = new Audio(audioSource);
        }

        // Формируем известные заранее musicloop'ы

        // Цикл музыки
        AudioLoops["MusicLoop"] = new AudioLoop(
            new[]
            {
                Audios["BeerLofi"],
                Audios["SnowBeer"],
                Audios["Baltika9beer"],
                Audios["WindBeer"],
                Audios["AloneField"]
            },
            fadeEffect: true
            );
        
        //AudioLoops["MusicLoop"].Play();
    }

    /// <summary>
    /// Обновим коэффициент громкости для всех audiosource в Audios
    /// </summary>
    /// <param name="volumeRatio"></param>
    public void UpdateVolumeRatio(float volumeRatio)
    {
        foreach (Audio audio in  Audios.Values)
        {
            audio.volumeRatio = volumeRatio;
        }
    }



}