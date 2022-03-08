using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmProject.Enity
{
    public static class Baglanti
    { // Veritabanı bağlantılarımız ve tablolarımıza erişimimiz için oluşturduğumuz Statik sınıf.
        public static FilmDBEntities db = new FilmDBEntities();
        // Veritabanındaki tablolarımıza erişmek için Entity modelimizden bir nesne türetiyoruz.
    }
}
