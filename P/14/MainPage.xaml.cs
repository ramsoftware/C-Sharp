using System.Collections.ObjectModel;

namespace Ejemplo {

    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();

        }

        private void MySwitch_Toggled(object sender, ToggledEventArgs e) {
            if (e.Value) // true = ON
            {
                MensajeLabel.Text = "✅ Modo activado. ¡Todo listo!";
                MensajeEntry.Text = "Modo activado. ¡Todo listo!";
            }
            else // false = OFF
            {
                MensajeLabel.Text = "⏸️ Modo desactivado.";
                MensajeEntry.Text = "Modo desactivado.";
            }
        }

    }
}
