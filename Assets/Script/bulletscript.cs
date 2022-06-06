using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    Rigidbody rb;
    GameObject Player;



    [SerializeField] private float bulletspeed;
    float destroytime;
   

   
    [SerializeField] private bool IsBombBullet;
    bool splitworked = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player"); // I AM GONNA CHANGE IT SOON (COULD BE TRICKY SOMETIMES)
        
        
    }

    void FixedUpdate()
    {

        if (IsBombBullet)
        {
            rb.AddForce(new Vector3(0, 0.1f, 100*Time.deltaTime),ForceMode.Impulse); // Coming Back...
        }
        else
        {
            rb.velocity = transform.forward * Time.deltaTime * bulletspeed;
        }
      
       
        
        destroytime += Time.deltaTime;

        if (destroytime >Player.GetComponent<PlayerGeneralScript>().DistanceF)
        {
            DestroyItself();
            destroytime = 0;
        }


    }

    public void DestroyItself()
    {
      
        
        Destroy(gameObject);
   
    
    }
   
    
    
    // LineShot create 2 more bullets in different directions (x,-x); // check if line shot is open in ShootingScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "prop")
        {
           

            //if is_line_shot_open in shooting script create 2 more bullets when hit to the prop going different directions.
           
            if (Player.GetComponent<PlayerGeneralScript>().is_line_shot_open && !splitworked)
            {
                splitworked = true;
               
                gameObject.GetComponent<bulletscript>().enabled = true;
                
                transform.rotation = Quaternion.Euler(0, 90, 0);
                Instantiate(this.gameObject, new Vector3(other.gameObject.transform.position.x - 2, other.gameObject.transform.position.y + 2, other.gameObject.transform.position.z), Quaternion.Euler(0, -90, 0));

            }


          

        }




    }
}
