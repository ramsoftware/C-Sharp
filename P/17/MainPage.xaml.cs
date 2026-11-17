
namespace Ejemplo {

    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }

        private void BtnInfo_Clicked(object sender, EventArgs e) { 
            MensajeEntry.Text = "ℹ️ Información: acción de ejemplo.";
        }

        private void BtnWarning_Clicked(object sender, EventArgs e) { 
            MensajeEntry.Text = "⚠️ Advertencia: revisa los datos ingresados.";
        }

        private void BtnSuccess_Clicked(object sender, EventArgs e) { 
            MensajeEntry.Text = "✅ Operación realizada correctamente.";
        }

    }
}
