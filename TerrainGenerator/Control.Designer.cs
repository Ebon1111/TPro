namespace TerrainGenerator
{
    partial class Control
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
            this.inCamSpeed = new System.Windows.Forms.NumericUpDown();
            this.lbCamSpeed = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.gbTerrainControls = new System.Windows.Forms.GroupBox();
            this.btnBaseColour = new System.Windows.Forms.Button();
            this.inTerrainWidth = new System.Windows.Forms.NumericUpDown();
            this.lbTerrainWidth = new System.Windows.Forms.Label();
            this.inTerrainNoise = new System.Windows.Forms.NumericUpDown();
            this.inTerrainHeight = new System.Windows.Forms.NumericUpDown();
            this.lbTerrainHeight = new System.Windows.Forms.Label();
            this.lbTerrainNoise = new System.Windows.Forms.Label();
            this.gbCameraControls = new System.Windows.Forms.GroupBox();
            this.gbViewControls = new System.Windows.Forms.GroupBox();
            this.lbViewVisibility = new System.Windows.Forms.Label();
            this.inViewVisibility = new System.Windows.Forms.NumericUpDown();
            this.gbResolutionControls = new System.Windows.Forms.GroupBox();
            this.inViewResolutionX = new System.Windows.Forms.NumericUpDown();
            this.inViewResolutionY = new System.Windows.Forms.NumericUpDown();
            this.lbResolutionX = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inCamSpeed)).BeginInit();
            this.gbTerrainControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inTerrainWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inTerrainNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inTerrainHeight)).BeginInit();
            this.gbCameraControls.SuspendLayout();
            this.gbViewControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inViewVisibility)).BeginInit();
            this.gbResolutionControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inViewResolutionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inViewResolutionY)).BeginInit();
            this.SuspendLayout();
            // 
            // inCamSpeed
            // 
            this.inCamSpeed.DecimalPlaces = 2;
            this.inCamSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.inCamSpeed.Location = new System.Drawing.Point(6, 32);
            this.inCamSpeed.Name = "inCamSpeed";
            this.inCamSpeed.Size = new System.Drawing.Size(60, 20);
            this.inCamSpeed.TabIndex = 0;
            this.inCamSpeed.ValueChanged += new System.EventHandler(this.cameraSpeed_ValueChanged);
            // 
            // lbCamSpeed
            // 
            this.lbCamSpeed.AutoSize = true;
            this.lbCamSpeed.Location = new System.Drawing.Point(6, 16);
            this.lbCamSpeed.Name = "lbCamSpeed";
            this.lbCamSpeed.Size = new System.Drawing.Size(36, 13);
            this.lbCamSpeed.TabIndex = 1;
            this.lbCamSpeed.Text = "speed";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(12, 383);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(162, 24);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate World";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.generate_Click);
            // 
            // gbTerrainControls
            // 
            this.gbTerrainControls.Controls.Add(this.btnBaseColour);
            this.gbTerrainControls.Controls.Add(this.inTerrainWidth);
            this.gbTerrainControls.Controls.Add(this.lbTerrainWidth);
            this.gbTerrainControls.Controls.Add(this.inTerrainNoise);
            this.gbTerrainControls.Controls.Add(this.inTerrainHeight);
            this.gbTerrainControls.Controls.Add(this.lbTerrainHeight);
            this.gbTerrainControls.Controls.Add(this.lbTerrainNoise);
            this.gbTerrainControls.Location = new System.Drawing.Point(102, 12);
            this.gbTerrainControls.Name = "gbTerrainControls";
            this.gbTerrainControls.Size = new System.Drawing.Size(72, 166);
            this.gbTerrainControls.TabIndex = 3;
            this.gbTerrainControls.TabStop = false;
            this.gbTerrainControls.Text = "Terrain";
            // 
            // btnBaseColour
            // 
            this.btnBaseColour.Location = new System.Drawing.Point(6, 136);
            this.btnBaseColour.Name = "btnBaseColour";
            this.btnBaseColour.Size = new System.Drawing.Size(60, 22);
            this.btnBaseColour.TabIndex = 11;
            this.btnBaseColour.Text = "Base";
            this.btnBaseColour.UseVisualStyleBackColor = true;
            this.btnBaseColour.Click += new System.EventHandler(this.baseColour_Click);
            // 
            // inTerrainWidth
            // 
            this.inTerrainWidth.Location = new System.Drawing.Point(6, 71);
            this.inTerrainWidth.Name = "inTerrainWidth";
            this.inTerrainWidth.Size = new System.Drawing.Size(60, 20);
            this.inTerrainWidth.TabIndex = 6;
            this.inTerrainWidth.ValueChanged += new System.EventHandler(this.terrainWidth_ValueChanged);
            // 
            // lbTerrainWidth
            // 
            this.lbTerrainWidth.AutoSize = true;
            this.lbTerrainWidth.Location = new System.Drawing.Point(6, 55);
            this.lbTerrainWidth.Name = "lbTerrainWidth";
            this.lbTerrainWidth.Size = new System.Drawing.Size(32, 13);
            this.lbTerrainWidth.TabIndex = 5;
            this.lbTerrainWidth.Text = "width";
            // 
            // inTerrainNoise
            // 
            this.inTerrainNoise.DecimalPlaces = 2;
            this.inTerrainNoise.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.inTerrainNoise.Location = new System.Drawing.Point(6, 110);
            this.inTerrainNoise.Name = "inTerrainNoise";
            this.inTerrainNoise.Size = new System.Drawing.Size(60, 20);
            this.inTerrainNoise.TabIndex = 4;
            this.inTerrainNoise.ValueChanged += new System.EventHandler(this.terrainNoise_ValueChanged);
            // 
            // inTerrainHeight
            // 
            this.inTerrainHeight.Location = new System.Drawing.Point(6, 32);
            this.inTerrainHeight.Name = "inTerrainHeight";
            this.inTerrainHeight.Size = new System.Drawing.Size(60, 20);
            this.inTerrainHeight.TabIndex = 3;
            this.inTerrainHeight.ValueChanged += new System.EventHandler(this.terrainHeight_ValueChanged);
            // 
            // lbTerrainHeight
            // 
            this.lbTerrainHeight.AutoSize = true;
            this.lbTerrainHeight.Location = new System.Drawing.Point(6, 16);
            this.lbTerrainHeight.Name = "lbTerrainHeight";
            this.lbTerrainHeight.Size = new System.Drawing.Size(36, 13);
            this.lbTerrainHeight.TabIndex = 0;
            this.lbTerrainHeight.Text = "height";
            // 
            // lbTerrainNoise
            // 
            this.lbTerrainNoise.AutoSize = true;
            this.lbTerrainNoise.Location = new System.Drawing.Point(6, 94);
            this.lbTerrainNoise.Name = "lbTerrainNoise";
            this.lbTerrainNoise.Size = new System.Drawing.Size(32, 13);
            this.lbTerrainNoise.TabIndex = 1;
            this.lbTerrainNoise.Text = "noise";
            // 
            // gbCameraControls
            // 
            this.gbCameraControls.Controls.Add(this.lbCamSpeed);
            this.gbCameraControls.Controls.Add(this.inCamSpeed);
            this.gbCameraControls.Location = new System.Drawing.Point(15, 12);
            this.gbCameraControls.Name = "gbCameraControls";
            this.gbCameraControls.Size = new System.Drawing.Size(72, 166);
            this.gbCameraControls.TabIndex = 0;
            this.gbCameraControls.TabStop = false;
            this.gbCameraControls.Text = "Camera";
            // 
            // gbViewControls
            // 
            this.gbViewControls.Controls.Add(this.lbViewVisibility);
            this.gbViewControls.Controls.Add(this.inViewVisibility);
            this.gbViewControls.Controls.Add(this.gbResolutionControls);
            this.gbViewControls.Location = new System.Drawing.Point(12, 184);
            this.gbViewControls.Name = "gbViewControls";
            this.gbViewControls.Size = new System.Drawing.Size(162, 193);
            this.gbViewControls.TabIndex = 0;
            this.gbViewControls.TabStop = false;
            this.gbViewControls.Text = "View";
            // 
            // lbViewVisibility
            // 
            this.lbViewVisibility.AutoSize = true;
            this.lbViewVisibility.Location = new System.Drawing.Point(9, 25);
            this.lbViewVisibility.Name = "lbViewVisibility";
            this.lbViewVisibility.Size = new System.Drawing.Size(42, 13);
            this.lbViewVisibility.TabIndex = 3;
            this.lbViewVisibility.Text = "visibility";
            // 
            // inViewVisibility
            // 
            this.inViewVisibility.DecimalPlaces = 2;
            this.inViewVisibility.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.inViewVisibility.Location = new System.Drawing.Point(9, 41);
            this.inViewVisibility.Name = "inViewVisibility";
            this.inViewVisibility.Size = new System.Drawing.Size(60, 20);
            this.inViewVisibility.TabIndex = 2;
            this.inViewVisibility.ValueChanged += new System.EventHandler(this.viewVisibility_ValueChanged);
            // 
            // gbResolutionControls
            // 
            this.gbResolutionControls.Controls.Add(this.inViewResolutionX);
            this.gbResolutionControls.Controls.Add(this.inViewResolutionY);
            this.gbResolutionControls.Controls.Add(this.lbResolutionX);
            this.gbResolutionControls.Location = new System.Drawing.Point(6, 135);
            this.gbResolutionControls.Name = "gbResolutionControls";
            this.gbResolutionControls.Size = new System.Drawing.Size(150, 52);
            this.gbResolutionControls.TabIndex = 10;
            this.gbResolutionControls.TabStop = false;
            this.gbResolutionControls.Text = "resolution";
            // 
            // inViewResolutionX
            // 
            this.inViewResolutionX.Location = new System.Drawing.Point(6, 19);
            this.inViewResolutionX.Name = "inViewResolutionX";
            this.inViewResolutionX.Size = new System.Drawing.Size(57, 20);
            this.inViewResolutionX.TabIndex = 7;
            this.inViewResolutionX.ValueChanged += new System.EventHandler(this.viewResolutionX_ValueChanged);
            // 
            // inViewResolutionY
            // 
            this.inViewResolutionY.Location = new System.Drawing.Point(87, 19);
            this.inViewResolutionY.Name = "inViewResolutionY";
            this.inViewResolutionY.Size = new System.Drawing.Size(57, 20);
            this.inViewResolutionY.TabIndex = 8;
            this.inViewResolutionY.ValueChanged += new System.EventHandler(this.viewResolutionY_ValueChanged);
            // 
            // lbResolutionX
            // 
            this.lbResolutionX.AutoSize = true;
            this.lbResolutionX.Location = new System.Drawing.Point(69, 21);
            this.lbResolutionX.Name = "lbResolutionX";
            this.lbResolutionX.Size = new System.Drawing.Size(12, 13);
            this.lbResolutionX.TabIndex = 9;
            this.lbResolutionX.Text = "x";
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(187, 419);
            this.Controls.Add(this.gbCameraControls);
            this.Controls.Add(this.gbViewControls);
            this.Controls.Add(this.gbTerrainControls);
            this.Controls.Add(this.btnGenerate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(203, 458);
            this.Name = "Control";
            this.ShowIcon = false;
            this.Text = "WGenerator v1";
            ((System.ComponentModel.ISupportInitialize)(this.inCamSpeed)).EndInit();
            this.gbTerrainControls.ResumeLayout(false);
            this.gbTerrainControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inTerrainWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inTerrainNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inTerrainHeight)).EndInit();
            this.gbCameraControls.ResumeLayout(false);
            this.gbCameraControls.PerformLayout();
            this.gbViewControls.ResumeLayout(false);
            this.gbViewControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inViewVisibility)).EndInit();
            this.gbResolutionControls.ResumeLayout(false);
            this.gbResolutionControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inViewResolutionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inViewResolutionY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown inCamSpeed;
        private System.Windows.Forms.Label lbCamSpeed;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox gbTerrainControls;
        private System.Windows.Forms.GroupBox gbCameraControls;
        private System.Windows.Forms.GroupBox gbViewControls;
        private System.Windows.Forms.Label lbTerrainHeight;
        private System.Windows.Forms.Label lbTerrainNoise;
        private System.Windows.Forms.NumericUpDown inTerrainNoise;
        private System.Windows.Forms.NumericUpDown inTerrainHeight;
        private System.Windows.Forms.Label lbResolutionX;
        private System.Windows.Forms.NumericUpDown inViewResolutionY;
        private System.Windows.Forms.NumericUpDown inViewResolutionX;
        private System.Windows.Forms.GroupBox gbResolutionControls;
        private System.Windows.Forms.Label lbViewVisibility;
        private System.Windows.Forms.NumericUpDown inViewVisibility;
        private System.Windows.Forms.NumericUpDown inTerrainWidth;
        private System.Windows.Forms.Label lbTerrainWidth;
        private System.Windows.Forms.Button btnBaseColour;
    }
}