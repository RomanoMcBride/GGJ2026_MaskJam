using UnityEngine;

public class MoveContinuously : MonoBehaviour
{
	public Vector3 speed;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime);
    }
}
