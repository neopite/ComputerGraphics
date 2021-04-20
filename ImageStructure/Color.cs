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

        public static Color operator *(Color color,double intensative)
        {
            return new Color((byte)(color.R * intensative), (byte) (color.G * intensative), (byte) (color.B * intensative));
        }
        
    }
}