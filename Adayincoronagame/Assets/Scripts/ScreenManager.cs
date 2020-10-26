using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    public GameObject panelQuestion;
    public Text panelTextTitle;
    public Text panelTextQuestion;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void OpenQuestionArea(string title, string question)
    {
        panelTextTitle.text = title;
        panelTextQuestion.text = question;

        panelQuestion.SetActive(true);
    }

    public void CloseTheQuestionArea()
    {
        panelQuestion.SetActive(false);
    }
}
