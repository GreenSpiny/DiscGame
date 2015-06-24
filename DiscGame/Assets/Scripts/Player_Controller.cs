using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {
	
	//Public Variables
	public KeyCode left_key = KeyCode.LeftArrow;
	public KeyCode right_key = KeyCode.RightArrow;
	public float run_acceleration = 1.0f;
	public float max_run_speed = 10.0f;

	//Private Variables
	float x_position = 0; //TODO: Make this set itself to whatever the object's position in the editor is
	float y_position = 0; //TODO: Make this set itself to whatever the object's position in the editor is
	float x_velocity;
	float y_velocity;

	// Update is called once per frame
	void Update () {
	
		//Move left and right
		if (Input.GetKey(left_key)) {
			x_velocity -= run_acceleration;
			if (x_velocity < -max_run_speed){
				x_velocity = -max_run_speed;
			}
		}
		if (Input.GetKey(right_key)){
			x_velocity += run_acceleration;
			if (x_velocity > max_run_speed){
				x_velocity = max_run_speed;
			}
		}
		x_position += x_velocity;


		//Update the player's location with the new data
		this.transform.position = new Vector3(x_position, y_position, 0);
	}
}
