using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreText, livesText;
    public float score = 0, lives = 3;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
    }

    private void Update() {
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();

        if(lives <= 0) {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void DeductLife() {
        lives -= 1f;
    }

    public void AddScore() {
        score += 1f;
    }

}
