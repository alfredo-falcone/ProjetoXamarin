using Locabem.Xamarin.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Locabem.Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListagemBens : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }
        private bool isRowEven = false;
        public ListagemBens()
        {
            InitializeComponent();
            Load();
            // MyListView.IsPullToRefreshEnabled = true;
            
        }

        protected override void OnAppearing()
        {

            Load();
            base.OnAppearing();
        }


        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            //await DisplayAlert("Item Tapped", "An item was tapped.", "OK");
            await Navigation.PushAsync(new ManutencaoBem((Bem)e.Item));
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
            Load();
        }

        private void Load()
        {
            var bens = App.Banco.Table<Bem>().OrderBy(a => a.Nome);
            if (bens.Count() > 0)
                MyListView.ItemsSource = bens;
            else
                DisplayAlert("Vazio", "Ainda não há bens cadastrados", "Ok");
            
        }

        private void ViewCell_Appearing(object sender, EventArgs e)
        {

            // Alternate row color
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null && viewCell.View.BackgroundColor == default(Color))
            {
                if (this.isRowEven)
                {
                    viewCell.View.BackgroundColor = Color.Aqua;
                }
                else
                {
                    viewCell.View.BackgroundColor = Color.LightGray;
                }
            }
            this.isRowEven = !this.isRowEven;

        }

        /*public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
           // DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
           
           Navigation.PushAsync(new ManutencaoBem((Bem)mi.CommandParameter));

        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            //DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
            App.Banco.Delete((Bem)mi.CommandParameter);
        }*/

    }
}
