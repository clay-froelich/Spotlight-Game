using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI redKillText;
    public TextMeshProUGUI blueKillText;
    public TextMeshProUGUI percentLightText;
    public TextMeshProUGUI rulesText;
    public GameObject titleScreen;
    public Button restartButton;
    public int redKills = 0;
    public int blueKills = 0;
    public bool gameOver = false;
    public bool gameStart = false;
    public bool rulesToggle = false;
    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GameObject.Find("Light").GetComponent<Light>();
    }

    public void GameOver() {
        UpdateKills();
        UpdateLightText();
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        blueKillText.gameObject.SetActive(true);
        redKillText.gameObject.SetActive(true);
        percentLightText.gameObject.SetActive(true);
    }

    public void UpdateKills() {
        redKillText.text = "Kills: " + redKills;
        blueKillText.text = "Kills: " + blueKills;
    }

    public void UpdateLightText() {
        int lightPercent = (int)((light.range - 17) * 100 / 5);
        percentLightText.text = "Spotlight Strength: " + lightPercent + "%";
    }
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame() {
        titleScreen.gameObject.SetActive(false);
        gameStart = true;
    }

    public void ToggleRules() {
        rulesToggle = !rulesToggle;
        rulesText.gameObject.SetActive(rulesToggle);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
