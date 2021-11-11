namespace Analog_Control
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saat1 = new Analog_Control.Saat();
            ((System.ComponentModel.ISupportInitialize)(this.saat1)).BeginInit();
            this.SuspendLayout();
            // 
            // saat1
            // 
            this.saat1.BackColor = System.Drawing.Color.Salmon;
            this.saat1.BackColor2 = System.Drawing.Color.SkyBlue;
            this.saat1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.saat1.BorderWidth = 5F;
            this.saat1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.saat1.HourHandColor = System.Drawing.Color.DimGray;
            this.saat1.HourHandRatio = 3.3F;
            this.saat1.Location = new System.Drawing.Point(211, 39);
            this.saat1.MinuteHandColor = System.Drawing.Color.GhostWhite;
            this.saat1.MinuteHandRatio = 2.6F;
            this.saat1.Name = "saat1";
            this.saat1.Reqemstili = Analog_Control.ReqemStyle.yarireqem;
            this.saat1.SecondHandColor = System.Drawing.Color.Khaki;
            this.saat1.SecondHandRatio = 1.8F;
            this.saat1.Size = new System.Drawing.Size(440, 440);
            this.saat1.StrokeLength = 10F;
            this.saat1.TabIndex = 0;
            this.saat1.Text = "saat1";
            this.saat1.Click += new System.EventHandler(this.saat1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(909, 570);
            this.Controls.Add(this.saat1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.saat1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Saat saat1;
    }
}

