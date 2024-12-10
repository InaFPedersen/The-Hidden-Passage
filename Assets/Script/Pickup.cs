using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    //Variables:
    [Header("Items")]
    public Questitems questitem;
    public PickupItems pickupItems;

    //References to other script
    public QuestManager questManager;
    public Enemies enemiesScript;
    public PlayerController healing;
    public PlayerController experience;
    
    //Function that runs when the object player crashes into has collider and isTrigger active
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pickupItems == PickupItems.PoisonMushroom)
            {
                GatherPoisonMushroom();
                Destroy(this.gameObject);
            }
            if (pickupItems == PickupItems.HealthPotion)
            {
                GatherHealthPotion();
                Destroy(this.gameObject);
            }
            if (SceneManager.GetActiveScene().name == "Haunted")
            {
                if (pickupItems == PickupItems.Sign)
                {
                    experience.GetExperiencePoints(10);
                    QuestManager.instance.InteractNPC();

                }
                else if (pickupItems == PickupItems.DeadFlower)
                {
                    experience.GetExperiencePoints(4); //20 total + 5 flowers
                    QuestManager.instance.AddDeadFlower();
                    Destroy(this.gameObject);

                }
                else if (pickupItems == PickupItems.Cauldron)
                {
                    experience.GetExperiencePoints(20);
                    QuestManager.instance.AddCauldron();
                    Destroy(this.gameObject);
                }
                else if (pickupItems == PickupItems.Ghostie)
                {
                    experience.GetExperiencePoints(10);
                    QuestManager.instance.InteractGhost();
                }
                else if(pickupItems == PickupItems.HauntedKey)
                {
                    experience.GetExperiencePoints(40);
                    QuestManager.instance.AddKeys();
                    Destroy(this.gameObject);
                }
            }

            else if(SceneManager.GetActiveScene().name == "Magical")
            {
                if (pickupItems == PickupItems.WizardQuest)
                {
                    experience.GetExperiencePoints(20);
                    QuestManager.instance.InteractNPC();

                }
                else if (pickupItems == PickupItems.BrownMushroom)
                {
                    experience.GetExperiencePoints(5);//15 total 3 mushrooms
                    QuestManager.instance.AddMushroom();
                    Destroy(this.gameObject);

                }
                else if (pickupItems == PickupItems.Cauldron)
                {
                    experience.GetExperiencePoints(25);
                    QuestManager.instance.AddCauldron();
                }
                else if (pickupItems == PickupItems.MagicalKey)
                {
                    experience.GetExperiencePoints(40);
                    QuestManager.instance.AddKeys();
                    Destroy(this.gameObject);
                } 
            }

            else if(SceneManager.GetActiveScene().name == "Fortress")
            {
                if(pickupItems == PickupItems.MrMonocle)
                {
                    experience.GetExperiencePoints(20);
                    QuestManager.instance.InteractNPC();
                }
                else if(pickupItems == PickupItems.WineBottle)
                {
                    experience.GetExperiencePoints(5);//Total 15 3 winebottles
                    QuestManager.instance.AddWineBottle();
                    Destroy(this.gameObject);
                }
                else if(pickupItems == PickupItems.DeliverWine)
                {
                    experience.GetExperiencePoints(25);
                    QuestManager.instance.DeliverFort();
                }
                else if(pickupItems == PickupItems.FortressKey)
                {
                    experience.GetExperiencePoints(40);
                    QuestManager.instance.AddKeys();
                    Destroy(this.gameObject);
                }
            }   
        }
    }
    
    //Function for picking up health potions
    public void GatherHealthPotion()
    {
        healing.GainHealth(20);
    }
    
    //Function for gathering poisonous Mushrooms
    public void GatherPoisonMushroom()
    {
        enemiesScript.LoseHealth();
    }

    //Collection of scenes
    public enum Scenes
    {
        MainMenu,
        Lobby,
        Fortress,
        Magical,
        Haunted,
        GameOver
    }
    //Collection of Quest items
    public enum Questitems
    {
        MainQuest,
        HauntedQuest,
        MagicalQuest,
        FortressQuest,
    }
}
//Global collection of pickup items
public enum PickupItems
{
    WizardQuest,
    BrownMushroom,
    MagicalKey, 
    Sign,
    DeadFlower,
    Ghostie,
    HauntedKey,
    MrMonocle,
    WineBottle,
    DeliverWine,
    FortressKey,
    Cauldron,
    PoisonMushroom,
    HealthPotion,
}


