using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public VisualNovell vn;

    public GameObject pauseMenu;
    public GameObject gameMenu;
    public GameObject settingMenu;
    public GameObject saveMenu;
    public GameObject choiseMenu;

    public TMP_Text menuName;

    bool isPresed;

    public NovellMenuManager nm;

    // Update is called once per frame
    void Update()
    {
        if (vn.isPaused == false && (Input.GetMouseButtonDown(1) || Input.GetKeyDown("escape")))
        {
            Time.timeScale = 0;
            vn.isPaused = true;
            pauseMenu.SetActive(true);
            gameMenu.SetActive(false);
            choiseMenu.SetActive(false);
        }
        if (isPresed && (!vn.line.StartsWith("video play: ") || !!vn.line.StartsWith("choise: ")))
        {
            Skip();
        }
        else
        {
            isPresed = false;
        }
    }

    public void PauseMenuOff()
    {
        Time.timeScale = 1;
        vn.isPaused = false;
        pauseMenu.SetActive(false);
        gameMenu.SetActive(true);
        choiseMenu.SetActive(true);
    }

    public void BackMenu()
    {
        pauseMenu.SetActive(false);
        vn.ReturnGame();
    }

    public void SettingsMenu()
    {
        menuName.text = "Настройки";
        Time.timeScale = 0;
        vn.isPaused = true;
        pauseMenu.SetActive(true);
        choiseMenu.SetActive(false);
        settingMenu.SetActive(true);
        saveMenu.SetActive(false);
        gameMenu.SetActive(false);
        nm.loadMenu.SetActive(false);
    }

    public void SavesMenu()
    {
        menuName.text = "Сохранить";
        Time.timeScale = 0;
        vn.isPaused = true;
        pauseMenu.SetActive(true);
        choiseMenu.SetActive(false);
        saveMenu.SetActive(true);
        settingMenu.SetActive(false);
        gameMenu.SetActive(false);
        nm.loadMenu.SetActive(false);
    }

    public void BackAction()
    {
        vn.lineId--;
        vn.pastLineId--;
        vn.Back();
    }

    public void PresedOn()
    {
        isPresed = true;
    }

    public void PresedOff()
    {
        isPresed = false;
    }

    public void Skip()
    {
        vn.ReadNovelFile();
    }
}
