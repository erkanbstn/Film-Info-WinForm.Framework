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
    public partial class FilmListesi : Form
    {
        public FilmListesi()
        {
            InitializeComponent();
        }
        void Listele()
        {
            // Tablolarımızı listelemek için kod tekrarını önlemek adına method oluşturuyoruz
            gridControl1.DataSource = (from x in Baglanti.db.TFilm select new { x.ID, x.Poster, x.Film, x.Yil, x.TKategori.Kategori }).ToList();
            // Grid aracında Veritabanındaki FİLM tablosunu listeletiyoruz


            // Combobox aracından Kategorileri kolaylıkla seçmek için yazdığımız kod
            cmbKategori.DataSource = Baglanti.db.TKategori.ToList();
            cmbKategori.DisplayMember = "Kategori";
            cmbKategori.ValueMember = "ID";
        }
        private void FilmListesi_Load(object sender, EventArgs e)
        {
            Listele(); // Form açıldığında görmek adına methodumuzu çağırıyoruz.
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Grid aracındaki hücrelere çift tıkladığımızda gerçekleşecek olaylar
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtPoster.Text = gridView1.GetFocusedRowCellValue("Poster").ToString();
            txtFilm.Text = gridView1.GetFocusedRowCellValue("Film").ToString();
            txtYil.Text = gridView1.GetFocusedRowCellValue("Yil").ToString();
            // Hücrelerimzideki bilgileri araçlarımıza taşıma işlemi
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Listele(); // Listele butonumuza tıklandığına gerçekleşecek olay olarak Listeleme methodumuzu yazıyoruz
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // Yeni film eklemek için butonumuza bastığımızda
            // Tablomuzdan türettiğimiz nesne aracılığı ile kolonlarımıza erişip değer ataması yapıyoruz
            // Ardından veritabanına ekleme işlemini gerçekleştiriyoruz.
            TFilm f = new TFilm();
            f.Film = txtFilm.Text;
            f.Poster = txtPoster.Text;
            f.Yil = txtYil.Text;
            f.Kategori = cmbKategori.SelectedIndex;
            Baglanti.db.TFilm.Add(f);
            Baglanti.db.SaveChanges(); //  Veritabanına ekleme işlemi gerçekleşiyor
            Listele(); // Değişiklikleri anında görebilmek için Listeleme methodumuzu tekrar çağırıyoruz.
            MessageBox.Show("Kayıt İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information); // Kullanıcıyı bilgilendirme amaçlı mesaj kutumuzu gösteriyoruz.
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            // Veritabanından ilgili filmi silme işlemi için butonumuzun tıklanma olayına geliyoruz
            // Burada Filmlerimizin ID sini bulup seçtikten sonra o ID yi silme işlemi gerçkeştiriyoruz
            int id = Convert.ToInt32(txtID.Text);
            var x = Baglanti.db.TFilm.Find(id);
            Baglanti.db.TFilm.Remove(x);
            Baglanti.db.SaveChanges();
            Listele(); // Değişiklikleri anında görebilmek için Listeleme methodumuzu tekrar çağırıyoruz.
            MessageBox.Show("Silme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information); // Kullanıcıyı bilgilendirme amaçlı mesaj kutumuzu gösteriyoruz.
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            // Veritabanından ilgili filmi güncelleme işlemi için butonumuzun tıklanma olayına geliyoruz
            // Burada Filmlerimizin ID sini bulup seçtikten sonra o ID ye ait bilgileri güncelleme işlemi gerçkeştiriyoruz
            int id = Convert.ToInt32(txtID.Text);
            var f = Baglanti.db.TFilm.Find(id);
            f.Film = txtFilm.Text;
            f.Poster = txtPoster.Text;
            f.Yil = txtYil.Text;
            f.Kategori = cmbKategori.SelectedIndex;
            Baglanti.db.SaveChanges();
            Listele(); // Değişiklikleri anında görebilmek için Listeleme methodumuzu tekrar çağırıyoruz.
            MessageBox.Show("Güncelleme İşlemi Başarılı", "Bilgilendirme Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information); // Kullanıcıyı bilgilendirme amaçlı mesaj kutumuzu gösteriyoruz.
        }
    }
}
