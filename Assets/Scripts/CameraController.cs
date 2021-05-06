using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float fieldOfView;

    private void Update()
    {
        MoveCameraWithTarget();
    }

    private void MoveCameraWithTarget()
    {
        transform.position = new Vector3(target.transform.position.x, transform.transform.position.y, this.transform.position.z);
    }
}