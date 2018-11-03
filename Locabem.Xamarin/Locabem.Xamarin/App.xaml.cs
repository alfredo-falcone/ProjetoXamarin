using Locabem.Xamarin.Model;
using SQLite;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Locabem.Xamarin
{
    public partial class App : Application
    {
        private static SQLiteConnection banco;
        public static Color CorFundo = Color.Aqua;
        public static Color CorTexto = Color.Gray;
        public static FontAttributes AtributosTexto = FontAttributes.Bold;
        public static LayoutOptions PosicaoTexto = LayoutOptions.StartAndExpand;
        public static Color CorBotao = Color.LightBlue;
        public static Color CorDisponivel = CorTexto;
        public static Color CorAlugado = Color.Red;
        public App()
        {
            InitializeComponent();

            MainPage = new MasterDetailPagePrincipal();
        }

        public static SQLiteConnection Banco
        {
            get
            {
                if (banco == null)
                {
                    string caminho = DependencyService.Get<IFileHelper>().GetCaminho();
                    banco = new SQLiteConnection(caminho);
                    banco.CreateTable<Bem>();
                }
                return banco;
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
