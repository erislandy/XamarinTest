using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.components.SkiaComponents
{
    public class GlobalConst
    {
        public static SKColor[] HorizontalBarNormalColors =>
            new SKColor[10]
                {
                    SKColor.Parse("affff9"),
                    SKColor.Parse("00fff3"),
                    SKColor.Parse("00faf2"),
                    SKColor.Parse("00ebf1"),
                    SKColor.Parse("00d2ee"),
                    SKColor.Parse("00b0ea"),
                    SKColor.Parse("0083e5"),
                    SKColor.Parse("014ddf"),
                    SKColor.Parse("010ed8"),
                    SKColor.Parse("0101d7")
                };
        public static SKColor[] HorizontalBarSelectedColors =>
            new SKColor[9]
                {
                        SKColor.Parse("c5ffb7"),
                        SKColor.Parse("55ffbf"),
                        SKColor.Parse("53feba"),
                        SKColor.Parse("4cfcab"),
                        SKColor.Parse("41f992"),
                        SKColor.Parse("32f570"),
                        SKColor.Parse("1eef44"),
                        SKColor.Parse("07e90e"),
                        SKColor.Parse("01e701")
                       
                };
        public static float[] HorizontalBarNormalPointColors = new float[10]
             { 0f, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 };

        public static float[] HorizontalBarSelectedPointColors = new float[9]
             { 0f, 0.1f, 0.21f, 0.34f, 0.49f, 0.64f, 0.8f, 0.96f, 1 };

        public static SKColor[] FillSemiCircleNormalColors => new SKColor[2]
            {SKColor.Parse("57fffc"), SKColor.Parse("00a1f5")};
        public static SKColor[] FillSemiCircleSelectedColors => new SKColor[2]
           {SKColor.Parse("c5ffb7"), SKColor.Parse("01e701")};



    }

}
