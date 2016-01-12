using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	bool facingRight = true;
	public float jumpForce;
	public bool isGrounded = true;

	Animator anim;

	public Flashlight fLight;
	Vector3 rotationVector;
	public GameManager manager;

	public AudioClip[] clips;
	public AudioSource[] sources;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		fLight = fLight.GetComponent<Flashlight> ();
		manager = manager.GetComponent<GameManager> ();

		rotationVector = fLight.transform.rotation.eulerAngles;
		rotationVector.y = 77.5f;

		//Playing AudioSources
		sources = new AudioSource[clips.Length];
		int i = 0;
		while (i < clips.Length)
		{
			GameObject child = new GameObject ("Player");
			child.transform.parent = gameObject.transform;
			sources[i] = child.AddComponent("AudioSource") as AudioSource;
			sources[i].clip = clips[i];
			i++;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*float move = Input.GetAxisRaw ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);*/
		Movement ();


	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}

		if (transform.position.x > 26f)
		{
			manager.ReadyToGo();
		}
	}

	void Movement()
	{
		float move = Input.GetAxis ("Horizontal"); //variable that receives the input values
		anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis ("Horizontal"))); //initialize animation variable "speed" to receive input values
		rigidbody2D.velocity = new Vector2(move * speed, rigidbody2D.velocity.y); //2D movement

		if (move > 0 && !facingRight)
		{
			Flip();
			FlipLight();
		}
		if (move < 0 && facingRight)
		{
			Flip();
			FlipLight();
		}
	}

	void Flip() //flips the player when changing directions
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void FlipLight() //flips the flashlight direction when changing directions; hardcoded
	{
		if (rotationVector.y == 77.5f)
		{
			rotationVector.y = 282f;
		} else if (rotationVector.y == 282f)
		{
			rotationVector.y = 77.5f;
		}
		fLight.transform.rotation = Quaternion.Euler (rotationVector);
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Floor")
		{
			isGrounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Floor")
		{
			isGrounded = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Token")
		{
			manager.AddToken();
			Destroy (other.gameObject);
			sources[0].Play();
		}
	}
}
