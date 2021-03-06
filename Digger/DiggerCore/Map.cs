﻿using System.Collections.Generic;
using DiggerCore.Commands;
using DiggerCore.ElementalStructures;
using DiggerCore.Tiles;
using Serilog;

namespace DiggerCore {
    public class Map {
        private readonly ILogger log = Log.ForContext<Map>();

        private static readonly Point Left = new Point(-1, 0);
        private static readonly Point Right = new Point(1, 0);
        private static readonly Point Up = new Point(0, -1);
        private static readonly Point Down = new Point(0, 1);

        private static readonly List<Point> Points = new List<Point> {
                                                                         Left
                                                                         , Up
                                                                         , Right
                                                                         , Down
                                                                     };

        public readonly Rule Rule;
        public readonly TileArray TileMap;
        public Point DiggerPosition;

        public Map(Rule rule) {
            Rule = rule;
            TileMap = new TileArray(rule.MapSize);
            DiggerPosition = rule.DiggerPosition;
        }

        public bool AllowMovementFrom(MoveDirectionCommand command) {
            var resolution = GetCurrentTile().MoveFromInto(command.Direction);
            log.Verbose("{actor} {movement} from {tileCoordinate}", "Digger", resolution ? "ready to move" : "stay", DiggerPosition);
            return resolution;
        }

        private Tile GetCurrentTile() {
            return TileMap[DiggerPosition];
        }

        private Tile GetTileNextTo(Direction moveDirectionCommand) {
            return TileMap[DiggerPosition + GetPoint(moveDirectionCommand)];
        }

        private static Point GetPoint(Direction direction) {
            return Points[(int) direction];
        }

        public void Move(DiggerMoves command) {
            var tile = GetTileNextTo(command.Direction);
            log.Verbose("Next possible active tile is {tile}", tile);

            var allowEntrance = tile.CanVisit(command.Digger);
            log.Verbose("{actor} {movement} on {tileCoordinate}", "Digger", 
                allowEntrance ? "allowed to move" : "stay", 
                allowEntrance ? DiggerPosition + Points[(int) command.Direction] : DiggerPosition);

            if(!allowEntrance)
                return;

            // todo: rethink what to do with diggers actions
            MoveDigger(command.Direction);
            tile.Visit(command.Digger);

            log.Information("{actor} {movement} on {tileCoordinate}. Stamina left {stamina}, gold {gold}", "Digger", "move", DiggerPosition, command.Digger.Stamina, command.Digger.Gold);
        }

        private void MoveDigger(Direction moveTo) {
            DiggerPosition += Points[(int) moveTo];

            if (TileMap[DiggerPosition].Type == TileType.Dirt) {
                TileMap[DiggerPosition] = new EmptyTile();
            }
        }
    }
}
