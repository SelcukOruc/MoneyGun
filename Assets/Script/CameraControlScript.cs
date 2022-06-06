using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlScript : MonoBehaviour
{
    Vector3 difference;
   
    void Start()
    {
        difference = Camera.main.transform.position - transform.position;
    }

   
    void Update()
    {

       
        Camera.main.transform.position = transform.position + difference;

    }


}
