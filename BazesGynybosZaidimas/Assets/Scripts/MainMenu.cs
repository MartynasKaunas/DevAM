using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject Title;
    public GameObject PlayButton;
    public GameObject HelpButton;
    public GameObject QuitButton;
    public GameObject BackButton;
    public GameObject TeamName;
    public Text HelpText;
    public static string pagalba = "Jūs valdote bokštelį su patranka." + Environment.NewLine +
                        "Jūsų tikslas - kuo ilgiau išgyventi, pereiti kuo daugiau lygių ir surinkti kuo daugiau taškų." + Environment.NewLine +
                        "Bokštelio taikymasis valdomas pele, šaudoma kairiuoju pelės mygtuku " + Environment.NewLine + 
                        "Šovinių kiekis ribotas. Šoviniams pasibaigus spauskite R raidę, kad iš naujo užtaisytumėte ginklą " + Environment.NewLine +
                        "Turite maną, kurią, paspaudę Q raidę, galite naudoti specialiam sustiprinančiam gebėjimui " + Environment.NewLine +
                        "Tarp lygių parduotuvėje už surinktus taškus galite pirkti naujus ginklus arba tobulinti jau turimą" + Environment.NewLine +
                        "  " + Environment.NewLine +
                        "Sėkmės" + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine;

    public void StartGame()
    {
        SceneManager.LoadScene("TestScene");
        HelpText.text = "";
        HelpText.enabled = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        Title.SetActive(true);
        PlayButton.SetActive(true);
        HelpButton.SetActive(true);
        QuitButton.SetActive(true);
        BackButton.SetActive(false);
        TeamName.SetActive(true);
        HelpText.enabled = false;
        HelpText.text = "";

    }

    public void Help()
    {
        Title.SetActive(false);
        PlayButton.SetActive(false);
        HelpButton.SetActive(false);
        QuitButton.SetActive(false);
        BackButton.SetActive(true);
        TeamName.SetActive(false);
        HelpText.enabled = true;
        HelpText.text = pagalba;
    }
}
