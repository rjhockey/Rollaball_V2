using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

	private float movementX;
	private float movementY;

	private Rigidbody rb;
	private int count;

	public float restartDelay = 1f;      // sets delay time before next scene loads


	
	void Start()        // At the start of the game..
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero at begining of game
		count = 0;

		SetCountText();

		// Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
		winTextObject.SetActive(false);
	}

	void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the 'SetCountText()' function (see below)
			SetCountText();
		}

	}

	void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();

		if (count >= 12)
		{

			// Set the text value of your 'winText'
			winTextObject.SetActive(true);
			
			Invoke("Restart", restartDelay);

		}
	}

	//  add method to load next scene to feed into Invoke method above
	void Restart()
	{
		if (SceneManager.GetActiveScene().buildIndex < 4)
		{
			// Moves to next scene/level on completion tied to UnityEngine.SceneManagement
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
		else
			Quit();
	}

	// should only work on build, put debug to show in console that it is called
	public void Quit()
	{		
		Debug.Log("Stop Play");
		Application.Quit();
	}
}
