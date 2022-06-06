using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PerkScript : MonoBehaviour
{
    public GameObject Player; // this gameobject consists of TouchInputScript, ShootingScript, CameraControlScript and MovmentScript in it.


    MeshRenderer meshrenderer;
    
    public Material[] RedandGreenColors;   // 0 = Red 1 = Green
    public TextMeshProUGUI Title;
    public TextMeshProUGUI ValueText;

    public SpriteRenderer SplashImage;
    public Sprite[] Splashes;
    void Start()
    {
        Player = GameObject.Find("Player");
        meshrenderer = GetComponent<MeshRenderer>();
    
    }

   
    void Update()
    {

        ChangePerk();

    }

    // SYSTEM BELOW WAS WRITTEN TO CHANGE PERKOBJECT'S COLOR, FUNCTION ONLY BY CHANGING TAG; BY DOING SO WE CAN GENERATE INFINITE PLATFORM ON RUNTIME IF WE WANT
    void ChangePerk()
    {
       


        // FIRE RATE

        if (this.gameObject.tag == "incfirerate")
        {

            meshrenderer.material = RedandGreenColors[1]; // green

            Title.text = "Fire Delay";
            ValueText.text = "+ " + Player.GetComponent<PlayerGeneralScript>().DCRD_WaitForFire.ToString();





        }
        if (this.gameObject.tag == "decfirerate")
        {

            meshrenderer.material = RedandGreenColors[0]; //red

            Title.text = "Fire Delay";
            ValueText.text = "- " + Player.GetComponent<PlayerGeneralScript>().INCD_WaitForFire.ToString();
        }



        // DISTANCE

        if (this.gameObject.tag == "incdistance")
        {
            meshrenderer.material = RedandGreenColors[1]; // green
            Title.text = "Distance";
            ValueText.text ="+ "+ Player.GetComponent<PlayerGeneralScript>().INCD_distanceValue.ToString();
        }
        if (this.gameObject.tag == "decdistance")
        {
            meshrenderer.material = RedandGreenColors[0]; //red
            Title.text = "Distance";
            ValueText.text = "- " + Player.GetComponent<PlayerGeneralScript>().DCRD_DistanceValue.ToString();

        }


        // SHOTLINE
        if (this.gameObject.tag == "lineshot")
        {
            meshrenderer.material = RedandGreenColors[1]; // green
            Title.text = "Shot Line";
            SplashImage.sprite = Splashes[0];

        }



        // DOUBLE GUN
        if (this.gameObject.tag == "doublegun")
        {
            meshrenderer.material = RedandGreenColors[1]; // green
            Title.text = "Double Gun";
            SplashImage.sprite = Splashes[1];
        }





        // SPREAD SHOT

        if (this.gameObject.tag == "spreadshot")
        {
            meshrenderer.material = RedandGreenColors[1]; // green
            Title.text = "Spread Shot ";
            SplashImage.sprite = Splashes[2];
        }
        // DOUBLE SHOT
        if (this.gameObject.tag == "doubleshot")
        {
            meshrenderer.material = RedandGreenColors[1]; // green
            Title.text = "Double Shot ";
            SplashImage.sprite = Splashes[3];
        }
     

    }

}
