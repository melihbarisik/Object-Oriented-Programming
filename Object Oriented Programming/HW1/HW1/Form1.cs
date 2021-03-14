/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2014-2015 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........:1
**				ÖĞRENCİ ADI............:Melih Ensar Barışık
**				ÖĞRENCİ NUMARASI.......:B181210393
**              DERSİN ALINDIĞI GRUP...:D
****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SurukleBirak
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog destinationFile = new OpenFileDialog();

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (destinationFile.ShowDialog() == DialogResult.OK)
            {

                string dosyaYolu = destinationFile.FileName.ToString();
                richTextBoxPersonelBilgileri.Text = System.IO.File.ReadAllText(dosyaYolu, Encoding.GetEncoding("windows-1254"));
                // Ekrandan seçilen bilgileri richtextbox kısmına yazdırıyor.
            }

        }
       
        private void buttonPersonelMaasHesapla_Click(object sender, EventArgs e)
        {
            if (textBoxArananTc.Text != "")
            {

                int kontrol = 0;
                string tümVeri;
                string[] satirlar;

                tümVeri = richTextBoxPersonelBilgileri.Text;
                satirlar = tümVeri.Split('\n');
                double brutMaas;
                double damgaVergisi;
                double gelirVergisi;
                double emeklilikKesintisi;
                double maas;

                pictureBoxPersonelResmi.SizeMode = PictureBoxSizeMode.StretchImage;


                foreach (string s in satirlar)
                {

                    string[] kelimeler = s.Split(' ');



                    if (textBoxArananTc.Text == kelimeler[0])
                    {  // kelimeler dizi elemanlarının karşılık geldikleri textlere yazdırıyor.
                        kontrol = 1;
                        textBoxAd.Text = kelimeler[1];
                        textBoxSoyAd.Text = kelimeler[2];
                        textBoxYas.Text = kelimeler[3];
                        textBoxCalısmaSüresi.Text = kelimeler[4];
                        textBoxEvlilikDurumu.Text = kelimeler[5];
                        textBoxEsiCalisiyorMu.Text = kelimeler[6];
                        textBoxCocukSayisi.Text = kelimeler[7];

                        textBoxTabanMaas.Text = kelimeler[8];
                        textBoxMakamTazminati.Text = kelimeler[9];
                        textBoxIdariGorevTaz.Text = kelimeler[10];
                        textBoxFazlaMesaiSaati.Text = kelimeler[11];
                        textBoxFazlaMesaiUcr.Text = kelimeler[12];
                        textBoxVergiMatrahi.Text = kelimeler[13];
                        

                        pictureBoxPersonelResmi.ImageLocation = kelimeler[14];
                        


                        // işlem yapımı için değerleri dönüştürüyor.
                        double calismaSuresi = Convert.ToDouble(textBoxCalısmaSüresi.Text);
                        double cocukSayisi = Convert.ToDouble(textBoxCocukSayisi.Text);
                        double tabanMaas = Convert.ToDouble(textBoxTabanMaas.Text);
                        double maasTazminti = Convert.ToDouble(textBoxTabanMaas.Text);
                        double idariGorevTaz = Convert.ToDouble(textBoxIdariGorevTaz.Text);
                        double fazlaMesaiSaati = Convert.ToDouble(textBoxFazlaMesaiSaati.Text);
                        double fazlaMesaiUcreti = Convert.ToDouble(textBoxFazlaMesaiUcr.Text);
                        double makamTazminati = Convert.ToDouble(textBoxMakamTazminati.Text);
                        double vergiMatrahi = Convert.ToDouble(textBoxVergiMatrahi.Text);



                        char evlilikDurumu = Convert.ToChar(textBoxEvlilikDurumu.Text);
                        char esiCalısıyorMu = Convert.ToChar(textBoxEsiCalisiyorMu.Text);



                        if (evlilikDurumu == 'B') // Bekar İse
                        {
                            brutMaas = tabanMaas + makamTazminati + idariGorevTaz + cocukSayisi * 30 + fazlaMesaiSaati * fazlaMesaiUcreti;
                            damgaVergisi = brutMaas * 10 / 100;

                            if (vergiMatrahi < 10000)
                            {
                                gelirVergisi = brutMaas * 15 / 100;
                                emeklilikKesintisi = brutMaas * 15 / 100;

                                maas = brutMaas - (emeklilikKesintisi + gelirVergisi + damgaVergisi);
                                textBoxMaas.Text = Convert.ToString(maas);
                            }
                            if (vergiMatrahi >= 10000 && vergiMatrahi < 20000)
                            {
                                gelirVergisi = brutMaas * 20 / 100;
                                emeklilikKesintisi = brutMaas * 15 / 100;

                                maas = brutMaas - (emeklilikKesintisi + gelirVergisi + damgaVergisi);
                                textBoxMaas.Text = Convert.ToString(maas);
                            }
                            if (vergiMatrahi >= 20000 && vergiMatrahi < 30000)
                            {
                                gelirVergisi = brutMaas * 25 / 100;
                                emeklilikKesintisi = brutMaas * 15 / 100;

                                maas = brutMaas - (emeklilikKesintisi + gelirVergisi + damgaVergisi);
                                textBoxMaas.Text = Convert.ToString(maas);
                            }
                            if (vergiMatrahi >= 30000)
                            {
                                gelirVergisi = brutMaas * 30 / 100;
                                emeklilikKesintisi = brutMaas * 15 / 100;

                                maas = brutMaas - (emeklilikKesintisi + gelirVergisi + damgaVergisi);
                                textBoxMaas.Text = Convert.ToString(maas);
                            }
                        }
                        else if (evlilikDurumu == 'E' && esiCalısıyorMu == 'E') //Evli Ve Eşi Çalışıyor İse
                        {
                            brutMaas = tabanMaas + makamTazminati + idariGorevTaz + cocukSayisi * 30 + fazlaMesaiSaati * fazlaMesaiUcreti;
                            damgaVergisi = brutMaas * 10 / 100;

                            if (vergiMatrahi < 10000)
                            {
                                gelirVergisi = brutMaas * 15 / 100;
                                emeklilikKesintisi = brutMaas * 15 / 100;

                                maas = brutMaas - (emeklilikKesintisi + gelirVergisi + damgaVergisi);
                                textBoxMaas.Text = Convert.ToString(maas);
                            }
                            if (vergiMatrahi >= 10000 && vergiMatrahi < 20000)
                            {
                                gelirVergisi = brutMaas * 20 / 100;
                                emeklilikKesintisi = brutMaas * 15 / 100;

                                maas = brutMaas - (emeklilikKesintisi + gelirVergisi + damgaVergisi);
                                textBoxMaas.Text = Convert.ToString(maas);
                            }
                            if (vergiMatrahi >= 20000 && vergiMatrahi < 30000)
                            {
                                gelirVergisi = brutMaas * 25 / 100;
                                emeklilikKesintisi = brutMaas * 15 / 100;

                                maas = brutMaas - (emeklilikKesintisi + gelirVergisi + damgaVergisi);
                                textBoxMaas.Text = Convert.ToString(maas);
                            }
                            if (vergiMatrahi >= 30000)
                            {
                                gelirVergisi = brutMaas * 30 / 100;
                                emeklilikKesintisi = brutMaas * 15 / 100;

                                maas = brutMaas - (emeklilikKesintisi + gelirVergisi + damgaVergisi);
                                textBoxMaas.Text = Convert.ToString(maas);
                            }

                        }
                        else if (evlilikDurumu == 'E' && esiCalısıyorMu == 'H') // Evli ve eşi çalışmıyor
                        {
                            brutMaas = tabanMaas + makamTazminati + idariGorevTaz + 200 + cocukSayisi * 30 + fazlaMesaiUcreti * fazlaMesaiSaati;
                            damgaVergisi = brutMaas * 10 / 100;

                            if (vergiMatrahi < 10000)
                            {
                                gelirVergisi = brutMaas * 15 / 100;
                                emeklilikKesintisi = brutMaas * 15 / 100;

                                maas = brutMaas - (emeklilikKesintisi + gelirVergisi + damgaVergisi);
                                textBoxMaas.Text = Convert.ToString(maas);
                            }
                            if (vergiMatrahi >= 10000 && vergiMatrahi < 20000)
                            {
                                gelirVergisi = brutMaas * 20 / 100;
                                emeklilikKesintisi = brutMaas * 15 / 100;

                                maas = brutMaas - (emeklilikKesintisi + gelirVergisi + damgaVergisi);
                                textBoxMaas.Text = Convert.ToString(maas);
                            }
                            if (vergiMatrahi >= 20000 && vergiMatrahi < 30000)
                            {
                                gelirVergisi = brutMaas * 25 / 100;
                                emeklilikKesintisi = brutMaas * 15 / 100;

                                maas = brutMaas - (emeklilikKesintisi + gelirVergisi + damgaVergisi);
                                textBoxMaas.Text = Convert.ToString(maas);
                            }
                            if (vergiMatrahi >= 30000)
                            {
                                gelirVergisi = brutMaas * 30 / 100;
                                emeklilikKesintisi = brutMaas * 15 / 100;

                                maas = brutMaas - (emeklilikKesintisi + gelirVergisi + damgaVergisi);
                                textBoxMaas.Text = Convert.ToString(maas);
                            }
                        }


                    }
                   
                }
                if(kontrol==0)
                {
                    MessageBox.Show("Lütfen Geçerli Bir Kimlik Numarası Giriniz");
                    // kontrol değişkeni artmadı ise uygulama üst kısımdaki   if (textBoxArananTc.Text == kelimeler[0])
                    // kısmına giriş yapmadı yani girilen sayı bir kimlik numarasına eşit değil.
                }

            }
            else 
            {
                MessageBox.Show("Lütfen Geçerli Bir Kimlik Numarası Giriniz");
                // istenen kimlik numarası kısmına bir değer girilmedi boş olduğu için hata veriyor.
            }
           


        }

        private void labelPersonelResmi_Click(object sender, EventArgs e)
        {

        }

        private void labelPersonelListele_Click(object sender, EventArgs e)
        {

        }
    }
}












