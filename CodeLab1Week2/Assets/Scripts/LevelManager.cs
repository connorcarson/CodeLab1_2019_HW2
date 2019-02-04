using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
	public TextMeshProUGUI Timer;

	public float TimeLeft = 30;
	private int WholeTime;

	// Use this for initialization
	void Start()
	{
		Spawn(); //spawn first prize at the start of our game
	}

	// Update is called once per frame
	void Update()
	{
		TimeLeft -= Time.deltaTime; //Countdown one second, every second
		WholeTime = (int) TimeLeft; //Convert float to int, round time in seconds up to whole number
		Timer.text = "" + WholeTime; //display Time
		CheckForPrize();
	}

	void Spawn() //function for spawning our prize
	{
		GameObject newPrize = Instantiate(Resources.Load<GameObject>("Prefabs/Prize")); //loads prefab into game
		newPrize.transform.position = new Vector2(Random.Range(-10, 10), Random.Range(-4, 4)); //at new, random location
	}

	void CheckForPrize() //check if prize has been destroyed
	{
		GameObject prizesInScene = GameObject.FindWithTag("Prize"); //find all objects in scene tagged "Prize"
		if (prizesInScene == null) //if there are no objects tagged "Prize" in our scene
		{
			Spawn(); //then spawn a new prize
		}
	}
}
