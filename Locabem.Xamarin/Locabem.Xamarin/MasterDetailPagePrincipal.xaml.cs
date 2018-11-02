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
            if (Application.Current.Properties.ContainsKey("UltimaPagina") )
            {
                string ultimaPagina = (string)Application.Current.Properties["UltimaPagina"];
                if (!string.IsNullOrEmpty(ultimaPagina))
                {
                    int idItem = int.Parse(ultimaPagina);
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
            Application.Current.Properties["UltimaPagina"] = item.Id;
            App.Current.SavePropertiesAsync();
        }
    }
}