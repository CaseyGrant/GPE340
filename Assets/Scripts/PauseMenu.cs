using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject SettingsMenuUI;

    public AudioMixer audioMixer;

    private Slider masterSlider;
    private Slider musicSlider;
    private Slider sfxSlider;
    private Toggle fullscreenToggle;
    private Dropdown resolutionDropdown;
    private Dropdown qualityDropdown;

    public void Awake()
    {
        masterSlider = GameObject.FindGameObjectWithTag("Master").GetComponent<Slider>(); // gets the UI element
        musicSlider = GameObject.FindGameObjectWithTag("Music").GetComponent<Slider>(); // gets the UI element
        sfxSlider = GameObject.FindGameObjectWithTag("SFX").GetComponent<Slider>(); // gets the UI element
        fullscreenToggle = GameObject.FindGameObjectWithTag("Fullscreen").GetComponent<Toggle>(); // gets the UI element
        resolutionDropdown = GameObject.FindGameObjectWithTag("Resolution").GetComponent<Dropdown>(); // gets the UI element
        qualityDropdown = GameObject.FindGameObjectWithTag("Quality").GetComponent<Dropdown>(); // gets the UI element
    }

    public void Start()
    {
        pauseMenuUI.SetActive(false); // hides the menu
        SettingsMenuUI.SetActive(false); // hides the menu

        if (PlayerPrefs.GetInt("Fullscreen") == 0) // if previously full screen
        {
            fullscreenToggle.isOn = true; // keep fullscreen
        }
        else
        {
            fullscreenToggle.isOn = false; // make windowed
        }

        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume"); // updates based on prefs
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume"); // updates based on prefs
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume"); // updates based on prefs
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution"); // updates based on prefs
        qualityDropdown.value = PlayerPrefs.GetInt("Quality"); // updates based on prefs
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // if you press escape
        {
            if (gameIsPaused) // if the game is paused
            {
                Resume(); // resume the game
            }
            else
            {
                Pause(); // pause the game
            }
        }
    }

    public void Pause()
    {
        GameObject.Find("Timmy").GetComponent<PlayerController>().enabled = false; // disables player movement
        pauseMenuUI.SetActive(true); // shows the pause menu
        Time.timeScale = 0f; // stops the world
        gameIsPaused = true; // sets paused
    }

    public void Resume()
    {
        GameObject.Find("Timmy").GetComponent<PlayerController>().enabled = true; // enables player movement
        pauseMenuUI.SetActive(false); // hides the pause menu
        SettingsMenuUI.SetActive(false); // hides the settings menu
        Time.timeScale = 1f; // resumes the world
        gameIsPaused = false; // turns off paused
    }

    public void Settings()
    {
        SettingsMenuUI.SetActive(true); // shows settings
        pauseMenuUI.SetActive(false); // hides pause
    }

    public void SettingsBack()
    {
        SettingsMenuUI.SetActive(false); // hides settings
        pauseMenuUI.SetActive(true); // shows pause
    }

    public void MasterVolume(float sliderValue)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) *20); // sets the mixer
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value); // updates the player prefs
    }

    public void MusicVolume(float sliderValue)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20); // sets the mixer
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value); // updates the player prefs
    }

    public void SFXVolume(float sliderValue)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20); // sets the mixer
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value); // updates the player prefs
    }

    public void Fullscreen()
    {
        if (fullscreenToggle.isOn)
        {
            Screen.fullScreen = true; // sets fullscreen
            PlayerPrefs.SetInt("Fullscreen", 0); // updates the player prefs
        }
        else
        {
            Screen.fullScreen = false; // sets windowed
            PlayerPrefs.SetInt("Fullscreen", 1); // updates the player prefs
        }
        
    }

    public void Resolution()
    {
        if (resolutionDropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, fullscreenToggle.isOn); // changes the resolution
            PlayerPrefs.SetInt("Resolution", 0); // updates the player prefs
        }
        if (resolutionDropdown.value == 1)
        {
            Screen.SetResolution(900, 1440, fullscreenToggle.isOn); // changes the resolution
            PlayerPrefs.SetInt("Resolution", 1); // updates the player prefs
        }
        if (resolutionDropdown.value == 2)
        {
            Screen.SetResolution(768, 1024, fullscreenToggle.isOn); // changes the resolution
            PlayerPrefs.SetInt("Resolution", 2); // updates the player prefs
        }
    }

    public void Quality()
    {
        if (qualityDropdown.value == 0)
        {
            QualitySettings.SetQualityLevel(4, true); // changes the quality
            PlayerPrefs.SetInt("Quality", 0); // updates the player prefs
        }
        if (qualityDropdown.value == 1)
        {
            QualitySettings.SetQualityLevel(2, true); // changes the quality
            PlayerPrefs.SetInt("Quality", 1); // updates the player prefs
        }
        if (qualityDropdown.value == 2)
        {
            QualitySettings.SetQualityLevel(0, true); // changes the quality
            PlayerPrefs.SetInt("Quality", 2); // updates the player prefs
        }
    }
}