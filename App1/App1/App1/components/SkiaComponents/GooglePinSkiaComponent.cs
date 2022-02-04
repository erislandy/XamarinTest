using System;
using System.Collections.Generic;
using System.Text;

namespace App1.components.SkiaComponents
{

    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    public class GooglePinSkiaComponent: SKCanvasView
    {
        SKPaint fillColor = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            Color = SKColors.Aqua

        };
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 92.5f);

            canvas.Translate(-46.2f, -62.0f);
            var fillColors = new SKColor[10];
            SKColor.TryParse("b1fffb", out fillColors[0]);
            SKColor.TryParse("00fff5", out fillColors[1]);
            SKColor.TryParse("00faf4", out fillColors[2]);
            SKColor.TryParse("00ebf3", out fillColors[3]);
            SKColor.TryParse("00d2f0", out fillColors[4]);
            SKColor.TryParse("00b0ec", out fillColors[5]);
            SKColor.TryParse("0083e7", out fillColors[6]);
            SKColor.TryParse("014de1", out fillColors[7]);
            SKColor.TryParse("010eda", out fillColors[8]);
            SKColor.TryParse("0101d9", out fillColors[9]);

            var pin = SKPath.ParseSvgPathData("M41.5,121.46C6.5,70.46,0,65.23,0,46.49a46.25,46.25,0,1,1,92.5,0c0,18.74-6.5,24-41.5,75a5.77,5.77,0,0,1-9.5,0Zm4.75-55.61A19.37,19.37,0,1,0,27,46.49,19.32,19.32,0,0,0,46.25,65.85Z");
            canvas.DrawPath(pin, fillColor);
        }

    }
}
