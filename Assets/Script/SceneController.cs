using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("Credit");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void openGit()
    {
        Application.OpenURL("https://github.com/MHasanudin");
    }

    public void openLinkedin()
    {
        Application.OpenURL("https://linkedin.com/in/mhhasanudin/");
    }

    public void sendEmail()
    {
        string mail = "mhhasanudin22@gmail.com";
        string subject = "Subject Test Game Pong";
        string body = "Hasan, Game-mu keren dan Kamu tampan, hehe....";

        string mailTo = "mailTo:" + mail + "?subject=" + subject + "&body=" + body;

        Application.OpenURL(mailTo);
    }


}
