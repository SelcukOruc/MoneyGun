using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovmentScript : MonoBehaviour
{
    Rigidbody rb;
    public float playerspeed = 5;
    [SerializeField] private float jump_power = 10;

    public bool is_grounded;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }


    void Update()
    {

        PcController();


    }


    // JUMP

    private void OnTriggerEnter(Collider other) { if (other.gameObject.tag == "jumpprop") {  Jump();  } }
    void Jump() { rb.AddForce(0, 200f * Time.deltaTime * jump_power, 0); }




    void PcController()
    {
        // Movment constraint for playing on pc. // movment constraint for smartphone is in TouchInputScript
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.5f, 9.5f), transform.position.y, transform.position.z);


        // PC INPUT
        float horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * -15;
        Vector3 MovmentVec = new Vector3(0, horizontal, 1 * Time.deltaTime * playerspeed);
        transform.Translate(MovmentVec);

    }





























}
