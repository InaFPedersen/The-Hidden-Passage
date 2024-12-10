using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    //Variables:

    [Header("MainQuest")]
    public TextMeshProUGUI mainQuest;
    public int keys;
    public GameObject mainPopUp;

    [Header("QuestItems")]
    //In magical scene
    public TextMeshProUGUI magicalQuest;
    public int wizard;
    public TextMeshProUGUI magicalQuest2;
    public int brownMushroom;
    public TextMeshProUGUI magicalQuest3;
    public int couldron;
    public TextMeshProUGUI magicalMainQuest;
    public int magicalKey;
    public GameObject magicKey;
    public TextMeshProUGUI magicalMessage;
    public GameObject hauntedPortal;
    public GameObject magicalPopUp1;
    public GameObject magicalPopUp2;

    //In haunted scene
    public TextMeshProUGUI hauntedQuest1;
    public int deadFlower;
    public TextMeshProUGUI hauntedQuest2;
    public int cauldron;
    public TextMeshProUGUI hauntedQuest3;
    public int ghostie;
    public TextMeshProUGUI hauntedMainQuest;
    public int hauntedKey;
    public GameObject spookyKey;
    public TextMeshProUGUI hauntedMessage;
    public GameObject victoryPortal;
    public GameObject hauntedPopUp;

    //In fortress scene
    public TextMeshProUGUI fortressQuest;
    public int mrMonocle;
    public TextMeshProUGUI fortressMainQuest;
    public int wineBottle;
    public TextMeshProUGUI fortressDeliverQuest;
    public int deliver;
    public TextMeshProUGUI fortressQuest2;
    public int fortressKey;
    public GameObject fortKey;
    public TextMeshProUGUI fortressMessage;
    public GameObject magicalPortal;
    public GameObject deliveryBox;
    public GameObject fortressPopUp;

    //Connecting to the enums
    public Scenes scenes;
    public PickupItems pickupItems;
    // Reference to script
    public QuestPopUps popUp;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //ifsetninger som sjekker hvilken bane spilleren er i
        if (SceneManager.GetActiveScene().name == "Magical")
        {
            magicalQuest.gameObject.SetActive(true);
            magicalQuest2.gameObject.SetActive(false);
            magicalQuest3.gameObject.SetActive(false);
            magicalMainQuest.gameObject.SetActive(false);
            magicalMessage.gameObject.SetActive(false);
            magicKey.gameObject.SetActive(false);
            hauntedPortal.gameObject.SetActive(false);

            mainPopUp.gameObject.SetActive(true);
            magicalPopUp1.gameObject.SetActive(true);
         
           
            if (magicalQuest)
            {

                wizard = 0;
                magicalQuest.text = "Interacted with Wizard Quartz: " + wizard + " /1";
            }
            if (magicalQuest2) 
            {
                mainPopUp.gameObject.SetActive(true);
                magicalPopUp2.gameObject.SetActive(true);

                brownMushroom = 0;
                magicalQuest2.text = "Brown mushrooms collected: " + brownMushroom + " /3";
            }
            if (magicalQuest3)
            {

                cauldron = 0;
                magicalQuest3.text = "Interacted with cauldron next to wizard: " + cauldron+ " /1";
            }
            if (magicalMainQuest)
            {
                magicalKey = 0;
                magicalMainQuest.text = "Find the Magical Key near the house: " + magicalKey + " /1";
            }

            if (magicalMessage)
            
                magicalMessage.text = "Go over the bridge, there is a portal to your next adventure";
            }

        else if (SceneManager.GetActiveScene().name == "Fortress")
        {
            fortressQuest.gameObject.SetActive(true);
            fortressMainQuest.gameObject.SetActive(false);
            fortressDeliverQuest.gameObject.SetActive(false);
            fortressQuest2.gameObject.SetActive(false);
            fortressMessage.gameObject.SetActive(false);
            fortKey.gameObject.SetActive(false);
            magicalPortal.gameObject.SetActive(false);
            deliveryBox.gameObject.SetActive(false);

            if (fortressQuest)
            {
                mrMonocle = 0;
                fortressQuest.text = "Interact with Mr. Monocle " + mrMonocle + " /1";
            }
            if (fortressQuest2)
            {
                wineBottle = 0;
                fortressQuest2.text = "Wine bottle from basement collected: " + wineBottle + " /3";
            }
            if(fortressDeliverQuest)
            {
                deliver = 0;
                fortressDeliverQuest.text = "Wine bottles delivered to box next to Mr. Monocle" + deliver + " /1";
            }
            if (fortressMainQuest)
            {
                fortressKey = 0;
                fortressMainQuest.text = "FortressKey collected: " + fortressKey + " /1";
            }
            if (fortressMessage)
            {
                fortressMessage.text = "Go up one of these stairs, and you will find a portal to your next adventure";
            }
        }
        else if (SceneManager.GetActiveScene().name == "Haunted")
        {

            hauntedQuest1.gameObject.SetActive(false);
            hauntedQuest2.gameObject.SetActive(false);
            hauntedQuest3.gameObject.SetActive(false);
            hauntedMainQuest.gameObject.SetActive(false);
            hauntedMessage.gameObject.SetActive(false);
            spookyKey.gameObject.SetActive(false);
            victoryPortal.gameObject.SetActive(false);


            if (hauntedQuest1)
            {
                

                deadFlower = 0;
                hauntedQuest1.text = "Dead flowers: " + deadFlower + " / 5";
            }
            if (hauntedQuest2)
            {
                cauldron = 0;
                hauntedQuest2.text = "Cauldron: " + cauldron + " / 1";
            }
            if (hauntedQuest3)
            {
                ghostie = 0;
                hauntedQuest3.text = "Deliver your gifts to the gentle ghost. " + ghostie + " / 1";
            }
            if (hauntedMainQuest)
            {
                hauntedKey = 0;
                hauntedMainQuest.text = "Find the Haunted Key " + hauntedKey + " / 1";
            }
            if (hauntedMessage)
            {
                hauntedMessage.text = "The gentle ghost gestures to her side, and a portal to your next adventure have now appared";
            }

        }
    }

    public void OpenPopUp()
    {
        popUp.gameObject.SetActive(true);
        Time.timeScale = 0;
    }


    public void OKpushed()
    {
        popUp.gameObject.SetActive(false);
        fortressPopUp.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    //Function for mainquest keys
    public void AddKeys()
    {
        if (SceneManager.GetActiveScene().name == "Magical")
        {
            magicalKey++;
            magicalMainQuest.text = "Find the Magical Key near the house: " + magicalKey + " /1";
            if (magicalKey >= 1)
            {
                magicalMessage.gameObject.SetActive(true);
                hauntedPortal.gameObject.SetActive(true);
            }
            else
            {
                magicalMessage.gameObject.SetActive(false);
                hauntedPortal.gameObject.SetActive(false);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Fortress")
        {
            fortressKey++;
            fortressMainQuest.text = "FortressKey collected: " + fortressKey + " /1";
            if (fortressKey >= 1)
            {
                fortressMessage.gameObject.SetActive(true);
                magicalPortal.gameObject.SetActive(true);
            }
            else
            {
                fortressMessage.gameObject.SetActive(false);
                magicalPortal.gameObject.SetActive(false);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Haunted")
        {
            hauntedKey++;
            hauntedMainQuest.text = "Find the Haunted Key" + hauntedKey + " /1";
            if(hauntedKey >= 1)
            {
                hauntedMessage.gameObject.SetActive(true);
                victoryPortal.gameObject.SetActive(true);
            }
            else
            {
                hauntedMessage.gameObject.SetActive(false);
                victoryPortal.gameObject.SetActive(false);
            }
        }
    }

    public void InteractNPC()
    {
        if(SceneManager.GetActiveScene().name == "Magical")
        {
            wizard++;
            magicalQuest.text = "Interacted with Wizard Quartz: " + wizard + " /1";
            if (wizard >= 1)
            {
                mainPopUp.gameObject.SetActive(true);
                magicalPopUp2.gameObject.SetActive(true);
                magicalQuest2.gameObject.SetActive(true);
            }
            else
            {
                magicalQuest2.gameObject.SetActive(false);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Fortress")
        {
            
                mrMonocle++;
                fortressQuest.text = "Interact with Mr. Monocle" + mrMonocle + " /1";
                if (mrMonocle >= 1)
                {
                mainPopUp.gameObject.SetActive(true);
                fortressPopUp.gameObject.SetActive(true);
                fortressQuest2.gameObject.SetActive(true);
                }
                else
                {
                    fortressQuest2.gameObject.SetActive(false);
                }
            
        }

        else if (SceneManager.GetActiveScene().name == "Haunted")
        {

            mainPopUp.gameObject.SetActive(true);
            hauntedPopUp.gameObject.SetActive(true);

            hauntedQuest1.gameObject.SetActive(true);
                hauntedQuest2.gameObject.SetActive(true);
            
            
            
        }
    }
    public void DeliverFort()
    {
        deliver++;
        fortressDeliverQuest.text = "Wine bottles delivered to box next to Mr. Monocle" + deliver + " /1";

        fortKey.gameObject.SetActive(true);

        if (deliver >= 1)
        {
            fortressMainQuest.gameObject.SetActive(true);
        }
        else
        {
            fortressMainQuest.gameObject.SetActive(false);
        }
    }
    public void InteractGhost()
    {
        ghostie++;
        hauntedQuest3.text = "Deliver your gifts to the gentle ghost. " + ghostie + " /1";

        spookyKey.gameObject.SetActive(true);


        if (ghostie >= 1)
        {
            hauntedMainQuest.gameObject.SetActive(true);
        }
        else
        {
            hauntedMainQuest.gameObject.SetActive(false);
        }
    }

    public void AddMushroom()
    {
        brownMushroom++;
        magicalQuest2.text = "Brown mushrooms collected: " + brownMushroom + " /3";
        
        if (brownMushroom >= 3)
        {
            magicalQuest3.gameObject.SetActive(true);
        }
        else
        {
            magicalQuest3.gameObject.SetActive(false);
        }
    }

    public void AddDeadFlower()
    {
        deadFlower++;
        hauntedQuest1.text = "Dead flowers: " + deadFlower + " / 5";

        if(deadFlower >= 5 && cauldron >= 1)
        {
            hauntedQuest3.gameObject.SetActive(true);
        }
        else
        {
            hauntedQuest3.gameObject.SetActive(false);
        }
    }
    
    public void AddWineBottle()
    {
        wineBottle++;
        fortressQuest2.text = "Wine bottle from basement collected: " + wineBottle + " /3";
        if (wineBottle >= 3)
        {
            fortressDeliverQuest.gameObject.SetActive(true);
            deliveryBox.gameObject.SetActive(true);
        }
        else
        {
            fortressDeliverQuest.gameObject.SetActive(false);
            deliveryBox.gameObject.SetActive(false);
        }
    }

    public void AddCauldron()
    {
        if (SceneManager.GetActiveScene().name == "Magical")
        {
            cauldron++;
            magicalQuest3.text = "Interacted with cauldron next to wizard: " + cauldron + " /1";
            magicKey.gameObject.SetActive(true);
            if (cauldron >= 1)
            {
                magicalMainQuest.gameObject.SetActive(true);
            }
            else
            {
                magicalMainQuest.gameObject.SetActive(false);
            }
        }
        if (SceneManager.GetActiveScene().name == "Haunted")
        {
            cauldron++;
            hauntedQuest2.text = "Cauldron: " + cauldron + " /1";
            if (deadFlower >= 5 && cauldron >= 1)
            {
                hauntedQuest3.gameObject.SetActive(true);
            }
            else
            {
                hauntedQuest3.gameObject.SetActive(false);
            }
        }
    }
    

    //Collection of scenes
    public enum Scenes
    {
        MainMenu,
        Lobby,
        Fortress,
        Magical,
        Haunted,
        GameOver,
        Victory
    }
}
