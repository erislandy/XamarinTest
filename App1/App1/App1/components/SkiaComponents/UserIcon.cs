
namespace App1.components.SkiaComponents
{
    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    public class UserIcon : SKCanvasView
    {
        SKPaint fillBody = new SKPaint
        {
            Style = SKPaintStyle.Fill,

        };
        SKPaint fillHead = new SKPaint
        {
            Style = SKPaintStyle.Fill,

        };
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e) 
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 100f);
            var userBody = SKPath.ParseSvgPathData("M25.2,44.64H45.52a25.2,25.2,0,0,1,25.2,25.2V80a0,0,0,0,1,0,0H0a0,0,0,0,1,0,0V69.84A25.2,25.2,0,0,1,25.2,44.64Z");
            var rect = userBody.GetRect();


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

            fillHead.Shader = SKShader.CreateLinearGradient(
               new SKPoint(13.4f, 20.89f),
               new SKPoint(55.18f, 20.89f),
               fillColors,
               new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
               SKShaderTileMode.Repeat);

            fillBody.Shader = SKShader.CreateLinearGradient(
              new SKPoint(0, 20.89f),
              new SKPoint(71, 20.89f),
              fillColors,
              new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
              SKShaderTileMode.Repeat);
            canvas.Translate(-34.29f, -41.78f);
            canvas.DrawCircle(34.29f, 20.89f, 20.89f, fillHead);

            canvas.DrawPath(userBody, fillBody);
            canvas.Save();

        }
    }
}
