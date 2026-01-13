using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI score_text_object;
    public GameObject Generater;
    int time;
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score_text_object.text = "Score:" +score;

        time = Generater.GetComponent<EneGen>().time;
        if(time >= 3000){
            UnityEditor.EditorApplication.isPaused = true;
        }
    }
}
