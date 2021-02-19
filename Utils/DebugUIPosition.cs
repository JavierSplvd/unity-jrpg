using UnityEngine;

public class DebugUIPosition : MonoBehaviour {
    [SerializeField] private Vector3 position, rectPosition, rectLocalPosition;
    [SerializeField] private Vector2 anchoredPosition;
    [SerializeField] private RectTransform rect;
    
    void Start()
    {
        rect = GetComponent<RectTransform>();
        if(!Application.isEditor)
        {
            Destroy(this);
        }
    }

    void Update()
    {
        position = transform.position;
        rectPosition = rect.position;
        rectLocalPosition = rect.localPosition;
        anchoredPosition = rect.anchoredPosition;
    }
}