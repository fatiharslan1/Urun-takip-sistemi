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
    public partial class frm_urunler : Form
    {
        public frm_urunler()
        {
            InitializeComponent();
        }

        dbentityurunEntities db = new dbentityurunEntities();

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.tbl_urunler
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.FIYAT,
                                            x.tbl_kategoriler.AD,
                                            x.STOK,
                                            x.DURUM,
                                        }).ToList() ;
            
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            tbl_urunler t = new tbl_urunler();
            t.URUNAD = txturun.Text;
            t.MARKA = txtmarka.Text;
            t.STOK = short.Parse(txtstok.Text);
            t.FIYAT = decimal.Parse(txtfiyat.Text);
            t.DURUM = true;
            t.KATEGORİ = int.Parse(comboBox1.SelectedValue.ToString());
            db.tbl_urunler.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Yapıldı");

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var urun = db.tbl_urunler.Find(x);
            db.tbl_urunler.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Yapıldı");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var urun = db.tbl_urunler.Find(x);
            urun.URUNAD = txturun.Text;
            urun.FIYAT = decimal.Parse(txtfiyat.Text);
            urun.STOK = short.Parse(txtstok.Text);
            urun.MARKA = txtmarka.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Yapıldı");


        }

        private void frm_urunler_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.tbl_kategoriler
                               select new
                               {
                                   x.ID,
                                   x.AD
                               }
                               ).ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = kategoriler;
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txturun.Text = "";
            txtmarka.Text = "";
            txtstok.Text = "";
            txtfiyat.Text = "";
            txtdurum.Text = "";
            comboBox1.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txturun.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtmarka.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtstok.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

        }
    }
}
