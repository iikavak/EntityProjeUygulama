using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EntityProjeUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities1 db= new DbEntityUrunEntities1();
        private void btnlistele_Click(object sender, EventArgs e)
        {
            var kategoriler= db.tblkategori.ToList();
            dataGridView1.DataSource= kategoriler;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            tblkategori t= new tblkategori();
            t.AD = textBox2.Text;
            db.tblkategori.Add(t);
            db.SaveChanges();
            MessageBox.Show("kategori eklendi");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x=Convert.ToInt32(textBox1.Text);
            var ktgr = db.tblkategori.Find(x);
            db.tblkategori.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");
        }

        private void btngun_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktgr = db.tblkategori.Find(x);
            ktgr.AD = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");
        }
    }
}
