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
    public partial class iller : Form
    {
        public iller()
        {
            InitializeComponent();
        }
        public void bilgigoster()
        {
            string rw = oleprojem.mi.Eval("Iller.rowid");
            oleprojem.mi.Do("select Area(obj, \"sq km\") from Iller where rowid=" + rw + " into alan noselect");
            lbl_rowid.Text = oleprojem.mi.Eval("iller.rowid");
            txt_ilAdi.Text = oleprojem.mi.Eval("iller.il_adi");
            txt_plakaNo.Text = oleprojem.mi.Eval("iller.plaka_no");
            txt_nufus90.Text = oleprojem.mi.Eval("iller.nufus_1990");
            txt_nufus97.Text = oleprojem.mi.Eval("iller.nufus_1997");
            txt_alan.Text = oleprojem.mi.Eval("alan.col1") + " km²";
        }
        private bool onay = false;
        private void vazgec()
        {
            if (onay == false)
            {
                oleprojem.mi.Do("rollback table line");
            }
            onay = false;
            this.Hide();
        }
        private void updateinfo()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update iller set il_adi=\"" + txt_ilAdi.Text + "\"");
                sb.Append(", plaka_no=\"" + txt_plakaNo.Text + "\"");
                sb.Append(", nufus_1990=\"" + txt_nufus90.Text + "\"");
                sb.Append(", nufus_1997=\"" + txt_nufus97.Text + "\"");
                sb.Append(" where rowid=" + lbl_rowid.Text);
                oleprojem.mi.Do(sb.ToString());
                oleprojem.mi.Do("commit table iller");
                onay = true;
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            updateinfo();
        }

        private void iller_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            vazgec();
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
             vazgec();
        }

    }
}
