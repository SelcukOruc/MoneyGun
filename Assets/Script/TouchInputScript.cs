using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputScript : MonoBehaviour
{

    [SerializeField] private  float touchspeed = 2f;
    Vector3 pos_constraints_vec;

    void Update()
    {

      
        // Movment Constraint SmartPhone
       
        pos_constraints_vec = new Vector3(Mathf.Clamp(transform.position.x, -7, 7), Mathf.Clamp(transform.position.y, 0, 100), transform.position.z);
        transform.position = pos_constraints_vec;

        // WHEN WE TOUCH SCREEN
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
              
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * touchspeed*Time.deltaTime, transform.position.y, transform.position.z);
           
            }

        }




    }




}





