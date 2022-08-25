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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        dbentityurunEntities db = new dbentityurunEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            var kategoriler = db.tbl_kategoriler.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            tbl_kategoriler t = new tbl_kategoriler();
            t.AD = textBox2.Text;
            db.tbl_kategoriler.Add(t);
            db.SaveChanges();
            MessageBox.Show("kayıt yapıldı");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktgr = db.tbl_kategoriler.Find(x);
            db.tbl_kategoriler.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi Yapıldı");

            
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktgr = db.tbl_kategoriler.Find(x);
            ktgr.AD = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Yapıldı");
        }
    }
}
