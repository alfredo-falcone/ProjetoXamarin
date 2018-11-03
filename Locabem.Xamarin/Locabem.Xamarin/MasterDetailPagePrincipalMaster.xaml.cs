using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Locabem.Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPagePrincipalMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailPagePrincipalMaster()
        {
            InitializeComponent();

            var model = new MasterDetailPagePrincipalMasterViewModel();
            BindingContext = model;

            
            ListView = MenuItemsListView;
        }

        public class MasterDetailPagePrincipalMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPagePrincipalMenuItem> MenuItems { get; set; }
            
            public MasterDetailPagePrincipalMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPagePrincipalMenuItem>(new[]
                {
                    new MasterDetailPagePrincipalMenuItem { Id = 0, Title = "Cadastrar Bem", TargetType=typeof(ManutencaoBem) },
                    new MasterDetailPagePrincipalMenuItem { Id = 1, Title = "Listar Bens", TargetType=typeof(ListagemBens) },
                    new MasterDetailPagePrincipalMenuItem { Id = 2, Title = "Registrar Aluguel", TargetType=typeof(RegistroAluguelBem) },
                    new MasterDetailPagePrincipalMenuItem { Id = 3, Title = "Registrar Devolucao", TargetType=typeof(RegistroDevolucaoBem) },
                    new MasterDetailPagePrincipalMenuItem { Id = 4, Title = "Opções", TargetType=typeof(Opcoes) },
                    //new MasterDetailPagePrincipalMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}