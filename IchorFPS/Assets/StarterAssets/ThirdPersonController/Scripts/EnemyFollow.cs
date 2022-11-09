using UnityEngine;
using System.Collections;
using UnityEngine.AI;
[RequireComponent(typeof(CharacterController))]

public class EnemyFollow : MonoBehaviour {
	private Animator anim;
	public float speed = 0.1f;
	public float minDist = 2f;
	public bool EnemyIsAttacking = false;
    private bool hasAttacked = false;
	public Transform target;
	public NavMeshAgent agent;
	private float AttackRate = 1f;
	private float NextAttack = 0f; 

	public AudioSource source;
	public AudioClip swing;
	[Range(0, 1)] public float SwingAudioVolume = 0.5f;

	public AudioClip LandingAudioClip;
    [Range(0, 1)] public float LandingAudioVolume = 0.5f;
	public AudioClip[] FootstepAudioClips;
    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

	private CharacterController controller;
 	// UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	// Use this for initialization
	void Start () 
	{
        anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
		
		// // if no target specified, assume the player
		// if (target == null) {

		// 	if (GameObject.FindWithTag ("Player")!=null)
		// 	{
		// 		target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
		// 	}
		// }

		agent.destination  = target.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f  && anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy"))
        {
            anim.SetBool("Attack", false);
			EnemyIsAttacking = false;
            hasAttacked = true;

        }
		if (target == null)
			return;

		// // face the target
		

		// //get the distance between the chaser and the target
		float distance = Vector3.Distance(transform.position,target.position);
        // Debug.Log(distance);
		// //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
		anim.SetBool("Walk", agent.velocity.magnitude>0.01f);
		// if(distance > 1f) {
        //     anim.SetBool("Walk", true);
        //     transform.position += transform.forward * speed * Time.deltaTime * 0.2f;
        //     //transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        // }

		agent.destination  = target.position;
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy"))
        {
			agent.velocity = Vector3.zero;
			// NextAttack = Time.time+ AttackRate;

        }
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
			agent.velocity = Vector3.zero;
			anim.SetBool("Attack", false);
			// NextAttack = Time.time+ AttackRate;
        }
        if (distance<2.3f && Time.time>NextAttack){
			NextAttack = Time.time+ AttackRate;
			transform.LookAt(target);
			
            if(hasAttacked == false){

				EnemyIsAttacking = true;
				anim.SetBool("Attack", true);
				//source.PlayOneShot(clip);
				hasAttacked = true;
			}
            else hasAttacked  = false;
        }
	}

	// Set the target of the chaser
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}
	private void OnFootstep(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                if (FootstepAudioClips.Length > 0)
                {
                    var index = Random.Range(0, FootstepAudioClips.Length);
                    AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(controller.center), FootstepAudioVolume);
                }
            }
        }

	private void OnLand(AnimationEvent animationEvent)
	{
		if (animationEvent.animatorClipInfo.weight > 0.5f)
		{
			AudioSource.PlayClipAtPoint(LandingAudioClip, transform.TransformPoint(controller.center), LandingAudioVolume);
		}
	}

	public void OnSwing(AnimationEvent animationEvent){
		if (animationEvent.animatorClipInfo.weight > 0.5f)
		{
			AudioSource.PlayClipAtPoint(swing,transform.TransformPoint(controller.center), SwingAudioVolume);
		}
	}

}