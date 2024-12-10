using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    //Variables
    public PortalType type;
    

    //checks every frame player is inside the collider perimeters 
    //if player clicks E it will check wich portal type you stand at
    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(type == PortalType.FortressPortal)
            {
                SceneManager.LoadScene((int)Scenes.Fortress);
            }
            else if (type == PortalType.MagicalPortal)
            {
                SceneManager.LoadScene((int)Scenes.Magical);
            }
            else if (type == PortalType.HauntedPortal)
            {
                SceneManager.LoadScene((int)Scenes.Haunted);
            }
            else if (type == PortalType.VictoryPortal)
            {
                SceneManager.LoadScene((int)Scenes.Victory);
            }

           
        }
    }
    //Collection of the different portal types
    public enum PortalType
    {
        HauntedPortal,
        MagicalPortal,
        FortressPortal,
        VictoryPortal
    }

    //Collection of the different scenes
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
