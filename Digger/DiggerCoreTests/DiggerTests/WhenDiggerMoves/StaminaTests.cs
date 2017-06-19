﻿using DiggerCore;
using DiggerCore.Commands;
using FluentAssertions;
using NUnit.Framework;

namespace DiggerCoreTests.DiggerTests.WhenDiggerMoves {
    [TestFixture]
    public class StaminaTests {
        [Test]
        public void StaminaShouldDecrese() {
            var digger = new Digger();
            var initialStamina = digger.Stamina;

            digger.Move(new MoveCommand(Direction.Right, new Tile(TileType.Empty)));

            digger.Stamina
                  .Should()
                  .BeLessThan(initialStamina);
        }
    }
}