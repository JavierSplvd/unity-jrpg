using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
 public GameObject objectToToggle;
    public KeyCode toggleKey = KeyCode.F1;

    private void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            // Toggle the active state of the GameObject
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}