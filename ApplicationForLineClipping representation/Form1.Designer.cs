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
            this.тестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестСазерлендаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partlyVisibleLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundPartlyVisibleLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullyInvisibleLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullyVisibleLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beckTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRestrictiveBorder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSutherland = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClippingWindow = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBeckAlgorithm = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxField = new System.Windows.Forms.PictureBox();
            this.randomPartlyVisibleLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundPartlyVisibleLinesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fullyVisibleLinesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fullyInvisibleLinesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxField)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьToolStripMenuItem,
            this.тестыToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(984, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.очиститьToolStripMenuItem.Text = "Clear";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // тестыToolStripMenuItem
            // 
            this.тестыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тестСазерлендаToolStripMenuItem,
            this.beckTestToolStripMenuItem});
            this.тестыToolStripMenuItem.Name = "тестыToolStripMenuItem";
            this.тестыToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.тестыToolStripMenuItem.Text = "Tests";
            // 
            // тестСазерлендаToolStripMenuItem
            // 
            this.тестСазерлендаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.partlyVisibleLinesToolStripMenuItem,
            this.roundPartlyVisibleLinesToolStripMenuItem,
            this.fullyInvisibleLinesToolStripMenuItem,
            this.fullyVisibleLinesToolStripMenuItem});
            this.тестСазерлендаToolStripMenuItem.Name = "тестСазерлендаToolStripMenuItem";
            this.тестСазерлендаToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.тестСазерлендаToolStripMenuItem.Text = "Sutherland test";
            // 
            // partlyVisibleLinesToolStripMenuItem
            // 
            this.partlyVisibleLinesToolStripMenuItem.Name = "partlyVisibleLinesToolStripMenuItem";
            this.partlyVisibleLinesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.partlyVisibleLinesToolStripMenuItem.Text = "Random partly visible lines";
            this.partlyVisibleLinesToolStripMenuItem.Click += new System.EventHandler(this.partlyVisibleLinesToolStripMenuItem_Click);
            // 
            // roundPartlyVisibleLinesToolStripMenuItem
            // 
            this.roundPartlyVisibleLinesToolStripMenuItem.Name = "roundPartlyVisibleLinesToolStripMenuItem";
            this.roundPartlyVisibleLinesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.roundPartlyVisibleLinesToolStripMenuItem.Text = "Round partly visible lines";
            this.roundPartlyVisibleLinesToolStripMenuItem.Click += new System.EventHandler(this.roundPartlyVisibleLinesToolStripMenuItem_Click);
            // 
            // fullyInvisibleLinesToolStripMenuItem
            // 
            this.fullyInvisibleLinesToolStripMenuItem.Name = "fullyInvisibleLinesToolStripMenuItem";
            this.fullyInvisibleLinesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.fullyInvisibleLinesToolStripMenuItem.Text = "Fully invisible lines";
            this.fullyInvisibleLinesToolStripMenuItem.Click += new System.EventHandler(this.fullyInvisibleLinesToolStripMenuItem_Click);
            // 
            // fullyVisibleLinesToolStripMenuItem
            // 
            this.fullyVisibleLinesToolStripMenuItem.Name = "fullyVisibleLinesToolStripMenuItem";
            this.fullyVisibleLinesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.fullyVisibleLinesToolStripMenuItem.Text = "Fully visible lines";
            this.fullyVisibleLinesToolStripMenuItem.Click += new System.EventHandler(this.fullyVisibleLinesToolStripMenuItem_Click);
            // 
            // beckTestToolStripMenuItem
            // 
            this.beckTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomPartlyVisibleLinesToolStripMenuItem,
            this.roundPartlyVisibleLinesToolStripMenuItem1,
            this.fullyVisibleLinesToolStripMenuItem1,
            this.fullyInvisibleLinesToolStripMenuItem1});
            this.beckTestToolStripMenuItem.Name = "beckTestToolStripMenuItem";
            this.beckTestToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beckTestToolStripMenuItem.Text = "Beck test";
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
            this.toolStripButtonBeckAlgorithm});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip.Size = new System.Drawing.Size(984, 39);
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
            // pictureBoxField
            // 
            this.pictureBoxField.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxField.Location = new System.Drawing.Point(0, 63);
            this.pictureBoxField.Name = "pictureBoxField";
            this.pictureBoxField.Size = new System.Drawing.Size(984, 898);
            this.pictureBoxField.TabIndex = 2;
            this.pictureBoxField.TabStop = false;
            this.pictureBoxField.Click += new System.EventHandler(this.pictureBoxField_Click);
            this.pictureBoxField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxField_MouseDown);
            this.pictureBoxField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxField_MouseUp);
            // 
            // randomPartlyVisibleLinesToolStripMenuItem
            // 
            this.randomPartlyVisibleLinesToolStripMenuItem.Name = "randomPartlyVisibleLinesToolStripMenuItem";
            this.randomPartlyVisibleLinesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.randomPartlyVisibleLinesToolStripMenuItem.Text = "Random partly visible lines";
            this.randomPartlyVisibleLinesToolStripMenuItem.Click += new System.EventHandler(this.randomPartlyVisibleLinesToolStripMenuItem_Click);
            // 
            // roundPartlyVisibleLinesToolStripMenuItem1
            // 
            this.roundPartlyVisibleLinesToolStripMenuItem1.Name = "roundPartlyVisibleLinesToolStripMenuItem1";
            this.roundPartlyVisibleLinesToolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
            this.roundPartlyVisibleLinesToolStripMenuItem1.Text = "Round partly visible lines";
            this.roundPartlyVisibleLinesToolStripMenuItem1.Click += new System.EventHandler(this.roundPartlyVisibleLinesToolStripMenuItem1_Click);
            // 
            // fullyVisibleLinesToolStripMenuItem1
            // 
            this.fullyVisibleLinesToolStripMenuItem1.Name = "fullyVisibleLinesToolStripMenuItem1";
            this.fullyVisibleLinesToolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
            this.fullyVisibleLinesToolStripMenuItem1.Text = "Fully visible lines";
            this.fullyVisibleLinesToolStripMenuItem1.Click += new System.EventHandler(this.fullyVisibleLinesToolStripMenuItem1_Click);
            // 
            // fullyInvisibleLinesToolStripMenuItem1
            // 
            this.fullyInvisibleLinesToolStripMenuItem1.Name = "fullyInvisibleLinesToolStripMenuItem1";
            this.fullyInvisibleLinesToolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
            this.fullyInvisibleLinesToolStripMenuItem1.Text = "Fully invisible lines";
            this.fullyInvisibleLinesToolStripMenuItem1.Click += new System.EventHandler(this.fullyInvisibleLinesToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(984, 961);
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
        private System.Windows.Forms.ToolStripMenuItem тестыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестСазерлендаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partlyVisibleLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roundPartlyVisibleLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullyInvisibleLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beckTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullyVisibleLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomPartlyVisibleLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roundPartlyVisibleLinesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fullyVisibleLinesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fullyInvisibleLinesToolStripMenuItem1;
    }
}

