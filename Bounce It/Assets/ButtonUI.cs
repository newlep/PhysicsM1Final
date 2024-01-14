using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public void StartButton()
{
    SceneManager.LoadScene("Playground");

}
    public void QuitButton()
{
    Application.Quit();
}
}
