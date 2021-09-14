using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace oleprojem
{
     [ComVisible(true)]
  public  class callback
    {
         public string statusText;
         oleprojem anaform;
         public callback(oleprojem _anaform)
        { 
            anaform = _anaform;
        }

        public long WindowContentsChanged(long windowID)
        {
            long id;
            id = windowID;
            return 0;
        }

        //Buttonpad de tanımlanan isim ile
        //callback içerisinde yer alan isimlerin aynı olması gereklidir.

        public void cizgiciz(string cizgiciz)
        {
            anaform.draw_line();
        }
        public void noktaAt(string noktaAt)
        {
            anaform.nokta_At();
        }
        public void kapaliAlan(string kapaliAlan)
        {
            anaform.kapali_Alan();
        }
        
        //info tool
        //Tıklanan yerin x ve y koordinatları
        //Koordinatlarda yer alan tablo isimlerinin alınması ve istenilen kısımlara yonlendirilmesi

        public void info(string bisiler)
        {
            string x = oleprojem.mi.Eval("format$(commandinfo(1), \",#######.###########\")").Replace(',', '.');
            string y = oleprojem.mi.Eval("format$(commandinfo(2), \",#######.###########\")").Replace(',', '.');
            string tabloadi = string.Empty;
            int i_found = Convert.ToInt32(oleprojem.mi.Eval("SearchPoint(" + ((oleprojem)anaform).gMainWinId + "," + x + "," + y + ")"));
            string row_id;
            if (i_found > 0)//tıklanılan yerde tablo var ise
            {
                anaform.infolist = new bilgi(anaform);
                anaform.infolist.listeyi_temizle();

                string _tabloadi = string.Empty;
                for (int i = 1; i <= i_found; i++)
                {
                    tabloadi = oleprojem.mi.Eval("SearchInfo(" + i.ToString() + ",1)");
                    row_id = oleprojem.mi.Eval("SearchInfo(" + i.ToString() + ",2)");
                    oleprojem.mi.Do("Fetch rec " + row_id + " From " + tabloadi);
                    if ((!tabloadi.StartsWith("sel")))// Haritada sel ile baslayan gecici tabloları dikkate alma
                    {
                        if (tabloadi == "line")
                            anaform.infolist.listeye_ekle(tabloadi, row_id, oleprojem.mi.Eval(tabloadi + ".adi"));
                        if (tabloadi == "point")
                            anaform.infolist.listeye_ekle(tabloadi, row_id, oleprojem.mi.Eval(tabloadi + ".adi"));
                        if (tabloadi == "region")
                            anaform.infolist.listeye_ekle(tabloadi, row_id, oleprojem.mi.Eval(tabloadi + ".adi"));
                        if (tabloadi == "Iller")
                            anaform.infolist.listeye_ekle(tabloadi, row_id, oleprojem.mi.Eval(tabloadi + ".il_adi"));_tabloadi = tabloadi;
                    }
                    anaform._tabloadi = _tabloadi;
                }
                anaform.bilgi();
            }
          }
        }
     }
        
   

