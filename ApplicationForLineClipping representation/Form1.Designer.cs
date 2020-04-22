namespace ApplicationForLineClipping_representation
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRestrictiveBorder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSutherland = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxField = new System.Windows.Forms.PictureBox();
            this.toolStripButtonClippingWindow = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBeckAlgorithm = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTestSutherland = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTextBeck = new System.Windows.Forms.ToolStripButton();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxField)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Silver;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRestrictiveBorder,
            this.toolStripButtonSutherland,
            this.toolStripButtonClippingWindow,
            this.toolStripButtonBeckAlgorithm,
            this.toolStripButtonTestSutherland,
            this.toolStripButtonTextBeck});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip.Size = new System.Drawing.Size(800, 39);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "Tools";
            this.toolStrip.Resize += new System.EventHandler(this.toolStrip_Resize);
            // 
            // toolStripButtonRestrictiveBorder
            // 
            this.toolStripButtonRestrictiveBorder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRestrictiveBorder.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRestrictiveBorder.Image")));
            this.toolStripButtonRestrictiveBorder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRestrictiveBorder.Name = "toolStripButtonRestrictiveBorder";
            this.toolStripButtonRestrictiveBorder.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonRestrictiveBorder.Text = "Restictive Border";
            this.toolStripButtonRestrictiveBorder.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButtonSutherland
            // 
            this.toolStripButtonSutherland.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSutherland.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSutherland.Image")));
            this.toolStripButtonSutherland.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSutherland.Name = "toolStripButtonSutherland";
            this.toolStripButtonSutherland.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSutherland.Text = "Sutherland";
            this.toolStripButtonSutherland.Click += new System.EventHandler(this.toolStripButtonSutherland_Click);
            // 
            // pictureBoxField
            // 
            this.pictureBoxField.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxField.Location = new System.Drawing.Point(0, 63);
            this.pictureBoxField.Name = "pictureBoxField";
            this.pictureBoxField.Size = new System.Drawing.Size(800, 387);
            this.pictureBoxField.TabIndex = 2;
            this.pictureBoxField.TabStop = false;
            this.pictureBoxField.Click += new System.EventHandler(this.pictureBoxField_Click);
            this.pictureBoxField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxField_MouseDown);
            this.pictureBoxField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxField_MouseUp);
            // 
            // toolStripButtonClippingWindow
            // 
            this.toolStripButtonClippingWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonClippingWindow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClippingWindow.Image")));
            this.toolStripButtonClippingWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClippingWindow.Name = "toolStripButtonClippingWindow";
            this.toolStripButtonClippingWindow.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonClippingWindow.Text = "Clipping Window";
            this.toolStripButtonClippingWindow.Click += new System.EventHandler(this.toolStripButtonClippingWindow_Click);
            // 
            // toolStripButtonBeckAlgorithm
            // 
            this.toolStripButtonBeckAlgorithm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBeckAlgorithm.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBeckAlgorithm.Image")));
            this.toolStripButtonBeckAlgorithm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBeckAlgorithm.Name = "toolStripButtonBeckAlgorithm";
            this.toolStripButtonBeckAlgorithm.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonBeckAlgorithm.Text = "toolStripButton1";
            this.toolStripButtonBeckAlgorithm.Click += new System.EventHandler(this.toolStripButtonBeckAlgorithm_Click_1);
            // 
            // toolStripButtonTestSutherland
            // 
            this.toolStripButtonTestSutherland.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTestSutherland.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTestSutherland.Image")));
            this.toolStripButtonTestSutherland.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTestSutherland.Name = "toolStripButtonTestSutherland";
            this.toolStripButtonTestSutherland.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonTestSutherland.Text = "toolStripButton1";
            this.toolStripButtonTestSutherland.Click += new System.EventHandler(this.toolStripButtonTestSutherland_Click);
            // 
            // toolStripButtonTextBeck
            // 
            this.toolStripButtonTextBeck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTextBeck.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTextBeck.Image")));
            this.toolStripButtonTextBeck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTextBeck.Name = "toolStripButtonTextBeck";
            this.toolStripButtonTextBeck.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonTextBeck.Text = "toolStripButton1";
            this.toolStripButtonTextBeck.Click += new System.EventHandler(this.toolStripButtonTextBeck_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxField);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Line Clipping";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxField;
        private System.Windows.Forms.ToolStripButton toolStripButtonRestrictiveBorder;
        private System.Windows.Forms.ToolStripButton toolStripButtonSutherland;
        private System.Windows.Forms.ToolStripButton toolStripButtonClippingWindow;
        private System.Windows.Forms.ToolStripButton toolStripButtonBeckAlgorithm;
        private System.Windows.Forms.ToolStripButton toolStripButtonTestSutherland;
        private System.Windows.Forms.ToolStripButton toolStripButtonTextBeck;
    }
}

