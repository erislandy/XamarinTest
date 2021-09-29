using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SkiaComponentsView : ContentPage
    {
        SKPaint fill = new SKPaint
        {
            Style = SKPaintStyle.Fill,

        };

        public SkiaComponentsView()
        {
            InitializeComponent();
        }

        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Translate to the center and scale to 200px
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 200f);

            var arrowScroll = new SKPath();

            arrowScroll.MoveTo(-100, 0);
            arrowScroll.RLineTo(31.56f, -30.93f);
            arrowScroll.RLineTo(68.44f, 68.77f);
            arrowScroll.RLineTo(68.44f, -68.77f);
            arrowScroll.RLineTo(31.56f, 30.93f);
            arrowScroll.RLineTo(-100.63f, 100.48f);
            arrowScroll.RLineTo(-100.63f, -100.48f);
            arrowScroll.Close();

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

            fill.Shader = SKShader.CreateLinearGradient(
               new SKPoint(0, 132.04f),
               new SKPoint(0, -30.93f),
               fillColors,
               new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
               SKShaderTileMode.Repeat
               );
            canvas.DrawPath(arrowScroll, fill);

        }
    }
}