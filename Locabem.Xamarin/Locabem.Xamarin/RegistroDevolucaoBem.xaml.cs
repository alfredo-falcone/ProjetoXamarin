using Locabem.Xamarin.Model;
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
	public partial class RegistroDevolucaoBem : ContentPage
	{
        private List<Bem> bens;
        public RegistroDevolucaoBem ()
		{
            InitializeComponent();
            bens = App.Banco.Table<Bem>().Where(b => b.IsAlugado).OrderBy(a => a.Nome).ToList();
            cmbBens.ItemsSource = bens;//.Select(b => b.Nome).ToList();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            bens[cmbBens.SelectedIndex].IsAlugado = false;
            App.Banco.Update(bens[cmbBens.SelectedIndex]);
            ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new ListagemBens());

        }
    }
}