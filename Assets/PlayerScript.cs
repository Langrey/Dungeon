using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	float distanceToGround;
	float jumpTimer;
	// Use this for initialization
	void Start () {
		distanceToGround = collider2D.bounds.extents.y;
		jumpTimer = 0.5f;
	}

	//Sprawdza czy objekt jest na ziemi
	bool IsGrounded() {
		return Physics2D.Raycast(transform.position, -Vector3.up, distanceToGround + 0.1f);
	}
	bool Cooldown(float time, float maxTime){
		if (time <= 0) {
			time = maxTime;
						return true;
				}else {
			time -= Time.deltaTime;
						return false;
				}
						

		}
	
	void Update () {
		if (IsGrounded () && Cooldown (jumpTimer, 0.5f)) {
			rigidbody2D.AddForce((Vector2.up + Vector2.right) * 100);
				} else if (!IsGrounded ()) {
			jumpTimer = 0.5f;
				}
	}
}
