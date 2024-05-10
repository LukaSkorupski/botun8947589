using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace botun2
{
    public partial class Form1 : Form
    {
        struct Podatak {
            public string Ime;
            public string Prezime;
            public string Godina_rodenja;
            public string Email;
        }

        List<Podatak> podatci = new List<Podatak>();

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string ime = textBox1.Text;
            string prezime = textBox2.Text;
            string godina_rodenja = textBox3.Text;
            string email= textBox4.Text;

            if (!Regex.IsMatch(ime, @"^[a-zA-Z]*$"))
            {
                MessageBox.Show("Nevažeće ime");
                return;
            }
            if (!Regex.IsMatch(prezime, @"^[a-zA-Z]*$"))
            {
                MessageBox.Show("Nevažeće prezime");
                return;
            }
            if (!Regex.IsMatch(godina_rodenja, @"^\d{4}[-](0[1-9]|1[012])[-](0[1-9]|[12][0-9]|3[01])$"))
            {
                MessageBox.Show("Nevažeće godina rodenja. (GGGG-MM-DD)");
                return;
            }
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("Nevažeće email adresa");
                return;
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            podatci.Add(new Podatak() {
                Ime = ime,
                Prezime = prezime,
                Godina_rodenja = godina_rodenja,
                Email = email,
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> csvData = new List<string>();
            csvData.Add("Ime,Prezime,Godina rođenja,E-mail");

            foreach (Podatak podatak in podatci)
            {
                csvData.Add($"{podatak.Ime},{podatak.Prezime},{podatak.Godina_rodenja},{podatak.Email}");
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Write the file
                File.WriteAllLines(saveFileDialog.FileName, csvData);
            }
        }
    }

 
}
