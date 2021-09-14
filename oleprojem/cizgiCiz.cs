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
    public partial class cizgiCiz : Form
    {
        public cizgiCiz()
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

            //line ciz
            oleprojem.mi.Do("insert into line (obj) values(commandinfo(1))");
            oleprojem.mi.Do("fetch last from line");

            //alter object ile objeye stil,renk verebiliriz.
            //renk ve stil numaraları için mapbasic klasorunde "Mapbasic.def" e bakınız.

            string rowid = oleprojem.mi.Eval("line.rowid");
            oleprojem.mi.Do("select*from line where rowid=" + rowid + " into secim noselect");
            oleprojem.mi.Do("o=secim.obj");
            oleprojem.mi.Do("alter object o info 2, makepen (2,2,16711680)");
            oleprojem.mi.Do("update secim set obj=o");
            bilgigoster();
            this.Show();
        }

        public void bilgigoster()
        {
            
            lbl_rowid.Text = oleprojem.mi.Eval("line.rowid");
            txt_tip.Text = oleprojem.mi.Eval("line.tip");
            txt_ad.Text = oleprojem.mi.Eval("line.adi");

        }
        private bool onay = false;
        private void vazgec()
        {
            //kaydedilmemisse çizileni geri alır.

            if (onay == false)
            {
                oleprojem.mi.Do("rollback table line");
            }
            onay = false;
            this.Hide();
        }

        private void cizgiCiz_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            vazgec();

        }

        private void updateinfo()
        {
            //guncelle
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("update line set tip=\"" + txt_tip.Text + "\"");
                sb.Append(", adi=\"" + txt_ad.Text + "\"");
                sb.Append(" where rowid=" + lbl_rowid.Text);
                oleprojem.mi.Do(sb.ToString());
                oleprojem.mi.Do("commit table line");
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
        private void btn_sil_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Kayıt silinecektir, Devam Etmek istiyormusunuz?", "Dikkat",
                MessageBoxButtons.YesNoCancel);
            if (sonuc == DialogResult.Yes)
            {
                oleprojem.mi.Do("delete from line where rowid=" + lbl_rowid.Text);
                oleprojem.mi.Do("commit table line");
                this.Close();
            }
        }
        private void btn_kapat_Click(object sender, EventArgs e)
        {
            vazgec();
        }

           
        private void cizgiCiz_Load(object sender, EventArgs e)
        {

        }
    }
}
