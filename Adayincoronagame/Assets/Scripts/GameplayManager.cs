using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public int CoronaRisk = 0;
    ScreenManager sm;
    public GameObject player;

    //Buttons
    public GameObject Home;
    public GameObject University;
    public GameObject Cafe;

    // Start is called before the first frame update
    void Start()
    {
        sm = ScreenManager.instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveCharacter(GameObject target)
    {
        Vector2 start = player.transform.position;
        Vector2 end = target.transform.position;
        player.transform.position = Vector2.Lerp(start, end, 1);

        //Play sound effects according to style (Bus/taxi/walk)
    }

    public void AddCoronaRisk(int risk)
    {
       CoronaRisk = CoronaRisk + risk;
        if (CoronaRisk > 100)
        {
            CoronaRisk = 100;
        }
        else if (CoronaRisk < 0)
        {
            CoronaRisk = 0;
        }
        sm.ChangeCoronaMeter(CoronaRisk);
    }

    #region DailyActivities
    // Daily Activities

    public void GoToHome()
    {
        string Title = "Home";
        string Question = "It's time to go back home, I need some rest!";
        sm.OpenQuestionArea(Title,Question);
        MoveCharacter(Home);
    }
    public void GoToUni()
    {
        string Title = "Uni";
        string Question = "It's time to go to university, I need to remember that I'm still a student.";
        sm.OpenQuestionArea(Title, Question);
        MoveCharacter(University);
    }
    public void GoToCafe()
    {
        string Title = "Cafe";
        string Question = "Who feels that it's coffe o'clock! Maybe I can also get some cookies as well.";
        sm.OpenQuestionArea(Title, Question);
        MoveCharacter(Cafe);
    }
    #endregion

    #region TransportationDecisions
    // Transportation Decisions

    public void Walk()
    {
        sm.CloseTheQuestionArea();
    }

    public void PublicTransport()
    {
        //    string Title = "Wear mask?";
        //    string Question = "You decide to go by public transport, are you going to wear mask to protect yourself from any infection?";
        sm.CloseTheQuestionArea();
        sm.OpenMaskPanel();
        int risk = 20;
        AddCoronaRisk(risk);
    }

    public void Taxi()
    {
        sm.CloseTheQuestionArea();
        int risk = 5;
        AddCoronaRisk(risk);
    }

    #endregion

    #region HealthDecisions
    // Health Decisions

    public void WearMaskYes()
    {
        int risk = -10;
        AddCoronaRisk(risk);
        sm.CloseMaskPanel();
    }

    public void UseSanitizerYes()
    {
        int risk = -5;
        AddCoronaRisk(risk);
        sm.CloseSanitizerPanel();
    }

    public void WashYourHandsYes()
    {
        int risk = -5;
        AddCoronaRisk(risk);
        sm.CloseWashHandsPanel();
    }

    public void WearMaskNo()
    {
        sm.CloseMaskPanel();
    }

    public void UseSanitizerNo()
    {
        sm.CloseSanitizerPanel();
    }

    public void WashYourHandsNo()
    {
        sm.CloseWashHandsPanel();
    }
    #endregion

    // Day/Night Shift


}
