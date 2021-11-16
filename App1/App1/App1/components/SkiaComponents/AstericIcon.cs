

namespace App1.components.SkiaComponents
{
    using SkiaSharp;
    using SkiaSharp.Views.Forms;

    public class AstericIcon : SKCanvasView
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

            //Translate to the center and scale to 200px
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 67f);
            var afterBody = SKPath.ParseSvgPathData("M23.47,36,0,29.48,4.68,15.89l23,9.42L25.84,0H41.25L39.38,25.82l22.31-9.21,4.68,13.74L42.62,36.82,58.38,55.9,45.93,64.39,32.75,43.23,19.51,63.67,7.05,55.54Z");
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
               new SKPoint(0, 32.2f),
               new SKPoint(66.37f, 32.2f),
               fillColors,
               new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
               SKShaderTileMode.Repeat);

            canvas.Translate(-33, -33);

            canvas.DrawPath(afterBody, fillAfter);
        }


    }
}
