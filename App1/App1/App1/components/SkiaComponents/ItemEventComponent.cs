namespace App1.components.SkiaComponents
{
    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    using Xamarin.Forms;

    public class ItemEventComponent : SKCanvasView
    {
        #region Bindables Properties
        public static readonly BindableProperty DescriptionTitleProperty = BindableProperty.Create(
                                                               "DescriptionTitle",
                                                               typeof(string),
                                                               typeof(ItemEventComponent),
                                                               string.Empty,
                                                               propertyChanged: OnPropertyChanged);
        public static readonly BindableProperty DescriptionDateProperty = BindableProperty.Create(
                                                               "DescriptionDate",
                                                               typeof(string),
                                                               typeof(ItemEventComponent),
                                                               string.Empty,
                                                               propertyChanged: OnPropertyChanged);

        public static readonly BindableProperty IsCreatedByUserProperty = BindableProperty.Create(
                                                      "IsCreatedByUser",
                                                      typeof(bool),
                                                      typeof(ItemEventComponent),
                                                      false,
                                                      propertyChanged: OnPropertyChanged,
                                                      defaultBindingMode: BindingMode.TwoWay);


        #endregion

        #region Constructors

        #endregion

        #region Properties
        public bool IsCreatedByUser
        {
            get { return (bool)GetValue(IsCreatedByUserProperty); }
            set
            {
                SetValue(IsCreatedByUserProperty, value);
            }
        }

        public string DescriptionTitle
        {
            get { return (string)GetValue(DescriptionTitleProperty); }
            set
            {
                SetValue(DescriptionTitleProperty, value);
            }
        }

        public string DescriptionDate
        {
            get { return (string)GetValue(DescriptionDateProperty); }
            set
            {
                SetValue(DescriptionDateProperty, value);
            }
        }

        #endregion



        #region Paint Surfacae
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            #region Config canvas
            var canvas = e.Surface.Canvas;
            int width = e.Info.Width;
            int height = e.Info.Height;

            //Translate to the center and scale to 1229.71px
            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 1229.71f);

            canvas.Translate(-614.855f, -59.31f);
            #endregion


            //Background shape
            var path = new SKPath();
            var rectInf = new SKRect(0, 0, 118.62f, 118.62f);
            path.ArcTo(rectInf, 180, 90, false);
            path.RLineTo(1111.09f, 0);
            var rect2 = new SKRect(1111.09f, 0, 1229.71f, 118.62f);
            path.ArcTo(rect2, 270, 180, false);
            path.RLineTo(-1111.09f, 0);
            path.ArcTo(rectInf, 90, 90, false);
            path.Close();


            canvas.DrawPath(path, new SKPaint { Style = SKPaintStyle.Fill, Color = SKColor.Parse("2e313b") });
            canvas.Save();


            //Border
            var pathCls3 = SKPath.ParseSvgPathData("M1170.41,4a55.31,55.31,0,0,1,0,110.61H59.31A55.31,55.31,0,1,1,59.31,4h1111.1m0-4H59.31A59.3,59.3,0,0,0,0,59.31H0a59.3,59.3,0,0,0,59.31,59.3h1111.1a59.3,59.3,0,0,0,59.3-59.3h0A59.3,59.3,0,0,0,1170.41,0Z");
            var fillColors = new SKColor[17]
                {
                    SKColors.Blue,
                    SKColor.Parse("0005ff"),
                    SKColor.Parse("0015fe"),
                    SKColor.Parse("002ffd"),
                    SKColor.Parse("0053fb"),
                    SKColor.Parse("0081f9"),
                    SKColor.Parse("00b9f7"),
                    SKColor.Parse("00faf4"),
                    SKColor.Parse("00fff4"),
                    SKColor.Parse("00e7f1"),
                    SKColor.Parse("00abeb"),
                    SKColor.Parse("0177e5"),
                    SKColor.Parse("014de0"),
                    SKColor.Parse("012cdd"),
                    SKColor.Parse("0114da"),
                    SKColor.Parse("0106d9"),
                    SKColor.Parse("0101d8")
                };
            SKPaint fillAfter = new SKPaint
            {
                Style = SKPaintStyle.Fill,

            };

            fillAfter.Shader = SKShader.CreateLinearGradient(
               new SKPoint(0, 59.31f),
               new SKPoint(1229.71f, 59.31f),
               fillColors,
               new float[] { 0, 0.05f, 0.11f, 0.18f, 0.25f, 0.33f, 0.41f, 0.49f, 0.49f, 0.52f, 0.6f, 0.67f, 0.75f, 0.82f, 0.88f, 0.95f, 1 },
               SKShaderTileMode.Repeat);

            canvas.DrawPath(pathCls3, fillAfter);

            var borderPath = new SKPath();
            borderPath.MoveTo(21.29f, 104.83f);
            borderPath.RLineTo(1186.51f, 0);
            borderPath.ArcTo(rect2, 50, 40, false);
            borderPath.RLineTo(-1111.09f, 0);
            borderPath.ArcTo(rectInf, 90, 40, false);

            var fillColorRectangle = new SKColor[10]
                  {
                       SKColor.Parse("b0fffa"),
                       SKColor.Parse("00fff4"),
                       SKColor.Parse("00faf3"),
                       SKColor.Parse("00ebf2"),
                       SKColor.Parse("00d2ef"),
                       SKColor.Parse("00b0eb"),
                       SKColor.Parse("0083e6"),
                       SKColor.Parse("014de0"),
                       SKColor.Parse("010ed9"),
                       SKColor.Parse("0101d8")
                  };
            SKPaint fillRectangle = new SKPaint
            {
                Style = SKPaintStyle.Fill,

            };
            fillRectangle.Shader = SKShader.CreateLinearGradient(
                 new SKPoint(0, 159.78f),
                 new SKPoint(1227.62f, 159.78f),
                 fillColorRectangle,
                 new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
                 SKShaderTileMode.Repeat);
            canvas.DrawPath(borderPath, fillRectangle);

            var circleColor = IsCreatedByUser ? SKColors.Lime : SKColors.Aqua;
            canvas.DrawCircle(1170.41f, 59.31f, 59.31f, new SKPaint { Style = SKPaintStyle.Fill, Color = circleColor });
            var pathLocator = SKPath.ParseSvgPathData("M1167.42,96.64c-22-31.91-26.11-35.19-26.11-46.92a29.1,29.1,0,0,1,58.19,0c0,11.73-4.09,15-26.1,46.92a3.64,3.64,0,0,1-6,0Zm3-34.8a12.12,12.12,0,1,0-12.12-12.12A12.12,12.12,0,0,0,1170.41,61.84Z");
            var fillPathLocator = new SKColor[6]
                {
                       SKColor.Parse("424654"),
                       SKColor.Parse("3f4350"),
                       SKColor.Parse("363944"),
                       SKColor.Parse("262830"),
                       SKColor.Parse("101115"),
                       SKColor.Parse("000000")

                };
            SKPaint paintPathLocator = new SKPaint
            {
                Style = SKPaintStyle.Fill,

            };

            paintPathLocator.Shader = SKShader.CreateLinearGradient(
               new SKPoint(1141.31f, 59.42f),
               new SKPoint(1199.5f, 59.42f),
               fillPathLocator,
               new float[] { 0.01f, 0.16f, 0.31f, 0.45f, 0.6f, 0.69f },
               SKShaderTileMode.Repeat);
            canvas.DrawPath(pathLocator, paintPathLocator);

            var poligonPath2 = new SKPath();
            var points2 = new SKPoint[]
            {
                new SKPoint(683.77f, 118.84f),
                new SKPoint(731.5f, 118.84f),
                new SKPoint(760.94f, 0),
                new SKPoint(713.24f, 0 ),
                new SKPoint(683.77f, 118.84f),

            };
            poligonPath2.AddPoly(points2, true);
            var point2Paint = new SKPaint { Style = SKPaintStyle.Fill };
            var point2PaintColors = new SKColor[]
            {
                SKColor.Parse("b7fff4"),
                SKColor.Parse("b4fef3"),
                SKColor.Parse("a9faf2"),
                SKColor.Parse("98f4ef"),
                SKColor.Parse("7febeb"),
                SKColor.Parse("5fe0e6"),
                SKColor.Parse("38d2e0"),
                SKColor.Parse("0ac2d9"),
                SKColor.Parse("01bfd8")
            };
            point2Paint.Shader = SKShader.CreateRadialGradient(
                new SKPoint(468.83f, 97.26f),
                63.86f,
                point2PaintColors,
                new float[] { 0f, 0.18f, 0.33f, 0.47f, 0.6f, 0.73f, 0.86f, 0.98f, 1 },
                SKShaderTileMode.Clamp
            );

            canvas.DrawPath(poligonPath2, point2Paint);

            var poligonPath3 = new SKPath();
            var points3 = new SKPoint[]
            {
                new SKPoint(687.34f, 116.03f),
                new SKPoint(729.3f, 116.03f),
                new SKPoint(757.36f, 2.77f),
                new SKPoint(715.4f, 2.77f),
                new SKPoint(687.34f, 116.03f),

            };
            poligonPath3.AddPoly(points3, true);

            var poli3Paint = new SKPaint { Style = SKPaintStyle.Fill };
            poli3Paint.Shader = SKShader.CreateLinearGradient(
                 new SKPoint(748.68f, -35.58f),
                 new SKPoint(687.73f, 184.34f),
                 fillColorRectangle,
                 new float[] { 0, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
                 SKShaderTileMode.Repeat);

            var shadowColor = new SKColor();
            SKColor.TryParse("80618181", out shadowColor);
            poli3Paint.ImageFilter = SKImageFilter.CreateDropShadow(
                 15, 0, 4, 4, shadowColor
                );
            canvas.DrawPath(poligonPath3, poli3Paint);
            canvas.Save();

            #region Drawer Title

            canvas.Translate(360f, 58.44f);
            var drawerTitle = DescriptionTitle.ToUpper();
            var drawerTitleColor = new SKColor();
            SKColor.TryParse("02e3f9", out drawerTitleColor);
            var drawerTitlePaint = new SKPaint
            {
                Color = drawerTitleColor,
                TextAlign = SKTextAlign.Center,
                Typeface = SKTypeface.FromFamilyName(null, SKFontStyle.Bold)
            };
            float titleWidth = drawerTitlePaint.MeasureText(drawerTitle);
            var calc1 = 51f;
            //var calc1 = 10.12f * drawerTitle.Length * drawerTitlePaint.TextSize / titleWidth;
            drawerTitlePaint.TextSize = calc1;
            SKRect drawerTitleTextBounds = new SKRect();
            drawerTitlePaint.MeasureText(drawerTitle, ref drawerTitleTextBounds);
            canvas.DrawText(drawerTitle, 0, -1 * drawerTitleTextBounds.MidY, drawerTitlePaint);

           
            canvas.Restore();
            #endregion

            #region Description Date

            canvas.Translate(928.97f, 58.44f);
            var descriptionDate = DescriptionDate.ToUpper();
            float dateWidth = drawerTitlePaint.MeasureText(descriptionDate);
            var calcDate = 51;
            drawerTitlePaint.TextSize = calcDate;
            drawerTitlePaint.MeasureText(descriptionDate, ref drawerTitleTextBounds);
            canvas.DrawText(descriptionDate, 0, -1 * drawerTitleTextBounds.MidY, drawerTitlePaint);

            #endregion

        }

        #endregion

        #region Private Methods
        private static void OnPropertyChanged(BindableObject bindable, object oldVal, object newVal)
        {
            var itemEvent = bindable as ItemEventComponent;
            itemEvent?.InvalidateSurface();
        }
         #endregion
    }
}
