using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public EntityBase basis;
    public AttackTypes currentAttack;

    [Header("Movement")]
    public bool isInCombat;
    public float movementSpeed;
    public float jumpForce;
    public float distToJump;
    public bool canJump;
    public bool isGrounded;
    public LayerMask ground;
    public Transform groundPoint;
    public Rigidbody rb;
    public LayerMask obstacles;

    [Header("Camera")]
    public cameraScript cam;
    public float camDist;

    public Animator anim;

    [Header("Combat")]
    public float helium;
    public float maxHelium;
    public int soup;

    private void Start()
    {
        camDist = Vector3.Distance(transform.position, cam.transform.position);
    }

    public void attack(AttackTypes type, enemyScript enemy, float damage)
    {
        if (type != enemy.basis.immuneTo)
        {
            enemy.basis.health -= damage;
        }
        if (type != AttackTypes.None && type != AttackTypes.Basic)
        {
            helium -= 5f;
        }
    }

    private void Update()
    {
        if (!isInCombat)
        {
            RaycastHit hit;
            if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, distToJump, ground))
            {
                isGrounded = true;
            } else
            {
                isGrounded = false;
            }

            if (Input.GetAxisRaw("Jump") >= 0.5f && canJump && isGrounded)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }

            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            rb.velocity = new Vector3(input.x * movementSpeed, rb.velocity.y, input.y * movementSpeed);

            if (input != Vector2.zero)
            {
                anim.SetBool("isWalking", true);
            } else
            {
                anim.SetBool("isWalking", false);
            }

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        }
    }
}
