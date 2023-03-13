using CapaNegocio;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System;
using TextBox = System.Windows.Forms.TextBox;
using System.Windows.Forms;

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
            Cb_Sexo.DropDownStyle = ComboBoxStyle.DropDownList;
            MostrarPersonas();
            comboBoxItems();
        }
        private List<string> comboBoxItems()
        {
            List<string> comboBoxItems = new List<string>() {"Hombre", "Mujer"};// Declarar una lista para almacenar los elementos del ComboBox
            
            foreach (var item in comboBoxItems)
            {
                Cb_Sexo.Items.Add(item);
            }
            return comboBoxItems;
        }

        private void MostrarPersonas()
        {
            CN_Persona Objeto = new CN_Persona();
            dataGridView1.DataSource = Objeto.MostrarPersona();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            bool seIngresoTexto = !string.IsNullOrEmpty(Txt_Nombre.Text) && !string.IsNullOrEmpty(Txt_Apellido.Text); //Valida que los texbox no esten vacio


            //Valida que los campos esten vacios
            switch(Editar)
            {
                //insertar 
                case false:
                    if (seIngresoTexto == false && Cb_Sexo.Text == "" || seIngresoTexto == true && Cb_Sexo.Text == "" || seIngresoTexto == false && Cb_Sexo.Text != "")
                    {
                        Cb_Sexo.Items.Clear();
                        MessageBox.Show("Llenar todos los campos");
                        comboBoxItems();
                    }
                    else
                    {
                        try
                        {
                            ObjetoCN.InsertarPersona(Txt_Nombre.Text, Txt_Apellido.Text, Dtp_Fecha_nac.Text, Cb_Sexo.Text);
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
                    
                    break;

                    //editar
                case true:
                    if (seIngresoTexto == false && Cb_Sexo.Text == "" || seIngresoTexto == true && Cb_Sexo.Text == "" || seIngresoTexto == false && Cb_Sexo.Text != "")
                    {
                        Cb_Sexo.Items.Clear();
                        comboBoxItems();
                        MessageBox.Show("Llenar todos los campos");
                    }
                    else
                    {
                        try
                        {
                            
                            comboBoxItems();
                            ObjetoCN.EditarRegistro(Id_Personas, Txt_Nombre.Text, Txt_Apellido.Text, Dtp_Fecha_nac.Text, Cb_Sexo.Text);
                            MessageBox.Show("se edito correctamente");
                            MostrarPersonas();
                            limpiarForm();
                            comboBoxItems();
                            tabControl1.SelectedTab = tabPage2;
                            Editar = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("no se pudo editar los datos por: " + ex);
                        }
                    }
                    
                    break;
                    MessageBox.Show("Llenar todos los campos");
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                Cb_Sexo.Items.Clear();
                tabControl1.SelectedTab = tabPage1;
                Editar= true;
                Id_Personas = dataGridView1.CurrentRow.Cells["Id_Persona"].Value.ToString();
                Txt_Nombre.Text = dataGridView1.CurrentRow.Cells["Nombres"].Value.ToString();
                Txt_Apellido.Text = dataGridView1.CurrentRow.Cells["Apellidos"].Value.ToString();
                Dtp_Fecha_nac.Text = dataGridView1.CurrentRow.Cells["Fecha_Nacimiento"].Value.ToString();
                Cb_Sexo.Text = dataGridView1.CurrentRow.Cells["Sexo"].Value.ToString();
                comboBoxItems();
                
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
        private void limpiarForm()
        {
            Txt_Nombre.Text = "";
            Txt_Apellido.Text = "";
            Dtp_Fecha_nac.Text = null;
            Cb_Sexo.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Id_Personas = dataGridView1.CurrentRow.Cells["Id_Persona"].Value.ToString();
                ObjetoCN.EliminarPersonas(Id_Personas);
                MessageBox.Show("Eliminado satisfactoriamente");
                MostrarPersonas();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void Cb_Sexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}