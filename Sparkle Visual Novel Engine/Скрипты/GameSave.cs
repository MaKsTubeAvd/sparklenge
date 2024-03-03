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

    // ����� ��� ���������� ��������� �����
    public void SaveGame()
    {
        SaveData saveData = new SaveData();

        // ��������� ������ SaveData ������� � ������� ��������� ����� �� ������� VisualNovell
        saveData.lineId = visualNovell.lineId;
        saveData.pastLineId = visualNovell.pastLineId;
        saveData.pastStroke = visualNovell.pastStroke;
        saveData.lastBackground = visualNovell.lastBackground;
        saveData.nextBackground = visualNovell.nextBackground;
        saveData.lastAudio = visualNovell.lastAudio;
        saveData.nextAudio = visualNovell.nextAudio;
        saveData.lastSprite = visualNovell.lastSprite;
        saveData.nextSprite = visualNovell.nextSprite;
        // �������� ������ ������, ������� �� ������ ���������

        string json = JsonUtility.ToJson(saveData);
        string filePath = Path.Combine(Application.persistentDataPath, "saveNovel.json");

        File.WriteAllText(filePath, json);
        saveStatus.text = "���� ��������� �: " + filePath;
    }

    // ����� ��� �������� ��������� �����
    public void LoadGame()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "saveNovel.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            // ��������� ������ �� saveData � ������� VisualNovell
            visualNovell.lineId = saveData.lineId;
            visualNovell.pastLineId = saveData.pastLineId;
            visualNovell.lastBackground = saveData.lastBackground;
            visualNovell.lastAudio = saveData.lastAudio;
            visualNovell.pastStroke = saveData.pastStroke;
            visualNovell.lastAudio = saveData.lastAudio;
            visualNovell.nextAudio = saveData.nextAudio;
            visualNovell.lastSprite = saveData.lastSprite;
            visualNovell.nextSprite = saveData.nextSprite;
            // ������ �������� �� �������� ������

            string audioName = saveData.nextAudio;
            string imageName = saveData.nextBackground;
            string[] spriteParts = saveData.nextSprite.Split(" ");
            if (spriteParts.Length == 2 ) 
            {
                string spriteName = spriteParts[0].Trim();
                string spritePosition = spriteParts[1].Trim();
                visualNovell.ApplySpriteImage(spriteName, spritePosition);
            }
            loadStatus.text = "��������� � " + filePath;
            visualNovell.ReadNovelFile();
            visualNovell.PlayAudioFile(audioName);
            visualNovell.ApplyBackgroundImage(imageName);
        }
        else
        {
            loadStatus.text = "���������� �� �������";
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
    // ������ ������ ��� ���������� ���������
}
