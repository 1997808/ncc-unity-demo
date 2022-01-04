using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LevelButton()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void OptionButton()
    {
        SceneManager.LoadScene("Option", LoadSceneMode.Additive);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
