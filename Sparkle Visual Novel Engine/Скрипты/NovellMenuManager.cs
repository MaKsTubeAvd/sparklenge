using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NovellMenuManager : MonoBehaviour
{
    public GameObject gameInterface;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject loadMenu;
    public GameObject pauseMenu;
    public GameObject backToGameButton;
    public VisualNovell vn;
    public Pause p;
    public TMP_Text menuName;
    public GameObject choiseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNovel()
    {
        vn.ReadNovelFile();
        gameInterface.SetActive(true);
        mainMenu.SetActive(false);
        vn.isPaused = false;

    }
    public void Settings()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(true);
        loadMenu.SetActive(false);
        mainMenu.SetActive(false);
        p.saveMenu.SetActive(false);
        menuName.text = "Настройки";
    }

    public void Menu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Главное меню");
    }

    public void LoadMenu()
    {
        mainMenu.SetActive(false);
        gameInterface.SetActive(false);
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        loadMenu.SetActive(true);
        p.saveMenu.SetActive(false);
        choiseMenu.SetActive(false);
        menuName.text = "Загрузить";
    }
}
