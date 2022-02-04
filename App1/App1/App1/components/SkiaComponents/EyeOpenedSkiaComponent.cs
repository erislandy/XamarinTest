using System;
using System.Collections.Generic;
using System.Text;

namespace App1.components.SkiaComponents
{
    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    public class EyeOpenedSkiaComponent: SKCanvasView
    {
        SKPaint circleColor = new SKPaint
        {
            Style = SKPaintStyle.Fill,

        };


        SKPaint externalRinColor = new SKPaint
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
            canvas.Scale(width / 68.81f);

            canvas.Translate(-34.4f, -23.5f);
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

            var circle = SKPath.ParseSvgPathData("M34.41,14.08a9.38,9.38,0,1,0,9.38,9.38A9.39,9.39,0,0,0,34.41,14.08Z");

            circleColor.Shader = SKShader.CreateLinearGradient(
               new SKPoint(25.02f, 23.46f),
               new SKPoint(43.79f, 23.46f),
               fillColors,
               new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
               SKShaderTileMode.Repeat);

            canvas.DrawPath(circle, circleColor);

            var externalRin = SKPath.ParseSvgPathData("M34.41,0A37,37,0,0,0,0,23.46a37,37,0,0,0,68.81,0A37,37,0,0,0,34.41,0Zm0,39.1A15.64,15.64,0,1,1,50,23.46,15.64,15.64,0,0,1,34.41,39.1Z");

            externalRinColor.Shader = SKShader.CreateLinearGradient(
               new SKPoint(0f, 23.46f),
               new SKPoint(68.81f, 23.46f),
               fillColors,
               new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
               SKShaderTileMode.Repeat);

            canvas.DrawPath(externalRin, externalRinColor);

        }


    }
}
