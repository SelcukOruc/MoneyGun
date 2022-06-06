using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScoreScript : MonoBehaviour
{
    public GameObject GoldObj;
    public Transform GoldCreatePos;

    float endcounter;
    public Transform forcetransform;
    float forcetoapply;


    GameObject LatestCreatedGoldObj;

    int CreatedGoldNumber;

    public Slider ForceSliderUI;

    public float GoldEarned;

    public GameObject FinalPanel;
    private void Start()
    {
        StartCoroutine(GoldCreatorIE());
      
        ForceSliderUI.maxValue = 40;
    }






    private void Update()
    {
      
        // STEP 1 || Create Golds  
        if (CreatedGoldNumber >= 1)
        {
            LatestCreatedGoldObj = GameObject.Find(CreatedGoldNumber.ToString());
            forcetransform.position = new Vector3(GoldCreatePos.position.x, CreatedGoldNumber, GoldCreatePos.position.z - 1);
           
        
        }
       

        // STEP 2 || PRESS TO INCREASE FORCE

        if (CreatedGoldNumber>=GeneralScript.instance.Gold)
        {

            endcounter += Time.deltaTime;
           


            // INCREASE FORCE BY PRESSING. ( OBJECTS CREATED AND PILED UP, WE ARE SUPPOSED TO PRESS AS MUCH AS POSSIBLE IN GIVEN TIME (endcounter) )

            if (Input.touchCount > 0&&forcetoapply<=40)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    forcetoapply += 4f;
                  

                }
           
            }

            // DECREASE WHEN NOT TOUCHED
           
            forcetoapply -= 0.02f;
      
        }

















        ForceSliderUI.value = forcetoapply;

        // STEP 3 || WHEN STEP ONE IS OVER THE FORCE WE GET WILL BE APPLIED TO THE OBJECTS.

        if (endcounter>5)
        {
            //APPLY FORCE IN FORCE TRANSFORM WHEN THE GIVEN TIME(endcounter) IS OVER.
            
            Collider[] forcecolliders = Physics.OverlapSphere(forcetransform.position, 50);
          
            foreach (Collider otherobjects in forcecolliders)
            {
                if (otherobjects.GetComponent<Rigidbody>() != null)
                {
                    Rigidbody rg = otherobjects.GetComponent<Rigidbody>();
                    rg.isKinematic = false;
                    rg.AddExplosionForce(forcetoapply, forcetransform.position, 50);
                   
                    ForceSliderUI.gameObject.SetActive(false);
                    Debug.Log(LatestCreatedGoldObj.transform.position.z);


                    if (LatestCreatedGoldObj.transform.position.z > 0)
                    {
                        float xXvalue = LatestCreatedGoldObj.transform.position.z / 10;


                        GoldEarned = Mathf.Floor(GeneralScript.instance.Gold * xXvalue);
                        Debug.Log("Gold Earned = " + GoldEarned);

                    }
                    else
                    {
                        GoldEarned = GeneralScript.instance.Gold;
                    }
                   
                    Invoke("Final", 8); // THIS IS WHEN EVERYTHING IS OVER.
                
                }


            }


            Camera.main.transform.position = new Vector3(LatestCreatedGoldObj.transform.position.x, 15, LatestCreatedGoldObj.transform.position.z-20); // AFTER FORCE IS APPLIED, CAMERA FOLLOWS THE LATEST OBJECT.
        }
        else { ForceSliderUI.value -= 3; } // WHEN NOT PRESSED FORCE VALUE DECREASES *


       

    }
  

   
    
    
    IEnumerator GoldCreatorIE()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i <= GeneralScript.instance.Gold; i++)
        {
            yield return new WaitForSeconds(0.3f);
           
            GameObject bb= Instantiate(GoldObj, new Vector3(GoldCreatePos.position.x,GoldCreatePos.position.y+i+1,GoldCreatePos.position.z) , Quaternion.Euler(90,0,0));
          
            Camera.main.transform.position = new Vector3(bb.transform.position.x, bb.transform.position.y, transform.position.z - 30);
            
            CreatedGoldNumber++;
            bb.name = CreatedGoldNumber.ToString();
       
            yield return new WaitForSeconds(0.3f);
            bb.GetComponent<Rigidbody>().isKinematic = true;
         
        }
        yield return new WaitForSeconds(0.3f);

    }



    public void Final() { FinalPanel.SetActive(true); FinalPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = GoldEarned.ToString(); } // AFTER EVERYTHING IS DONE FINALPANEL IS OPENED.




    public void Restart()
    {
        GeneralScript.instance.Gold = 0;
        SceneManager.LoadScene(0);

    }

}
