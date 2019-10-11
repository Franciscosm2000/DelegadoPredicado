using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delegado_Predicado
{
    public partial class Form1 : Form
    {
        List<int> num;
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

                int numero = int.Parse(txtnum.Text);

                listBox1.Items.Add(numero);

                txtnum.Text = "";

            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }

        }


        public  bool TipoNumero(int num)
        {
            String tipo;

            if (radioButton1.Checked) tipo = "Par";
            else
                tipo = "Impar";

            bool bandera = false;
            switch (tipo)
            {
                case "Par":
                    if (num % 2 == 0)
                         bandera = true;
                    else
                        bandera = false;
                    break;

                case "Impar":
                    if (num % 2 != 0)
                        bandera = true;
                    else
                        bandera = false;
                    break;
            }

            return bandera;
        }
        //para poder separar numero pares e impares
        //terminado solo los pares, falta impares
        private void button1_Click(object sender, EventArgs e)
        {
            num = new List<int>();

            foreach (int dat in listBox1.Items )
            {

                num.Add(int.Parse(dat.ToString()));
            }

            if (radioButton1.Checked)
            {
                //delegado predicado 
                Predicate<int> elDelegado = new Predicate<int>(TipoNumero);

                List<int> datos = num.FindAll(elDelegado);

                foreach (int n in datos)
                {
                    listBox2.Items.Add(n);
                }
            }
            else
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
