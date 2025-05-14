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
    public GameObject trackedPoop;
    private Vector3 lastPoopPos;
    private bool moved = false;
    
    
    public float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPoopPos = trackedPoop.transform.position;
       
    }

    // Update is called once per frame
    private void StartAnimating()
    {
        if (moved == true)
        {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animToPlay = "Run";
        }
        else
        {
            animToPlay = "Walk";
        }

        animator.SetTrigger(animToPlay);
        }
    }

    void FixedUpdate()
    {

        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        rb.AddForce(player.transform.TransformVector(xInput *speed, 0, zInput * speed));
        poopPos = transform.position;
        
        Vector3 directionToPlayer = transform.position - player.transform.position;
        
        
            
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        float angleDifference = Quaternion.Angle(player.transform.rotation, targetRotation);

// Only rotate if the angle is significant
        if (angleDifference > 0.5f) //How quickly it turns
        {
            float rotationSpeed = 7f; // How fast it turns
            player.transform.rotation = Quaternion.Slerp(
                player.transform.rotation,
                targetRotation,
                rotationSpeed * Time.fixedDeltaTime
            
            );
          
        }
        
        player.transform.position = transform.position;
        
        StartAnimating();
        OnTransformedChanged();
        //player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, player.transform.rotation.y, 0f);
    }
    void OnTransformedChanged()
    {
        float movementThreshold = 0.01f; // Tolerance value — adjust as needed
        float distance = Vector3.Distance(trackedPoop.transform.position, lastPoopPos);

        if (distance > movementThreshold)
        {
            moved = true;
            // Optional: clear Idle trigger if needed
            // animator.ResetTrigger("Idle");
            print("moving");
        }
        else
        {
            moved = false;
            animToPlay = "Idle";
            animator.SetTrigger(animToPlay);
        }

        lastPoopPos = trackedPoop.transform.position;
    }
    
}
