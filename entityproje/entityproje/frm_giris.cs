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
    public partial class frm_giris : Form
    {
        public frm_giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           dbentityurunEntities db = new dbentityurunEntities();
           var sorgu = from x in db.tbl_admin where x.KULLANICI == textBox1.Text && x.SİFRE == textBox2.Text select x;
            if (sorgu.Any())
            {
                frmanaform fr = new frmanaform();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı KUllanıcı Adı ya da Şifre", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
