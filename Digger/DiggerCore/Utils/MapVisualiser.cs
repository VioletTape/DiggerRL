using System;
using System.Collections.Generic;
using System.Text;
using DiggerCore.Tiles;

namespace DiggerCore.Utils {
    public class MapVisualiser {
        private readonly Map map;
        private readonly Dictionary<Type, char> mapper;

        public MapVisualiser(Map map) {
            this.map = map;
            mapper = new Dictionary<Type, char>();
        }

        public MapVisualiser Render<T>(char displayElement) where T : Tile {
            mapper.Add(typeof(T), displayElement);
            return this;
        }

        public string Print() {
            var sb = new StringBuilder();
            var tm = map.TileMap;
            for (var w = 0; w < tm.Width; w++) {
                for (var d = 0; d < tm.Depth; d++) {
                    var type = tm[d, w].GetType();
                    sb.Append(mapper.ContainsKey(type) ? mapper[type] : ' ');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}