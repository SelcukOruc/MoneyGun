using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningPanelScript : MonoBehaviour
{
    [SerializeField] float turn_speed = 80;

    // ROTATING
    void Update()
    {
        transform.Rotate(0, 1 * Time.deltaTime * turn_speed, 0);
    }


}
