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
            this.cameraSpeed = new System.Windows.Forms.NumericUpDown();
            this.lbCamSpeed = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.gbTerrainControls = new System.Windows.Forms.GroupBox();
            this.baseColour = new System.Windows.Forms.Button();
            this.terrainWidth = new System.Windows.Forms.NumericUpDown();
            this.lbTerrainWidth = new System.Windows.Forms.Label();
            this.terrainNoise = new System.Windows.Forms.NumericUpDown();
            this.terrainHeight = new System.Windows.Forms.NumericUpDown();
            this.lbTerrainHeight = new System.Windows.Forms.Label();
            this.lbTerrainNoise = new System.Windows.Forms.Label();
            this.gbCameraControls = new System.Windows.Forms.GroupBox();
            this.gbViewControls = new System.Windows.Forms.GroupBox();
            this.lbViewVisibility = new System.Windows.Forms.Label();
            this.visibility = new System.Windows.Forms.NumericUpDown();
            this.gbResolutionControls = new System.Windows.Forms.GroupBox();
            this.resX = new System.Windows.Forms.NumericUpDown();
            this.resY = new System.Windows.Forms.NumericUpDown();
            this.lbResolutionX = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cameraSpeed)).BeginInit();
            this.gbTerrainControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.terrainWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.terrainNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.terrainHeight)).BeginInit();
            this.gbCameraControls.SuspendLayout();
            this.gbViewControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visibility)).BeginInit();
            this.gbResolutionControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resY)).BeginInit();
            this.SuspendLayout();
            // 
            // cameraSpeed
            // 
            this.cameraSpeed.DecimalPlaces = 2;
            this.cameraSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.cameraSpeed.Location = new System.Drawing.Point(12, 61);
            this.cameraSpeed.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cameraSpeed.Name = "cameraSpeed";
            this.cameraSpeed.Size = new System.Drawing.Size(120, 31);
            this.cameraSpeed.TabIndex = 0;
            // 
            // lbCamSpeed
            // 
            this.lbCamSpeed.AutoSize = true;
            this.lbCamSpeed.Location = new System.Drawing.Point(12, 31);
            this.lbCamSpeed.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbCamSpeed.Name = "lbCamSpeed";
            this.lbCamSpeed.Size = new System.Drawing.Size(71, 25);
            this.lbCamSpeed.TabIndex = 1;
            this.lbCamSpeed.Text = "speed";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(24, 736);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(324, 46);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate World";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.generate_Click);
            // 
            // gbTerrainControls
            // 
            this.gbTerrainControls.Controls.Add(this.baseColour);
            this.gbTerrainControls.Controls.Add(this.terrainWidth);
            this.gbTerrainControls.Controls.Add(this.lbTerrainWidth);
            this.gbTerrainControls.Controls.Add(this.terrainNoise);
            this.gbTerrainControls.Controls.Add(this.terrainHeight);
            this.gbTerrainControls.Controls.Add(this.lbTerrainHeight);
            this.gbTerrainControls.Controls.Add(this.lbTerrainNoise);
            this.gbTerrainControls.Location = new System.Drawing.Point(204, 23);
            this.gbTerrainControls.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbTerrainControls.Name = "gbTerrainControls";
            this.gbTerrainControls.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbTerrainControls.Size = new System.Drawing.Size(144, 319);
            this.gbTerrainControls.TabIndex = 3;
            this.gbTerrainControls.TabStop = false;
            this.gbTerrainControls.Text = "Terrain";
            // 
            // baseColour
            // 
            this.baseColour.Location = new System.Drawing.Point(12, 261);
            this.baseColour.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.baseColour.Name = "baseColour";
            this.baseColour.Size = new System.Drawing.Size(120, 42);
            this.baseColour.TabIndex = 11;
            this.baseColour.Text = "Base";
            this.baseColour.UseVisualStyleBackColor = true;
            this.baseColour.Click += new System.EventHandler(this.btnColour_Click);
            // 
            // terrainWidth
            // 
            this.terrainWidth.Location = new System.Drawing.Point(12, 136);
            this.terrainWidth.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.terrainWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.terrainWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.terrainWidth.Name = "terrainWidth";
            this.terrainWidth.Size = new System.Drawing.Size(120, 31);
            this.terrainWidth.TabIndex = 6;
            this.terrainWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lbTerrainWidth
            // 
            this.lbTerrainWidth.AutoSize = true;
            this.lbTerrainWidth.Location = new System.Drawing.Point(12, 106);
            this.lbTerrainWidth.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbTerrainWidth.Name = "lbTerrainWidth";
            this.lbTerrainWidth.Size = new System.Drawing.Size(62, 25);
            this.lbTerrainWidth.TabIndex = 5;
            this.lbTerrainWidth.Text = "width";
            // 
            // terrainNoise
            // 
            this.terrainNoise.DecimalPlaces = 2;
            this.terrainNoise.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.terrainNoise.Location = new System.Drawing.Point(12, 211);
            this.terrainNoise.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.terrainNoise.Name = "terrainNoise";
            this.terrainNoise.Size = new System.Drawing.Size(120, 31);
            this.terrainNoise.TabIndex = 4;
            // 
            // terrainHeight
            // 
            this.terrainHeight.Location = new System.Drawing.Point(12, 61);
            this.terrainHeight.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.terrainHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.terrainHeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.terrainHeight.Name = "terrainHeight";
            this.terrainHeight.Size = new System.Drawing.Size(120, 31);
            this.terrainHeight.TabIndex = 3;
            this.terrainHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lbTerrainHeight
            // 
            this.lbTerrainHeight.AutoSize = true;
            this.lbTerrainHeight.Location = new System.Drawing.Point(12, 31);
            this.lbTerrainHeight.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbTerrainHeight.Name = "lbTerrainHeight";
            this.lbTerrainHeight.Size = new System.Drawing.Size(71, 25);
            this.lbTerrainHeight.TabIndex = 0;
            this.lbTerrainHeight.Text = "height";
            // 
            // lbTerrainNoise
            // 
            this.lbTerrainNoise.AutoSize = true;
            this.lbTerrainNoise.Location = new System.Drawing.Point(12, 181);
            this.lbTerrainNoise.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbTerrainNoise.Name = "lbTerrainNoise";
            this.lbTerrainNoise.Size = new System.Drawing.Size(64, 25);
            this.lbTerrainNoise.TabIndex = 1;
            this.lbTerrainNoise.Text = "noise";
            // 
            // gbCameraControls
            // 
            this.gbCameraControls.Controls.Add(this.lbCamSpeed);
            this.gbCameraControls.Controls.Add(this.cameraSpeed);
            this.gbCameraControls.Location = new System.Drawing.Point(30, 23);
            this.gbCameraControls.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbCameraControls.Name = "gbCameraControls";
            this.gbCameraControls.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbCameraControls.Size = new System.Drawing.Size(144, 319);
            this.gbCameraControls.TabIndex = 0;
            this.gbCameraControls.TabStop = false;
            this.gbCameraControls.Text = "Camera";
            // 
            // gbViewControls
            // 
            this.gbViewControls.Controls.Add(this.lbViewVisibility);
            this.gbViewControls.Controls.Add(this.visibility);
            this.gbViewControls.Controls.Add(this.gbResolutionControls);
            this.gbViewControls.Location = new System.Drawing.Point(24, 354);
            this.gbViewControls.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbViewControls.Name = "gbViewControls";
            this.gbViewControls.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbViewControls.Size = new System.Drawing.Size(324, 371);
            this.gbViewControls.TabIndex = 0;
            this.gbViewControls.TabStop = false;
            this.gbViewControls.Text = "View";
            // 
            // lbViewVisibility
            // 
            this.lbViewVisibility.AutoSize = true;
            this.lbViewVisibility.Location = new System.Drawing.Point(18, 48);
            this.lbViewVisibility.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbViewVisibility.Name = "lbViewVisibility";
            this.lbViewVisibility.Size = new System.Drawing.Size(88, 25);
            this.lbViewVisibility.TabIndex = 3;
            this.lbViewVisibility.Text = "visibility";
            // 
            // visibility
            // 
            this.visibility.DecimalPlaces = 2;
            this.visibility.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.visibility.Location = new System.Drawing.Point(18, 79);
            this.visibility.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.visibility.Name = "visibility";
            this.visibility.Size = new System.Drawing.Size(120, 31);
            this.visibility.TabIndex = 2;
            // 
            // gbResolutionControls
            // 
            this.gbResolutionControls.Controls.Add(this.resX);
            this.gbResolutionControls.Controls.Add(this.resY);
            this.gbResolutionControls.Controls.Add(this.lbResolutionX);
            this.gbResolutionControls.Location = new System.Drawing.Point(12, 260);
            this.gbResolutionControls.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbResolutionControls.Name = "gbResolutionControls";
            this.gbResolutionControls.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbResolutionControls.Size = new System.Drawing.Size(300, 100);
            this.gbResolutionControls.TabIndex = 10;
            this.gbResolutionControls.TabStop = false;
            this.gbResolutionControls.Text = "resolution";
            // 
            // resX
            // 
            this.resX.Location = new System.Drawing.Point(12, 36);
            this.resX.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.resX.Name = "resX";
            this.resX.Size = new System.Drawing.Size(114, 31);
            this.resX.TabIndex = 7;
            // 
            // resY
            // 
            this.resY.Location = new System.Drawing.Point(174, 36);
            this.resY.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.resY.Name = "resY";
            this.resY.Size = new System.Drawing.Size(114, 31);
            this.resY.TabIndex = 8;
            // 
            // lbResolutionX
            // 
            this.lbResolutionX.AutoSize = true;
            this.lbResolutionX.Location = new System.Drawing.Point(138, 40);
            this.lbResolutionX.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbResolutionX.Name = "lbResolutionX";
            this.lbResolutionX.Size = new System.Drawing.Size(23, 25);
            this.lbResolutionX.TabIndex = 9;
            this.lbResolutionX.Text = "x";
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(374, 836);
            this.Controls.Add(this.gbCameraControls);
            this.Controls.Add(this.gbViewControls);
            this.Controls.Add(this.gbTerrainControls);
            this.Controls.Add(this.btnGenerate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(352, 740);
            this.Name = "Control";
            this.ShowIcon = false;
            this.Text = "WGenerator v1";
            ((System.ComponentModel.ISupportInitialize)(this.cameraSpeed)).EndInit();
            this.gbTerrainControls.ResumeLayout(false);
            this.gbTerrainControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.terrainWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.terrainNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.terrainHeight)).EndInit();
            this.gbCameraControls.ResumeLayout(false);
            this.gbCameraControls.PerformLayout();
            this.gbViewControls.ResumeLayout(false);
            this.gbViewControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visibility)).EndInit();
            this.gbResolutionControls.ResumeLayout(false);
            this.gbResolutionControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown cameraSpeed;
        private System.Windows.Forms.Label lbCamSpeed;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox gbTerrainControls;
        private System.Windows.Forms.GroupBox gbCameraControls;
        private System.Windows.Forms.GroupBox gbViewControls;
        private System.Windows.Forms.Label lbTerrainHeight;
        private System.Windows.Forms.Label lbTerrainNoise;
        private System.Windows.Forms.NumericUpDown terrainNoise;
        private System.Windows.Forms.NumericUpDown terrainHeight;
        private System.Windows.Forms.Label lbResolutionX;
        private System.Windows.Forms.NumericUpDown resY;
        private System.Windows.Forms.NumericUpDown resX;
        private System.Windows.Forms.GroupBox gbResolutionControls;
        private System.Windows.Forms.Label lbViewVisibility;
        private System.Windows.Forms.NumericUpDown visibility;
        private System.Windows.Forms.NumericUpDown terrainWidth;
        private System.Windows.Forms.Label lbTerrainWidth;
        private System.Windows.Forms.Button baseColour;
    }
}