﻿using System;
using System.Collections.Generic;
using System.Text;
using DiggerCore.ElementalStructures;
using DiggerCore.Tiles;

namespace DiggerCore.Utils {
    public class MapVisualiser {
        private readonly Map map;
        private readonly Dictionary<Type, char> mapper;
        private bool isDiggerOnMap;

        public MapVisualiser(Map map) {
            this.map = map;
            mapper = new Dictionary<Type, char>();
        }

        public MapVisualiser Render<T>(char displayElement) where T : Tile {
            mapper.Add(typeof(T), displayElement);
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
                    var type = tm[w, dp].GetType();
                    sb.Append(mapper.ContainsKey(type) ? mapper[type] : ' ');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}