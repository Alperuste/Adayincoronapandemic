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
    public GameObject Bar;
    public GameObject FriendsPlace;
    public GameObject GroceryStore;
    public GameObject ShoppingCenter;
    public GameObject KadriorgPark;
    public GameObject OldTown;

    [SerializeField]
    GameObject currentTarget;

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

        if (currentTarget == Home || currentTarget == FriendsPlace)
        {
            sm.OpenWashHandsPanel();
        }
        else if (currentTarget == University || currentTarget == Cafe || currentTarget == Bar || currentTarget == GroceryStore || currentTarget == ShoppingCenter)
        {
            sm.OpenSanitizerPanel();
        }
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
        string Title = "Go to Home";
        string Question = "It's time to go back home, I need some rest!";
        sm.OpenQuestionArea(Title,Question);
        currentTarget = Home;
        //sm.OpenWashHandsPanel();
    }
    public void GoToUni()
    {
        string Title = "Go to University";
        string Question = "It's time to go to university, I need to remember that I'm still a student.";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = University;
        //sm.OpenSanitizerPanel();
    }
    public void GoToCafe()
    {
        string Title = "Go to Cafe";
        string Question = "Who feels that it's coffe o'clock! Maybe I can also get some cookies as well.";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = Cafe;
        //sm.OpenSanitizerPanel();
    }

    public void GoToBar()
    {
        string Title = "Go to Bar";
        string Question = "My classmates were talking about a beer pong tournament at this bar, let’s check what is going on.";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = Bar;
        //sm.OpenSanitizerPanel();
    }
    public void GoToFriendsPlace()
    {
        string Title = "Go to Friend's Place";
        string Question = "Long time no see my friend!";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = FriendsPlace;
        //sm.OpenWashHandsPanel();
    }
    public void GoToGroceryStore()
    {
        string Title = "Go to Grocery Store";
        string Question = "I need to buy some groceries for home, nothing left to eat.";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = GroceryStore;
        //sm.OpenSanitizerPanel();
    }
    public void GoToShoppingCenter()
    {
        string Title = "Go to Shopping Center";
        string Question = " Let’s see if they have anything on discount, I don’t need anything but maybe I can buy a new t-shirt!";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = ShoppingCenter;
        //sm.OpenSanitizerPanel();
    }
    public void GoToKadriorgPark()
    {
        string Title = "Go to Kadriorg Park";
        string Question = "Ahh Kadriorg Park, one of my favorite places to walk around and have some fresh air.";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = KadriorgPark;
    }
    public void GoToOldTown()
    {
        string Title = "Go to Old Town";
        string Question = "My dear old town! That's one of the reasons that I choose to study in Tallinn!";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = OldTown;
    }
    #endregion

    #region TransportationDecisions
    // Transportation Decisions

    public void Walk()
    {
        sm.CloseTheQuestionArea();
        MoveCharacter(currentTarget);
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
        MoveCharacter(currentTarget);
    }

    #endregion

    #region HealthDecisions
    // Health Decisions

    public void WearMaskYes()
    {
        int risk = -10;
        AddCoronaRisk(risk);
        sm.CloseMaskPanel();
        MoveCharacter(currentTarget);
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
        MoveCharacter(currentTarget);
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
