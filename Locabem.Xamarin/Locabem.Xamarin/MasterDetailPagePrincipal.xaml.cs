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
    public partial class MasterDetailPagePrincipal : MasterDetailPage
    {
        public MasterDetailPagePrincipal()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            if (App.Current.Properties.ContainsKey("RetomaUltimaTela") 
                && (bool)App.Current.Properties["RetomaUltimaTela"] 
                && App.Current.Properties.ContainsKey("UltimaPagina"))
            {
                var ultimaPagina = App.Current.Properties["UltimaPagina"];
                if (ultimaPagina != null)
                {
                    int idItem = (int)ultimaPagina;
                    MasterDetailPagePrincipalMenuItem item = ((MasterDetailPagePrincipalMaster.MasterDetailPagePrincipalMasterViewModel)MasterPage.BindingContext).MenuItems[idItem];
                    var page = (Page)Activator.CreateInstance(item.TargetType);
                    page.Title = item.Title;

                    Detail = new NavigationPage(page);
                    IsPresented = false;
                }
            }

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailPagePrincipalMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
            App.Current.Properties["UltimaPagina"] = item.Id;
            App.Current.SavePropertiesAsync();
        }
    }
}