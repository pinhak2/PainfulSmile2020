using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;


    private void Awake()
    {
        MoveCameraWithTarget();
    }
    private void Update()
    {
        MoveCameraWithTarget();
    }

    private void MoveCameraWithTarget()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
    }
}