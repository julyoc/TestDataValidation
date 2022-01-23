namespace TestDataValidation
{
    public partial class Form1 : Form
    {
        private PersonData _personData = new PersonData();

        public Form1()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            _personData.Nombre = Nombre.Text;
            _personData.Apellido = Apellido.Text;
            _personData.Edad = uint.Parse(Edad.Text);
            _personData.Email = Email.Text;
            _personData.Telefono = Telefono.Text;
            _personData.Cedula = cedula.Text;
            var valid = _personData.Valid();
            VName.Text = valid.Nombre ? "Ingresado correctamente." : "No se ha ingresado correctamente.";
            VApellido.Text = valid.Apellido ? "Ingresado correctamente." : "No se ha ingresado correctamente.";
            VEdad.Text = valid.Edad ? "Ingresado correctamente." : "No se ha ingresado correctamente.";
            VEmail.Text = valid.Email ? "Ingresado correctamente." : "No se ha ingresado correctamente.";
            VTelefono.Text = valid.Telefono ? "Ingresado correctamente." : "No se ha ingresado correctamente.";
            VCedula.Text = valid.Cedula ? "Ingresado correctamente." : "No se ha ingresado correctamente.";
        }
    }
}