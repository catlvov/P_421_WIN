namespace Clock
{
    partial class FontDialog
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
            this.comboBoxFronts = new System.Windows.Forms.ComboBox();
            this.nudFrontSize = new System.Windows.Forms.NumericUpDown();
            this.labelExample = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudFrontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxFronts
            // 
            this.comboBoxFronts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFronts.FormattingEnabled = true;
            this.comboBoxFronts.Location = new System.Drawing.Point(13, 13);
            this.comboBoxFronts.Name = "comboBoxFronts";
            this.comboBoxFronts.Size = new System.Drawing.Size(442, 21);
            this.comboBoxFronts.TabIndex = 0;
            this.comboBoxFronts.SelectedIndexChanged += new System.EventHandler(this.comboBoxFronts_SelectedIndexChanged);
            // 
            // nudFrontSize
            // 
            this.nudFrontSize.Location = new System.Drawing.Point(461, 14);
            this.nudFrontSize.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudFrontSize.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFrontSize.Name = "nudFrontSize";
            this.nudFrontSize.Size = new System.Drawing.Size(59, 20);
            this.nudFrontSize.TabIndex = 1;
            this.nudFrontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudFrontSize.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.nudFrontSize.ValueChanged += new System.EventHandler(this.nudFrontSize_ValueChanged);
            // 
            // labelExample
            // 
            this.labelExample.AutoSize = true;
            this.labelExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelExample.Location = new System.Drawing.Point(13, 41);
            this.labelExample.Name = "labelExample";
            this.labelExample.Size = new System.Drawing.Size(191, 51);
            this.labelExample.TabIndex = 2;
            this.labelExample.Text = "Example";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(445, 167);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(364, 166);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "CANSEL";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FontDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 202);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelExample);
            this.Controls.Add(this.nudFrontSize);
            this.Controls.Add(this.comboBoxFronts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FontDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ChooseFont";
            this.Load += new System.EventHandler(this.ChooswFont_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudFrontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFronts;
        private System.Windows.Forms.NumericUpDown nudFrontSize;
        private System.Windows.Forms.Label labelExample;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}