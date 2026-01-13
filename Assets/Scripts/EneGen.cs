using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneGen : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject enemy_air;
    public GameObject enemy_air_shoot;
    public GameObject score_object;
    public int time;
    private int enemy_prob;
    GameObject insenemy;
    void Start()
    {
        enemy_prob = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if(time%enemy_prob==0){
            int a = Random.Range(0,3);
            float ran = Random.Range(0,2*Mathf.PI);
            if(a==0){
                this.transform.position = new Vector3(10*Mathf.Cos(ran),0,10*Mathf.Sin(ran));
                insenemy = Instantiate(enemy,this.transform.position,this.transform.rotation);
                insenemy.GetComponent<Move>().player = player;
                insenemy.GetComponent<Move>().score_object = score_object;
            }else if(a==1){
                this.transform.position = new Vector3(10*Mathf.Cos(ran),Random.Range(1.5f,10f),10*Mathf.Sin(ran));
                insenemy = Instantiate(enemy_air,this.transform.position,this.transform.rotation);
                insenemy.GetComponent<MoveAir>().player = player;
                insenemy.GetComponent<MoveAir>().score_object = score_object;
            }else{
                this.transform.position = new Vector3(10*Mathf.Cos(ran),Random.Range(1.5f,10f),10*Mathf.Sin(ran));
                insenemy = Instantiate(enemy_air_shoot,this.transform.position,this.transform.rotation);
                insenemy.GetComponent<MoveAirShoot>().player = player;
                insenemy.GetComponent<MoveAirShoot>().score_object = score_object;
            }
        }
        time++;

        if(time>=1000){
            enemy_prob = 30;
        }
    }
}
