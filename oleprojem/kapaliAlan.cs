using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oleprojem
{
    public partial class region : Form
    {
        public region()
        {
            InitializeComponent();
        }
        public void yenikayit()
        {
            try
            {
                oleprojem.mi.Do("undim o as object");
            }
            catch { }
            oleprojem.mi.Do("dim o as object");
            oleprojem.mi.Do("insert into region (obj) values(commandinfo(1))");
            oleprojem.mi.Do("fetch last from region");
            string rowid = oleprojem.mi.Eval("region.rowid");
            oleprojem.mi.Do("select*from region where rowid=" + rowid + " into secim noselect");
            oleprojem.mi.Do("o=secim.obj");
            oleprojem.mi.Do("alter object o info 3, makebrush(46, 11796288,-1)");// -1 arka planı transparan yapar
            oleprojem.mi.Do("update secim set obj=o");
            bilgigoster();
            this.ShowDialog();
        }

        public void bilgigoster()
        {
            lbl_rowid.Text = oleprojem.mi.Eval("region.rowid");
            txt_tip.Text = oleprojem.mi.Eval("region.tip");
            txt_ad.Text = oleprojem.mi.Eval("region.adi");
        }
        private void updateinfo()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update region set tip=\"" + txt_tip.Text + "\"");
                sb.Append(", adi=\"" + txt_ad.Text + "\"");
                sb.Append(" where rowid=" + lbl_rowid.Text);
                oleprojem.mi.Do(sb.ToString());
                oleprojem.mi.Do("commit table region automatic applyupdates");
                onay = true;
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void vazgec()
        {
            if (onay == false)
            {
                oleprojem.mi.Do("rollback table region");
            }
            onay = false;
            this.Hide();
        }
        private bool onay = false;

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            updateinfo();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Kayıt silinecektir, Devam Etmek istiyormusunuz?", "Dikkat",
                MessageBoxButtons.YesNoCancel);
            if (sonuc == DialogResult.Yes)
            {
                oleprojem.mi.Do("delete from region where rowid=" + lbl_rowid.Text);
                oleprojem.mi.Do("commit table region automatic applyupdates");
                this.Close();
            }
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            vazgec();
        }
        private void region_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            vazgec();
        }
    }
}
