using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class betterjump : MonoBehaviour
{
    public float fallMultiplier = 4f;
    public float lowJumpMultiplier = 2f;
    Rigidbody rb;
    ThirdPersonController tpc;
    void Awake(){
        tpc = GetComponent<ThirdPersonController>();
        rb = GetComponent<Rigidbody> ();
    }
    void Update()
    {
        Debug.Log(rb.velocity);
        if(rb.velocity.y<0){
            rb.velocity += Vector3.up * tpc.Gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y>0 && !Input.GetButton("Jump")){
            rb.velocity += Vector3.up * tpc.Gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
