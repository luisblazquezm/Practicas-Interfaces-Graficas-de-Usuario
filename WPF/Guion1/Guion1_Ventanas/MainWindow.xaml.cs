﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Guion1_Ventanas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string previousInput = "";


        public class Function
        {
            public bool isVisible { get; set; }
            public string color { get; set; }
            public string name { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();

            List<Function> obj = new List<Function>();

            Function f = new Function();
            f.isVisible = false;
            f.color = "Red";
            f.name = "sin(x)";
            obj.Add(f);

            f = new Function();
            f.isVisible = false;
            f.color = "Red";
            f.name = "cos(x)";
            obj.Add(f);

            f = new Function();
            f.isVisible = false;
            f.color = "Red";
            f.name = "1/(x-2)";
            obj.Add(f);

            tableGrid.ItemsSource = obj;
        }

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        Boolean numberFirst = false;
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void OnlyNumbersBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            Regex reg = new Regex(@"^-?[0-9]*(\.[0-9]*)?$");

            if (Char.IsDigit(e.Text[0]))
            {
                Console.WriteLine("JA");
                numberFirst = true;
            } else
            {
                if ((e.Text[0]).Equals('-') && numberFirst)
                {
                    Console.WriteLine("JAJA");
                    e.Handled = false;
                }
                else
                {
                    Console.WriteLine("JAAJAJAJA");
                    if ((reg.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)) && !(e.Text == "-" && ((TextBox)sender).Text.Contains(e.Text))))
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
            }




            // ^-?[0-9]+$|^-?[0-9]*.?[0-9]$
            // ^-?[0-9]+(?:\.[0-9]*)?$
            /*
            Regex reg = new Regex(@"^-[0-9]*(\.[0-9]*)?$");

            if ((reg.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)) && !(e.Text == "-" && ((TextBox)sender).Text.Contains(e.Text))))
                e.Handled = false;
            else
                e.Handled = true;
            
            */
            //e.Handled = !reg.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
    }
}
