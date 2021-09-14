using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace oleprojem
{
    public partial class noktaAt : Form
    {
        public noktaAt()
        {
            InitializeComponent();

        }
        public void yenikayit()
        {
            try
            {
                oleprojem.mi.Do("undim o as object");

            }
            catch
            {

            }
            oleprojem.mi.Do("dim o as object");
            oleprojem.mi.Do("o=createpoint(commandinfo(1),commandinfo(2))");
            oleprojem.mi.Do("insert into point (obj) values (o)");
            oleprojem.mi.Do("fetch last from point");
            string rowid = oleprojem.mi.Eval("point.rowid");
            oleprojem.mi.Do("select*from point where rowid=" + rowid + " into secim noselect");
            oleprojem.mi.Do("o=secim.obj");
            oleprojem.mi.Do("alter object o info 2, makesymbol(34, 16776960, 12)");
            oleprojem.mi.Do("update secim set obj=o");
            bilgigoster();
            this.Show();
        }

        public void bilgigoster()
        {
            lbl_rowid.Text = oleprojem.mi.Eval("point.rowid");
            txt_tip.Text = oleprojem.mi.Eval("point.tipi");
            txt_ad.Text = oleprojem.mi.Eval("point.adi");
        }

        private bool onay = false;

        private void noktaAt_Load(object sender, EventArgs e)
        {

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            updateinfo();
        }
        private void updateinfo()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update point set tipi=\"" + txt_tip.Text + "\"");
                sb.Append(", adi=\"" + txt_ad.Text + "\"");
                sb.Append(" where rowid=" + lbl_rowid.Text);
                oleprojem.mi.Do(sb.ToString());
                oleprojem.mi.Do("commit table point automatic applyupdates");
                onay = true;
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Kayıt silinecektir, Devam Etmek istiyormusunuz?", "Dikkat",
                MessageBoxButtons.YesNoCancel);
            if (sonuc == DialogResult.Yes)
            {
                oleprojem.mi.Do("delete from point where rowid=" + lbl_rowid.Text);
                oleprojem.mi.Do("commit table point automatic applyupdates");
                this.Hide();
            }
        }
        private void vazgec()
        {
            if (onay == false)
            {
                oleprojem.mi.Do("rollback table point");
            }
            onay = false;
            this.Hide();
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            vazgec();
        }
        private void noktaAt_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            vazgec();
        }
        internal void yenikayıt()
        {
            throw new NotImplementedException();
        }
    }
}
