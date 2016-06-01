﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App14
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registracija : Page
    {
        public Registracija()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Sistem.e = 0;
            int k = 0;
            if (textBox.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.PasswordChar == "")
            {
                var dialog = new MessageDialog("Greška! Popunite obavezna polja.");
                dialog.ShowAsync();
            }
            else
            {
                if (textBox4.Text == "")
                {
                    Sistem.korisnici.Add(new Gradjanin(textBox.Text, textBox1.Text, textBox2.Text, textBox3.PasswordChar));
                    this.Frame.Navigate(typeof(UspjesnaRegistracija2));
                    Sistem.b = Sistem.korisnici.Count-1;
                }
                else
                {

                    for (int i=0;i<Sistem.sluzbenici.Count;i++) {
                        if (Sistem.sluzbenici[i].DajBrojZnacke()==textBox4.Text)
                        {
                            Sistem.sluzbenici[i].PostaviUsername(textBox2.Text);
                            Sistem.sluzbenici[i].PostaviPassword(textBox3.PasswordChar);
                            k = 1;
                            Sistem.c = Sistem.sluzbenici.Count - 1;
                            this.Frame.Navigate(typeof(UspjesnaRegistracija));

                        }

                    }

                   
                }
               

                }
            if (k==0 && textBox4.Text!="")
            {
                var dialog = new MessageDialog("Greška! Nevalidan broj značke");
                dialog.ShowAsync();
            }
            }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
    
}
