using System;
using System.Collections.Generic;
using System.Text;

namespace App1.components.SkiaComponents
{
    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    public class EyeClosedSkiaComponent: SKCanvasView
    {
        SKPaint circleColor = new SKPaint
        {
            Style = SKPaintStyle.Fill,

        };


        SKPaint externalRinColor = new SKPaint
        {
            Style = SKPaintStyle.Fill,

        };
        SKPaint barColor = new SKPaint
        {
            Style = SKPaintStyle.Fill,

        };
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Translate to the center and scale to 200px
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 70.06f);

            canvas.Translate(-35f, -30.2f);
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

            var circle = SKPath.ParseSvgPathData("M34.5,19.15l10,10,0-.53A9.56,9.56,0,0,0,35,19.1Z");

            circleColor.Shader = SKShader.CreateLinearGradient(
               new SKPoint(34.5f, 24.14f),
               new SKPoint(44.57f, 24.14f),
               fillColors,
               new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
               SKShaderTileMode.Repeat);

            canvas.DrawPath(circle, circleColor);

            var externalRin = SKPath.ParseSvgPathData("M35,12.74A15.92,15.92,0,0,1,50.94,28.65a15.63,15.63,0,0,1-1.13,5.82l9.31,9.31A37.75,37.75,0,0,0,70.06,28.65,37.67,37.67,0,0,0,35,4.78,37.27,37.27,0,0,0,22.34,7l6.87,6.87A16,16,0,0,1,35,12.74Z");

            externalRinColor.Shader = SKShader.CreateLinearGradient(
               new SKPoint(22.34f, 24.28f),
               new SKPoint(70.06f, 24.28f),
               fillColors,
               new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
               SKShaderTileMode.Repeat);

            canvas.DrawPath(externalRin, externalRinColor);

            var bar = SKPath.ParseSvgPathData("M3.18,4.06l7.26,7.26,1.45,1.45A37.64,37.64,0,0,0,0,28.65,37.65,37.65,0,0,0,35,52.53a37.19,37.19,0,0,0,14-2.69l1.36,1.36,9.28,9.29,4.06-4L7.24,0ZM20.79,21.65l4.92,4.92a10.28,10.28,0,0,0-.24,2.08A9.56,9.56,0,0,0,35,38.21,10,10,0,0,0,37.09,38L42,42.89a15.66,15.66,0,0,1-7,1.68A15.81,15.81,0,0,1,20.79,21.65Z");

            barColor.Shader = SKShader.CreateLinearGradient(
               new SKPoint(0, 30.25f),
               new SKPoint(63.68f, 30.25f),
               fillColors,
               new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
               SKShaderTileMode.Repeat);

            canvas.DrawPath(bar, barColor);

        }

    }
}
