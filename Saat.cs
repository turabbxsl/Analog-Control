using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analog_Control
{
    public partial class Saat : Control,ISupportInitialize
    {
        public Saat()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new Size(200, 200);
            BackColor = Color.Salmon;
            BackColor2 = Color.Silver;
            timer = new Timer(components);
            timer.Interval = 1000;
            timer.Tick += (s, e) => {  if (!DesignMode) Invalidate(); };  
            {

            }
            if (!DesignMode)
            {
                timer.Start();
            }
           
        }

        #region Fields
        private bool _initializing = false;
        private Color _backcolor2;
        private Color _bordercolor;
        private ClockStyle _clockstyle = ClockStyle.Dairevi;
        private LinearGradientMode _gradientmode = LinearGradientMode.BackwardDiagonal;
        private float _borderwidth = 6f;
        private float _strokelength = 10;
        private Timer timer = null;
        private ReqemStyle _reqemstyle = ReqemStyle.Reqem;

        private Color _hourcolor = Color.DimGray;
        private float _hourWidth = 3.3f;

        private Color _mincolor = Color.GhostWhite;
        private float _minWidth = 2.6f;

        private Color _seccolor = Color.PaleVioletRed;
        private float _secWidth = 1.8f;




        #endregion

        #region Properties
        [DefaultValue(typeof(Color),"Empty")]
        public Color BackColor2 {
            get
            {
                return _backcolor2;
            }
            set
            {
                
                _backcolor2 = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(ClockStyle),"Dairevi")]
        public ClockStyle Style {
            get
            {
                return _clockstyle;
            }
            set
            {
                _clockstyle = value;
                Invalidate();
            }
        }
        public ReqemStyle Reqemstili {
            get
            {
                return _reqemstyle;
            }
            set
            {
                _reqemstyle = value;
                Invalidate();
            }
        }

        [DefaultValue(typeof(LinearGradientMode),"Horizontal")]
        public LinearGradientMode GradientMode {
            get
            {
                return _gradientmode;
            }
            set
            {
                _gradientmode = value;
                Invalidate();
            }
        }

        [Browsable(false)]
        public PointF CenterPoint => new PointF(ClientRectangle.Width / 2f, ClientRectangle.Height / 2f);

        [DefaultValue(6)]
        public float BorderWidth {
            get
            {
                return _borderwidth;
            }
            set
            {
                _borderwidth = value;
                OnBorderWidthChanged(EventArgs.Empty);
                Invalidate();
            }
        }
        public Color BorderColor {
            get
            {
                return _bordercolor;
            }
            set
            {
                _bordercolor = value;
                Invalidate();
            }
        }

        [DefaultValue(10)]
        public float StrokeLength {
            get
            {
                return _strokelength;
            }
            set
            {
                _strokelength = value;
                Invalidate();
            }
        }
        public Color HourHandColor {
            get
            {
                return _hourcolor;
            }
            set
            {
                _hourcolor = value;
                Invalidate();
            }
        }
        public float HourHandRatio {
            get
            {
                return _hourWidth;
            }
            set
            {
                _hourWidth = value;
                Invalidate();
            }
        }
        public Color MinuteHandColor
        {
            get
            {
                return _mincolor;
            }
            set
            {
                _mincolor = value;
                Invalidate();
            }
        }
        public float MinuteHandRatio
        {
            get
            {
                return _minWidth;
            }
            set
            {
                _minWidth = value;
                Invalidate();
            }
        }
        public Color SecondHandColor
        {
            get
            {
                return _seccolor;
            }
            set
            {
                _seccolor = value;
                Invalidate();
            }
        }
        public float SecondHandRatio
        {
            get
            {
                return _secWidth;
            }
            set
            {
                _secWidth = value;
                Invalidate();
            }
        }
       


        #endregion
        protected override void OnPaintBackground(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            using (Brush brush = _backcolor2 != Color.Empty ? (Brush)new LinearGradientBrush(ClientRectangle,BackColor,BackColor2,GradientMode) : new SolidBrush(BackColor))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillRectangle(new SolidBrush(Parent.BackColor), ClientRectangle);
                if (_clockstyle == ClockStyle.Kvadrat)
                {
                    g.FillRectangle(brush, ClientRectangle);
                    Region = new Region(ClientRectangle);
                }
                else
                {
                    using (GraphicsPath path = new GraphicsPath())
                    {
                        path.AddEllipse(ClientRectangle);
                        g.FillPath(brush, path);
                        this.Region = new Region(path);
                    }
                }
                Region region = new Region();
            }
            



        }
        protected override void OnPaint(PaintEventArgs pe)
        {

            Graphics g = pe.Graphics;
            Rectangle rect = ClientRectangle;
            rect.Inflate(-1,-1);



            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen penborder = new Pen(BorderColor, BorderWidth))
            using (Pen penSQuarter = new Pen(BorderColor,5))
            using (Pen penSThicker = new Pen(BorderColor,2.9f))
            using (Pen penSThin = new Pen(BorderColor,1.3f))
            {
                penSQuarter.DashCap = DashCap.Triangle;
                penborder.Alignment = PenAlignment.Inset;
                if (_clockstyle == ClockStyle.Dairevi)
                {
                    g.DrawEllipse(penborder, rect);

                    for (int i = 0; i < 60; i++)
                    {
                        Matrix matrix = new Matrix();
                        matrix.RotateAt(i * 6, CenterPoint);
                        g.Transform = matrix;
                        g.DrawLine(i * 6 % 90 == 0 ? penSQuarter : ((i * 6) % 30 == 0) ? penSThicker : penSThin, CenterPoint.X, Padding.Top + BorderWidth, CenterPoint.X, Padding.Top + BorderWidth + StrokeLength);
                    }



                    using (Pen penHour = new Pen(_hourcolor, _hourWidth))
                    using (Pen penMin = new Pen(_mincolor, _minWidth))
                    using (Pen penSec = new Pen(_seccolor, _secWidth))
                    using (Matrix mHour = new Matrix())
                    using (Matrix mMin = new Matrix())
                    using (Matrix mSec = new Matrix())
                    {
                        DateTime now = DateTime.Now;
                        float radius = ClientRectangle.Width / 2f;

                        mHour.RotateAt((now.Hour + (now.Minute / 60f)) * 30, CenterPoint);
                        g.Transform = mHour;
                        g.DrawLine(penHour, CenterPoint.X, CenterPoint.Y + 8, CenterPoint.X, CenterPoint.Y - (radius * .4f));

                        mMin.RotateAt((now.Minute + (now.Second / 60f)) * 6, CenterPoint);
                        g.Transform = mMin;
                        g.DrawLine(penMin, CenterPoint.X, CenterPoint.Y + 10, CenterPoint.X, CenterPoint.Y - (radius * .6f));

                        mSec.RotateAt(now.Second * 6, CenterPoint);
                        g.Transform = mSec;
                        g.DrawLine(penSec, CenterPoint.X, CenterPoint.Y + 15, CenterPoint.X, CenterPoint.Y - (radius * .8f));

                        g.ResetTransform();
                        RectangleF rectcenter = new RectangleF((rect.Width - 10) / 2f, (rect.Height - 10) / 2f, 10, 10);
                        g.FillEllipse(new SolidBrush(BorderColor), rectcenter);



                    }
                    g.DrawString(DateTime.Now.DayOfWeek.ToString().ToUpper(), new Font("Arial", 20, FontStyle.Bold), Brushes.Turquoise, ClientRectangle.Width / 3, ClientRectangle.Height / 1.5f);
                    //g.DrawString(DateTime.DaysInMonth(DateTime.Now).ToString(), new Font("Arial", 20, FontStyle.Bold), Brushes.Turquoise, ClientRectangle.Width / 3.5f, ClientRectangle.Height / 1.1f);

                    int angle = 0;

                    for (int i = 0; i < 12; i++)
                    {

                       
                        Matrix matrix = new Matrix();
                        matrix.RotateAt(angle, CenterPoint);
                        g.Transform = matrix;

                        if (_reqemstyle == ReqemStyle.Reqem || (_reqemstyle == ReqemStyle.yarireqem && i % 3 == 0))
                            g.DrawString(i.ToString(), new Font("Arial",17,FontStyle.Regular), Brushes.Black, CenterPoint.X - 5, Padding.Top + BorderWidth + StrokeLength + 5, StringFormat.GenericTypographic);

                        angle += 30;
                    }


                }
                else
                {
                    g.DrawRectangle(penborder, rect);
                }
            }
            base.OnPaint(pe);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            if (Width > Height)
                Width = Height;

            else
                Height = Width;
            



            if (!_initializing)
            {
                Invalidate();
            }
            base.OnSizeChanged(e);
        }

        protected override void OnPaddingChanged(EventArgs e)
        {

            

            if (Padding.All == -1)
            {
               int padding = Math.Max(Math.Max(Math.Max(Padding.Top, Padding.Bottom), Padding.Left), Padding.Right);

                Padding = new Padding(padding);
            }

            Invalidate();
                


            base.OnPaddingChanged(e);
        }

        public void BeginInit()
        {
            _initializing = true;
        }

        public void EndInit()
        {
            _initializing = false;
        }
        protected virtual void OnBorderWidthChanged(EventArgs e)
        {
            BorderWitdhChanged?.Invoke(this, e);

        }

        public event EventHandler BorderWitdhChanged;

    }
    public enum ClockStyle {Dairevi,Kvadrat}
    public enum ReqemStyle {Reqem,yarireqem,Rum}
}
