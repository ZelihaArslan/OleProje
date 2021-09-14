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
    public partial class frminfoclick : Form
    {
        oleprojem harita;
        public frminfoclick(oleprojem _anaform)
        {
            InitializeComponent();
            harita = _anaform;
        }

        private void frminfoclick_Load(object sender, EventArgs e)
        {

        }
        public void listeyi_temizle()
        {
            lbtablolar.Items.Clear();
        }
        public void listeye_ekle(string tablo_adi)
        {
            lbtablolar.Items.Add(tablo_adi);
        }
    }
}
