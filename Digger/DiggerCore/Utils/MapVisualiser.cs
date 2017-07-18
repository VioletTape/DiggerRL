using System;
using System.Collections.Generic;
using System.Text;
using DiggerCore.ElementalStructures;
using DiggerCore.Items;
using DiggerCore.Tiles;

namespace DiggerCore.Utils {
    public class MapVisualiser {
        private readonly Map map;
        private readonly Dictionary<Type, char> tileMap;
        private readonly Dictionary<Type, char> itemMap;
        private bool isDiggerOnMap;

        public MapVisualiser(Map map) {
            this.map = map;
            tileMap = new Dictionary<Type, char>();
            itemMap = new Dictionary<Type, char>();
        }

        public MapVisualiser Render<T>(char displayElement) where T : Tile {
            tileMap.Add(typeof(T), displayElement);
            return this;
        }

        public MapVisualiser WithDigger() {
            isDiggerOnMap = true;
            return this;
        }

        public string Print() {
            var sb = new StringBuilder();
            var tm = map.TileMap;
            for (var dp = 0; dp < tm.Depth; dp++) {
                for (var w = 0; w < tm.Width; w++) {
                    if (isDiggerOnMap && map.DiggerPosition == new Point(w, dp)) {
                        sb.Append('&');
                        continue;
                    }

                    var itemType = tm[w, dp].Item.GetType();
                    if (itemMap.ContainsKey(itemType)) {
                        sb.Append(itemMap[itemType]);
                        continue;
                    } 

                    var type = tm[w, dp].GetType();
                    sb.Append(tileMap.ContainsKey(type) ? tileMap[type] : ' ');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public MapVisualiser RenderItem<T>(char displayElement) where T : IItem {
            itemMap.Add(typeof(T), displayElement);

            return this;
        }
    }
}