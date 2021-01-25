using UnityEngine;

namespace MoveLogic
{
    public enum Layers
    {
        R, L, U, D, F, B, M,
        Rw, Lw, Uw, Dw, LMR
    };

    public class Move
    {
        public readonly Layers layer;
        public readonly Vector3 RotationVec;
        public readonly float angle;
        public readonly string move_name;

        public Move(Layers layer, Vector3 RotationVec, float angle,string move_name)
        {
            this.angle = angle;
            this.layer = layer;
            this.RotationVec = RotationVec;
            this.move_name = move_name;
        }
    }

    public static class Moves
    {
        public static readonly Move U = new Move(Layers.U, new Vector3(0, 1, 0), 90,"U");
        public static readonly Move U_ = new Move(Layers.U, new Vector3(0, -1, 0), 90, "U'");
        public static readonly Move U2 = new Move(Layers.U, new Vector3(0, 1, 0), 180, "U2");
        public static readonly Move Uw = new Move(Layers.Uw, new Vector3(0, 1, 0), 90, "Uw");
        public static readonly Move Uw_ = new Move(Layers.Uw, new Vector3(0, -1, 0), 90, "Uw'");

        public static readonly Move R = new Move(Layers.R, new Vector3(0, 0, 1), 90, "R");
        public static readonly Move R_ = new Move(Layers.R, new Vector3(0, 0, -1), 90, "R'");
        public static readonly Move R2 = new Move(Layers.R, new Vector3(0, 0, 1), 180, "R2");
        public static readonly Move Rw = new Move(Layers.Rw, new Vector3(0, 0, 1), 90,"Rw");
        public static readonly Move Rw_ = new Move(Layers.Rw, new Vector3(0, 0, -1), 90,"Rw'");

        public static readonly Move L = new Move(Layers.L, new Vector3(0, 0, -1), 90,"L");
        public static readonly Move L_ = new Move(Layers.L, new Vector3(0, 0, 1), 90,"L'");
        public static readonly Move L2 = new Move(Layers.L, new Vector3(0, 0, 1), 180, "L2");
        public static readonly Move Lw = new Move(Layers.Lw, new Vector3(0, 0, 1), 90,"Lw");
        public static readonly Move Lw_ = new Move(Layers.Lw, new Vector3(0, 0, -1), 90,"Lw'");

        public static readonly Move D = new Move(Layers.D, new Vector3(0, -1, 0), 90,"D");
        public static readonly Move D_ = new Move(Layers.D, new Vector3(0, 1, 0), 90,"D'");
        public static readonly Move D2 = new Move(Layers.D, new Vector3(0, -1, 0), 180,"D2");
        public static readonly Move Dw = new Move(Layers.Dw, new Vector3(0, -1, 0), 90,"Dw");
        public static readonly Move Dw_ = new Move(Layers.Dw, new Vector3(0, 1, 0), 90,"Dw'");

        public static readonly Move F = new Move(Layers.F, new Vector3(1, 0, 0), 90,"F");
        public static readonly Move F_ = new Move(Layers.F, new Vector3(-1, 0, 0), 90,"F'");
        public static readonly Move F2 = new Move(Layers.F, new Vector3(-1, 0, 0), 180,"F2");

        public static readonly Move B = new Move(Layers.B, new Vector3(-1, 0, 0), 90,"B");
        public static readonly Move B_ = new Move(Layers.B, new Vector3(1, 0, 0), 90,"B'");
        public static readonly Move B2 = new Move(Layers.B, new Vector3(1, 0, 0), 180,"B2");

        public static readonly Move M = new Move(Layers.M, new Vector3(0, 0, 1), 90,"M");
        public static readonly Move M_ = new Move(Layers.M, new Vector3(0, 0, -1), 90,"M'");
        public static readonly Move M2 = new Move(Layers.M, new Vector3(0, 0, 1), 180,"M2");

        public static readonly Move x = new Move(Layers.LMR, new Vector3(0, 0, 1), 90,"x");
        public static readonly Move x_ = new Move(Layers.LMR, new Vector3(0, 0, -1), 90,"x'");
        public static readonly Move x2 = new Move(Layers.LMR, new Vector3(0, 0, 1), 180,"x2");

        public static readonly Move y = new Move(Layers.LMR, new Vector3(0, 1, 0), 90,"y");
        public static readonly Move y_ = new Move(Layers.LMR, new Vector3(0, -1, 0), 90,"y'");
        public static readonly Move y2 = new Move(Layers.LMR, new Vector3(0, 1, 0), 90,"y2");

        public static readonly Move z = new Move(Layers.LMR, new Vector3(1, 0, 0), 90,"z");
        public static readonly Move z_ = new Move(Layers.LMR, new Vector3(-1, 0, 0), 90,"z'");
    }
}

