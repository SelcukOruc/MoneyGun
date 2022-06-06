using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PropScript : MonoBehaviour
{
   
    // IMPORTANT NOTIFICATION ---> When SpreadShot is open, as more than one bullets hit at the same time; value in 
    
    int index;

    [Header("Calculations and Height")]         // MAKE AN BOOL WHICH AUTOMATICALLY CALCULATES EQUATION
    public float step_number_limit;
    [SerializeField] private float value = 999;
    private float damage_to_value = 10;

    public GameObject step;
    GameObject emptychild;

    [Header("Visual Editing")]
    [SerializeField] private bool MessyBlocks;
    [SerializeField] private bool ColorfulBlocks;

    public GameObject[] TopObjects;


    GameObject top_object;

    float timee;

    float bullethit = 0;
    private float bullethit_number = 0;

    public Color BlockColor;

  TextMeshProUGUI ValueText;


   



    void Start()
    {

       // Finding ValueText
        ValueText = transform.parent.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
     
        
        // CALCULATIONS AUTOMATIC
        damage_to_value = value / step_number_limit;  // if i insert these two values beforehand in editor?
        bullethit_number = step_number_limit / damage_to_value;

        // damage_to_value and bullethit_number is right proportion. while inserting value, please take this info into consideration.





        // Change What's on the top of the prop.
        top_object = Instantiate(TopObjects[Random.Range(0, TopObjects.Length)], transform.position, Quaternion.identity); // If you want you can create various objects only by using 'Random.range(min,max)'; // --> done.
        
       //Change color of Steps.
        var renderertransform = GetComponent<Renderer>();
        renderertransform.material.SetColor("_Color", Color.white);

       
        StartCoroutine(CreateEmptyObj());
        StartCoroutine(SetObjects());



      



    }





    private void FixedUpdate()
    {

        TopObjPos(); // --> top_object's position.

        // TEXT UI
        if (value > 0)
        {
            ValueText.text = value.ToString();
        }
     

    }


    // STEP ONE
    IEnumerator CreateEmptyObj()
    {

        yield return new WaitForSeconds(0.1f);

        float height = 0;



        float emptylimit = step_number_limit;



        for (int i = 0; i < emptylimit; i++)
        {






            height += 0.5f;
            emptychild = new GameObject("EmptyChildObj");
            emptychild.transform.position = new Vector3(transform.position.x, height, transform.position.z);
            emptychild.transform.parent = transform;





        }




    }




    // STEP TWO
    IEnumerator SetObjects()
    {
        yield return new WaitForSeconds(0.3f);



       

            for (index = 0; index < transform.childCount - 1; index++)
            {

             
              
                GameObject mm = Instantiate(step, transform.GetChild(index).position, Quaternion.identity);
                mm.transform.SetParent(transform.GetChild(index).transform);
                var renderer = mm.GetComponent<Renderer>();


                if (MessyBlocks)
                {
                    mm.transform.rotation = Quaternion.Euler(0, Random.Range(0, 90), 0);
                }

                if (ColorfulBlocks)
                {
                   
                    renderer.material.SetColor("_Color", Random.ColorHSV(0,0.5f));   /// ("_Color", Random.ColorHSV(0.4f,1f,0.4f,1f,0.4f,1f,0.4f,1f)); // If you want it could be composition of different colors
                }
                else
                {
                    renderer.material.SetColor("_Color", BlockColor);
                
                     
                }
          




            }




        

        
            
       
        
       



    }


   
    // STEP THREE
    void TopObjPos()
    {
        // UPDATING POSITION OF THE OBJ ON THE TOP
        timee += Time.deltaTime;

        if (timee > 0.5f) 
        {
            if (transform.childCount > 0)
            {


                top_object.transform.position = new Vector3
                  (transform.GetChild(transform.childCount - 1).transform.position.x,
                  transform.GetChild(transform.childCount - 1).transform.position.y + 1.5f, // Height of top_object 
                  transform.GetChild(transform.childCount - 1).transform.position.z);



                top_object.transform.parent = transform.GetChild(0).transform; // parent top object???



            }
            else
            {
                Destroy(top_object);
            }

            timee = 0;

        }

    }

    
    // What will happen when hit by bullet
    public void DecreaseValue()
    {
        Destroy(transform.GetChild(transform.childCount - 1).gameObject);
        // animation can be added (buzzy etc.)
        value -= damage_to_value;
        bullethit = 0;
    }
 
   

    private void OnTriggerEnter(Collider other)
    {
        // Prop hit by normal bullet

        if (other.gameObject.tag == "bullet")
        {



            if (transform.childCount <= 0)
            {



                Destroy(transform.parent.gameObject);


            }
            else
            {

                bullethit += bullethit_number / step_number_limit*20; // Can be fixed (better number) for better...

                if (bullethit >= bullethit_number)
                {

                    DecreaseValue();
                    // Animation can be added later on...


                }






            }
        
        
        }



    


    }


    private void OnDestroy()
    {
        GeneralScript.instance.Gold += 2;
   
    
    }


}















