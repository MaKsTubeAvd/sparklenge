using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.Video;


public class VisualNovell : MonoBehaviour
{
    public TextAsset indexFile;

    public Choise cs;

    public TMP_Text characterNameText;
    public TMP_Text characterPhrase;

    public Image back;

    public Image centerSprite;
    public Image rightSprite;
    public Image leftSprite;

    public int lineId;

    public int pastLineId;

    public GameObject mainMenu;

    public GameObject gameMenu;

    public GameObject textBox;

    public bool isPaused = true;

    bool isPlaying = false;

    private AudioSource a;

    public VideoPlayer v;

    public string line;

    public string lastBackground;
    public string nextBackground;

    public string lastAudio;
    public string nextAudio;

    public string lastSprite;
    public string nextSprite;

    public string pastStroke;

    void Start()
    {
        a = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) && (isPaused == false && isPlaying == false))
        {
            pastLineId = lineId - 1;
            ReadNovelFile();
        }

        if (Input.GetKey("left ctrl") && (isPaused == false && isPlaying == false))
        {
            ReadNovelFile();
        }
        if (Input.GetMouseButtonDown(2))
        {
            textBox.SetActive(false);
        }
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")))
        {
            textBox.SetActive(true);
        }
        if (Input.GetKeyDown("right ctrl"))
        {
            Back();
        }
    }

    public void ReadNovelFile()
    {
        if (indexFile != null)
        {

            string[] lines = indexFile.text.Split('\n');
            if (lineId < lines.Length)
            {
                line = lines[lineId];
                pastStroke = lines[pastLineId];
                if (line.StartsWith("dialoge_ "))
                {
                    string[] lineparts = line.Split('_');
                    if (lineparts.Length == 2)
                    {
                        string liner = lineparts[1].Trim();
                        string[] parts = liner.Split('|'); // Разделение строки на две части по символу "-"
                        if (parts.Length == 2)
                        {
                            string character = parts[0].Trim(); // Получение персонажа
                            string text = parts[1].Trim().Trim('"'); // Получение текста без кавычек и лишних пробелов

                            // Далее можно использовать character и text по своему усмотрению
                            if (character == null)
                            {
                                characterPhrase.text = text;
                                pastLineId++;
                                lineId++;
                            }
                            if (character != null)
                            {
                                characterNameText.text = character;
                                characterPhrase.text = text;
                                pastLineId++;
                                lineId++;
                            }
                        }
                    }

                }

                if (line.StartsWith("background: "))
                {
                    lastBackground = nextBackground;
                    string[] lineparts = line.Split(':');
                    if (lineparts.Length == 2) 
                    {
                        string imageName = lineparts[1].Trim();
                        ApplyBackgroundImage(imageName);
                    }
                }

                if (line.StartsWith("sprite: "))
                {
                    lastSprite = nextSprite;
                    string[] lineparts = line.Split(":");
                    if (lineparts.Length == 2)
                    {
                        string spriteLine = lineparts[1].Trim();
                        nextSprite = lineparts[1].Trim();
                        string[] spriteParts = spriteLine.Split(" ");
                        if (spriteParts.Length == 2)
                        {
                            string spriteName = spriteParts[0].Trim();
                            string spritePosition = spriteParts[1].Trim();
                            pastLineId++;
                            lineId++;
                            ApplySpriteImage(spriteName, spritePosition);
                        }

                    }

                }

                if (line.StartsWith("spritehide: "))
                {
                    string[] lineparts = line.Split(':');
                    if (lineparts.Length == 2)
                    {
                        string spriteLine = lineparts[1].Trim();
                        string[] spriteParts = spriteLine.Split(" ");
                        if (spriteParts.Length == 2)
                        {
                            string spriteName = spriteParts[0].Trim();
                            string spritePosition = spriteParts[1].Trim();
                            pastLineId++;
                            lineId++;
                            HideSpriteImage(spriteName, spritePosition);                     
                        }
                    }
                }
                if (line.StartsWith("video play: "))
                {
                    isPlaying = true;
                    string[] lineparts = line.Split(":");
                    if (lineparts.Length == 2)
                    {
                        string videoName = lineparts[1].Trim();
                        pastLineId++;
                        lineId++;
                        PlayVideoFile(videoName);
                    }
                }

                if (line.StartsWith("audio play: "))
                {
                    lastAudio = nextAudio;
                    string[] lineparts = line.Split(":");
                    if (lineparts.Length == 2)
                    {
                        string audioName = lineparts[1].Trim();
                        pastLineId++;
                        lineId++;
                        PlayAudioFile(audioName);
                    }
                }

                if (line.StartsWith("audio stop"))
                {
                    a.mute = true;
                    pastLineId++;
                    lineId++;
                    ReadNovelFile();
                }

                if (line.StartsWith("choise: "))
                {
                    cs.selected = false;
                    string[] lineparts = line.Split(":");
                    if (lineparts.Length == 2)
                    {
                        textBox.SetActive(false);
                        string choiseLine = lineparts[1].Trim();
                        string[] choiseLength = choiseLine.Split(",");
                        if (choiseLength.Length == 1)
                        {
                            cs.choiseSum = 1;
                            cs.choiseText1 = choiseLength[0].Trim();
                        }
                        else if (choiseLength.Length == 2)
                        {
                            cs.choiseSum = 2;
                            cs.choiseText1 = choiseLength[0].Trim();
                            cs.choiseText2 = choiseLength[1].Trim();
                        }
                        else if (choiseLength.Length == 3)
                        {
                            cs.choiseSum = 3;
                            cs.choiseText1 = choiseLength[0].Trim();
                            cs.choiseText2 = choiseLength[1].Trim();
                            cs.choiseText3 = choiseLength[2].Trim();
                        }
                        else if (choiseLength.Length == 4)
                        {
                            cs.choiseSum = 4;
                            cs.choiseText1 = choiseLength[0].Trim();
                            cs.choiseText2 = choiseLength[1].Trim();
                            cs.choiseText3 = choiseLength[2].Trim();
                            cs.choiseText4 = choiseLength[3].Trim();
                        }
                        else if (choiseLength.Length == 5)
                        {
                            cs.choiseSum = 5;
                            cs.choiseText1 = choiseLength[0].Trim();
                            cs.choiseText2 = choiseLength[1].Trim();
                            cs.choiseText3 = choiseLength[2].Trim();
                            cs.choiseText4 = choiseLength[3].Trim();
                            cs.choiseText5 = choiseLength[4].Trim();
                        }
                        else if (choiseLength.Length == 6)
                        {
                            cs.choiseSum = 6;
                            cs.choiseText1 = choiseLength[0].Trim();
                            cs.choiseText2 = choiseLength[1].Trim();
                            cs.choiseText3 = choiseLength[2].Trim();
                            cs.choiseText4 = choiseLength[3].Trim();
                            cs.choiseText5 = choiseLength[4].Trim();
                            cs.choiseText6 = choiseLength[5].Trim();
                        }
                        else if (choiseLength.Length == 7)
                        {
                            cs.choiseSum = 7;
                            cs.choiseText1 = choiseLength[0].Trim();
                            cs.choiseText2 = choiseLength[1].Trim();
                            cs.choiseText3 = choiseLength[2].Trim();
                            cs.choiseText4 = choiseLength[3].Trim();
                            cs.choiseText5 = choiseLength[4].Trim();
                            cs.choiseText6 = choiseLength[5].Trim();
                            cs.choiseText6 = choiseLength[6].Trim();
                        }
                        else if (choiseLength.Length > 7)
                        {
                            Debug.Log("Превышено количество допустимых выборов");
                        }
                        else if (choiseLength.Length < 1 || choiseLength == null)
                        {
                            Debug.Log("Не указаны выборы");
                        }
                    }
                }
                if (line.StartsWith("label - "))
                {
                    string[] lineparts = line.Split('-');
                    if (lineparts.Length == 2)
                    {
                        string labelName = lineparts[1].Trim();
                        pastLineId++;
                        lineId++;
                        ReadNovelFile();
                    }
                }
                if (line.StartsWith("jump: "))
                {
                    string[] lineparts = line.Split(':');
                    if (lineparts.Length == 2)
                    {
                        string jumpLabelName = lineparts[1].Trim();
                        GoToLabel(jumpLabelName);
                    }
                }
                if (line.StartsWith("return"))
                {
                    lineId = 0;
                    pastLineId = 0;
                    ReturnGame();
                }
            }

        }
        else
        {
            Debug.Log("Файл с текстом для новеллы отсуствует");
        }
    }

    public void ApplyBackgroundImage(string imageName)
    {
        nextBackground = imageName;
        
        string imagePath = "Фоны/" + imageName; // Предполагается, что изображения расположены в папке "Images" в папке Resources

        Sprite imageSprite = Resources.Load<Sprite>(imagePath); // Загружаем изображение из ресурсов по пути

        if (imageSprite != null)
        {
            back.sprite = imageSprite;
            pastLineId++;
            lineId++;
            ReadNovelFile();
        }
        else
        {
            Debug.Log("Изображение " + imageName + " не найдено в ресурсах");
            Debug.Log("Проверьте папку Resources на наличие файла " + imageName);
        }
    }

    public void ApplySpriteImage(string spriteName, string spritePosition)
    {
        string spritePath = "Персонажи/" + spriteName;
        Sprite imageSprite = Resources.Load<Sprite>(spritePath);
        if (imageSprite != null)
        {
            float width = imageSprite.rect.width / imageSprite.pixelsPerUnit;
            float height = imageSprite.rect.height / imageSprite.pixelsPerUnit;

            if (spritePosition == "right")
            {
                rightSprite.gameObject.SetActive(true);
                RectTransform rt = rightSprite.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(width, height);
                rightSprite.sprite = imageSprite;
                rightSprite.SetNativeSize();
                ReadNovelFile();
            }
            if (spritePosition == "left")
            {
                leftSprite.gameObject.SetActive(true);
                RectTransform rt = leftSprite.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(width, height);
                leftSprite.sprite = imageSprite;
                leftSprite.SetNativeSize();
                ReadNovelFile();
            }

            if (spritePosition == "center" || spritePosition == null)
            {
                centerSprite.gameObject.SetActive(true);
                RectTransform rt = centerSprite.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(width, height);
                centerSprite.sprite = imageSprite;
                centerSprite.SetNativeSize();
                ReadNovelFile();
            }
        }
        else
        {
            Debug.Log("Изображение " + spriteName + " не найдено в ресурсах");
            Debug.Log("Проверьте папку Resources на наличие файла " + spriteName);
        }
    }

    void HideSpriteImage(string spriteName, string spritePosition)
    {

            if (spritePosition == "right")
            {
                rightSprite.gameObject.SetActive(false);
                ReadNovelFile();
            }
            if (spritePosition == "left")
            {
                leftSprite.gameObject.SetActive(false);
                ReadNovelFile();
            }

            if (spritePosition == "center")
            {
                centerSprite.gameObject.SetActive(false);
                ReadNovelFile();
            }
    }

    public void PlayAudioFile(string audioName)
    {
        nextAudio = audioName;
        string audioPath = "Аудио/" + audioName;
        AudioClip audio = Resources.Load<AudioClip>(audioPath);
        a.clip = audio;
        a.mute = false;
        a.Play();
        ReadNovelFile();
    }

    void PlayVideoFile(string videoName)
    {
        gameMenu.SetActive(false);
        a.mute = true;
        string videoPath = "Видео/" + videoName;
        VideoClip video = Resources.Load<VideoClip>(videoPath);
        v.clip = video;
        v.Play();
        v.loopPointReached += OnVideoEnd;
    }
    public void ReturnGame()
    {
        a.mute = true;
        lineId = 0;
        isPaused = true;
        centerSprite.gameObject.SetActive(false);
        rightSprite.gameObject.SetActive(false);
        leftSprite.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        gameMenu.gameObject.SetActive(false);
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        a.mute = false;
        gameMenu.SetActive(true);
        isPlaying = false;
        vp.loopPointReached -= OnVideoEnd;
        ReadNovelFile();
    }

    public void GoToLabel(string jumpLabelName)
    {
        if (indexFile != null)
        {
            string[] lines = indexFile.text.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line.StartsWith("label - " + jumpLabelName))
                {
                    lineId = i;
                    lineId++;
                    pastLineId++;
                    ReadNovelFile();
                    break;
                }
            }
        }
    }
    public void Back()
    {
        if (lineId >= 0)
        {
            if (pastStroke.StartsWith("dialoge_"))
            {
                lineId = lineId - 2;
                pastLineId = pastLineId - 2;
                ReadNovelFile();
                Debug.Log("назад");
            }

            if (pastStroke.StartsWith("background: "))
            {
                lineId = lineId - 3;
                pastLineId = pastLineId - 3;
                string imageName = lastBackground;
                ApplyBackgroundImage(imageName);
            }

            if (pastStroke.StartsWith("audio play: "))
            {
                lineId = lineId - 3;
                pastLineId = pastLineId - 3;
                string audioName = lastAudio;
                PlayAudioFile(audioName);
            }
            if (pastStroke.StartsWith("audio stop "))
            {
                lineId = lineId - 3;
                pastLineId = pastLineId - 3;
                string audioName = lastAudio;
                PlayAudioFile(audioName);
            }
            if (pastStroke.StartsWith("video play: "))
            {
                lineId = lineId - 3;
                pastLineId = pastLineId - 3;
                ReadNovelFile();
            }

            if (pastStroke.StartsWith("spritehide: "))
            {
                string[] lineparts = pastStroke.Split(':');
                if (lineparts.Length == 2)
                {
                    string spriteLine = lineparts[1].Trim();
                    string[] spriteParts = spriteLine.Split(" ");
                    if (spriteParts.Length == 2)
                    {
                        string spriteName = spriteParts[0].Trim();
                        string spritePosition = spriteParts[1].Trim();
                        if (spritePosition == "right")
                        {
                            rightSprite.gameObject.SetActive(true);
                            lineId = lineId - 3;
                            pastLineId = pastLineId - 3;
                            ReadNovelFile();
                        }
                        if (spritePosition == "left")
                        {
                            leftSprite.gameObject.SetActive(true);
                            lineId = lineId - 3;
                            pastLineId = pastLineId - 3;
                            ReadNovelFile();
                        }

                        if (spritePosition == "center")
                        {
                            centerSprite.gameObject.SetActive(true);
                            lineId = lineId - 3;
                            pastLineId = pastLineId - 3;
                            ReadNovelFile();
                        }
                    }
                }

            }

            if (pastStroke.StartsWith("sprite: "))
            {
                string[] lineparts = pastStroke.Split(':');
                if (lineparts.Length == 2)
                {
                    string spriteLine = lineparts[1].Trim();
                    string[] spriteParts = spriteLine.Split(" ");
                    if (spriteParts.Length == 2)
                    {
                        string spriteName = spriteParts[0].Trim();
                        string spritePosition = spriteParts[1].Trim();
                        if (spritePosition == "right")
                        {
                            rightSprite.gameObject.SetActive(false);
                            lineId = lineId - 3;
                            pastLineId = pastLineId - 3;
                            ReadNovelFile();
                        }
                        if (spritePosition == "left")
                        {
                            leftSprite.gameObject.SetActive(false);
                            lineId = lineId - 3;
                            pastLineId = pastLineId - 3;
                            ReadNovelFile();
                        }

                        if (spritePosition == "center")
                        {
                            centerSprite.gameObject.SetActive(false);
                            lineId = lineId - 3;
                            pastLineId = pastLineId - 3;
                            ReadNovelFile();
                        }
                    }
                }
            }
        }
    }
}
