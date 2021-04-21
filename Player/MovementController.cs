using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 10f;
    public float jumpForce = 4;
    public float dragForce = 1f;

    public Animator anim;
    [Tooltip("To get the exact length of animation")]
    public AnimationClip attack;
    public CapsuleCollider playerCollider;

    public Transform mainCamera;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 direction;
    bool jumpKeyPressed;
    bool glideKeyHeld;
    bool isAttacking = false;


    private void Start()
    {
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        anim = anim == null ? gameObject.GetComponent<Animator>() : anim;
        rb = rb == null ? gameObject.GetComponent<Rigidbody>() : rb;
    }
    private void Update()
    {
        if (Application.loadedLevelName != "GameplayScene")
        {
            anim.SetBool("isSwimming", false);
        }

        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        jumpKeyPressed = Input.GetKeyDown(KeyCode.Space);
        glideKeyHeld = Input.GetKey(KeyCode.Space);

        Jump();
        if (Input.GetMouseButton(0) && !isAttacking)
        {
            StartCoroutine(meleeAttack());
        }
        Animation();
    }

    private void FixedUpdate()
    {
        Movement();
        Glide();


    }

    private void Movement()
    {

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            rb.MovePosition(rb.position + moveDir.normalized * speed * Time.deltaTime);
            
        }

       
    }

    private void Jump()
    {
        if (jumpKeyPressed && isGrounded())
        {
            
            Vector3 jumpVector = Vector3.up * jumpForce;
            jumpVector.x = rb.velocity.x;
            jumpVector.z = rb.velocity.z;
            rb.velocity = jumpVector;
            
        }
 
    }

    private void Glide()
    {
        if(glideKeyHeld && !isGrounded())
        {
            rb.drag = dragForce;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void Animation()
    {
        if (direction.magnitude >= 0.1f && isGrounded())
        {


            anim.SetBool("isMoving", true);
            if (TryGetComponent(out PlayerAudio audio))
            {
                audio.WalkSource.Play();
            }


        }
        else
        {
            anim.SetBool("isMoving", false);
            if (TryGetComponent(out PlayerAudio audio))
            {
                audio.WalkSource.Pause();
            }
        }


        if (jumpKeyPressed && isGrounded())
        {
            anim.SetBool("isJumping", true);
            
            if (TryGetComponent(out PlayerAudio audio))
            {
                audio.JumpSource.Play();
            }
        }
    
        else if (isGrounded())
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);

        }

        if (!isGrounded())
        {
            anim.SetBool("isFalling", true);
        }

        if (transform.position.y < 92.5f & Application.loadedLevelName == "GameplayScene")
        {
            anim.SetBool("isSwimming", true);

        }
        if (transform.position.y > 92.5f & Application.loadedLevelName == "GameplayScene")
        {
            anim.SetBool("isSwimming", false);
        }




    }


    private bool isGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position, -gameObject.transform.up, playerCollider.bounds.extents.y + 0.6f);
        return isGrounded;
    }

    private IEnumerator meleeAttack()
    {
        
        isAttacking = true;
        anim.SetBool("isAttacking", true);
        float time = attack.length;
        StartCoroutine(attackSound(time / 1.7f));
        yield return new WaitForSeconds(time);
        anim.SetBool("isAttacking", false);
        isAttacking = false;
    }

    private IEnumerator attackSound(float time)
    {
        yield return new WaitForSeconds(time);
        if (TryGetComponent(out PlayerAudio audio))
        {
            audio.AttackSource.Play();
        }
    }

    public void DisableMovement()
    {
        playerCollider.enabled = false;

        anim.SetBool("isMoving", false);
        anim.SetBool("isJumping", false);
        anim.SetBool("isAttacking", false);
        this.enabled = false;

    }
}
