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

    IEnumerator Testcoroutine;


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
    public void GoToIntro()
    {
        SceneManager.LoadScene("Intro");
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
        if (panelQuestion.activeInHierarchy == true || panelMask.activeInHierarchy == true)
        {
            Testcoroutine = CROpenWashHandsanel(1f);
            StartCoroutine(Testcoroutine);
        }
        else
        {
            panelWashHands.SetActive(true);
            StopCoroutine(Testcoroutine);
        }
    }

    public void CloseWashHandsPanel()
    {
        panelWashHands.SetActive(false);
    }

    public void OpenSanitizerPanel()
    {
        if (panelQuestion.activeInHierarchy == true || panelMask.activeInHierarchy == true)
        {
            Testcoroutine = CROpenSanitizerPanel(1f);
            StartCoroutine(Testcoroutine);
        }
        else
        {
            panelSanitizer.SetActive(true);
            StopCoroutine(Testcoroutine);
        }
    }

    public void CloseSanitizerPanel()
    {
        panelSanitizer.SetActive(false);
    }

    //CoRoutines
    private IEnumerator CROpenWashHandsanel(float waitTime)
    {
            yield return new WaitForSeconds(waitTime);
            OpenWashHandsPanel();
    }

    private IEnumerator CROpenSanitizerPanel(float waitTime)
    {
            yield return new WaitForSeconds(waitTime);
            OpenSanitizerPanel();
    }
}
