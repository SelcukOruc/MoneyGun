using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralScript : MonoBehaviour
{
    public static GeneralScript instance;



    public int Gold = 0;
    GameObject GoldText;

    GameObject EndUI;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
          

        }


    }

   

    private void Update()
    {
      
        // Updating Score Text;
        GoldText = GameObject.Find("GoldText");
        GoldText.GetComponent<TextMeshProUGUI>().text = Gold.ToString();

        EndUI = GameObject.Find("EndUI");



    }




    public void OnDeath()
    {

        // Player False
        GameObject Player = GameObject.Find("Player");
        Player.SetActive(false);


        //OPEN UI
        EndUI.transform.GetChild(0).gameObject.SetActive(true);

    }













  








}













