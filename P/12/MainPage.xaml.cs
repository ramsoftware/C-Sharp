using System.Globalization;

namespace Ejemplo {

    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
        }


        private void OnConvertirClicked(object sender, EventArgs e) {
            MensajeLabel.Text = string.Empty;

            // Leemos y validamos el entero
            var texto = NumeroEntry.Text?.Trim();

            // Puedes decidir si aceptas signo; aquí aceptamos negativos
            if (!int.TryParse(texto, NumberStyles.Integer, CultureInfo.InvariantCulture, out int valor)) {
                MensajeLabel.Text = "Por favor, ingresa un número entero válido.";
                LimpiarResultados();
                return;
            }

            // Convertir preservando el signo para las bases (opcional)
            // Convert.ToString soporta base 2, 8, 10 y 16 para enteros con signo.
            // Para negativos, Convert.ToString produce representación con signo '-'
            // y magnitud en la base dada.
            string octal = Convert.ToString(valor, 8);
            string hex = Convert.ToString(valor, 16).ToUpperInvariant();
            string bin = Convert.ToString(valor, 2);

            // Mostrar
            OctalLabel.Text = octal;
            HexLabel.Text = hex;
            BinLabel.Text = bin;
        }

        private void LimpiarResultados() {
            OctalLabel.Text = string.Empty;
            HexLabel.Text = string.Empty;
            BinLabel.Text = string.Empty;
        }


    }
}
