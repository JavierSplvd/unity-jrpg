using UnityEngine;

public class RoundedFollow : MonoBehaviour
{
    public Transform targetTransform;
    public float moveSpeed = 5f;
    private Vector3 desiredPosition;

    private void LateUpdate()
    {
        desiredPosition.x = targetTransform.position.x;
        desiredPosition.y = targetTransform.position.y;
        desiredPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, moveSpeed * Time.deltaTime);
    }
}
