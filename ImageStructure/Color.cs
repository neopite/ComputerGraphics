using System;

namespace ImageConverter.ImageStructure
{
    public class Color
    {
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color Red = new Color(255, 0, 0);
        public static readonly Color Green = new Color(0, 255, 0);
        
        public static Color operator *(Color color,double intensative)
        {
            return new Color((byte)(color.R * intensative), (byte) (color.G * intensative), (byte) (color.B * intensative));
        }
        
    }
}