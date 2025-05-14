using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject poopBall;

    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //offset = transform.position - poopBall.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraRot = poopBall.transform.position + poopBall.transform.TransformVector(offset);
        transform.position = cameraRot;
        Vector3 directionToPlayer = transform.position - poopBall.transform.position;
        
        
        transform.LookAt(poopBall.transform.position);
        // Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        // transform.rotation = targetRotation;
    }
}
