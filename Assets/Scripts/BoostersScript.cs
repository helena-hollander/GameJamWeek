using UnityEngine;

public class BoostersScript : MonoBehaviour
{
    public GameObject player;
    private GameObject bouncer;
    public float jumpSpeed = 0f;

    private bool hasJumped = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bouncer = GameObject.FindWithTag("Bouncer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
{
    hasJumped = true;

    if (hasJumped == true) {
    Debug.Log("OnTriggerEnter");
    player.GetComponent<Rigidbody>().AddForce(0, jumpSpeed, 0, ForceMode.VelocityChange);
    hasJumped = false;
bouncer.transform.localScale = new Vector3(1f, 0.05f, 1f);
    }
}

}
