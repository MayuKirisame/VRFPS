using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAir : MonoBehaviour
{
    public GameObject player;
    public float speed = 1;
    private Rigidbody rb;
    public GameObject score_object;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player.transform.position);
        rb.velocity = this.transform.forward*speed;
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag=="Player"){
            score_object.GetComponent<Score>().score -= 100;
            Destroy(this.gameObject);
        }else if(other.gameObject.tag=="Sword"){
            score_object.GetComponent<Score>().score += 300;
            Destroy(this.gameObject);
        }
    }
}
