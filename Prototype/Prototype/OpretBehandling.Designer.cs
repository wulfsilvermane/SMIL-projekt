namespace Prototype
{
    partial class OpretBehandling
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonGem = new System.Windows.Forms.Button();
            this.buttonAnnuller = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(260, 208);
            this.textBox1.TabIndex = 0;
            // 
            // buttonGem
            // 
            this.buttonGem.Location = new System.Drawing.Point(12, 226);
            this.buttonGem.Name = "buttonGem";
            this.buttonGem.Size = new System.Drawing.Size(75, 23);
            this.buttonGem.TabIndex = 1;
            this.buttonGem.Text = "Gem";
            this.buttonGem.UseVisualStyleBackColor = true;
            // 
            // buttonAnnuller
            // 
            this.buttonAnnuller.Location = new System.Drawing.Point(197, 226);
            this.buttonAnnuller.Name = "buttonAnnuller";
            this.buttonAnnuller.Size = new System.Drawing.Size(75, 23);
            this.buttonAnnuller.TabIndex = 2;
            this.buttonAnnuller.Text = "Annuller";
            this.buttonAnnuller.UseVisualStyleBackColor = true;
            // 
            // OpretBehandling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonAnnuller);
            this.Controls.Add(this.buttonGem);
            this.Controls.Add(this.textBox1);
            this.Name = "OpretBehandling";
            this.Text = "OpretBehandling";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonGem;
        private System.Windows.Forms.Button buttonAnnuller;
    }
}