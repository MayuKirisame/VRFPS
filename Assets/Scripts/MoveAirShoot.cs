using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAirShoot : MonoBehaviour
{
    public GameObject player;
    public float speed = 1;
    private Rigidbody rb;
    public GameObject score_object;
    GameObject insenemy;
    public GameObject bullet;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player.transform.position);
        if(Random.Range(0,1f)>=0.8f){
            this.transform.position += new Vector3(Random.Range(-0.01f,0.01f),Random.Range(-0.01f,0.01f),Random.Range(-0.01f,0.01f));
        }

        if(Random.Range(0,1f)>=0.99f){
            insenemy = Instantiate(bullet,this.transform.position,this.transform.rotation);
            insenemy.GetComponent<MoveAir>().player = player;
            insenemy.GetComponent<MoveAir>().score_object = score_object;
        }
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
