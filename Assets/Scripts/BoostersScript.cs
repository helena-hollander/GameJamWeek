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
    bouncer = transform.Find("Bouncer")?.gameObject;
    blood = transform.Find("Blood")?.gameObject;

    if (bouncer == null) Debug.LogWarning("Bouncer not found in children");
    if (blood == null) Debug.LogWarning("Blood not found in children");
}

void Update()
{
    if (Vector3.Distance(transform.position, player.transform.position) < 2f)
    {
        Debug.Log($"Near booster: {gameObject.name}, hasJumped = {hasJumped}");
    }
}



    void OnTriggerEnter(Collider other)
{
    Debug.Log($"OnTriggerEnter called with {other.gameObject.name}");
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
