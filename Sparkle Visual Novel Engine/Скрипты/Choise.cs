using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Choise : MonoBehaviour
{
    public VisualNovell vn;
    public int choiseSum;
    public GameObject choise1;
    public GameObject choise2;
    public GameObject choise3;
    public GameObject choise4;
    public GameObject choise5;
    public GameObject choise6;
    public GameObject choise7;
    public string choiseText1;
    public string choiseText2;
    public string choiseText3;
    public string choiseText4;
    public string choiseText5;
    public string choiseText6;
    public string choiseText7;
    public TMP_Text textChoise1;
    public TMP_Text textChoise2;
    public TMP_Text textChoise3;
    public TMP_Text textChoise4;
    public TMP_Text textChoise5;
    public TMP_Text textChoise6;
    public TMP_Text textChoise7;
    public bool selected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (choiseSum == 1 && selected == false)
        {
            choise1.SetActive(true);
            string[] text1 = choiseText1.Split("-");
            if (text1.Length == 2 )
            {
                textChoise1.text = text1[0].Trim();
            }         
        }
        else if (choiseSum == 2 && selected == false)
        {
            choise1.SetActive(true);
            choise2.SetActive(true);
            string[] text1 = choiseText1.Split("-");
            if (text1.Length == 2)
            {
                textChoise1.text = text1[0].Trim();
            }
            string[] text2 = choiseText2.Split("-");
            if (text2.Length == 2)
            {
                textChoise1.text = text2[0].Trim();
            }
        }
        else if (choiseSum == 3 && selected == false)
        {
            choise1.SetActive(true);
            choise2.SetActive(true);
            choise3.SetActive(true);
            string[] text1 = choiseText1.Split("-");
            if (text1.Length == 2)
            {
                textChoise1.text = text1[0].Trim();
            }
            string[] text2 = choiseText2.Split("-");
            if (text2.Length == 2)
            {
                textChoise2.text = text2[0].Trim();
            }
            string[] text3 = choiseText3.Split("-");
            if (text3.Length == 2)
            {
                textChoise3.text = text3[0].Trim();
            }
        }
        else if (choiseSum == 4 && selected == false)
        {
            choise1.SetActive(true);
            choise2.SetActive(true);
            choise3.SetActive(true);
            choise4.SetActive(true);
            string[] text1 = choiseText1.Split("-");
            if (text1.Length == 2)
            {
                textChoise1.text = text1[0].Trim();
            }
            string[] text2 = choiseText2.Split("-");
            if (text2.Length == 2)
            {
                textChoise2.text = text2[0].Trim();
            }
            string[] text3 = choiseText3.Split("-");
            if (text3.Length == 2)
            {
                textChoise3.text = text3[0].Trim();
            }
            string[] text4 = choiseText4.Split("-");
            if (text4.Length == 2)
            {
                textChoise4.text = text4[0].Trim();
            }
        }
        else if (choiseSum == 5 && selected == false)
        {
            choise1.SetActive(true);
            choise2.SetActive(true);
            choise3.SetActive(true);
            choise4.SetActive(true);
            choise5.SetActive(true);
            string[] text1 = choiseText1.Split("-");
            if (text1.Length == 2)
            {
                textChoise1.text = text1[0].Trim();
            }
            string[] text2 = choiseText2.Split("-");
            if (text2.Length == 2)
            {
                textChoise2.text = text2[0].Trim();
            }
            string[] text3 = choiseText3.Split("-");
            if (text3.Length == 2)
            {
                textChoise3.text = text3[0].Trim();
            }
            string[] text4 = choiseText4.Split("-");
            if (text4.Length == 2)
            {
                textChoise4.text = text4[0].Trim();
            }
            string[] text5 = choiseText5.Split("-");
            if (text5.Length == 2)
            {
                textChoise5.text = text5[0].Trim();
            }
        }
        else if (choiseSum == 6 && selected == false)
        {
            choise1.SetActive(true);
            choise2.SetActive(true);
            choise3.SetActive(true);
            choise4.SetActive(true);
            choise5.SetActive(true);
            choise6.SetActive(true);
            string[] text1 = choiseText1.Split("-");
            if (text1.Length == 2)
            {
                textChoise1.text = text1[0].Trim();
            }
            string[] text2 = choiseText2.Split("-");
            if (text2.Length == 2)
            {
                textChoise2.text = text2[0].Trim();
            }
            string[] text3 = choiseText3.Split("-");
            if (text3.Length == 2)
            {
                textChoise3.text = text3[0].Trim();
            }
            string[] text4 = choiseText4.Split("-");
            if (text4.Length == 2)
            {
                textChoise4.text = text4[0].Trim();
            }
            string[] text5 = choiseText5.Split("-");
            if (text5.Length == 2)
            {
                textChoise5.text = text5[0].Trim();
            }
            string[] text6 = choiseText6.Split("-");
            if (text6.Length == 2)
            {
                textChoise6.text = text6[0].Trim();
            }
        }
        else if (choiseSum == 7 && selected == false)
        {
            choise1.SetActive(true);
            choise2.SetActive(true);
            choise3.SetActive(true);
            choise4.SetActive(true);
            choise5.SetActive(true);
            choise6.SetActive(true);
            choise7.SetActive(true);
            string[] text1 = choiseText1.Split("-");
            if (text1.Length == 2)
            {
                textChoise1.text = text1[0].Trim();
            }
            string[] text2 = choiseText2.Split("-");
            if (text2.Length == 2)
            {
                textChoise2.text = text2[0].Trim();
            }
            string[] text3 = choiseText3.Split("-");
            if (text3.Length == 2)
            {
                textChoise3.text = text3[0].Trim();
            }
            string[] text4 = choiseText4.Split("-");
            if (text4.Length == 2)
            {
                textChoise4.text = text4[0].Trim();
            }
            string[] text5 = choiseText5.Split("-");
            if (text5.Length == 2)
            {
                textChoise5.text = text5[0].Trim();
            }
            string[] text6 = choiseText6.Split("-");
            if (text6.Length == 2)
            {
                textChoise6.text = text6[0].Trim();
            }
            string[] text7 = choiseText7.Split("-");
            if (text7.Length == 2)
            {
                textChoise7.text = text7[0].Trim();
            }
        }
    }

    public void ChoiseButton1()
    {
        selected = true;
        choise1.SetActive(false);
        choise2.SetActive(false);
        choise3.SetActive(false);
        choise4.SetActive(false);
        choise5.SetActive(false);
        choise6.SetActive(false);
        choise7.SetActive(false);
        vn.textBox.SetActive(true);
        string[] text = choiseText1.Split("-");
        if (text.Length == 2)
        {
            if (text[1].Trim().StartsWith("jump"))
            {
                string labelJump = text[1].Trim();
                string[] labelNameJump = labelJump.Split("|");
                if (labelNameJump.Length == 2)
                {
                    string labelJumpName = labelNameJump[1].Trim();
                    vn.GoToLabel(labelJumpName);
                }
            }
        }
    }

    public void ChoiseButton2()
    {
        selected = true;
        choise1.SetActive(false);
        choise2.SetActive(false);
        choise3.SetActive(false);
        choise4.SetActive(false);
        choise5.SetActive(false);
        choise6.SetActive(false);
        choise7.SetActive(false);
        vn.textBox.SetActive(true);
        string[] text = choiseText2.Split("-");
        if (text.Length == 2)
        {
            if (text[1].Trim().StartsWith("jump"))
            {
                string labelJump = text[1].Trim();
                string[] labelNameJump = labelJump.Split("|");
                if (labelNameJump.Length == 2)
                {
                    string labelJumpName = labelNameJump[1].Trim();
                    vn.GoToLabel(labelJumpName);
                }
            }
        }
    }

    public void ChoiseButton3()
    {
        selected = true;
        choise1.SetActive(false);
        choise2.SetActive(false);
        choise3.SetActive(false);
        choise4.SetActive(false);
        choise5.SetActive(false);
        choise6.SetActive(false);
        choise7.SetActive(false);
        vn.textBox.SetActive(true);
        string[] text = choiseText3.Split("-");
        if (text.Length == 2)
        {
            if (text[1].Trim().StartsWith("jump"))
            {
                string labelJump = text[1].Trim();
                string[] labelNameJump = labelJump.Split("|");
                if (labelNameJump.Length == 2)
                {
                    string labelJumpName = labelNameJump[1].Trim();
                    vn.GoToLabel(labelJumpName);
                }
            }
        }
    }

    public void ChoiseButton4()
    {
        selected = true;
        choise1.SetActive(false);
        choise2.SetActive(false);
        choise3.SetActive(false);
        choise4.SetActive(false);
        choise5.SetActive(false);
        choise6.SetActive(false);
        choise7.SetActive(false);
        vn.textBox.SetActive(true);
        string[] text = choiseText4.Split("-");
        if (text.Length == 2)
        {
            if (text[1].Trim().StartsWith("jump"))
            {
                string labelJump = text[1].Trim();
                string[] labelNameJump = labelJump.Split("|");
                if (labelNameJump.Length == 2)
                {
                    string labelJumpName = labelNameJump[1].Trim();
                    vn.GoToLabel(labelJumpName);
                }
            }
        }
    }

    public void ChoiseButton5()
    {
        selected = true;
        choise1.SetActive(false);
        choise2.SetActive(false);
        choise3.SetActive(false);
        choise4.SetActive(false);
        choise5.SetActive(false);
        choise6.SetActive(false);
        choise7.SetActive(false);
        vn.textBox.SetActive(true);
        string[] text = choiseText5.Split("-");
        if (text.Length == 2)
        {
            if (text[1].Trim().StartsWith("jump"))
            {
                string labelJump = text[1].Trim();
                string[] labelNameJump = labelJump.Split("|");
                if (labelNameJump.Length == 2)
                {
                    string labelJumpName = labelNameJump[1].Trim();
                    vn.GoToLabel(labelJumpName);
                }
            }
        }
    }

    public void ChoiseButton6()
    {
        selected = true;
        choise1.SetActive(false);
        choise2.SetActive(false);
        choise3.SetActive(false);
        choise4.SetActive(false);
        choise5.SetActive(false);
        choise6.SetActive(false);
        choise7.SetActive(false);
        vn.textBox.SetActive(true);
        string[] text = choiseText6.Split("-");
        if (text.Length == 2)
        {
            if (text[1].Trim().StartsWith("jump"))
            {
                string labelJump = text[1].Trim();
                string[] labelNameJump = labelJump.Split("|");
                if (labelNameJump.Length == 2)
                {
                    string labelJumpName = labelNameJump[1].Trim();
                    vn.GoToLabel(labelJumpName);
                }
            }
        }
    }

    public void ChoiseButton7()
    {
        selected = true;
        choise1.SetActive(false);
        choise2.SetActive(false);
        choise3.SetActive(false);
        choise4.SetActive(false);
        choise5.SetActive(false);
        choise6.SetActive(false);
        choise7.SetActive(false);
        vn.textBox.SetActive(true);
        string[] text = choiseText7.Split("-");
        if (text.Length == 2)
        {
            if (text[1].Trim().StartsWith("jump"))
            {
                string labelJump = text[1].Trim();
                string[] labelNameJump = labelJump.Split("|");
                if (labelNameJump.Length == 2)
                {
                    string labelJumpName = labelNameJump[1].Trim();
                    vn.GoToLabel(labelJumpName);
                }
            }
        }
    }
}
