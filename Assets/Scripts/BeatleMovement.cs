using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BeatleMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float xInput;
    private float zInput;
    public GameObject player;
    public Vector3 poopPos;
    public float offset = 3f;
    public Animator animator;
    private string animToPlay;
    
    public float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        poopPos = transform.position;
    }

    // Update is called once per frame
    private void StartAnimating()
    {
        if (player.transform.position != poopPos)
        {
            animToPlay = "Walk";
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animToPlay = "Run";
                animator.SetTrigger(animToPlay);
                
            }
        animator.SetTrigger(animToPlay);
        }
    }

    void Update()
    {

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        rb.AddForce(xInput *speed, 0, zInput * speed);
        
        poopPos = transform.position;
        player.transform.position = new Vector3(poopPos.x - offset, poopPos.y, poopPos.z - offset);
        StartAnimating();
    }
}
