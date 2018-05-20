using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rutas
{
    public partial class Form1 : Form
    {
        Ruta ruta = new Ruta();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregarUltimo_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int tiempo = int.Parse(txtTiempo.Text);

            Base nuevo = new Base(nombre, tiempo);
            ruta.Agregar_Final(nuevo);

            txtNombre.Clear();
            txtTiempo.Clear();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int posicion = int.Parse(txtPosicion.Text);
            string nombre = txtNombre.Text;
            int tiempo = int.Parse(txtTiempo.Text);

            Base nuevo = new Base(nombre, tiempo);

            ruta.Insertar(nuevo, posicion);

            txtNombre.Clear();
            txtTiempo.Clear();
            txtPosicion.Clear();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Base buscar;
            string nombre = txtNombre.Text;

            buscar = ruta.Buscar(nombre);

            if(buscar != null)
            {
                txtNombre.Text = buscar.Nombre;
                txtTiempo.Text = Convert.ToString(buscar.Minutos);
            }
            else
            {
                MessageBox.Show("Base no encontrada");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Base eliminada;
            string nombre = txtNombre.Text;

            eliminada = ruta.Eliminar(nombre);

            txtTablero.Text = "La base " + eliminada.ToString() + " fue eliminada";
            txtNombre.Clear();
        }

        private void btnEliminarInicio_Click(object sender, EventArgs e)
        {
            Base eliminarInicio;

            eliminarInicio = ruta.Eliminar_Inicio();

            txtTablero.Text = "La base : " + eliminarInicio.ToString() + " fue eliminada";
            txtNombre.Clear();
        }

        private void btnEliminarUltimo_Click(object sender, EventArgs e)
        {
            Base eliminarUltima;

            eliminarUltima = ruta.Eliminar_Ultimo();

            txtTablero.Text = "La base : " + eliminarUltima.ToString() + " fue eliminada";
            txtNombre.Clear();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            txtTablero.Text = ruta.Listar();
        }

        private void txtRuta_Click(object sender, EventArgs e)
        {
            DateTime hora_inicio = dtpHoraInicio.Value;
            DateTime hora_final = dtpHoraFinal.Value;
            string nombre = txtNombreBase.Text;
            string cadena = ruta.Rutas(nombre, hora_inicio, hora_final);
            txtTablero.Text = cadena;
        }
    }
}
