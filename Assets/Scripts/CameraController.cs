using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject poopBall;

    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - poopBall.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = poopBall.transform.position + offset;
        Vector3 directionToPlayer = transform.position - poopBall.transform.position;
        
        
            
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = targetRotation;
    }
}
