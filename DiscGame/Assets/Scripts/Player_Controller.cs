using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

	/*
		Allows the player to control the 
	*/

	//Declares that we have a rigidbody on this object
	Rigidbody2D rigbod;

	//Used to manage the player's velocity based on Rigidbody2D physics
	Vector3 velocity;

	//Keyboard input
	public KeyCode left_key = KeyCode.LeftArrow;
	public KeyCode right_key = KeyCode.RightArrow;
	public KeyCode jump_key = KeyCode.UpArrow;

	//Movement Variables
	public float run_acceleration = 3000.0f;
	public float run_deceleration = 3000.0f;
	public float max_run_speed = 120000.0f;

	//Collisions
	bool collision_from_left;
	bool collision_from_right;
	bool collision_from_below;

	void OnCollisionEnter(Collision col){
		//Do collision stuff here
	}

	void Start(){
		//Allows access to the rigidbody
		rigbod = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		//Get the velocities from the Rigidbody
		velocity = rigbod.velocity;

		//Move left and right

		//If the player has pressed the left or right key, start accelerating to that direction
		//If they are already moving at max velocity in that direction, just have them move at max velocity
		if (Input.GetKey(left_key)) {
			velocity.x -= run_acceleration;
			if (velocity.x < -max_run_speed) {
				velocity.x = -max_run_speed;
			}
		}
		if (Input.GetKey(right_key)) {
			velocity.x += run_acceleration;
			if (velocity.x > max_run_speed) {
				velocity.x = max_run_speed;
			}
		}

		//If the player is not pressing either the left key or the right key, begin to slow down
		if (!Input.GetKey (left_key) && !(Input.GetKey (right_key))){
			if (velocity.x > 0){
				velocity.x -= run_deceleration;
			} else if (velocity.x < 0){
				velocity.x += run_deceleration;
			}
		}
		//If they are going sufficiently slow enough, bring them to a stop
		if (-run_acceleration < velocity.x && velocity.x < run_acceleration
		    && -run_deceleration < velocity.x && velocity.x < run_deceleration){
			velocity.x = 0;
		}

		//Update the rigidbody x velocity
		rigbod.velocity = velocity*Time.deltaTime;

		Debug.Log("Run acceleration: " + run_acceleration*Time.deltaTime + "Run Deceleration: " + run_deceleration*Time.deltaTime + "Max Run Speed: " + max_run_speed*Time.deltaTime);
	}
}
