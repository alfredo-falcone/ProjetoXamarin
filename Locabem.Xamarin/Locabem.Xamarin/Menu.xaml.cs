using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Locabem.Xamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menu : ContentPage
	{

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Page pagina = null;
            switch (((Button)sender).Text)
            {
                case "Cadastrar Bem":
                    pagina = new ManutencaoBem();
                    break;
                case "Listar Bens":
                    pagina = new ListagemBens();
                    break;
                    
                case "Registrar Aluguel":
                    pagina = new RegistroAluguelBem();
                    break;
                default:
                    pagina = new ListagemBens();
                    break;
            }
            ((MasterDetailPage)this.Parent).Detail = new NavigationPage(pagina);
            ((MasterDetailPage)this.Parent).IsPresented = false;
        }

        public Menu ()
		{
			InitializeComponent ();
		}
	}
}