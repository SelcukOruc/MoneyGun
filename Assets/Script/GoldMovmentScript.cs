using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMovmentScript : MonoBehaviour
{

   
    void Update()
    {

        transform.Rotate(1 * Time.deltaTime * 200, 0, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(gameObject);
   
    }

    private void OnDestroy()
    {
        GeneralScript.instance.Gold++;
    }

}

