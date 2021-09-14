using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapInfo;
using System.IO;

namespace oleprojem
{
    public partial class oleprojem : Form
    {
        public oleprojem()
        {
            InitializeComponent();
            callb = new callback(this);
            infolist = new bilgi(this);

        }
        public static MapInfo.MapInfoApplication mi; //map class
        public string ws_path = string.Empty;
        public string gMainWinId;

        callback callb;

        private void oleprojem_Load(object sender, EventArgs e)
        {
            #region Mapinfo Kapat
            //Baska Mapinfo açık ise kapat

            foreach (System.Diagnostics.Process p in
                System.Diagnostics.Process.GetProcesses())
                if (p.ProcessName == "MapInfow" & p.MainWindowTitle == "")
                {
                    p.Kill();
                }
            #endregion

            mi = Activator.CreateInstance(Type.GetTypeFromProgID("Mapinfo.Application")) as MapInfo.MapInfoApplication;
            mi.SetCallback(callb);


            #region Kitli dosyaları açılışta sil

            //string[] files = System.IO.Directory.GetFiles(Application.StartupPath + "\\" + "data" + "\\");
            //foreach (string s in files)
            //{
            //    string filename = Path.GetFileName(s);
            //    string[] filenamesplit = filename.Split(new char[] { '.' });
            //    string uzanti = "." + filenamesplit[filenamesplit.Count() - 1].ToUpper();
            //    if (uzanti == ".LDA" || uzanti == ".LIN" || uzanti == ".LMA" ||
            //        uzanti == ".TDA" || uzanti == ".TIN" || uzanti == ".TMA")
            //    {
            //        System.IO.File.Delete(s);
            //    }
            //}
            #endregion

            int h = map.Handle.ToInt32();//panel1 formda oluşturulan panelin adı
            //her panelin bir handle numarası var ve bu no Int32 formuna çevrildi
            mi.Do("Set Next Document Parent " + h.ToString() + " Style 1");
            mi.Do("set application window " + h.ToString());
            ws_path = Application.StartupPath + "\\" + "deneme.wor";//MapInfo'dan projeye olustuşturduğumuz workspace
            mi.Do("Run Application \"" + ws_path + "\"");//uygulamanın akitive
            //olmasını sağlar
            gMainWinId = mi.Eval("windowid(0)");


            //OLE Baglanti icin buttonpad tanımlamaları

            mi.Do("create buttonpad \"a\" as toolbutton calling OLE \"bilgi\" id 2001");
            mi.Do("create buttonpad \"b\" as toolbutton calling OLE \"cizgiciz\" drawmode 36 id 2003");
            mi.Do("create buttonpad \"c\" as toolbutton calling OLE \"noktaAt\" id 2004");
            mi.Do("create buttonpad \"d\" as toolbutton calling OLE \"kapaliAlan\" drawmode 35 id 2005");

            mi.Do("dim o as object"); // degisken tanımla objeler icin
        }

        // Callback te cagırılacak form tanımlamaları

        cizgiCiz cizdir = new cizgiCiz();
        noktaAt noktaAtalim = new noktaAt();
        region kapaliAlan_form = new region();
        iller iller_form = new iller();
        public frminfoclick bilgiform;
        public bilgi infolist;

        public string _tabloadi = string.Empty;
       
        //Callback Delegate sınıflarının oluşturulması

        public delegate void mapinfo_delegate();


        //Fonksiyonlar
        //Callback içerisinden bura tetiklenecek fonksiyon isimleri ile aynı olmalı

        public void draw_line()
        {
            mapinfo_delegate callbackdelegate = new mapinfo_delegate(cizgi_ciz);
            this.Invoke(callbackdelegate);
        }
        public void cizgi_ciz()
        {
            cizdir.yenikayit();
        }
        public void nokta_At()
        {
            //delagate de parantez içerisindeki verilen isim
            //cagırılacak olan formu tetiklemelidir.
            //Bir alttaki fonksiyon ile burada parantez icerisinde yerAlan isim aynı dikkat!

            mapinfo_delegate callbackdelegate = new mapinfo_delegate(noktaAt);
            this.Invoke(callbackdelegate);
        }

        public void noktaAt()
        {
            //noktaAtalim formunu tetikle

            noktaAtalim.yenikayit();
        }

        public void kapaliAlan()
        {
            mapinfo_delegate callbackdelegate = new mapinfo_delegate(kapali_Alan);
            this.Invoke(callbackdelegate);
        }

        public void kapali_Alan()
        {
            kapaliAlan_form.yenikayit();
        }
        public void bilgi()
        {
            mapinfo_delegate callbackdelegate = new mapinfo_delegate(bilgi);
            this.Invoke(callbackdelegate);
        }

        public void bilgi_goster()
        {
            //tıklanılan yerde birden fazla obje var ise infolist formu ac
            //yok ise sadece bilgisini göster

            if (infolist.listcount() > 1)
                infolist.Show();
            else if (infolist.listcount() == 1) 
                bilgi_goster(_tabloadi);
        }
        public void bilgi_goster(string tabloadi)
        {
            if (tabloadi == "line")
            {
                cizdir.bilgigoster();
                cizdir.Show();
            }
            if (tabloadi == "point")
            {
                noktaAtalim.bilgigoster();
                noktaAtalim.Show();
            }
            if (tabloadi == "region")
            {
                kapaliAlan_form.bilgigoster();
                kapaliAlan_form.Show();
            }
            if (tabloadi == "Iller")
            {
                iller_form.bilgigoster();
                iller_form.Show();
            }
            infolist.Focus();
        }

        private void btn_cizgiCiz_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command id 2003");
        }
        private void btn_kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_noktaAt_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command id 2004");
        }

        private void btn_region_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command id 2005");
        }
      
        private void btn_bilgi_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command id 2001");
        }


        private void btn_zoomin_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command 1705");
        }

        private void btn_zoomout_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command 1706");
        }

        private void btn_pan_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command 1702");
        }

        private void btn_sec_Click(object sender, EventArgs e)
        {
            mi.Do("run menu command 1701");
        }
        private void btn_yukle_Click(object sender, EventArgs e)
        {
            mi.Do("select il_adi from iller where il_adi<>\"\" order by il_adi into seliller noselect");
            int count = int.Parse(mi.Eval("tableinfo(seliller,8)"));
            mi.Do("fetch first from seliller");
            for (int i = 0; i < count; i++)
            {
                cmb_iller.Items.Add(mi.Eval("seliller.col1"));
                mi.Do("fetch next from seliller");
            }
        }

        private void cmb_iller_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_ilceler.Items.Clear();
            string ilAdi = cmb_iller.Text;
            if (ilAdi != "İl Seçiniz")
            {
                mi.Do("select * from iller where il_adi=\"" + ilAdi + "\" into selsec");
            }
            if (int.Parse(mi.Eval("tableinfo(selsec,8)")) > 0)
            {
                mi.Do("add map window frontwindow() layer selsec");
                mi.Do("set map window frontwindow() Zoom Entire Layer selsec");
                mi.Do("remove map window frontwindow() layer selsec");
            }
            mi.Do("select ilceadi from ilceler where iladi=\"" + cmb_iller.Text + "\" order by ilceadi into selilceler noselect");

            int count = int.Parse(mi.Eval("tableinfo(selilceler,8)"));

            for (int i = 0; i < count; i++)
            {
                cmb_ilceler.Items.Add(mi.Eval("selilceler.col1"));
                mi.Do("fetch next from selilceler");
            }


        }


        private void cmb_ilceler_SelectedIndexChanged(object sender, EventArgs e)
        {
            mi.Do("select*from ilceler where iladi=\"" + cmb_iller.Text + "\" and ilceadi=\"" + cmb_ilceler.Text + "\"into sel");
            mi.Do("add map layer sel");
            mi.Do("set map zoom entire layer sel");
        }

        internal void cb_Status(string statusText)
        {
            throw new NotImplementedException();
        }
        public bilgi infolist_form { get; set; }
    }
      
}