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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TextBoxPassword.Text != TextBoxPasswordConfirmacion.Text)
                MessageBox.Show("Ambas contraseñas deben ser iguales");

            else
            {
                try{
                    UsuarioController.Crear(TextBoxNombre.Text, TextBoxPassword.Text);
                    MessageBox.Show("Cuenta Creada");

                    TextBoxNombre.Text = "";
                    TextBoxPassword.Text = "";
                    TextBoxPasswordConfirmacion.Text = "";
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
