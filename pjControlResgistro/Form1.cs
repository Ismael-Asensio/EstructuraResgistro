namespace pjControlResgistro
{
    public partial class Form1 : Form
    {
        int num;
        int cjefe, cOperario, cAdministrativo, Participante;
        public Form1()
        {
            InitializeComponent();
            tHora.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Estas Seguro de Salir" , "Particpantes" , MessageBoxButtons.YesNo , MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }

        private void tHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            num++;
            lblNumero.Text = num.ToString("D4");
            lblFecha.Text = DateTime.Now.ToString("d");

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //CAPTURANDO LOS DATOS 
            DateTime fecha, hora;
            string participante, cargo;
            int numero;

            participante = txtParticipante.Text;
            numero = int.Parse(lblNumero.Text);
            fecha = DateTime.Parse(lblFecha.Text);
            hora = DateTime.Parse(lblHora.Text);
            cargo = comboBox1.Text;

            //CONTABILIZAR LA CANTIDAD SEGUN LOS CARGOS

            switch (cargo)
            {

                case "Jefe": cjefe++; break;
                case "Operario": cOperario++; break;
                case "Administrativo": cAdministrativo++; break;
                case "Participante": Participante++; break;


            }
            //IMPRIMIENDO EL REGISTRO

            ListViewItem fila = new ListViewItem(numero.ToString());
            fila.SubItems.Add(participante);
            fila.SubItems.Add(cargo);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(hora.ToString("hh:mm:ss"));
            lvParticipantes.Items.Add(fila);

            //IMPRIMIENDO LAS ESTADISTICAS 

            lvEstadisticas.Items.Clear();
            string[] elementosFila = new string[2];
            ListViewItem row;

            //AÑADIMOS LA PRIMERA FILA AL LVESTADISTICAS

            elementosFila[0] = "Jefe";
            elementosFila[1] = cjefe.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //AÑADIMOS LA SEGUNDA FILA AL LVESTADISTICAS
            elementosFila[0] = "Operario";
            elementosFila[1] = cOperario.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //AÑADIMOS LA TERCERA FILA AL LVESTADISTICAS

            elementosFila[0] = "Administrativo";
            elementosFila[1] = cAdministrativo.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //AÑADIMOS LA CUARTA FILA AL LVESTADISTICAS

            elementosFila[0] = "Participante";
            elementosFila[1] = Participante.ToString();
            row = new ListViewItem(elementosFila);
            lvEstadisticas.Items.Add(row);

            //MOSTRANDO EL NUMERO DE REGISTRO

            num++;
            lblNumero.Text = num.ToString("D4");

            //LIMPIANDO LOS CONTROLES

            txtParticipante.Clear();
            comboBox1.SelectedIndex= -1;
            comboBox1.Text = "(SELECCIONE CARGO)";
            txtParticipante.Focus();


        }
    }
}