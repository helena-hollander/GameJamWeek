using UnityEngine;

public class BoostersScript : MonoBehaviour
{
    public GameObject player;
    private GameObject bouncer;
    private GameObject blood;
    public float jumpSpeed = 0f;

    private bool hasJumped = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bouncer = GameObject.FindWithTag("Bouncer");
        blood = GameObject.FindWithTag("Blood");
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
    bouncer.transform.localScale = new Vector3(0.5f, 0.05f, 0.5f);
    blood.transform.localScale = new Vector3(2.5f, 0.02f, 2.5f);
    
    Vector3 pos = bouncer.transform.position;
    pos.y = 0f;
    bouncer.transform.position = pos;
    
    }
}

}
