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

    public GameObject panelMask;

    public GameObject panelWashHands;

    public GameObject panelSanitizer;

    public Slider CoronaSlider;

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

    public void ChangeCoronaMeter(int CoronaRisk)
    {
        CoronaSlider.value = CoronaRisk;
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

    public void OpenMaskPanel()
    {
        panelMask.SetActive(true);
    }

    public void CloseMaskPanel()
    {
        panelMask.SetActive(false);
    }

    public void OpenWashHandsPanel()
    {
        panelWashHands.SetActive(true);
    }

    public void CloseWashHandsPanel()
    {
        panelWashHands.SetActive(false);
    }

    public void OpenSanitizerPanel()
    {
        panelSanitizer.SetActive(true);
    }

    public void CloseSanitizerPanel()
    {
        panelSanitizer.SetActive(false);
    }
}
