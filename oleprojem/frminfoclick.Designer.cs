namespace oleprojem
{
    partial class frminfoclick
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
            this.lbtablolar = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbtablolar
            // 
            this.lbtablolar.FormattingEnabled = true;
            this.lbtablolar.Location = new System.Drawing.Point(24, 18);
            this.lbtablolar.Name = "lbtablolar";
            this.lbtablolar.Size = new System.Drawing.Size(152, 212);
            this.lbtablolar.TabIndex = 0;
            // 
            // frminfoclick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lbtablolar);
            this.Name = "frminfoclick";
            this.Text = "frminfoclick";
            this.Load += new System.EventHandler(this.frminfoclick_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbtablolar;
    }
}