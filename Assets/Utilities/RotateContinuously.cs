using UnityEngine;

public class RotateContinuously : MonoBehaviour
{
	public float rotationSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
