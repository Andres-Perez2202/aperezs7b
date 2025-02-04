using aperezs7b.Models;
using Newtonsoft.Json;
using static aperezs7b.Views.vEstudiante;
using System.Collections.ObjectModel;
using System.Text.Json.Nodes;

namespace aperezs7b.Views;

public partial class vEstudiante : ContentPage
{
    public partial class vEstudiante : ContentPage
    {
        private const string Url = "http://191.99.55.190/wsestudiantes/estudiante.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<Estudiante> estud;
        public vEstudiante()
        {
            InitializeComponent();
            Listar();
        }

        public async void Listar()
        {
            var content = await cliente.GetStringAsync(Url);
            List<Estudiante> ListaEstudiante = JsonConvert.DeserializeObject<List<Estudiante>>(content);
            estud = new ObservableCollection<Estudiante>(ListaEstudiante);
            lvEstudiantes.ItemsSource = estud;
        }

        private void btnAbrir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new vInsertar());
        }

        private void lvEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var ObjEstudiante = (Estudiante)e.SelectedItem;
            Navigation.PushAsync(new vActualizarEliminar(ObjEstudiante));

        }
    }
}