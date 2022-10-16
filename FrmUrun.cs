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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities1 db = new DbEntityUrunEntities1();
        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.tblurun select new { x.urunID, x.urunAd, x.marka, x.stok, x.fiyat, x.tblkategori.AD, x.durum }).ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            tblurun t = new tblurun();
            t.urunAd = txturunad.Text;
            t.marka = txtmarka.Text;
            t.stok = short.Parse(textBox5.Text);
            t.kategori = short.Parse(comboBox1.Text);
            t.fiyat = decimal.Parse(txtfiyat.Text);
            t.durum = true;
            db.tblurun.Add(t);
            db.SaveChanges();
            MessageBox.Show("ürün eklendi");


        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var urun = db.tblurun.Find(x);
            db.tblurun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("ürün silindi");

        }

        private void btngun_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var urun = db.tblurun.Find(x);
            urun.urunAd = txturunad.Text;
            urun.marka = txtmarka.Text;
            urun.stok = short.Parse(textBox5.Text);
            db.SaveChanges();
            MessageBox.Show("güncellendi");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.tblkategori select new { x.ID, x.AD }).ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = kategoriler;
        }
    }
}
