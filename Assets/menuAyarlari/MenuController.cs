using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Yüklenecek Seviye")] public string _newGameLevel;

    private string levelToLoad;

    [Header("Ses Ayarları")] [SerializeField]
    private TMP_Text volumeTextValue = null;

    [SerializeField] private GameObject confirmationPromt = null;

    [SerializeField] private Slider volumeSlider = null;
    
    

    public void Seviye()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    public void volumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());

    }

    public IEnumerator ConfirmationBox()
    {
        confirmationPromt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPromt.SetActive(false);
    }

}
