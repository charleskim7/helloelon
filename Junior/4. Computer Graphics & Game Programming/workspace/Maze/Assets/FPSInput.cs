using UnityEngine;
using System.Collections;

public class FPSInput : MonoBehaviour {
	public float speed = 6.0f;
	public float gravity = -9.8f;
	public float jumpSpeed = 100f;
	public float vertSpeed = 0f;

	private CharacterController charController;

	void Start() {
		charController = GetComponent<CharacterController>();
	}

	void Update() {
		// Move
		float deltaX = Input.GetAxis("Horizontal") * speed;
		float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3(deltaX, vertSpeed, deltaZ);
		movement = Vector3.ClampMagnitude(movement, speed);

		// movement.y = gravity;

		movement *= Time.deltaTime;
		movement = transform.TransformDirection(movement);
		charController.Move(movement);

		// Jump
		if (charController.isGrounded) {
			if (Input.GetButtonDown ("Jump")) {
				vertSpeed = jumpSpeed;
			} else {
				vertSpeed = 0;
			}
		} else {
			vertSpeed += gravity;
		}
		movement = new Vector3(deltaX, vertSpeed, deltaZ);
	}
}