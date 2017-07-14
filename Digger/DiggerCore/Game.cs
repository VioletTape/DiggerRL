using System;
using DiggerCore.Commands;
using DiggerCore.ElementalStructures;

namespace DiggerCore {
    public class Game {
        private Rule rule;
        public Map Map;
        public Player Player;
        public Digger Digger;

        public Game(Rule rule) {
            this.rule = rule;

            Map = new Map(rule);
            Map.GenerateMountain();

            CreatePlayer();
        }

        public Game(Map map) {
            rule = map.Rule;
            Map = map;

            CreatePlayer();
        }

        private void CreatePlayer() {
            Player = new Player();
            Digger = new Digger();

            Player.MoveCommand += PlayerOnMoveCommand;
        }

        /// <summary>
        /// Get next active tile and pass it to Digger, to detect what can be done with that tile
        /// </summary>
        /// <param name="sender">Player object</param>
        /// <param name="moveDirectionCommand">Command with proposed direction</param>
        private void PlayerOnMoveCommand(object sender, MoveDirectionCommand moveDirectionCommand) {
            if(!Map.GetCurrentTile().AllowMovementTo(moveDirectionCommand.Direction))
                return;

            var activeTile = Map.GetTileNextTo(moveDirectionCommand);

            if (activeTile.AllowEntrance()) {
                var moveCommand = new MoveCommand(moveDirectionCommand.Direction, activeTile);
                Digger.Move(moveCommand);
                Map.Move(moveCommand);
            }
        }
    }
}