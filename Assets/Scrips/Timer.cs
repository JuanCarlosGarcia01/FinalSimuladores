using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text UIText;
    public float time = 30f;

    private void Update()
    {
        time -= Time.deltaTime;
        UIText.text = time.ToString("Contador: " + "0");

        if (time <= 0)
        {
            final();
        }
    }

    public void final()
    {
        SceneManager.LoadScene("Final");
    }
}
