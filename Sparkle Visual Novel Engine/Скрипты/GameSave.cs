using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;

public class GameSave : MonoBehaviour
{
    public VisualNovell visualNovell;
    public TMP_Text saveStatus;
    public TMP_Text loadStatus;

    // Метод для сохранения состояния сцены
    public void SaveGame()
    {
        SaveData saveData = new SaveData();

        // Заполните объект SaveData данными о текущем состоянии сцены из скрипта VisualNovell
        saveData.lineId = visualNovell.lineId;
        saveData.pastLineId = visualNovell.pastLineId;
        saveData.pastStroke = visualNovell.pastStroke;
        saveData.lastBackground = visualNovell.lastBackground;
        saveData.nextBackground = visualNovell.nextBackground;
        saveData.lastAudio = visualNovell.lastAudio;
        saveData.nextAudio = visualNovell.nextAudio;
        saveData.lastSprite = visualNovell.lastSprite;
        saveData.nextSprite = visualNovell.nextSprite;
        // Добавьте другие данные, которые вы хотите сохранить

        string json = JsonUtility.ToJson(saveData);
        string filePath = Path.Combine(Application.persistentDataPath, "saveNovel.json");

        File.WriteAllText(filePath, json);
        saveStatus.text = "Игра сохранена в: " + filePath;
    }

    // Метод для загрузки состояния сцены
    public void LoadGame()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "saveNovel.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            // Примените данные из saveData к скрипту VisualNovell
            visualNovell.lineId = saveData.lineId;
            visualNovell.pastLineId = saveData.pastLineId;
            visualNovell.lastBackground = saveData.lastBackground;
            visualNovell.lastAudio = saveData.lastAudio;
            visualNovell.pastStroke = saveData.pastStroke;
            visualNovell.lastAudio = saveData.lastAudio;
            visualNovell.nextAudio = saveData.nextAudio;
            visualNovell.lastSprite = saveData.lastSprite;
            visualNovell.nextSprite = saveData.nextSprite;
            // Прочие действия по загрузке данных

            string audioName = saveData.nextAudio;
            string imageName = saveData.nextBackground;
            string[] spriteParts = saveData.nextSprite.Split(" ");
            if (spriteParts.Length == 2 ) 
            {
                string spriteName = spriteParts[0].Trim();
                string spritePosition = spriteParts[1].Trim();
                visualNovell.ApplySpriteImage(spriteName, spritePosition);
            }
            loadStatus.text = "Зашружено с " + filePath;
            visualNovell.ReadNovelFile();
            visualNovell.PlayAudioFile(audioName);
            visualNovell.ApplyBackgroundImage(imageName);
        }
        else
        {
            loadStatus.text = "Сохранение не найдено";
        }
    }
}

[Serializable]
public class SaveData
{
    public int lineId;
    public int pastLineId;
    public string lastBackground;
    public string nextBackground;
    public string lastAudio;
    public string nextAudio;
    public string pastStroke;
    public string lastSprite;
    public string nextSprite;
    // Другие данные для сохранения состояния
}
