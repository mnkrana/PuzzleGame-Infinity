using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Puzzle
{
    [CreateAssetMenu(menuName = "Puzzle/River")]
    public class RiverSO : ScriptableObject
    {
        [SerializeField]
        private List<Tile> tiles;

        public (bool, Tile) GetNextTile(string tile)
        {
            var exist = tiles.Exists(x => x.name.Equals(tile));
            if (!exist)
            {
                return (false, null);
            }

            var index = tiles.FindIndex(x => x.name.Equals(tile));
            if (index == tiles.Count - 1)
            {
                index = 0;
            }
            else
            {
                ++index;
            }

            return (true, tiles[index]);
        }
    }
}
