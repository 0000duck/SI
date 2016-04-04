using System.Windows.Forms;
using System.IO;

namespace SztucznaInteligencja
{
    class Otwieracz
    {
        OpenFileDialog ofd = new OpenFileDialog();

        bool odczytUdany = false;
        string nazwaPliku;
        string pelnyAdresPliku;
        string[] zawartoscPliku;


        public void ChooseFile()
        {
            ofd.Filter = "DXF|*.dxf";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                nazwaPliku = ofd.SafeFileName;
                pelnyAdresPliku = ofd.FileName;
                zawartoscPliku = File.ReadAllLines(ofd.FileName);
                odczytUdany = true;
            }
        }

        public bool czyOdczytUdany()
        {
            return odczytUdany;
        }
        public string podajNazwePliku()
        {
            return nazwaPliku;
        }
        public string[] podajZawartoscPliku()
        {
            return zawartoscPliku;
        }
    }
}
