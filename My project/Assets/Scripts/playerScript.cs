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
    public Rigidbody rb;
    public LayerMask obstacles;

    [Header("Camera")]
    public cameraScript cam;
    public float camDist;

    public Animator anim;

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
    }

    private void Update()
    {
        if (!isInCombat)
        {
            Quaternion olddirection = transform.rotation;
            transform.LookAt(cam.transform);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, camDist, obstacles))
            {
                cam.transform.position = hit.point;
            } else
            {
                cam.transform.position = Vector3.forward * camDist;
            }

            transform.rotation = olddirection;

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
