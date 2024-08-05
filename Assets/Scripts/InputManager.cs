using UnityEngine;
using UnityEngine.Tilemaps;

namespace Puzzle
{
    public sealed class InputManager : MonoBehaviour
    {
        [SerializeField]
        private Tilemap tileMap;

        [SerializeField]
        private RiverSO riverSO;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var hit = Physics2D.Raycast(worldPoint, Vector2.down);
                if (hit)
                {
                    var tpos = tileMap.WorldToCell(hit.point);
                    var tile = tileMap.GetTile(tpos);
                    var (found, nextTile) = riverSO.GetNextTile(tile.name);
                    if (found)
                    {
                        tileMap.SetTile(tpos, nextTile);
                    }
                }
            }
        }
    }
}
