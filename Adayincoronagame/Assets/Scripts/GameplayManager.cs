using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public int CoronaRisk;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region DailyActivities
        // Daily Activities

    public void GoToHome()
    {
        string strTitle = "Home";
        string strQuestion = "Home";
        ScreenManager.instance.OpenQuestionArea(strTitle,strQuestion);
    }
    public void GoToUni()
    {
        string strTitle = "Uni";
        string strQuestion = "Uni";
        ScreenManager.instance.OpenQuestionArea(strTitle, strQuestion);
    }
    public void GoToCafe()
    {
        string strTitle = "Cafe";
        string strQuestion = "Cafe";
        ScreenManager.instance.OpenQuestionArea(strTitle, strQuestion);
    }
    #endregion

    #region TransportationDecisions
        // Transportation Decisions

    public void Walk()
    {
        
    }

    public void PublicTransport()
    {

    }

    public void Taxi()
    {

    }

    #endregion

    #region HealthDecisions
    // Health Decisions

    public void WearMask()
    {

    }

    public void UseSanitizer()
    {

    }

    public void WashYourHands()
    {

    }
    #endregion

    // Day/Night Shift


}
