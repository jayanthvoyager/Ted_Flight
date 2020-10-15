using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Main_Jet;
    public GameObject SubJet1;
    public GameObject SubJet2;
    public bool gameLost;
    public bool gameWon;
    public GameObject GameLost_Canvas;
    public GameObject GameWon_Canvas;

    public bool Main_Jet_Landed_Pause= false;
    public bool SubJet1_Landed_Pause= false;
    public bool SubJet2_Landed_Pause= false;

    public GameObject UIMain_Jet;
    public GameObject UI1Main_Jet;
    public GameObject UISubJet1;
    public GameObject UISubJet2;

    public GameObject UIStopSubJet1;
    public GameObject UIStopSubJet2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GameStart()
    {
       if( Main_Jet_Landed_Pause == false)
        {
            Main_Jet.GetComponent<Test>().GameOn();
        }
        if (SubJet1_Landed_Pause == false)
        {
            SubJet1.GetComponent<Test>().GameOn();
        }
        if (SubJet2_Landed_Pause == false)
        {
            SubJet2.GetComponent<Test>().GameOn();
        }
    }

    public void subJet1_Landed_Pause()
    {
        SubJet1_Landed_Pause = true;
        SubJet1.GetComponent<Test>().Fuel = 135;
        SubJet1.GetComponent<Test>().IncreaseFuelSubJet2();
    }

    public void subJet2_Landed_Pause()
    {
        SubJet2_Landed_Pause = true;
        SubJet2.GetComponent<Test>().Fuel = 135;
        SubJet2.GetComponent<Test>().IncreaseFuelSubJet2();
    }

    public void subJet1_Landed_Go()
    {
        SubJet1_Landed_Pause = false;
        
    }

    public void subJet2_Landed_Go()
    {
        SubJet2_Landed_Pause = false;
       
    }

    public void GameLost()
    {
        if(gameLost==true)
        GameLost_Canvas.SetActive(true);
    }

    public void Fuel_to_MainJet_From_SubJet1()
    {
       if(Main_Jet.GetComponent<Test>().Fuel<180)
        {
 Main_Jet.GetComponent<Test>().IncreseFuel_in_MainJet();
        SubJet1.GetComponent<Test>().reduceFuelSubJet1();
        }
       
    }

    public void Fuel_to_MainJet_From_SubJet2()
    {
        if (Main_Jet.GetComponent<Test>().Fuel < 180)
        {
            Main_Jet.GetComponent<Test>().IncreseFuel_in_MainJet();
            SubJet2.GetComponent<Test>().reduceFuelSubJet2();
        }
    }

    public void IncreaseFueltoSubjet2()
    {
        if (SubJet2.GetComponent<Test>().Fuel < 180)
        {
            SubJet1.GetComponent<Test>().reduceFuelSubJet1();
            SubJet2.GetComponent<Test>().IncreaseFuelSubJet2();
        }
    }

    public void IncreaseFueltoSubjet1()
    {
        if (SubJet1.GetComponent<Test>().Fuel < 180)
        {
            SubJet2.GetComponent<Test>().reduceFuelSubJet2();
            SubJet1.GetComponent<Test>().IncreaseFuelSubJet1();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }





    // Update is called once per frame
    void Update()
    {
        if(Main_Jet.GetComponent<Test>().FinalAngle == 360&& SubJet1.GetComponent<Test>().FinalAngle == 360 && SubJet2.GetComponent<Test>().FinalAngle == 360) 
        {
            if(gameLost == false)
            {
                GameWon_Canvas.SetActive(true);
            }
            else
            {
                GameLost();// other airplane crahed
            }
         
        }
        
        if (SubJet1.GetComponent<Test>().FinalAngle != Main_Jet.GetComponent<Test>().FinalAngle)
        {
            if (Main_Jet.GetComponent<Test>().FinalAngle == 360 + (SubJet1.GetComponent<Test>().FinalAngle))
            {
                UIMain_Jet.SetActive(true);
            }
            else
            {
                UIMain_Jet.SetActive(false);
            }

        }
        
        if (Main_Jet.GetComponent<Test>().FinalAngle != SubJet2.GetComponent<Test>().FinalAngle)
        {
            if (Main_Jet.GetComponent<Test>().FinalAngle == 360 + (SubJet2.GetComponent<Test>().FinalAngle))
            {
                UI1Main_Jet.SetActive(true);
            } 
            else
            {
                UI1Main_Jet.SetActive(false);
            }
        }






        if (SubJet1.GetComponent<Test>().FinalAngle != SubJet2.GetComponent<Test>().FinalAngle)
        {
            if (SubJet1.GetComponent<Test>().FinalAngle == 360 + (SubJet2.GetComponent<Test>().FinalAngle))
            {

                UISubJet1.SetActive(true);
                UISubJet2.SetActive(true);
            }
            else
            {
                UISubJet1.SetActive(false);
                UISubJet2.SetActive(false);
            }
        }
        else
        {
            UISubJet1.SetActive(true);
            UISubJet2.SetActive(true);
        }

            if (SubJet1.GetComponent<Test>().FinalAngle ==0) 
        {
            UIStopSubJet1.SetActive(true);

        }
        else
        {
            UIStopSubJet1.SetActive(false);
        }

        if (SubJet2.GetComponent<Test>().FinalAngle == 0)
        {
            UIStopSubJet2.SetActive(true);

        }
        else
        {
            UIStopSubJet2.SetActive(false);
        }
    }
}
