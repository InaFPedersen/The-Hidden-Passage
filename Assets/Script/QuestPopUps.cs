using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class QuestPopUps : MonoBehaviour
{
    public GameObject popUp;

    public GameObject fortressQ;
    public GameObject magicQ1;
    public GameObject magicQ2;
    public GameObject hauntedQ;
    public GameObject lobbyI;

    public void OpenPopUp()
    {
        popUp.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePopUp()
    {
        popUp.SetActive(false);
    }

    public void OKpushed()
    {
        popUp.SetActive(false);
        Time.timeScale = 1;
        ClosePopUp();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
