using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace solucon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            // Configurar opciones para ComboBox de Nombre del Producto
            cmbNombreProducto.Items.Add("Producto 1");
            cmbNombreProducto.Items.Add("Producto 2");

            // Configurar opciones para ComboBox de Peso en Kilogramos
            cmbPesoKg.Items.Add("Menos de 1 kg");
            cmbPesoKg.Items.Add("1 - 5 kg");
            cmbPesoKg.Items.Add("Más de 5 kg");

            // Configurar opciones para ComboBox de Destino
            cmbDestino.Items.Add("San Salvador");
            cmbDestino.Items.Add("Interior del país");
        }

        private void btnCalcular_Click_Click(object sender, EventArgs e)
        {
            string producto = cmbNombreProducto.SelectedItem.ToString();
            string peso = cmbPesoKg.SelectedItem.ToString();
            string destino = cmbDestino.SelectedItem.ToString();
            decimal costoEnvio = 0;

            // Realizar cálculos según las condiciones dadas
            if (peso == "Menos de 1 kg")
            {
                costoEnvio = 5.00m;
            }
            else if (peso == "1 - 5 kg")
            {
                costoEnvio = 10.00m;
            }
            else if (peso == "Más de 5 kg")
            {
                costoEnvio = 10.00m + 2.00m * (decimal)(float.Parse(peso.Split(' ')[0]) - 5);
            }

            if (destino == "San Salvador" && peso != "Menos de 1 kg")
            {
                costoEnvio *= 0.9m; // Aplicar descuento del 10%
            }
            else if (destino == "Interior del país")
            {
                costoEnvio *= 1.2m; // Aplicar recargo del 20%
            }

            // Mostrar el resultado en un TextBox o Label
            txtResultado.Text = $"Producto: {producto}\r\nCosto de Envío: ${costoEnvio:F2}";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbNombreProducto.SelectedIndex = -1;
            cmbPesoKg.SelectedIndex = -1;
            cmbDestino.SelectedIndex = -1;
            txtResultado.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
