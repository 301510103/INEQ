using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conexiones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chkhabilitado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitado.Checked == true)
                chkHabilitado.Text = "Habilitado";
            else
                chkHabilitado.Text = "Inhabilitado";
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
            btnInsertar.Enabled = true;
            btnCancelar.Enabled = true;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtUsuario.Enabled = true;
            txtContraseña.Enabled = true;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            //Bloquear los campos
            btnNuevo.Enabled = true;
            btnInsertar.Enabled = false;
            btnCancelar.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtUsuario.Enabled = false;
            txtContraseña.Enabled = false;

            //Limpiar los campos
            cboId.SelectedIndex = -1;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            chkHabilitado.Checked = false;
            chkHabilitado.Text = "Inhabilitado";
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=localhost;user id=root;database=IneqDevDb";
                MySqlConnection mysqlConn = new MySqlConnection();
                mysqlConn.Open();
                string query = "INSERT INTO `ineq`.`user` (`Id`, `Name`, `LastName`, `UserName`, `Password`, `Active`) VALUES (@name, @lastname, @username, @password, @active)";
                MySqlCommand cmd = new MySqlCommand(query, mysqlConn);
                cmd.Parameters.AddWithValue("@name", txtNombre.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@lastname", txtApellido.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@username", txtUsuario.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@password", txtContraseña.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@active", chkHabilitado.Checked);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    MessageBox.Show("Se insertó correctamente");
                    cboId.SelectedIndex = -1;
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtUsuario.Text = "";
                    txtContraseña.Text = "";
                    chkHabilitado.Checked = false;
                    chkHabilitado.Text = "Inhabilitado";
                    btnNuevo.Enabled = true;
                    btnInsertar.Enabled = false;
                    btnAcrualizar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnCancelar.Enabled = false;
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    txtUsuario.Enabled = false;
                    txtContraseña.Enabled = false;
                    chkHabilitado.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se pudo insertar");
                }
                mysqlConn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

