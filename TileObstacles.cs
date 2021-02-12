using UnityEngine;
using UnityEngine.Tilemaps;

public class TileObstacles : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameContext.Instance.input.click)
        {
            Vector3 mouse = GameContext.Instance.input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);

            Vector3 worldPoint = castPoint.GetPoint(-castPoint.origin.z / castPoint.direction.z);
            Vector3Int position = tilemap.WorldToCell(worldPoint);
            TileBase tile = tilemap.GetTile(position);

            Debug.Log(tile);

        }
    }
}
