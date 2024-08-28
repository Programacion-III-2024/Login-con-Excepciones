using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace Aplicacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void labelRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registro formularioDeRegistro = new Registro();
            formularioDeRegistro.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UsuarioController.Login(TextBoxNombre.Text, TextBoxPassword.Text).ToString());
        }
    }
}
