using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CmachineScript : MonoBehaviour
{
    // Calculate how many times hit by bullet
    // Afterwards, when the time obj hit by bullet reaches a certain number,
    // Call Random perk from ShootingScript to activate
    // For example = IncreaseDistance, or DecreaseFireRate.

    GameObject Player;
    public GameObject Text;
    
    int counterint;
    int randomchoosevalue;

   

    Animator Casanimator;

    [SerializeField] private float counterlimit = 10;
    
    private void Start()
    {
        Player = GameObject.Find("Player");
        Casanimator = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other) 
    { 
        
        if (other.gameObject.tag == "bullet" || other.gameObject.tag == "bulletbomb") { counterint++; Destroy(other.gameObject); }

        if (other.gameObject.tag == "Player") { GeneralScript.instance.OnDeath(); }

    }







    private void Update()
    {


    
        
            if (counterint >= counterlimit)
            {
               
                
                
             
                counterint = 0;
                randomchoosevalue = Random.Range(0, 3); // *random numbers*
                GameObject popuptext = Instantiate(Text, transform.position, Quaternion.identity);
                popuptext.transform.SetParent(this.transform);
              
                // GIVE VISUAL FEEDBACK TO THE PLAYER// SUGGESTION; CREATE A TEXT SAYING WHAT HAS CHANGED AND DESTROY AFTER SHOWING FOR A WHILE.

                // Assigns perks from shootingscripts to *random numbers* and then chooses one of them. 
                if (randomchoosevalue == 0)
                {
                    Player.GetComponent<PlayerGeneralScript>().INC_FireRateV();
                    popuptext.GetComponent<TextMesh>().color = Color.green;
                    popuptext.GetComponent<TextMesh>().text = "FIRE RATE INCREASED !";


                }
                if (randomchoosevalue == 1)
                {
                    Player.GetComponent<PlayerGeneralScript>().DCR_FireRateV();
                    popuptext.GetComponent<TextMesh>().color = Color.red;
                    popuptext.GetComponent<TextMesh>().text = "FIRE RATE DECRASED !";
                }
                if (randomchoosevalue == 2)
                {
                    Player.GetComponent<PlayerGeneralScript>().INC_DistanceV();
                    popuptext.GetComponent<TextMesh>().color = Color.green;
                    popuptext.GetComponent<TextMesh>().text = "DISTANCE INCREASED !";
                }
                if (randomchoosevalue == 3)
                {
                    Player.GetComponent<PlayerGeneralScript>().DCR_DistanceV();
                    popuptext.GetComponent<TextMesh>().color = Color.red;
                    popuptext.GetComponent<TextMesh>().text = "DISTANCE DECREASED !";
                }


                // SET ANIMATION
                Casanimator.SetTrigger("hit");

                //DESTROY FEEDBACKTEXT
                Destroy(popuptext, 3);









            }
       
        
        
        




    }
















}
