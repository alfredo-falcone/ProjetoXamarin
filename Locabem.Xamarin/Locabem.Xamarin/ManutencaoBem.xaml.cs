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
	public partial class ManutencaoBem : ContentPage
	{
        private Bem __bemAtual;
        private bool bAlteracao;
        private Bem BemAtual
        {
            get
            {
                if (__bemAtual == null)
                    __bemAtual = new Bem();
                return __bemAtual;
            }
            set
            {
                this.__bemAtual = value;
                
            }
        }
        public ManutencaoBem() : this(null)
        {

        }

        public ManutencaoBem (Bem bem)
		{
            try
            {
                InitializeComponent();
                this.BemAtual = bem;
                bAlteracao = (bem != null);
                Load();
                btExcluir.IsEnabled = bAlteracao;
            }
            catch(Exception ex)
            {
                lbMensagem.IsVisible = true;
                lbMensagem.Text = ex.Message;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender == btGravar)
            {
                if (string.IsNullOrEmpty(tbNome.Text))
                {
                    DisplayAlert("Validação", "Nome é obrigatório.", "OK");
                    return;
                }
                if (App.Current.Properties.ContainsKey("MarcaObrigatoria") && (bool)App.Current.Properties["MarcaObrigatoria"] && string.IsNullOrEmpty(tbMarca.Text))
                {
                    DisplayAlert("Validação", "Marca é obrigatória.", "OK");
                    return;
                }

                this.BemAtual.Marca = tbMarca.Text;
                this.BemAtual.Nome = tbNome.Text;
                //this.BemAtual.IsAlugado = true;
                if (bAlteracao)
                    App.Banco.Update(this.BemAtual);
                else
                    App.Banco.Insert(this.BemAtual);

                DisplayAlert("Gravação", "Gravação efetivada com sucesso.", "OK");

                if (bAlteracao)
                {
                    Navigation.PopAsync();
                }
                else
                {
                    this.BemAtual = null;
                    if(App.Current.Properties.ContainsKey("RedirecionarListagem") && (bool)App.Current.Properties["RedirecionarListagem"])
                        ((MasterDetailPage)App.Current.MainPage).Detail = new NavigationPage(new ListagemBens());

                }
                Load();
            }
            else
            {
                App.Banco.Delete(this.BemAtual);
                DisplayAlert("Gravação", "Gravação efetivada com sucesso.", "OK" );
                Navigation.PopAsync();

            }
        }

        private void Load()
        {
            tbNome.Text = string.Empty;
            tbMarca.Text = string.Empty;
            if (this.BemAtual != null)
            {
                tbNome.Text = this.BemAtual.Nome;
                tbMarca.Text = this.BemAtual.Marca;
            }
        }
    }
}