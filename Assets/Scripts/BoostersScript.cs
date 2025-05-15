using UnityEngine;
using System.Collections;

public class BoostersScript : MonoBehaviour
{
    public GameObject player;
    private GameObject bouncer;
    private GameObject blood;
    public float jumpSpeed = 0f;

    private bool hasJumped = false;

    void Start()
{
    if (player == null)
        player = GameObject.FindWithTag("Player");
    bouncer = GameObject.FindWithTag("Bouncer");
    blood = GameObject.FindWithTag("Blood");
}


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !hasJumped)
        {
            hasJumped = true;
            Debug.Log("Boost activated");
            player.GetComponent<Rigidbody>().AddForce(0, jumpSpeed, 0, ForceMode.VelocityChange);

            bouncer.transform.localScale = new Vector3(0.5f, 0.05f, 0.5f);
            blood.transform.localScale = new Vector3(2.5f, 0.02f, 2.5f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            hasJumped = false;
            Debug.Log("Player left booster, can jump again");
        }
    }
}
