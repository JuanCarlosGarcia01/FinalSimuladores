using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaPuntos : MonoBehaviour
{
    public static int score;
    public Text TXTscore;

    void Start()
    {
        
    }


    void Update()
    {
        TXTscore.text = "Cantidad de peso: " + score;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Objeto")
        {
            score += 10;
        }

        if (collision.gameObject.tag == "Pesado")
        {
            score += 50;
        }
    }




}
