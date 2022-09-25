using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackingForDummies : MonoBehaviour
{
    private Animator anim;
    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
    private float normalizedTimeThing = 0.5f;
    public bool canMove = true;
 
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log("can move: "+canMove);
        
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > normalizedTimeThing && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1") && noOfClicks == 0)
        {
            Debug.Log("First Click No: "+ noOfClicks);
            noOfClicks = 0;
            anim.SetInteger("clicks", noOfClicks);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > normalizedTimeThing && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2") && noOfClicks == 1)
        {
            Debug.Log("Second Click No: "+ noOfClicks);
            noOfClicks = 0;
            anim.SetInteger("clicks", noOfClicks);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > normalizedTimeThing && anim.GetCurrentAnimatorStateInfo(0).IsName("hit3") && noOfClicks == 2)
        {
            Debug.Log("Third Click No: "+ noOfClicks);
            noOfClicks = 0;
            anim.SetInteger("clicks", noOfClicks);
        }
 
        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
            anim.SetInteger("clicks", noOfClicks);
        }
 
        //cooldown time
        if (Time.time > nextFireTime)
        {
            // Check for mouse input
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
 
            }
        }
    }
 
    void OnClick()
    {
        //so it looks at how many clicks have been made and if one animation has finished playing starts another one.
        
        if (noOfClicks == 0)
        {
            lastClickedTime = Time.time;
            noOfClicks=1;
            anim.SetInteger("clicks", noOfClicks);
        }
        
        if (noOfClicks == 1 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            lastClickedTime = Time.time;
            noOfClicks=2;
            anim.SetInteger("clicks", noOfClicks);
        }
        if (noOfClicks == 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            lastClickedTime = Time.time;
            noOfClicks=3;
            anim.SetInteger("clicks", noOfClicks);
        }
    }
}