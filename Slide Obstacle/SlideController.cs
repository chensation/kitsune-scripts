using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    public Animator anim;
    public SphereCollider playerSlideCollider;
    public Rigidbody rb;
    public Transform mainCamera;
    public MovementController playerMovement;


    public float force = 10f;

    private bool onSlide = false;
    float turnSmoothVelocity;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        if (onSlide)
        {
            
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, mainCamera.eulerAngles.y, ref turnSmoothVelocity, playerMovement.turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0f, mainCamera.eulerAngles.y, 0f) * (Vector3.forward * 2f + Vector3.down) * force;

            rb.AddForce(moveDir);
        }
        
    }

    private void Jump()
    {
        if (onSlide)
        {
            Vector3 jumpVector = Vector3.up * playerMovement.jumpForce * 1.5f;
            jumpVector.x = rb.velocity.x * 0.1f;
            jumpVector.z = rb.velocity.z * 0.1f;
            rb.velocity = jumpVector;
        }
       
    }

    public void EnableSliding()
    {
        anim.SetBool("isSliding", true);
        playerMovement.DisableMovement();
        playerSlideCollider.enabled = true;
        onSlide = true;

    }

    public void DisableSliding()
    {
        anim.SetBool("isSliding", false);
        playerMovement.playerCollider.enabled = true;
        playerMovement.enabled = true;
        playerSlideCollider.enabled = false;
        onSlide = false;
    }


}
