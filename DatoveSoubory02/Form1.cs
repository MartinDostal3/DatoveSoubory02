using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DatoveSoubory02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int n = int.Parse(textBox1.Text);
            FileStream fs = new FileStream("realnaCisla.dat", FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs);
            for (int i = 0; i < n; i++)
            {
                double nahodne = -200 + (201 - (-200)) * random.NextDouble();
                bw.Write(nahodne);
            }
           // fs.Close();
            //bw.Close();
            fs.Seek(0, SeekOrigin.Begin); // skok na zacatek streamu 

            listBox1.Items.Clear();
           
            BinaryReader br = new BinaryReader(fs);
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                double cislo = br.ReadDouble();
                listBox1.Items.Add(cislo);
            }
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("realnaCisla.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            StreamWriter sw = new StreamWriter("realnaCisla.txt");
            double cislo;
            while (fs.Position < fs.Length)
            {
                cislo = br.ReadDouble();
                sw.WriteLine(cislo);
                
               
               
            }
            fs.Close();
            sw.Close();
            StreamReader sr = new StreamReader("realnaCisla.txt");
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                listBox2.Items.Add(line);

            }
            sr.Close();

        }
    }
}
