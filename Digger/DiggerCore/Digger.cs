using System;
using System.Collections.Generic;
using DiggerCore.ElementalStructures;

namespace DiggerCore {
    public class Digger {
        public int  Stamina { get; set; }

        public Digger() {
            Stamina = 100;
        }

        public void Move(Player.MoveCommand move)
        {
            OnMove(Player.MoveCommandClass.GetPoint(move));
        }

        public event Action<Point> OnMove;

        public enum MoveCommand
        {
            Left
            , Right
            , Up
            , Down
        }

        public class MoveCommandClass
        {
            public static Point Left = new Point(0, -1);
            public static Point Right = new Point(0, 1);
            public static Point Up = new Point(-1, 0);
            public static Point Down = new Point(1, 0);

            private static readonly List<Point> points = new List<Point> {
                                                                             Left
                                                                             , Right
                                                                             , Up
                                                                             , Down
                                                                         };

            public static Point GetPoint(Player.MoveCommand command)
            {
                return points[(int)command];
            }
        }
    }
}