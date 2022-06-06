using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGeneralScript : MonoBehaviour
{
    float timee;

    public GameObject Bullet;
 
    public Transform ShootPoint;


    GameObject bullet0, bullet1,bullet2;
   

    public float DistanceF;
   
    float waitforfire;

   
    public bool is_double_gun_open, is_spread_shot_open, is_double_shot_open,is_line_shot_open;


   
    Rigidbody rb;

    // INCD = INCREASED   DCRD= DECREASED
    [Header("Set the values when touched perks")]
    public float INCD_distanceValue, DCRD_DistanceValue;
    public float INCD_WaitForFire, DCRD_WaitForFire; // the time that must pass before creating bullet.

   
    GameObject SecondGun;
   


    public bool original_gun = true;

  
    
    private void Start()
    {
        GeneralScript.instance.Gold = 0;
        rb = GetComponent<Rigidbody>();

        waitforfire = 0.4f;
        DistanceF = 1.3f;

        


        if (original_gun)
        {

            SecondGun = transform.GetChild(2).gameObject;

        }

    }



    private void OnTriggerEnter(Collider other)
    {
        //  -->   (inc) = increase // (dec) = decrease

        if (other.gameObject.tag == "prop")
        {
            GeneralScript.instance.OnDeath();
        }

        // WAIT FOR FIRE (FIRERATE ISSUES)

        if (other.gameObject.tag == "incfirerate")
        {
            INC_FireRateV();
        }
        if (other.gameObject.tag == "decfirerate")
        {
            DCR_FireRateV();
        }

        // RANGE ISSUES (HOW FAR BULLET CAN GO ?) // in other words, (float)lifespan in bulletscript

        if (other.gameObject.tag == "decdistance")
        {
            DCR_DistanceV();

        }
        if (other.gameObject.tag == "incdistance")
        {
            INC_DistanceV();

        }

        // LINE SHOT ISSUES
        if (other.gameObject.tag == "lineshot")
        {
            if (!is_line_shot_open)
            {
                is_line_shot_open = true;

            }


        }

        // Obstacle
        if (other.gameObject.tag == "tpanel")
        {
            GeneralScript.instance.OnDeath();
        }

        // DOUBLE GUN ISSUES
        if (other.gameObject.tag == "doublegun")
        {
            if (!is_double_gun_open && original_gun)
            {

                Open_DoubleGun();


            }


        }

        // SPREAD SHOT ISSUES
        if (other.gameObject.tag == "spreadshot")
        {
            if (!is_spread_shot_open)
            {


                Open_SpreadShot();


            }



        }

        // DOUBLE SHOT ISSUES
        if (other.gameObject.tag == "doubleshot")
        {
            if (!is_double_shot_open)
            {
                is_double_shot_open = true;




            }



        }

       




        // WHAT WILL HAPPEN WHEN PLAYER REACHES END?
        if (other.gameObject.tag == "endline")
        {


            gameObject.SetActive(false);
            SceneManager.LoadScene(1);


        }


    }


    // FIRE RATE

    public void INC_FireRateV()
    {
        waitforfire = waitforfire- DCRD_WaitForFire;
      
    }
    public void DCR_FireRateV()
    {
        waitforfire = waitforfire + INCD_WaitForFire;
       
    }



    // DISTANCE

    public void INC_DistanceV()
    {
        DistanceF += INCD_distanceValue;
    }
    public void DCR_DistanceV()
    {
        DistanceF -= DCRD_DistanceValue;

    }


   // SPREAD SHOT
    public void Open_SpreadShot()
    {
        is_spread_shot_open = true;
    }
    
    // DOUBLE GUN
    public void Open_DoubleGun()
    {
        is_double_gun_open = true;
        SecondGun.SetActive(true);
        
        SecondGun.GetComponent<PlayerGeneralScript>().original_gun = false;
        SecondGun.GetComponent<PlayerGeneralScript>().DistanceF = DistanceF;
        SecondGun.GetComponent<PlayerGeneralScript>().waitforfire = waitforfire;
        SecondGun.GetComponent<PlayerGeneralScript>().is_spread_shot_open = is_spread_shot_open;
        SecondGun.GetComponent<PlayerGeneralScript>().is_double_shot_open = is_double_shot_open;

    }


    private void FixedUpdate()
    {

        Shooting();

    }


    // SHOOTING



    public void Shooting()
    {

        timee += Time.deltaTime;


        if (timee > waitforfire)
        {
            timee = 0;
            for (int i = 0; i < 1; i++)
            {

                bullet0 = Instantiate(Bullet, transform.GetChild(0).transform.position, Quaternion.Euler(0, 0, 0));

                //is spread shot open?
                if (is_spread_shot_open)
                {
                    bullet1 = Instantiate(Bullet, transform.GetChild(0).transform.position, Quaternion.Euler(0, 5, 0));
                    bullet2 = Instantiate(Bullet, transform.GetChild(0).transform.position, Quaternion.Euler(0, -5, 0));
                }




                // IS DOUBLE SHOT OPEN ?
                if (is_double_shot_open)
                {

                    bullet0 = GameObject.Instantiate(Bullet, transform.GetChild(0).transform.position, Quaternion.Euler(0, 0, 0));

                    // is spread shot open?
                    if (is_spread_shot_open)
                    {
                        bullet1 = GameObject.Instantiate(Bullet, transform.GetChild(0).transform.position, Quaternion.Euler(0, 5, 0));
                        bullet2 = GameObject.Instantiate(Bullet, transform.GetChild(0).transform.position, Quaternion.Euler(0, -5, 0));
                    }






                }


            }



        }







    }
    
    
    
 







}











































