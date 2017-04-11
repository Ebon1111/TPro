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
            this.terrainWidth = new System.Windows.Forms.NumericUpDown();
            this.lbTerrainWidth = new System.Windows.Forms.Label();
            this.terrainNoise = new System.Windows.Forms.NumericUpDown();
            this.terrainLength = new System.Windows.Forms.NumericUpDown();
            this.lbTerrainLength = new System.Windows.Forms.Label();
            this.lbTerrainNoise = new System.Windows.Forms.Label();
            this.gbCameraControls = new System.Windows.Forms.GroupBox();
            this.gbViewControls = new System.Windows.Forms.GroupBox();
            this.lbViewVisibility = new System.Windows.Forms.Label();
            this.visibility = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.cameraSpeed)).BeginInit();
            this.gbTerrainControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.terrainWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.terrainNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.terrainLength)).BeginInit();
            this.gbCameraControls.SuspendLayout();
            this.gbViewControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visibility)).BeginInit();
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
            this.cameraSpeed.Location = new System.Drawing.Point(11, 41);
            this.cameraSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.cameraSpeed.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.cameraSpeed.Name = "cameraSpeed";
            this.cameraSpeed.Size = new System.Drawing.Size(80, 22);
            this.cameraSpeed.TabIndex = 0;
            this.cameraSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lbCamSpeed
            // 
            this.lbCamSpeed.AutoSize = true;
            this.lbCamSpeed.Location = new System.Drawing.Point(8, 20);
            this.lbCamSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCamSpeed.Name = "lbCamSpeed";
            this.lbCamSpeed.Size = new System.Drawing.Size(47, 17);
            this.lbCamSpeed.TabIndex = 1;
            this.lbCamSpeed.Text = "speed";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(20, 207);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(212, 29);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate World";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.generate_Click);
            // 
            // gbTerrainControls
            // 
            this.gbTerrainControls.Controls.Add(this.terrainWidth);
            this.gbTerrainControls.Controls.Add(this.lbTerrainWidth);
            this.gbTerrainControls.Controls.Add(this.terrainNoise);
            this.gbTerrainControls.Controls.Add(this.terrainLength);
            this.gbTerrainControls.Controls.Add(this.lbTerrainLength);
            this.gbTerrainControls.Controls.Add(this.lbTerrainNoise);
            this.gbTerrainControls.Location = new System.Drawing.Point(136, 15);
            this.gbTerrainControls.Margin = new System.Windows.Forms.Padding(4);
            this.gbTerrainControls.Name = "gbTerrainControls";
            this.gbTerrainControls.Padding = new System.Windows.Forms.Padding(4);
            this.gbTerrainControls.Size = new System.Drawing.Size(96, 184);
            this.gbTerrainControls.TabIndex = 3;
            this.gbTerrainControls.TabStop = false;
            this.gbTerrainControls.Text = "Terrain";
            // 
            // terrainWidth
            // 
            this.terrainWidth.Location = new System.Drawing.Point(8, 87);
            this.terrainWidth.Margin = new System.Windows.Forms.Padding(4);
            this.terrainWidth.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.terrainWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.terrainWidth.Name = "terrainWidth";
            this.terrainWidth.Size = new System.Drawing.Size(80, 22);
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
            this.lbTerrainWidth.Location = new System.Drawing.Point(8, 68);
            this.lbTerrainWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTerrainWidth.Name = "lbTerrainWidth";
            this.lbTerrainWidth.Size = new System.Drawing.Size(40, 17);
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
            this.terrainNoise.Location = new System.Drawing.Point(8, 135);
            this.terrainNoise.Margin = new System.Windows.Forms.Padding(4);
            this.terrainNoise.Name = "terrainNoise";
            this.terrainNoise.Size = new System.Drawing.Size(80, 22);
            this.terrainNoise.TabIndex = 4;
            this.terrainNoise.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // terrainLength
            // 
            this.terrainLength.Location = new System.Drawing.Point(8, 39);
            this.terrainLength.Margin = new System.Windows.Forms.Padding(4);
            this.terrainLength.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.terrainLength.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.terrainLength.Name = "terrainLength";
            this.terrainLength.Size = new System.Drawing.Size(80, 22);
            this.terrainLength.TabIndex = 3;
            this.terrainLength.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lbTerrainLength
            // 
            this.lbTerrainLength.AutoSize = true;
            this.lbTerrainLength.Location = new System.Drawing.Point(8, 20);
            this.lbTerrainLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTerrainLength.Name = "lbTerrainLength";
            this.lbTerrainLength.Size = new System.Drawing.Size(47, 17);
            this.lbTerrainLength.TabIndex = 0;
            this.lbTerrainLength.Text = "length";
            // 
            // lbTerrainNoise
            // 
            this.lbTerrainNoise.AutoSize = true;
            this.lbTerrainNoise.Location = new System.Drawing.Point(8, 116);
            this.lbTerrainNoise.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTerrainNoise.Name = "lbTerrainNoise";
            this.lbTerrainNoise.Size = new System.Drawing.Size(42, 17);
            this.lbTerrainNoise.TabIndex = 1;
            this.lbTerrainNoise.Text = "noise";
            // 
            // gbCameraControls
            // 
            this.gbCameraControls.Controls.Add(this.lbCamSpeed);
            this.gbCameraControls.Controls.Add(this.cameraSpeed);
            this.gbCameraControls.Location = new System.Drawing.Point(20, 15);
            this.gbCameraControls.Margin = new System.Windows.Forms.Padding(4);
            this.gbCameraControls.Name = "gbCameraControls";
            this.gbCameraControls.Padding = new System.Windows.Forms.Padding(4);
            this.gbCameraControls.Size = new System.Drawing.Size(100, 88);
            this.gbCameraControls.TabIndex = 0;
            this.gbCameraControls.TabStop = false;
            this.gbCameraControls.Text = "Camera";
            // 
            // gbViewControls
            // 
            this.gbViewControls.Controls.Add(this.lbViewVisibility);
            this.gbViewControls.Controls.Add(this.visibility);
            this.gbViewControls.Location = new System.Drawing.Point(20, 111);
            this.gbViewControls.Margin = new System.Windows.Forms.Padding(4);
            this.gbViewControls.Name = "gbViewControls";
            this.gbViewControls.Padding = new System.Windows.Forms.Padding(4);
            this.gbViewControls.Size = new System.Drawing.Size(100, 88);
            this.gbViewControls.TabIndex = 0;
            this.gbViewControls.TabStop = false;
            this.gbViewControls.Text = "View";
            // 
            // lbViewVisibility
            // 
            this.lbViewVisibility.AutoSize = true;
            this.lbViewVisibility.Location = new System.Drawing.Point(8, 19);
            this.lbViewVisibility.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbViewVisibility.Name = "lbViewVisibility";
            this.lbViewVisibility.Size = new System.Drawing.Size(56, 17);
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
            this.visibility.Location = new System.Drawing.Point(11, 40);
            this.visibility.Margin = new System.Windows.Forms.Padding(4);
            this.visibility.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.visibility.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.visibility.Name = "visibility";
            this.visibility.Size = new System.Drawing.Size(80, 22);
            this.visibility.TabIndex = 2;
            this.visibility.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(249, 270);
            this.Controls.Add(this.gbCameraControls);
            this.Controls.Add(this.gbViewControls);
            this.Controls.Add(this.gbTerrainControls);
            this.Controls.Add(this.btnGenerate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(267, 317);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(267, 317);
            this.Name = "Control";
            this.ShowIcon = false;
            this.Text = "WGenerator v1";
            ((System.ComponentModel.ISupportInitialize)(this.cameraSpeed)).EndInit();
            this.gbTerrainControls.ResumeLayout(false);
            this.gbTerrainControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.terrainWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.terrainNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.terrainLength)).EndInit();
            this.gbCameraControls.ResumeLayout(false);
            this.gbCameraControls.PerformLayout();
            this.gbViewControls.ResumeLayout(false);
            this.gbViewControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visibility)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown cameraSpeed;
        private System.Windows.Forms.Label lbCamSpeed;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox gbTerrainControls;
        private System.Windows.Forms.GroupBox gbCameraControls;
        private System.Windows.Forms.GroupBox gbViewControls;
        private System.Windows.Forms.Label lbTerrainLength;
        private System.Windows.Forms.Label lbTerrainNoise;
        private System.Windows.Forms.NumericUpDown terrainNoise;
        private System.Windows.Forms.NumericUpDown terrainLength;
        private System.Windows.Forms.Label lbViewVisibility;
        private System.Windows.Forms.NumericUpDown visibility;
        private System.Windows.Forms.NumericUpDown terrainWidth;
        private System.Windows.Forms.Label lbTerrainWidth;
    }
}