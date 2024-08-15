using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    private Rigidbody rb;

    // Reference to the water mask
    public LayerMask waterMask;

    // Track whether the player is in water
    public static bool inWater;

    public float checkRadius = 0.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
        rb = GetComponent<Rigidbody>();
        inWater = false;
    }

    void Update()
    {
        bool forward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow); 
        bool inWater = Physics.CheckSphere(transform.position, checkRadius, waterMask);
        
        // Running
        if (forward)
        {
            animator.SetBool("isRunning", true);
        }
        
        if (!forward)
        {
            animator.SetBool("isRunning", false);
        }

        // Swimming
        if (inWater)
        {
            animator.SetBool("isSwimming", true);
        }
        
        if (!inWater)
        {
            animator.SetBool("isSwimming", false);
        }
        
/*
// Swimming - only activate if the player is in water 
        if (inWater) 
        { 
            animator.SetBool("isSwimming", true); 
        } 
        
        if (!inWater)
        { 
            animator.SetBool("isSwimming", false); 
        }

        // Grounded - assumes player is grounded if not in water
        //bool IsGrounded = !isInWater;
        //animator.SetBool("IsGrounded", IsGrounded);
*/
    }
/*
    void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the water
        if (other.gameObject.CompareTag("Water"))
        {
            inWater = true;
            Debug.Log("Entered water");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player has exited the water
        if (other.gameObject.CompareTag("Water"))
        {
            inWater = false;
            Debug.Log("Exited water");
        }
    }
*/
}



