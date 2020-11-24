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

    public GameObject panelOptions;

    bool isAudioMuted = false;

    public GameObject btnMuteAudio;
    public GameObject btnUnmuteAudio;

    public GameObject panelGoHome;
    public GameObject panelEndGame;

    public Text panelEndGameText;

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

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
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

    //Options panel

    public void OpenOptionsPanel()
    {
        Time.timeScale = 0;
        panelOptions.SetActive(true);
    }

    public void CloseOptionsPanel()
    {
        Time.timeScale = 1;
        panelOptions.SetActive(false);
    }

    public void MuteTheSounds()
    {
        AudioListener.volume = 0;
        btnMuteAudio.SetActive(false);
        btnUnmuteAudio.SetActive(true);
    }

    public void UnMuteTheSounds()
    {
        AudioListener.volume = 1;
        btnMuteAudio.SetActive(true);
        btnUnmuteAudio.SetActive(false);
    }

    void ChangeTheSoundImage()
    {
        if (isAudioMuted)
        {

        }
    }

    //Go home panel

    public void OpenGoHomePanel()
    {
        panelGoHome.SetActive(true);
    }
    public void CloseGoHomePanel()
    {
        panelGoHome.SetActive(false);
    }

    //End game panel

    public void OpenEndGamePanel(int Risk)
    {
        string testText = "Today, you had a busy day. You've been in different places around the city and contacted with different people during the day. With all the health precautions you followed, you finished the day with a " + Risk.ToString() + "% infection risk. You didn't get sick today, but what about tomorrow? Please be aware of the health precautions and follow them.  #StayHealthy";
        panelEndGameText.text = testText;
        panelEndGame.SetActive(true);
    }

}
