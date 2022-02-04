using Prism.Commands;
using Prism.Navigation;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.components.SkiaComponents
{
    public class DrawerRightSkiaControl : SKCanvasView
    {
        #region Constructors
        public DrawerRightSkiaControl()
        {
            var tap = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1,
                Command = new DelegateCommand(() =>
                {
                    TapCommand?.Execute(new NavigationParameters {
                            { "handle", Handle },
                            {"dataType", DataType }
                        });
                })
            };
            this.GestureRecognizers.Add(tap);
        }
        #endregion

        #region Bindable properties
        public static readonly BindableProperty DataTypeProperty = BindableProperty.Create(
                                                               "DataType",
                                                               typeof(FilterType),
                                                               typeof(DrawerRightSkiaControl),
                                                               FilterType.NULL,
                                                               propertyChanged: DataTypeMethod,
                                                               defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty AddRemoveSelectionCommandProperty = BindableProperty.Create(
                                                          "AddRemoveSelectionCommand",
                                                          typeof(ICommand),
                                                          typeof(DrawerRightSkiaControl),
                                                          null);

        public static readonly BindableProperty TapCommandProperty = BindableProperty.Create(
                                                                 "TapCommand",
                                                                 typeof(ICommand),
                                                                 typeof(DrawerRightSkiaControl),
                                                                 null);

        public static readonly BindableProperty DescriptionButtonProperty = BindableProperty.Create(
                                                           "DescriptionButton",
                                                           typeof(string),
                                                           typeof(DrawerRightSkiaControl),
                                                           string.Empty,
                                                           propertyChanged: OnPropertyChanged);

        public static readonly BindableProperty HandleProperty = BindableProperty.Create(
                                                               "Handle",
                                                               typeof(string),
                                                               typeof(DrawerRightSkiaControl),
                                                               null,
                                                                propertyChanged: OnHandleChanged);

        public static readonly BindableProperty DescriptionTitleProperty = BindableProperty.Create(
                                                               "DescriptionTitle",
                                                               typeof(string),
                                                               typeof(DrawerRightSkiaControl),
                                                               string.Empty,
                                                               propertyChanged: OnPropertyChanged);

        public static readonly BindableProperty DescriptionValueProperty = BindableProperty.Create(
                                                               "DescriptionValue",
                                                               typeof(string),
                                                               typeof(DrawerRightSkiaControl),
                                                               string.Empty,
                                                               propertyChanged: OnPropertyChanged);
        public static readonly BindableProperty DrawerStateProperty = BindableProperty.Create(
                                                         "DrawerState",
                                                         typeof(string),
                                                         typeof(DrawerRightSkiaControl),
                                                         "Normal",
                                                        propertyChanged: OnDrawerStateChanged,
                                                        defaultBindingMode: BindingMode.TwoWay);




        #endregion

        #region Properties
        public ICommand AddRemoveSelectionCommand
        {
            get { return (ICommand)GetValue(AddRemoveSelectionCommandProperty); }
            set { SetValue(AddRemoveSelectionCommandProperty, value); }
        }
        public ICommand TapCommand
        {
            get { return (ICommand)GetValue(TapCommandProperty); }
            set { SetValue(TapCommandProperty, value); }
        }
        public FilterType DataType
        {
            get { return (FilterType)GetValue(DataTypeProperty); }
            set
            {
                SetValue(DataTypeProperty, value);
            }
        }
        public string DescriptionButton
        {
            get { return (string)GetValue(DescriptionButtonProperty); }
            set
            {

                SetValue(DescriptionButtonProperty, value);
            }
        }
        public string Handle
        {
            get { return (string)GetValue(HandleProperty); }
            set { SetValue(HandleProperty, value); }
        }

        public string DescriptionValue
        {
            get { return (string)GetValue(DescriptionValueProperty); }
            set { SetValue(DescriptionValueProperty, value); }
        }
        public string DescriptionTitle
        {
            get { return (string)GetValue(DescriptionTitleProperty); }
            set { SetValue(DescriptionTitleProperty, value); }
        }
        public string DrawerState
        {
            get { return (string)GetValue(DrawerStateProperty); }
            set
            {
                SetValue(DrawerStateProperty, value);
            }
        }

        #endregion

        #region Paint Attributes

        SKPaint fillButtonCircle = new SKPaint
        {
            Style = SKPaintStyle.Fill

        };
        SKPaint fillLeftSemiCircle = new SKPaint
        {
            Style = SKPaintStyle.Fill,

        };

        #endregion

        #region States

        public Dictionary<string, DrawerVisualState> DrawerVisualStates => new Dictionary<string, DrawerVisualState>
        {
            {"Normal", new DrawerVisualState
                {
                    TextIconColor = SKColor.Parse("02e3f9"),
                    HorizontalBarColors = GlobalConst.HorizontalBarNormalColors,
                    HorizontalBarPointColors = GlobalConst.HorizontalBarNormalPointColors,
                    FillSemiCircleColors = GlobalConst.FillSemiCircleNormalColors
                }
            },
            {"Selected", new DrawerVisualState
                {
                    TextIconColor = SKColors.Lime,
                    HorizontalBarColors = GlobalConst.HorizontalBarSelectedColors,
                    HorizontalBarPointColors = GlobalConst.HorizontalBarSelectedPointColors,
                    FillSemiCircleColors = GlobalConst.FillSemiCircleSelectedColors
                }
            },
            {"Marked", new DrawerVisualState
                {
                    TextIconColor = SKColors.Lime,
                    HorizontalBarColors = GlobalConst.HorizontalBarNormalColors,
                    HorizontalBarPointColors = GlobalConst.HorizontalBarNormalPointColors,
                    FillSemiCircleColors = GlobalConst.FillSemiCircleSelectedColors
                }
            },

        };
        #endregion
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            try
            {
                #region Canvas Configuration
                var canvas = e.Surface.Canvas;
                int width = e.Info.Width;
                int height = e.Info.Height;

                //Translate to the center and scale to 200px
                canvas.Translate(width / 2, height / 2);
                canvas.Scale(width / 200f);
                if (DrawerState == "EventsResultsEmpty")
                {
                    return;
                }

                #endregion

                #region Rectangle Background

                canvas.Translate(-100f, -19.09f);

                var fondoBarPaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill
                };

                var fondoBarPath = new SKPath();
                fondoBarPath.RLineTo(166.31f, 0);

                fondoBarPath.RLineTo(5.7f, 38.3f);
                fondoBarPath.RLineTo(-166.31f, 0);
                fondoBarPath.Close();

                var fillColors = new SKColor[5];
                SKColor.TryParse("2e313b", out fillColors[0]);
                SKColor.TryParse("2b2e37", out fillColors[1]);
                SKColor.TryParse("22242b", out fillColors[2]);
                SKColor.TryParse("121418", out fillColors[3]);
                SKColor.TryParse("000000", out fillColors[4]);

                fondoBarPaint.Shader = SKShader.CreateLinearGradient(
                    new SKPoint(114.62f, 0f),
                    new SKPoint(114.62f, 74.53f),
                    fillColors,
                    new float[] { 0.19f, 0.32f, 0.45f, 0.57f, 0.68f },
                SKShaderTileMode.Repeat
                    );

                canvas.DrawPath(fondoBarPath, fondoBarPaint);

                #endregion

                #region Alo Horizontal

                canvas.Translate(5.69f, 38.18f);

                var horizontalBarColors = DrawerVisualStates[DrawerState].HorizontalBarColors;
                var horizontalBarPointColors = DrawerVisualStates[DrawerState].HorizontalBarPointColors;
                fondoBarPaint.Shader = SKShader.CreateLinearGradient(
                    new SKPoint(113f, 34.34f),
                    new SKPoint(113f, -17.86f),
                    horizontalBarColors,
                    horizontalBarPointColors,
                SKShaderTileMode.Repeat
                    );

                var horizontalBarPath = new SKPath();
                horizontalBarPath.RLineTo(149.7f, 0);
                horizontalBarPath.RLineTo(3.06f, 16.07f);
                horizontalBarPath.RLineTo(-149.7f, 0);
                horizontalBarPath.Close();

                canvas.DrawPath(horizontalBarPath, fondoBarPaint);


                #endregion

                #region Drawer Description

                canvas.Translate(76.38f, 8.035f);
                var drawerDescription = DescriptionValue;
                var drawerDescriptionPaint = new SKPaint
                {
                    Color = SKColors.Black,
                    TextAlign = SKTextAlign.Center,
                    Typeface = SKTypeface.FromFamilyName(null, SKFontStyle.Bold)
                };
                float descriptionWidth = drawerDescriptionPaint.MeasureText(drawerDescription);
                var calc2 = 16.22f;
                //var calc2 = 9.11f * drawerDescription.Length * drawerDescriptionPaint.TextSize / descriptionWidth;
                drawerDescriptionPaint.TextSize = calc2;
                SKRect drawerDescriptionTextBounds = new SKRect();
                drawerDescriptionPaint.MeasureText(drawerDescription, ref drawerDescriptionTextBounds);
                canvas.DrawText(drawerDescription, 0, -1 * drawerDescriptionTextBounds.MidY, drawerDescriptionPaint);
                //TODO remover
                //canvas.Translate(17.93f, -27.94f);

                #endregion


                #region Circle Button
                canvas.Translate(87.08f, -27.94f);
                //canvas.Translate(69.6f, 0);
                fillButtonCircle.Shader = SKShader.CreateLinearGradient(
                new SKPoint(-26.76f, -20.23f),
                new SKPoint(45.25f, 34.07f),
                fillColors,
                new float[] { 0.19f, 0.32f, 0.45f, 0.57f, 0.68f },
                SKShaderTileMode.Repeat
                );
                canvas.DrawCircle(0, 0, 30.4f, fillButtonCircle);

                #endregion

                #region Semi Circle Left
                canvas.Translate(-1, 0);

                var semiCircleLeft = new SKPath();
                semiCircleLeft.MoveTo(0, 21.23f);
                semiCircleLeft.RLineTo(0, 2.12f);
                SKRect rectExterior = new SKRect(-23.35f, -23.35f, 23.35f, 23.35f);
                semiCircleLeft.ArcTo(rectExterior, 90, 180, false);
                semiCircleLeft.RLineTo(0, 2.12f);
                SKRect rectInterior = new SKRect(-21.23f, -21.23f, 21.23f, 21.23f);
                semiCircleLeft.ArcTo(rectInterior, -90, -180, false);
                semiCircleLeft.Close();
                var fillSemiCircleColors = DrawerVisualStates[DrawerState].FillSemiCircleColors;

                fillLeftSemiCircle.Shader = SKShader.CreateLinearGradient(
                    new SKPoint(24.25f, 0),
                    new SKPoint(-24.31f, 0),
                    fillSemiCircleColors,
                    new float[] { 0, 1 },
                    SKShaderTileMode.Repeat
                    );
                canvas.DrawPath(semiCircleLeft, fillLeftSemiCircle);

                #endregion

                #region Semi Circle Right
                canvas.Translate(2, 0);
                var semiCircleRight = new SKPath();
                semiCircleRight.MoveTo(0, 21.23f);
                semiCircleRight.RLineTo(0, 2.12f);
                semiCircleRight.ArcTo(rectExterior, 90, -180, false);
                semiCircleRight.RLineTo(0, 2.12f);
                semiCircleRight.ArcTo(rectInterior, -90, 180, false);
                semiCircleLeft.Close();

                fillLeftSemiCircle.Shader = SKShader.CreateLinearGradient(
                    new SKPoint(0, 0),
                    new SKPoint(-48.12f, 0),
                    fillSemiCircleColors,
                    new float[] { 0, 1 },
                    SKShaderTileMode.Repeat
                    );
                canvas.DrawPath(semiCircleRight, fillLeftSemiCircle);

                canvas.Translate(-1f, 0);

                #endregion

                #region Icon Description

                var iconDescription = DescriptionButton;
                var iconColor = DrawerVisualStates[DrawerState].TextIconColor;
                var iconPaint = new SKPaint
                {
                    Color = iconColor,
                    TextAlign = SKTextAlign.Center,
                    Typeface = SKTypeface.FromFamilyName(null, SKFontStyle.Bold)
                };
                float textWidth = iconPaint.MeasureText(iconDescription);
                var calc = 17f * iconDescription.Length * iconPaint.TextSize / textWidth;
                iconPaint.TextSize = calc;
                SKRect iconTextBounds = new SKRect();
                iconPaint.MeasureText(iconDescription, ref iconTextBounds);
                canvas.DrawText(iconDescription, 0, -1 * iconTextBounds.MidY, iconPaint);

                #endregion

                #region Drawer Title

                canvas.Translate(-83.16f, 0);
                var drawerTitle = DescriptionTitle;
                var drawerTitleColor = new SKColor();
                SKColor.TryParse("02e3f9", out drawerTitleColor);
                var drawerTitlePaint = new SKPaint
                {
                    Color = drawerTitleColor,
                    TextAlign = SKTextAlign.Center,
                    Typeface = SKTypeface.FromFamilyName(null, SKFontStyle.Bold)
                };
                float titleWidth = drawerTitlePaint.MeasureText(drawerTitle);
                var calc1 = 18.9588f;
                //var calc1 = 10.12f * drawerTitle.Length * drawerTitlePaint.TextSize / titleWidth;
                drawerTitlePaint.TextSize = calc1;
                SKRect drawerTitleTextBounds = new SKRect();
                drawerTitlePaint.MeasureText(drawerTitle, ref drawerTitleTextBounds);
                canvas.DrawText(drawerTitle, 0, -1 * drawerTitleTextBounds.MidY, drawerTitlePaint);

                #endregion

                #region Vertical Bar
                //canvas.Translate(-70.35f, -20.64f);
                canvas.Translate(-77.51f, -20.14f);
                var verticalBarColors = new SKColor[10];
                SKColor.TryParse("affff9", out verticalBarColors[0]);
                SKColor.TryParse("00fff3", out verticalBarColors[1]);
                SKColor.TryParse("00faf2", out verticalBarColors[2]);
                SKColor.TryParse("00ebf1", out verticalBarColors[3]);
                SKColor.TryParse("00d2ee", out verticalBarColors[4]);
                SKColor.TryParse("00b0ea", out verticalBarColors[5]);
                SKColor.TryParse("0083e5", out verticalBarColors[6]);
                SKColor.TryParse("014ddf", out verticalBarColors[7]);
                SKColor.TryParse("010ed8", out verticalBarColors[8]);
                SKColor.TryParse("0101d7", out verticalBarColors[9]);

                fondoBarPaint.Shader = SKShader.CreateLinearGradient(
                    new SKPoint(167.07f, -12.06f),
                    new SKPoint(162.03f, 64.04f),
                    verticalBarColors,
                    new float[10] { 0f, 0.1f, 0.19f, 0.3f, 0.42f, 0.55f, 0.69f, 0.83f, 0.97f, 1 },
                SKShaderTileMode.Repeat
                    );

                var verticalBarPath = new SKPath();
                verticalBarPath.RLineTo(11.9f, 0);
                verticalBarPath.RLineTo(7.15f, 41.28f);
                verticalBarPath.RLineTo(-11.9f, 0);
                verticalBarPath.Close();

                canvas.DrawPath(verticalBarPath, fondoBarPaint);

                #endregion
            }
            catch (Exception ex)
            {

                throw;
            }


        }

        #region Methods
        static void DataTypeMethod(BindableObject bindable, object oldValue, object newValue)
        {

            var type = (FilterType)newValue;
            (bindable as DrawerRightSkiaControl).DataType = type;
        }
        private static void OnPropertyChanged(BindableObject bindable, object oldVal, object newVal)
        {
            var bar = bindable as DrawerRightSkiaControl;
            bar?.InvalidateSurface();
        }
        static void OnHandleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var handle = newValue as string;
            (bindable as DrawerRightSkiaControl).IsVisible = handle == "" ? false : true;

        }
        private static void OnDrawerStateChanged(BindableObject bindable, object oldVal, object newVal)
        {
            var newValue = newVal as string;
            var bar = bindable as DrawerRightSkiaControl;
            if (newValue == "EventsResultsEmpty")
            {
                bar.Opacity = 0;
            }
            else
            {
                bar.Opacity = 1;
                bar?.InvalidateSurface();
            }

        }

        #endregion

    }

}
