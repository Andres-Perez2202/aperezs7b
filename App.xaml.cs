namespace aperezs7b
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new vEstudiante());
        }
    }
}
