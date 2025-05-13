using UnityEngine;

public class BeatleMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float xInput;
    private float zInput;

    public float speed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        rb.AddForce(xInput *speed, 0, zInput * speed);
        
    }
}
