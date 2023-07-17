using UnityEngine;

[ExecuteInEditMode]
public class EditorSquare : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // Set the color of the Gizmos to red
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);

        // Draw a square using Gizmos
        Gizmos.DrawCube(transform.position, new Vector3(1f, 1f, 0f));
    }
}
