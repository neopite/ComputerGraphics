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
            //return new Color((byte)color.R * intensative, color.G * intensative, color.B * intensative);
            return new Color((byte)new Random().Next(0, 255), (byte)new Random().Next(0, 255),(byte)new Random().Next(0, 255)); //TODO after render fixing
        }
        
    }
}