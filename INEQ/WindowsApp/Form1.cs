using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btniniciar_Click(object sender, EventArgs e)
        {
            string mensaje = BusinessLoyicLayer.UserBLL.iniciarSesion(txtUsuario.Text, txtpass.Text);
            if (string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show("Bienvenido");
            }
            else
            {
                MessageBox.Show(mensaje);
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
