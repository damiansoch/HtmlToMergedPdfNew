namespace HtmlToMergedPdfNew
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SelectFilesButton = new System.Windows.Forms.Button();
            this.totalFilestextBox = new System.Windows.Forms.TextBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.progressTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(226, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(364, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Converter";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SelectFilesButton
            // 
            this.SelectFilesButton.Location = new System.Drawing.Point(33, 176);
            this.SelectFilesButton.Name = "SelectFilesButton";
            this.SelectFilesButton.Size = new System.Drawing.Size(217, 36);
            this.SelectFilesButton.TabIndex = 1;
            this.SelectFilesButton.Text = "Select Html Files";
            this.SelectFilesButton.UseVisualStyleBackColor = false;
            this.SelectFilesButton.Click += new System.EventHandler(this.SelectFilesButton_Click);
            // 
            // totalFilestextBox
            // 
            this.totalFilestextBox.BackColor = System.Drawing.SystemColors.Control;
            this.totalFilestextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.totalFilestextBox.ForeColor = System.Drawing.Color.DarkGreen;
            this.totalFilestextBox.Location = new System.Drawing.Point(33, 237);
            this.totalFilestextBox.Name = "totalFilestextBox";
            this.totalFilestextBox.Size = new System.Drawing.Size(217, 16);
            this.totalFilestextBox.TabIndex = 2;
            this.totalFilestextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // convertButton
            // 
            this.convertButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.convertButton.Location = new System.Drawing.Point(335, 176);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(425, 77);
            this.convertButton.TabIndex = 3;
            this.convertButton.Text = "Convert to merged Pdf";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // progressTextBox
            // 
            this.progressTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.progressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.progressTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.progressTextBox.ForeColor = System.Drawing.Color.DarkGreen;
            this.progressTextBox.Location = new System.Drawing.Point(571, 340);
            this.progressTextBox.Name = "progressTextBox";
            this.progressTextBox.Size = new System.Drawing.Size(196, 22);
            this.progressTextBox.TabIndex = 4;
            this.progressTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressTextBox);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.totalFilestextBox);
            this.Controls.Add(this.SelectFilesButton);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Button SelectFilesButton;
        private TextBox totalFilestextBox;
        private Button convertButton;
        private TextBox progressTextBox;
    }
}