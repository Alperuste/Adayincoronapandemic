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
    public GameObject Cinema;
    public GameObject ShoppingCenter;
    public GameObject KadriorgPark;
    public GameObject OldTown;

    [SerializeField]
    GameObject currentTarget;

    //night mode
    public int numberOfPlacesVisited = 0;
    public SpriteRenderer Map;
    private bool isNightMode = false;


    // Start is called before the first frame update
    void Start()
    {
        sm = ScreenManager.instance;
        Home.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfPlacesVisited == 4)
        {
            if (isNightMode==false)
            {
                 SwitchToNightMode();
            }
        }
        else if (numberOfPlacesVisited > 5)
        {
            ForceToGoHome();
        }
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
        else if (currentTarget == University || currentTarget == Cafe || currentTarget == Bar || currentTarget == Cinema || currentTarget == ShoppingCenter)
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
    }
    public void GoToUni()
    {
        string Title = "Go to University";
        string Question = "It's time to go to university, I need to remember that I'm still a student.";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = University;
    }
    public void GoToCafe()
    {
        string Title = "Go to Cafe";
        string Question = "Who feels that it's coffe o'clock! Maybe I can also get some cookies as well.";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = Cafe;
    }

    public void GoToBar()
    {
        string Title = "Go to Bar";
        string Question = "My classmates were talking about a beer pong tournament at this bar, let’s check what is going on.";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = Bar;
    }
    public void GoToFriendsPlace()
    {
        string Title = "Go to Friend's Place";
        string Question = "Long time no see my friend!";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = FriendsPlace;
    }
    public void GoToCinema()
    {
        string Title = "Go to Cinema";
        string Question = "I've seen the ads about a new movie, maybe it is time to watch that with some popcorn.";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = Cinema;
    }
    public void GoToShoppingCenter()
    {
        string Title = "Go to Shopping Center";
        string Question = " Let’s see if they have anything on discount, I don’t need anything but maybe I can buy a new t-shirt!";
        sm.OpenQuestionArea(Title, Question);
        currentTarget = ShoppingCenter;
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
        numberOfPlacesVisited++;

        sm.CloseTheQuestionArea();
        MoveCharacter(currentTarget);
    }

    public void PublicTransport()
    {
        numberOfPlacesVisited++;

        sm.CloseTheQuestionArea();
        sm.OpenMaskPanel();
        int risk = 20;
        AddCoronaRisk(risk);
    }

    public void Taxi()
    {
        numberOfPlacesVisited++;

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
        if (currentTarget == Home)
        {
            sm.OpenEndGamePanel(CoronaRisk);
        }
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
        if (currentTarget == Home)
        {
            sm.OpenEndGamePanel(CoronaRisk);
        }
    }
    #endregion

    // Day/Night Shift

    public void SwitchToNightMode()
    {
        isNightMode = true;
        Map.material.color = Color.grey;
        Home.SetActive(true);
        sm.OpenGoHomePanel();
    }

    public void ForceToGoHome()
    {
        University.SetActive(false);
        Cinema.SetActive(false);
        KadriorgPark.SetActive(false);
        OldTown.SetActive(false);
        Bar.SetActive(false);
        FriendsPlace.SetActive(false);
        ShoppingCenter.SetActive(false);
        Cafe.SetActive(false);
    }
}
