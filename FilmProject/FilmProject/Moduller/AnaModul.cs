using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FilmProject.Moduller;

namespace FilmProject.Moduller
{
    public partial class AnaModul : Form
    {
        public AnaModul()
        {
            InitializeComponent();
        }
        KategoriListesi k;
        FilmListesi f;
        OyuncuListesi o;  // Diğer formlarımızı göstermek için nesne türetiyoruz
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Aynı sayfayı butona her basıldığında açmaması adına kontrollü şekilde açtırıyoruz
            // Eğer form zaten açıksa tekrar açmak yerine sadece öne çıkaracak
            if (f==null || f.IsDisposed)
            {
                f = new FilmListesi();
                f.Show();
            }
            else
            {
                f.Focus();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // Aynı sayfayı butona her basıldığında açmaması adına kontrollü şekilde açtırıyoruz
            // Eğer form zaten açıksa tekrar açmak yerine sadece öne çıkaracak
            if (k == null || k.IsDisposed)
            {
                k = new KategoriListesi();
                k.Show();
            }
            else
            {
                k.Focus();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            // Aynı sayfayı butona her basıldığında açmaması adına kontrollü şekilde açtırıyoruz
            // Eğer form zaten açıksa tekrar açmak yerine sadece öne çıkaracak
            if (o == null || o.IsDisposed)
            {
                o = new OyuncuListesi();
                o.Show();
            }
            else
            {
                o.Focus();
            }
        }
    }
}
