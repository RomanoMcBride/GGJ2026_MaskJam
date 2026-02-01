using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private GameObject player;

    public float cameraAdjustmentSpeed = 5.0f;
    public float camMovementOffset = 2.0f;
    public float maxDistanceMultiplier = 1.0f;
    
    private float currentCameraAdjustmentSpeed;

    private PlayerInput p;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find player in level
	    p = FindFirstObjectByType<PlayerInput>();
        player = p.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
	    Vector3 targetPosition = player.transform.position + p.move * camMovementOffset;
	    //Debug.Log("move offset: " + p.move.ToString());
        float distanceToTarget = Mathf.Clamp(Vector3.Distance(transform.position, targetPosition), 0, maxDistanceMultiplier);
        //Debug.Log("distance to target " + distanceToTarget);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, cameraAdjustmentSpeed * distanceToTarget * Time.deltaTime) ;
    }
}
