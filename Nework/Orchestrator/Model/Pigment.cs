namespace Nework.Orchestration.Model
{
    public class Pigment
    {
        public byte Red { get; }
        public byte Green { get; }
        public byte Blue { get; }
        public byte Rotation { get; }
        public byte Swap { get; }

        public Pigment()
            : this(128, 128, 128)
        { }

        public Pigment(byte red, byte green, byte blue)
            : this(red, green, blue, 128, 128)
        { }

        public Pigment(byte red, byte green, byte blue, byte rotation, byte swap)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Rotation = rotation;
            Swap = swap;
        }
    }
}
