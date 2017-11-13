using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Variables et attributs prives
	public bool isGrounded;
	float turnSmoothVelocity;
	float speedSmoothVelocity;
	float currentSpeed;
	Rigidbody rb;
	Animator animator;
	Transform cameraT;
	private int attackAnimation = 1;
	private Vector3 jump;
    public float Health = 100;

	//Attributs publics
	public float walkSpeed = 2;
	public float runSpeed = 6;
	public float turnSmoothTime = 0.2f;
	public float speedSmoothTime = 0.1f;
	public float JumpForce = 2.0f;
	public static float distanceFromTarget;
	public float ToTarget;

	float cooldownCounter = 1;
	public bool coolingdown = false;


	void Start () {
		
		//Preparation des variables
		animator = GetComponent<Animator> ();
		cameraT = Camera.main.transform;
		rb = GetComponent<Rigidbody>();
		jump = new Vector3 (0.0f, 2.0f, 0.0f);
	}

	void Update () {

		//RayCasting
		RaycastHit Hit;
		if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Hit)){
			ToTarget = Hit.distance;
			distanceFromTarget = ToTarget;
		}

			
		//Preparation
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 inputDir = input.normalized;


		//Rotation
		if (inputDir != Vector2.zero) {
			float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
		}

		//Translation
		bool running = Input.GetKey (KeyCode.LeftShift);
		float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
		transform.Translate (transform.forward * currentSpeed * Time.deltaTime, Space.World);

		//Animation selon la vitesse de deplacement marcher/courir
		float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
		animator.SetFloat ("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

		attackCooldown ();
		//Attacking. On bloque la prochaine attaque sil est deja en train dattaquer en se fiant sur lanimation
		if (Input.GetKeyDown(KeyCode.Mouse0)){
			if (animator.GetCurrentAnimatorStateInfo(1).IsName ("Attack1") || animator.GetCurrentAnimatorStateInfo(1).IsName ("Attack2") ) {
				return;}
			else {
				if (!coolingdown) {
					Attack ();
				}
			}
		}

		//Jumping
		if(Input.GetButtonDown("Jump") && isGrounded ){
			animator.Play ("Jump");
			isGrounded = false;
			rb.AddForce (jump * JumpForce, ForceMode.Impulse);
		}


	}

	//Permet de switcher danimation pour eviter la redondance
	//Peut joeur la meme deux fois si lutilisateur attaque une autre fois avant la fin de lanimation
	void Attack(){
		if (attackAnimation == 1 && isGrounded) {
			animator.SetTrigger ("Attack");
			attackAnimation = 2;
			return;
		} else {
			animator.SetTrigger ("Attack2");
			attackAnimation = 1;
			return;
		}
	}

	//On determine si on est au sol pour empecher les jumps multiples
	void OnCollisionStay(){
		isGrounded = true;
	}

	//Cooldown des attaques, on se fie au temps restant de lanimation pour determiner le cooldown
	void attackCooldown(){
		if (animator.GetCurrentAnimatorStateInfo (1).IsName ("Attack1") || animator.GetCurrentAnimatorStateInfo (1).IsName ("Attack2")) {
			AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo (0);
			AnimatorClipInfo[] myAnimatorClip = animator.GetCurrentAnimatorClipInfo (0);
			float myTime = myAnimatorClip [0].clip.length * animationState.normalizedTime;
			if (myTime > 0) {
				coolingdown = true;
			}
		} else {
			coolingdown = false;
		}
	}

    public void getHitted(float damages)
    {
        Health -= damages;
        if (Health <= 0)
            die();
    }

    void die()
    {
        //TODO
        //Animation
        //Son
        //GUI game over

    }
}

