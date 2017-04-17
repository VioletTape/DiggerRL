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
            var activeTile = Map.GetTileNextTo(moveDirectionCommand);
            Digger.Move(new MoveCommand(moveDirectionCommand.Direction, activeTile));
        }
    }
}