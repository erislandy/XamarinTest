using System;
using System.Collections.Generic;
using System.Text;

namespace App1.components.SkiaComponents
{
    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    public class PhoneSkiaComponent: SKCanvasView
    {
        SKPaint fillAfter = new SKPaint
        {
            Style = SKPaintStyle.Fill,

        };
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Translate to the center and scale to 81.44f
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 81.44f);
            var phoneBody = SKPath.ParseSvgPathData("M78.82,58.64c-.22-.18-16.38-11.83-20.82-11-2.11.37-3.32,1.82-5.75,4.71-.39.47-1.33,1.59-2.06,2.38a34.29,34.29,0,0,1-4.49-1.82A37.26,37.26,0,0,1,28.54,35.76a34.29,34.29,0,0,1-1.82-4.49c.8-.73,1.92-1.67,2.39-2.07,2.88-2.42,4.33-3.63,4.7-5.75.77-4.4-10.87-20.67-11-20.82A6.24,6.24,0,0,0,18.19,0C13.47,0,0,17.48,0,20.42,0,20.59.25,38,21.69,59.78,43.47,81.2,60.86,81.44,61,81.44,64,81.44,81.44,68,81.44,63.25a6.15,6.15,0,0,0-2.62-4.61Z");
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

            fillAfter.Shader = SKShader.CreateLinearGradient(
               new SKPoint(0f, 40.72f),
               new SKPoint(81.44f, 40.72f),
               fillColors,
               new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
               SKShaderTileMode.Repeat);
            canvas.Translate(-40.7f, -40.7f);
            canvas.DrawPath(phoneBody, fillAfter);

        }
    }
}
