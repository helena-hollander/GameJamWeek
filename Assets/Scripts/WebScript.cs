using System.Collections;
using UnityEngine;

public class WebScript : MonoBehaviour
{
    public GameObject player;
    public BeatleMovement playerScript;
    private float webSpeed;
    private bool isWebbed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerScript = player.GetComponent<BeatleMovement>();
        webSpeed = playerScript.speed / 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isWebbed)
        {
            StartCoroutine(SpeedDamp());
        }
        
    }

    IEnumerator SpeedDamp()
{
    isWebbed = true;

    float originalSpeed = playerScript.speed;
    float webSpeed = 0.01f;

    playerScript.speed = webSpeed;

    // Kun reducer farten lidt
    Rigidbody rb = playerScript.GetComponent<Rigidbody>();
    rb.linearVelocity = rb.linearVelocity * 0.2f;

    yield return new WaitForSeconds(1f);

    playerScript.speed = originalSpeed;
    isWebbed = false;
}


}
