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
	public partial class Opcoes : ContentPage
	{
		public Opcoes ()
		{
			InitializeComponent ();

            if(App.Current.Properties.ContainsKey("MarcaObrigatoria"))
                cbMarcaObrigatoria.IsToggled = (bool)App.Current.Properties["MarcaObrigatoria"];
            if(App.Current.Properties.ContainsKey("RedirecionarListagem"))
                cbRedirecionarListagem.IsToggled = (bool)App.Current.Properties["RedirecionarListagem"];
            if (App.Current.Properties.ContainsKey("RetomaUltimaTela"))
                cbRetomaUltimaTela.IsToggled = (bool)App.Current.Properties["RetomaUltimaTela"];

        }

        private void pbGravar_Clicked(object sender, EventArgs e)
        {
            App.Current.Properties["MarcaObrigatoria"] = cbMarcaObrigatoria.IsToggled;
            App.Current.Properties["RedirecionarListagem"] = cbRedirecionarListagem.IsToggled;
            App.Current.Properties["RetomaUltimaTela"] = cbRetomaUltimaTela.IsToggled;

            App.Current.SavePropertiesAsync();

        }
    }
}