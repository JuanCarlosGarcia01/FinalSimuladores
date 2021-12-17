using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
	public Text Peso;

	void Start()
	{
		Peso.text = SistemaPuntos.score.ToString();
	}

	
}
