namespace ControlMultasTransito
{
    public partial class frmMultas : Form
    {
        public frmMultas()
        {
            InitializeComponent();
        }

        private void frmMultas_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando datos
            string placa = txtPlaca.Text;
            double velocidad = double.Parse(txtVelocidad.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            DateTime hora = DateTime.Parse(lblHora.Text);

            //Procesando
            double multa = 0;
            if (velocidad <= 70)
                multa = 0;
            else if (velocidad > 70 && velocidad <= 90)
                multa = 120;
            else if (velocidad > 90 && velocidad <= 100)
                multa = 240;
            else if (velocidad > 100)
                multa = 500;

            //Imprimiedo resultados
            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(lblFecha.Text);
            fila.SubItems.Add(lblHora.Text);
            fila.SubItems.Add(velocidad.ToString("0.00"));
            fila.SubItems.Add(multa.ToString("C"));
            lvMultas.Items.Add(fila);



        }

        ListViewItem item;

        private void lvMultas_MouseClick(object sender, MouseEventArgs e)
        {
            item = lvMultas.GetItemAt(e.X, e.Y);

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(item != null)
            {
                lvMultas.Items.Remove(item);
                MessageBox.Show("¡Multa eliminada correctamente!");
            }
            else
            {
                MessageBox.Show("Debe seleccionar una multa de la lista");
            }
        }
    }
}
