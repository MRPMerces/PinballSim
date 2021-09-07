
var ball : Transform;

Vector3 startingPos;

function Start() {
	startingPos = ball.position;
}

function OnCollisionEnter(_other : Collision) {

	if(_other.gameObject.tag == "Ball") {
		Debug.Log("hello");
		_other.rigidbody.velocity = Vector3.zero;
		_other.transform.position = startingPos;
	}

}