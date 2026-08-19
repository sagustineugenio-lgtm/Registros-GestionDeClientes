using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registros_GestionDeClientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Declaración de un Registro
        private struct RegCli
        {
            public int Codigo;
            public string Usuario;
            public decimal Deuda;
            public decimal Limite;
        };

        //Declaración del Vector
        private RegCli[] Clientes = new RegCli[10];

        //Declaración del Indice
        private int IND = 0;

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (IND < Clientes.Length)
            {
                //Busqueda Secuencial
                Int32 i = 0;
                while (Clientes[i].Codigo != Convert.ToInt32(txtCodigo) && i<IND)
                {
                    i++;
                }
                if (i == IND)
                {
                    Clientes[IND].Codigo = Convert.ToInt32(txtCodigo.Text);
                    Clientes[IND].Usuario = txtUsuario.Text;
                    Clientes[IND].Deuda = Convert.ToDecimal(txtDeuda.Text);
                    Clientes[IND].Limite = Convert.ToDecimal(txtLimite.Text);
                    IND++;
                    //MessageBox.Show("Cliente cargado correctamente");
                    txtCodigo.Text = "";
                    txtUsuario.Text = "";
                    txtDeuda.Text = "";
                    txtLimite.Text = "";
                    Listar();
                }
                else
                {
                    MessageBox.Show("Codigo Existente");
                }


            }
            else
            {
                MessageBox.Show("No es posible cargar mas CLientes");
            }
            
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Decimal totalDeuda = 0;
            dgvClentes.Rows.Clear();
            for (Int32 i =0; i<IND; i++)
            {
                if (Clientes[i].Deuda > 0)
                {
                    dgvClentes.Rows.Add(Clientes[i].Codigo, Clientes[i].Usuario, Clientes[i].Limite, Clientes[i].Deuda);
                    totalDeuda = totalDeuda + Clientes[i].Deuda;
                }
            }
            lblTotalDeuda.Text = totalDeuda.ToString();
        }

        private void Listar()
        {
            Decimal totalDeuda = 0;
            dgvClentes.Rows.Clear();
            for (Int32 i = 0; i < IND; i++)
            {
                dgvClentes.Rows.Add(Clientes[i].Codigo, Clientes[i].Usuario, Clientes[i].Limite, Clientes[i].Deuda);
                totalDeuda = totalDeuda + Clientes[i].Deuda;
            }
            lblTotalDeuda.Text = totalDeuda.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnCargar.Enabled = false;
            Precarga();
            Listar();
        }

        private void Precarga()
        {
            Clientes[IND].Codigo = 1;
            Clientes[IND].Usuario = "Nico";
            Clientes[IND].Deuda = 12;
            Clientes[IND].Limite = 20000;
            IND++;
            Clientes[IND].Codigo = 2;
            Clientes[IND].Usuario = "Ana";
            Clientes[IND].Deuda = 0;
            Clientes[IND].Limite = 20000;
            IND++;
            Clientes[IND].Codigo = 3;
            Clientes[IND].Usuario = "Diego";
            Clientes[IND].Deuda = 30;
            Clientes[IND].Limite = 20000;
            IND++;
            Clientes[IND].Codigo = 4;
            Clientes[IND].Usuario = "María";
            Clientes[IND].Deuda = 10;
            Clientes[IND].Limite = 20000;
            IND++;
        }

        private void ControlarCajas()
        {
            if (txtCodigo.Text != "" && txtUsuario.Text != "" && txtLimite.Text != "" && txtDeuda.Text != "")
            {
                btnCargar.Enabled = true;
            }
            else
            {
                btnCargar.Enabled = false;
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            ControlarCajas();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            ControlarCajas();
        }

        private void txtDeuda_TextChanged(object sender, EventArgs e)
        {
            ControlarCajas();
        }

        private void txtLimite_TextChanged(object sender, EventArgs e)
        {
            ControlarCajas();
        }

    }
}
