using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Persona ObjetoCN = new CN_Persona();
        private string Id_Personas = null;
        private bool Editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarPersonas(); 
        }

        private void MostrarPersonas()
        {
            CN_Persona Objeto = new CN_Persona();
            dataGridView1.DataSource = Objeto.MostrarPersona();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (Editar == false)
            {
                try
                {
                    ObjetoCN.InsertarPersona(Txt_Nombre.Text, Txt_Apellido.Text, Dtp_Fecha_nac.Text, Cb_Sexo.SelectedItem.ToString());
                    MessageBox.Show("se inserto correctamente");
                    MostrarPersonas();
                    limpiarForm();
                    tabControl1.SelectedTab = tabPage2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo insertar los datos por: " + ex);
                }
            }
            //EDITAR
            if (Editar == true)
            {
                try
                {
                    
                    ObjetoCN.EditarRegistro(Id_Personas,Txt_Nombre.Text, Txt_Apellido.Text, Dtp_Fecha_nac.Text, Cb_Sexo.SelectedItem.ToString());
                    MessageBox.Show("se edito correctamente");
                    MostrarPersonas();
                    limpiarForm();
                    Editar = false;
                    tabControl1.SelectedTab = tabPage2;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar los datos por: " + ex);
                }
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                tabControl1.SelectedTab = tabPage1;
                Editar= true;
                Id_Personas = dataGridView1.CurrentRow.Cells["Id_Persona"].Value.ToString();
                Txt_Nombre.Text = dataGridView1.CurrentRow.Cells["Nombres"].Value.ToString();
                Txt_Apellido.Text = dataGridView1.CurrentRow.Cells["Apellidos"].Value.ToString();
                Dtp_Fecha_nac.Text = dataGridView1.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString();
                Cb_Sexo.Text = dataGridView1.CurrentRow.Cells["Sexo"].Value.ToString();
              
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
        private void limpiarForm()
        {
            Txt_Nombre.Text = "";
            Txt_Apellido.Text = "";
            Dtp_Fecha_nac.Text = "";
            Cb_Sexo.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Id_Personas = dataGridView1.CurrentRow.Cells["Id_Persona"].Value.ToString();
                ObjetoCN.EliminarPersonas(Id_Personas);
                MessageBox.Show("Eliminado correctamente");
                MostrarPersonas();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }
}