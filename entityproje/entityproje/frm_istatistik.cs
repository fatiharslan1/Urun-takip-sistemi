using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entityproje
{
    public partial class frm_istatistik : Form
    {
        public frm_istatistik()
        {
            InitializeComponent();
        }

        dbentityurunEntities db = new dbentityurunEntities();

        private void frm_istatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.tbl_kategoriler.Count().ToString();
            label21.Text = db.tbl_urunler.Count().ToString();
            label5.Text = db.tbl_musteriler.Count(x => x.DURUM == true).ToString();
            label23.Text = db.tbl_musteriler.Count(x => x.DURUM == false ).ToString();
            label17.Text = db.tbl_urunler.Sum(x => x.STOK).ToString();
            label11.Text = db.tbl_satis.Sum(z => z.FIYAT).ToString() + " TL";
            label25.Text = (from x in db.tbl_urunler orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();
            label7.Text = (from x in db.tbl_urunler orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault();
            label19.Text = db.tbl_urunler.Count(x => x.KATEGORİ == 1).ToString();
            label15.Text = (from x in db.tbl_satis orderby x.URUN ascending select x.URUN).FirstOrDefault().ToString();
            label9.Text = (from x in db.tbl_musteriler select x.SEHIR).Distinct().Count().ToString();
            label13.Text = db.MARKAGETİR().FirstOrDefault();
        }
    }
}
