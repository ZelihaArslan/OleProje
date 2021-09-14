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
    public partial class bilgi : Form
    {
        public bilgi(Form _anaform)
        {
            InitializeComponent();
           anaform = _anaform;
        }
        string tabloadi = "";
        Form anaform;

        public void listeye_ekle(string info, string rowid, string xx)
        {
            ListViewItem lvi = new ListViewItem(new string[] { info, rowid, xx });
            lvi.Tag = rowid;
            listView1.Items.Add(lvi);

        }
        public void listeyi_temizle()
        {
            listView1.Items.Clear();
            tabloadi = "";
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void infolist_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public string get_tablename()
        {
            return tabloadi;
        }
        public int listcount()
        {
            return listView1.Items.Count;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listView1.SelectedItems.Count > 0)
            //{
            //    tabloadi = listView1.SelectedItems[0].Text;
            //    DefaultMI.mi.Do("Fetch rec " + listView1.SelectedItems[0].Tag.ToString() + " From " + tabloadi);
            //    ((DefaultMI)anaform).bilgi_goster(tabloadi);

            //}
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    tabloadi = listView1.SelectedItems[0].Text;
                    oleprojem.mi.Do("Fetch rec " + listView1.SelectedItems[0].Tag.ToString() + " From " + tabloadi);
                    ((oleprojem)anaform).bilgi_goster(tabloadi);
                }
            }
            catch { MessageBox.Show("Lütfen Formu kapatıp tekrar bilgi almayı deneyiniz!", "Dikkat"); }
        
        }
    }
}
