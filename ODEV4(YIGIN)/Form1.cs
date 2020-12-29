using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ODEV4_YIGIN_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class node
        {
            public char parantez;
            public node sonraki;
        }

        private void btn_KontrolEt_Click(object sender, EventArgs e)
        {
            node tepe = null;
            int parantezsayisi = 0;
            int susluparantezsayisi = 0;
            int kapaliparantezsayisi = 0;

            int geciciparantezsayisi = 0;
            int gecicisusluparantezsayisi = 0;
            int gecicikapaliparantezsayisi = 0;

            bool devam = true;
            string hesaplanacak = textBox1.Text;
            for (int i = 0; i < hesaplanacak.Length; i++)
            {
                if (hesaplanacak[i] == '(' || hesaplanacak[i] == '{' || hesaplanacak[i] == '[')
                {
                    if (hesaplanacak[i] == '(')
                    {
                        parantezsayisi += 1;
                    }
                    if (hesaplanacak[i] == '{')
                    {
                        susluparantezsayisi += 1;
                    }
                    if (hesaplanacak[i] == '[')
                    {
                        kapaliparantezsayisi += 1;
                    }
                    node yeni = new node();
                    yeni.parantez = hesaplanacak[i];
                    if (tepe == null)
                    {
                        tepe = yeni;
                        yeni.sonraki = null;
                    }
                    else
                    {
                        yeni.sonraki = tepe;
                        tepe = yeni;
                    }
                }
                if (hesaplanacak[i] == ')' || hesaplanacak[i] == '}' || hesaplanacak[i] == ']')
                {
                    if (tepe == null)
                    {
                        if (hesaplanacak[i] == ')')
                        {
                            geciciparantezsayisi += 1;
                            parantezsayisi -= 1;
                        }
                        if (hesaplanacak[i] == '}')
                        {
                            gecicisusluparantezsayisi += 1;
                            susluparantezsayisi -= 1;
                        }
                        if (hesaplanacak[i] == ']')
                        {
                            gecicikapaliparantezsayisi += 1;
                            kapaliparantezsayisi -= 1;
                        }
                        devam = false;
                    }
                    if (hesaplanacak[i] == ')' && parantezsayisi > 0)
                    {
                        parantezsayisi -= 1;
                        tepe = tepe.sonraki;
                    }
                    if (hesaplanacak[i] == '}' && susluparantezsayisi > 0)
                    {
                        susluparantezsayisi -= 1;
                        tepe = tepe.sonraki;
                    }
                    if (hesaplanacak[i] == ']' && kapaliparantezsayisi > 0)
                    {
                        kapaliparantezsayisi -= 1;
                        tepe = tepe.sonraki;
                    }
                }
            }
            if (devam == true)
            {
                if (tepe == null || (kapaliparantezsayisi == 0 && susluparantezsayisi == 0 && parantezsayisi == 0))
                {
                    MessageBox.Show("Eksik bir sembol yoktur.");
                }
                else
                {
                    MessageBox.Show(parantezsayisi + " Kadar ')' işareti eksiktir \n" +
                                    kapaliparantezsayisi + " Kadar ']' işareti eksiktir \n" +
                                    susluparantezsayisi + " Kadar '}' işareti eksiktir");
                }
            }
            if (devam == false)
            {
                MessageBox.Show(geciciparantezsayisi + " Kadar ')' işareti fazladır \n" +
                                gecicikapaliparantezsayisi + " Kadar ']' işareti fazladır \n" +
                                gecicisusluparantezsayisi + " Kadar '}' işareti fazladır");
                //MessageBox.Show("Fazla bir kapatma sembol'ü vardır.");
            }
        }
    }
}