using System;
using System.ComponentModel.Design.Serialization;
using Mono.Cecil.Cil;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenLockerScript : MonoBehaviour
{
    [SerializeField] private Text timerText;
    private float timeLeft = 60;
    [SerializeField] private Text pinAText;
    [SerializeField] private Text pinBText;
    [SerializeField] private Text pinCText;
    [SerializeField] private Text goalText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text gameOverText;
    private int[] currentLevel = new int[] {};
    private int[] level1 = {4, 2, 6, 555};
    void Start()
    {
        currentLevel = level1;
        LockerInfo(currentLevel);
    }

    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = Mathf.Round(timeLeft).ToString();
    }

    private void LockerInfo (int [] level)
    {
        pinAText.text = level[0].ToString();
        pinBText.text = level[1].ToString();
        pinCText.text = level[2].ToString();
        goalText.text = level[3].ToString();
    }

    public void HummerButton()
    {
        int a = Convert.ToInt32(pinAText.text);
        int b = Convert.ToInt32(pinBText.text);
        int c = Convert.ToInt32(pinCText.text);
        pinAText.text = (a + 1).ToString();
        pinBText.text = (b + 3).ToString();
        pinCText.text = (c - 1).ToString();
        Unlock();
    }

    public void MasterKey()
    {
        int a = Convert.ToInt32(pinAText.text);
        int b = Convert.ToInt32(pinBText.text);
        int c = Convert.ToInt32(pinCText.text);
        pinAText.text = (a - 1).ToString();
        pinBText.text = (b + 2).ToString();
        pinCText.text = (c - 1).ToString();
        Unlock();   
    }

    public void Drill()
    {
        int a = Convert.ToInt32(pinAText.text);
        int b = Convert.ToInt32(pinBText.text);
        int c = Convert.ToInt32(pinCText.text);
        pinAText.text = (a + 2).ToString();
        pinBText.text = (b - 2).ToString();
        pinCText.text = (c - 2).ToString();
        Unlock();
    }

    public void Unlock()
    {
        string result = $"{pinAText.text}{pinBText.text}{pinCText.text}";
        if(result == "555")
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "YOU WIN!";
        }
    }

    public void Restart()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
