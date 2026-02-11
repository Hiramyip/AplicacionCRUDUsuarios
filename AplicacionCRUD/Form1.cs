using MongoDB.Bson;
using MongoDB.Driver;
using System;


namespace AplicacionCRUD
{
    public partial class Form1 : Form
    {
        private UsuarioRepositorio repo = new UsuarioRepositorio();

        public Form1()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var persona = new Usuario() { Nombre = txtNombre.Text, Puntos = Int32.Parse(txtPuntos.Text) };
            repo.Insertar(persona);
            MessageBox.Show("Creado correctamente");
            CargarDatos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dtgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dtgUsuarios.CurrentRow != null && dtgUsuarios.CurrentRow.DataBoundItem is Usuario usuarioSeleccionado)
            {
                usuarioSeleccionado.Nombre = txtNombre.Text;
                usuarioSeleccionado.Puntos = int.Parse(txtPuntos.Text);
                repo.Actualizar(usuarioSeleccionado.Id, usuarioSeleccionado);

                MessageBox.Show("Actualizado correctamente");
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila de la tabla");
            }
        }
        private void CargarDatos()
        {
            dtgUsuarios.Columns.Clear();
            dtgUsuarios.DataSource = null;
            dtgUsuarios.DataSource = repo.ObtenerTodos();
            if (dtgUsuarios.Columns["Id"] != null)
                dtgUsuarios.Columns["Id"].Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtgUsuarios.CurrentRow?.DataBoundItem is Usuario seleccionado)
            {
                repo.Eliminar(seleccionado.Id);
                CargarDatos();
            }
        }
    }
}
