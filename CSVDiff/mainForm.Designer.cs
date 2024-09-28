namespace CSVDiff
{
    partial class mainForm
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
            this.compareButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gentxtCheckbox = new System.Windows.Forms.CheckBox();
            this.genhtmlCheckbox = new System.Windows.Forms.CheckBox();
            this.mfTextbox = new System.Windows.Forms.TextBox();
            this.mfButton = new System.Windows.Forms.Button();
            this.ofButton = new System.Windows.Forms.Button();
            this.ofTextbox = new System.Windows.Forms.TextBox();
            this.ofLabel = new System.Windows.Forms.Label();
            this.mfLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.copyrightLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // compareButton
            // 
            this.compareButton.Enabled = false;
            this.compareButton.Location = new System.Drawing.Point(341, 147);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(109, 30);
            this.compareButton.TabIndex = 5;
            this.compareButton.TabStop = false;
            this.compareButton.Text = "Compare";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gentxtCheckbox);
            this.groupBox1.Controls.Add(this.genhtmlCheckbox);
            this.groupBox1.Controls.Add(this.mfTextbox);
            this.groupBox1.Controls.Add(this.mfButton);
            this.groupBox1.Controls.Add(this.ofButton);
            this.groupBox1.Controls.Add(this.ofTextbox);
            this.groupBox1.Controls.Add(this.ofLabel);
            this.groupBox1.Controls.Add(this.mfLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 129);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // gentxtCheckbox
            // 
            this.gentxtCheckbox.AutoSize = true;
            this.gentxtCheckbox.Checked = true;
            this.gentxtCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gentxtCheckbox.Enabled = false;
            this.gentxtCheckbox.Location = new System.Drawing.Point(226, 97);
            this.gentxtCheckbox.Name = "gentxtCheckbox";
            this.gentxtCheckbox.Size = new System.Drawing.Size(106, 19);
            this.gentxtCheckbox.TabIndex = 3;
            this.gentxtCheckbox.TabStop = false;
            this.gentxtCheckbox.Text = "Generate Text";
            this.gentxtCheckbox.UseVisualStyleBackColor = true;
            // 
            // genhtmlCheckbox
            // 
            this.genhtmlCheckbox.AutoSize = true;
            this.genhtmlCheckbox.Checked = true;
            this.genhtmlCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.genhtmlCheckbox.Enabled = false;
            this.genhtmlCheckbox.Location = new System.Drawing.Point(326, 97);
            this.genhtmlCheckbox.Name = "genhtmlCheckbox";
            this.genhtmlCheckbox.Size = new System.Drawing.Size(117, 19);
            this.genhtmlCheckbox.TabIndex = 4;
            this.genhtmlCheckbox.TabStop = false;
            this.genhtmlCheckbox.Text = "Generate HTML";
            this.genhtmlCheckbox.UseVisualStyleBackColor = true;
            // 
            // mfTextbox
            // 
            this.mfTextbox.Location = new System.Drawing.Point(94, 48);
            this.mfTextbox.Name = "mfTextbox";
            this.mfTextbox.ReadOnly = true;
            this.mfTextbox.Size = new System.Drawing.Size(254, 20);
            this.mfTextbox.TabIndex = 6;
            this.mfTextbox.TabStop = false;
            // 
            // mfButton
            // 
            this.mfButton.Enabled = false;
            this.mfButton.Location = new System.Drawing.Point(354, 48);
            this.mfButton.Name = "mfButton";
            this.mfButton.Size = new System.Drawing.Size(75, 23);
            this.mfButton.TabIndex = 5;
            this.mfButton.TabStop = false;
            this.mfButton.Text = "...";
            this.mfButton.UseVisualStyleBackColor = true;
            this.mfButton.Click += new System.EventHandler(this.mfButton_Click);
            // 
            // ofButton
            // 
            this.ofButton.Location = new System.Drawing.Point(354, 19);
            this.ofButton.Name = "ofButton";
            this.ofButton.Size = new System.Drawing.Size(75, 23);
            this.ofButton.TabIndex = 4;
            this.ofButton.TabStop = false;
            this.ofButton.Text = "...";
            this.ofButton.UseVisualStyleBackColor = true;
            this.ofButton.Click += new System.EventHandler(this.ofButton_Click);
            // 
            // ofTextbox
            // 
            this.ofTextbox.Location = new System.Drawing.Point(94, 19);
            this.ofTextbox.Name = "ofTextbox";
            this.ofTextbox.ReadOnly = true;
            this.ofTextbox.Size = new System.Drawing.Size(254, 20);
            this.ofTextbox.TabIndex = 3;
            this.ofTextbox.TabStop = false;
            // 
            // ofLabel
            // 
            this.ofLabel.AutoSize = true;
            this.ofLabel.Location = new System.Drawing.Point(24, 22);
            this.ofLabel.Name = "ofLabel";
            this.ofLabel.Size = new System.Drawing.Size(76, 15);
            this.ofLabel.TabIndex = 0;
            this.ofLabel.Text = "Original File:";
            // 
            // mfLabel
            // 
            this.mfLabel.AutoSize = true;
            this.mfLabel.Location = new System.Drawing.Point(19, 51);
            this.mfLabel.Name = "mfLabel";
            this.mfLabel.Size = new System.Drawing.Size(81, 15);
            this.mfLabel.TabIndex = 1;
            this.mfLabel.Text = "Modified File:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyrightLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 176);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(462, 26);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(177, 20);
            this.copyrightLabel.Text = "https://github.com/xkrisl/";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 202);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSVDiff";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button compareButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox gentxtCheckbox;
        private System.Windows.Forms.CheckBox genhtmlCheckbox;
        private System.Windows.Forms.TextBox mfTextbox;
        private System.Windows.Forms.Button mfButton;
        private System.Windows.Forms.Button ofButton;
        private System.Windows.Forms.TextBox ofTextbox;
        private System.Windows.Forms.Label ofLabel;
        private System.Windows.Forms.Label mfLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel copyrightLabel;
    }
}

