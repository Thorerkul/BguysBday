using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Object playscene;
    public GameObject mainCanvas;
    public GameObject optionsCanvas;
    public void Play()
    {
        //THIS IS HARD-CODED, CHANGE THIS AS YOU WANT
        SceneManager.LoadScene(playscene.name);
    }
    public void Options()
    {
        //THE ACTUAL OPTIONS CANVAS IS EMPTY RN, ADD WHATEVER YOU WANT TO IT.
        mainCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Back(){
        mainCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
    }
    void Update()
    {
    }
}
