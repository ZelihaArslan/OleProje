namespace oleprojem
{
    partial class oleprojem
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
            this.btn_zoomin = new System.Windows.Forms.Button();
            this.btn_zoomout = new System.Windows.Forms.Button();
            this.btn_pan = new System.Windows.Forms.Button();
            this.btn_sec = new System.Windows.Forms.Button();
            this.btn_kapat = new System.Windows.Forms.Button();
            this.map = new System.Windows.Forms.Panel();
            this.cmb_iller = new System.Windows.Forms.ComboBox();
            this.cmb_ilceler = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_yukle = new System.Windows.Forms.Button();
            this.btn_cizgiCiz = new System.Windows.Forms.Button();
            this.btn_noktaAt = new System.Windows.Forms.Button();
            this.btn_region = new System.Windows.Forms.Button();
            this.btn_bilgi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_zoomin
            // 
            this.btn_zoomin.Location = new System.Drawing.Point(12, 29);
            this.btn_zoomin.Name = "btn_zoomin";
            this.btn_zoomin.Size = new System.Drawing.Size(75, 23);
            this.btn_zoomin.TabIndex = 0;
            this.btn_zoomin.Text = "zoom in";
            this.btn_zoomin.UseVisualStyleBackColor = true;
            this.btn_zoomin.Click += new System.EventHandler(this.btn_zoomin_Click);
            // 
            // btn_zoomout
            // 
            this.btn_zoomout.Location = new System.Drawing.Point(93, 28);
            this.btn_zoomout.Name = "btn_zoomout";
            this.btn_zoomout.Size = new System.Drawing.Size(75, 23);
            this.btn_zoomout.TabIndex = 1;
            this.btn_zoomout.Text = "zoom out";
            this.btn_zoomout.UseVisualStyleBackColor = true;
            this.btn_zoomout.Click += new System.EventHandler(this.btn_zoomout_Click);
            // 
            // btn_pan
            // 
            this.btn_pan.Location = new System.Drawing.Point(174, 28);
            this.btn_pan.Name = "btn_pan";
            this.btn_pan.Size = new System.Drawing.Size(75, 23);
            this.btn_pan.TabIndex = 2;
            this.btn_pan.Text = "pan";
            this.btn_pan.UseVisualStyleBackColor = true;
            this.btn_pan.Click += new System.EventHandler(this.btn_pan_Click);
            // 
            // btn_sec
            // 
            this.btn_sec.Location = new System.Drawing.Point(255, 29);
            this.btn_sec.Name = "btn_sec";
            this.btn_sec.Size = new System.Drawing.Size(75, 23);
            this.btn_sec.TabIndex = 3;
            this.btn_sec.Text = "seç";
            this.btn_sec.UseVisualStyleBackColor = true;
            this.btn_sec.Click += new System.EventHandler(this.btn_sec_Click);
            // 
            // btn_kapat
            // 
            this.btn_kapat.Location = new System.Drawing.Point(667, 28);
            this.btn_kapat.Name = "btn_kapat";
            this.btn_kapat.Size = new System.Drawing.Size(75, 23);
            this.btn_kapat.TabIndex = 4;
            this.btn_kapat.Text = "kapat";
            this.btn_kapat.UseVisualStyleBackColor = true;
            this.btn_kapat.Click += new System.EventHandler(this.btn_kapat_Click);
            // 
            // map
            // 
            this.map.Location = new System.Drawing.Point(12, 58);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(626, 244);
            this.map.TabIndex = 5;
            // 
            // cmb_iller
            // 
            this.cmb_iller.FormattingEnabled = true;
            this.cmb_iller.Location = new System.Drawing.Point(684, 78);
            this.cmb_iller.Name = "cmb_iller";
            this.cmb_iller.Size = new System.Drawing.Size(121, 21);
            this.cmb_iller.TabIndex = 6;
            this.cmb_iller.Text = "il seçiniz";
            this.cmb_iller.SelectedIndexChanged += new System.EventHandler(this.cmb_iller_SelectedIndexChanged);
            // 
            // cmb_ilceler
            // 
            this.cmb_ilceler.FormattingEnabled = true;
            this.cmb_ilceler.Location = new System.Drawing.Point(684, 135);
            this.cmb_ilceler.Name = "cmb_ilceler";
            this.cmb_ilceler.Size = new System.Drawing.Size(121, 21);
            this.cmb_ilceler.TabIndex = 7;
            this.cmb_ilceler.Text = "ilçe seçiniz";
            this.cmb_ilceler.SelectedIndexChanged += new System.EventHandler(this.cmb_ilceler_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(644, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "iller";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(644, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "ilçeler";
            // 
            // btn_yukle
            // 
            this.btn_yukle.Location = new System.Drawing.Point(647, 172);
            this.btn_yukle.Name = "btn_yukle";
            this.btn_yukle.Size = new System.Drawing.Size(75, 23);
            this.btn_yukle.TabIndex = 10;
            this.btn_yukle.Text = "içeriği yükle";
            this.btn_yukle.UseVisualStyleBackColor = true;
            this.btn_yukle.Click += new System.EventHandler(this.btn_yukle_Click);
            // 
            // btn_cizgiCiz
            // 
            this.btn_cizgiCiz.Location = new System.Drawing.Point(336, 28);
            this.btn_cizgiCiz.Name = "btn_cizgiCiz";
            this.btn_cizgiCiz.Size = new System.Drawing.Size(75, 23);
            this.btn_cizgiCiz.TabIndex = 14;
            this.btn_cizgiCiz.Text = "çizgi çiz";
            this.btn_cizgiCiz.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_cizgiCiz.UseVisualStyleBackColor = true;
            this.btn_cizgiCiz.Click += new System.EventHandler(this.btn_cizgiCiz_Click);
            // 
            // btn_noktaAt
            // 
            this.btn_noktaAt.Location = new System.Drawing.Point(417, 28);
            this.btn_noktaAt.Name = "btn_noktaAt";
            this.btn_noktaAt.Size = new System.Drawing.Size(75, 23);
            this.btn_noktaAt.TabIndex = 12;
            this.btn_noktaAt.Text = "nokta at";
            this.btn_noktaAt.UseVisualStyleBackColor = true;
            this.btn_noktaAt.Click += new System.EventHandler(this.btn_noktaAt_Click);
            // 
            // btn_region
            // 
            this.btn_region.Location = new System.Drawing.Point(499, 29);
            this.btn_region.Name = "btn_region";
            this.btn_region.Size = new System.Drawing.Size(75, 23);
            this.btn_region.TabIndex = 13;
            this.btn_region.Text = "kapalı alan oluştur";
            this.btn_region.UseVisualStyleBackColor = true;
            this.btn_region.Click += new System.EventHandler(this.btn_region_Click);
            // 
            // btn_bilgi
            // 
            this.btn_bilgi.Location = new System.Drawing.Point(581, 27);
            this.btn_bilgi.Name = "btn_bilgi";
            this.btn_bilgi.Size = new System.Drawing.Size(75, 23);
            this.btn_bilgi.TabIndex = 14;
            this.btn_bilgi.Text = "bilgi";
            this.btn_bilgi.UseVisualStyleBackColor = true;
            // 
            // oleprojem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 314);
            this.Controls.Add(this.btn_bilgi);
            this.Controls.Add(this.btn_region);
            this.Controls.Add(this.btn_noktaAt);
            this.Controls.Add(this.btn_cizgiCiz);
            this.Controls.Add(this.btn_yukle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_ilceler);
            this.Controls.Add(this.cmb_iller);
            this.Controls.Add(this.map);
            this.Controls.Add(this.btn_kapat);
            this.Controls.Add(this.btn_sec);
            this.Controls.Add(this.btn_pan);
            this.Controls.Add(this.btn_zoomout);
            this.Controls.Add(this.btn_zoomin);
            this.Name = "oleprojem";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.oleprojem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.Button btn_zoomin;
        private System.Windows.Forms.Button btn_zoomout;
        private System.Windows.Forms.Button btn_pan;
        private System.Windows.Forms.Button btn_sec;
        private System.Windows.Forms.Button btn_kapat;
        private System.Windows.Forms.Panel map;
        private System.Windows.Forms.ComboBox cmb_iller;
        private System.Windows.Forms.ComboBox cmb_ilceler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_yukle;
        private System.Windows.Forms.Button btn_cizgiCiz;
        private System.Windows.Forms.Button btn_noktaAt;
        private System.Windows.Forms.Button btn_region;
        private System.Windows.Forms.Button btn_bilgi;
    }
}

