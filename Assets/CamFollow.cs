using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private GameObject player;

    public float maxCameraAdjustmentSpeed = 5.0f;
    public float cameraAdjustmentSpeedAcceleration = 5.0f;
    
    private float currentCameraAdjustmentSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find player in level
        PlayerInput p = FindFirstObjectByType<PlayerInput>();
        player = p.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float targetDistance = Vector3.Distance(transform.position, player.transform.position);
        currentCameraAdjustmentSpeed = Mathf.Max(targetDistance, maxCameraAdjustmentSpeed);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, currentCameraAdjustmentSpeed * Time.deltaTime) ;
    }
}
