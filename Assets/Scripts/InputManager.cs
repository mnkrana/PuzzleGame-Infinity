using UnityEngine;
using UnityEngine.Tilemaps;

namespace Puzzle
{
    public sealed class InputManager : MonoBehaviour
    {
        [SerializeField]
        private Tilemap tileMap;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var hit = Physics2D.Raycast(worldPoint, Vector2.down);
                if (hit)
                {
                    Debug.Log($"Hit something {hit.collider.gameObject.name}");
                    var tpos = tileMap.WorldToCell(hit.point);
                    var tile = tileMap.GetTile(tpos);
                    Debug.Log($"Tile name {tile}");
                }
                else
                {
                    Debug.Log("Hit Nothing");
                }
            }
        }
    }
}
