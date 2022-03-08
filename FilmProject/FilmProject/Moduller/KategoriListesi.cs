using FilmProject.Enity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmProject.Moduller
{
    public partial class KategoriListesi : Form
    {
        public KategoriListesi()
        {
            InitializeComponent();
        }
        void Listele()
        {
            // Durum kolonu true olan kayıtları listeletiyoruz
            // Tablolarımızı listelemek için kod tekrarını önlemek adına method oluşturuyoruz
            gridControl1.DataSource = (from x in Baglanti.db.TKategori where x.Durum == true select new { x.ID, x.Kategori }).ToList();
            // Grid aracında Veritabanındaki KATEGORİ tablosunu listeletiyoruz
        }
        private void KategoriListesi_Load(object sender, EventArgs e)
        {
            Listele(); // Form açıldığında görmek adına methodumuzu çağırıyoruz.
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Listele(); // Listele butonumuza tıklandığına gerçekleşecek olay olarak Listeleme methodumuzu yazıyoruz
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            // Veritabanından ilgili kategoriyi silme işlemi için butonumuzun tıklanma olayına geliyoruz
            // Burada Kategorilerimizin ID sini bulup seçtikten sonra o ID yi silme işlemi gerçkeştiriyoruz
            int id = Convert.ToInt32(txtID.Text);
            var x = Baglanti.db.TKategori.Find(id);
            x.Durum = false; // Silme işlemi bu kategoriyi kullanan bir film olduğunda sorun olabileceğinden dolayı DURUM kolonumuzu sadece false yaparak sadece listelenmesini önlüyoruz
            Baglanti.db.SaveChanges();
            Listele(); // Değişiklikleri anında görebilmek için Listeleme methodumuzu tekrar çağırıyoruz.
            MessageBox.Show("Silme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information); // Kullanıcıyı bilgilendirme amaçlı mesaj kutumuzu gösteriyoruz.
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            // Veritabanından ilgili kategoriyi güncelleme işlemi için butonumuzun tıklanma olayına geliyoruz
            // Burada Kategorilerimizin ID sini bulup seçtikten sonra o ID ye ait bilgileri güncelleme işlemi gerçkeştiriyoruz
            int id = Convert.ToInt32(txtID.Text);
            var f = Baglanti.db.TKategori.Find(id);
            f.Kategori = txtKategori.Text;
            Baglanti.db.SaveChanges();
            Listele(); // Değişiklikleri anında görebilmek için Listeleme methodumuzu tekrar çağırıyoruz.
            MessageBox.Show("Güncelleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information); // Kullanıcıyı bilgilendirme amaçlı mesaj kutumuzu gösteriyoruz.
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // Yeni Kategori eklemek için butonumuza bastığımızda
            // Tablomuzdan türettiğimiz nesne aracılığı ile kolonlarımıza erişip değer ataması yapıyoruz
            // Ardından veritabanına ekleme işlemini gerçekleştiriyoruz.
            TKategori f = new TKategori();
            f.Kategori = txtKategori.Text;
            f.Durum = true; // Varsayılan olarak listelenmesi için başta True değeri veriyoruz
            Baglanti.db.TKategori.Add(f);
            Baglanti.db.SaveChanges(); //  Veritabanına ekleme işlemi gerçekleşiyor
            Listele(); // Değişiklikleri anında görebilmek için Listeleme methodumuzu tekrar çağırıyoruz.
            MessageBox.Show("Kayıt İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information); // Kullanıcıyı bilgilendirme amaçlı mesaj kutumuzu gösteriyoruz.
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Grid aracındaki hücrelere çift tıkladığımızda gerçekleşecek olaylar
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtKategori.Text = gridView1.GetFocusedRowCellValue("Kategori").ToString();
            // Hücrelerimzideki bilgileri araçlarımıza taşıma işlemi
        }
    }
}
