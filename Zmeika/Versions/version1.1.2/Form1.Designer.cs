namespace Zmeika
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zona = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.butNewGame = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.butMinus = new System.Windows.Forms.ToolStripButton();
            this.tbSpeed = new System.Windows.Forms.ToolStripTextBox();
            this.butPlus = new System.Windows.Forms.ToolStripButton();
            this.butstart1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.zona)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zona
            // 
            this.zona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zona.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zona.Location = new System.Drawing.Point(0, 25);
            this.zona.Name = "zona";
            this.zona.Size = new System.Drawing.Size(484, 336);
            this.zona.TabIndex = 0;
            this.zona.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butNewGame,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.butMinus,
            this.tbSpeed,
            this.butPlus});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(484, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // butNewGame
            // 
            this.butNewGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butNewGame.Image = global::Zmeika.Properties.Resources.media_play_green;
            this.butNewGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butNewGame.Name = "butNewGame";
            this.butNewGame.Size = new System.Drawing.Size(23, 22);
            this.butNewGame.Text = "Start";
            this.butNewGame.Click += new System.EventHandler(this.butstart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(82, 22);
            this.toolStripLabel1.Text = "Change speed";
            // 
            // butMinus
            // 
            this.butMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butMinus.Image = global::Zmeika.Properties.Resources.завантаження;
            this.butMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butMinus.Name = "butMinus";
            this.butMinus.Size = new System.Drawing.Size(23, 22);
            this.butMinus.Text = "Decrease speed";
            this.butMinus.Click += new System.EventHandler(this.butMinus_Click);
            // 
            // tbSpeed
            // 
            this.tbSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.ReadOnly = true;
            this.tbSpeed.Size = new System.Drawing.Size(20, 25);
            this.tbSpeed.Text = "6";
            // 
            // butPlus
            // 
            this.butPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.butPlus.Image = global::Zmeika.Properties.Resources.green_plus_minus_md;
            this.butPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.butPlus.Name = "butPlus";
            this.butPlus.Size = new System.Drawing.Size(23, 22);
            this.butPlus.Text = "Increase speed";
            this.butPlus.Click += new System.EventHandler(this.butPlus_Click);
            // 
            // butstart1
            // 
            this.butstart1.Location = new System.Drawing.Point(430, 1);
            this.butstart1.Name = "butstart1";
            this.butstart1.Size = new System.Drawing.Size(54, 24);
            this.butstart1.TabIndex = 1;
            this.butstart1.TabStop = false;
            this.butstart1.Text = "button1";
            this.butstart1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.zona);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.butstart1);
            this.Name = "Form1";
            this.Text = "Snake version1.1";
            ((System.ComponentModel.ISupportInitialize)(this.zona)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox zona;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton butNewGame;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbSpeed;
        private System.Windows.Forms.ToolStripButton butMinus;
        private System.Windows.Forms.ToolStripButton butPlus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button butstart1;
    }
}

