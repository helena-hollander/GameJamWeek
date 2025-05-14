using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class AnnaTestScript : MonoBehaviour
{
    private Rigidbody rb;
    private float xInput;
    private float zInput;
    public float speed = 1f;
    private float diameter = 1f;
    public float boostedSpeed = 3f;
    private bool isBoosted = false;

    private GameObject scaler;
    private GameObject speeder;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scaler = GameObject.FindWithTag("Scaler");
        speeder = GameObject.FindWithTag("Speeder");
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("PoopBall");
    }

    // Update is called once per frame
    void Update()
    {
        scaler.GetComponent<BoxCollider>();
        speeder.GetComponent<BoxCollider>();
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        rb.AddForce(xInput *speed, 0, zInput * speed);
    }

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Scaler"))
    {
        diameter += 0.5f;
        player.transform.localScale = new Vector3(diameter, diameter, diameter);
    }

    //!isBoosted Forhindrer, at man aktiverer speed boost flere gange samtidig
     if (other.CompareTag("Speeder") && !isBoosted)
        {
            StartCoroutine(SpeedBoost());
        }
    }


//Det er en coroutine, altså en funktion der kører over tid. Den bruges til at midlertidigt booste farten i x sekunder, og derefter sætte den tilbage.
    IEnumerator SpeedBoost()
    {
        isBoosted = true;
        float originalSpeed = speed;
        speed = boostedSpeed;

        yield return new WaitForSeconds(3f);

        speed = originalSpeed;
        isBoosted = false;
    }
}


