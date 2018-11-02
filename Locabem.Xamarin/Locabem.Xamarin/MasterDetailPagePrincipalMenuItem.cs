using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locabem.Xamarin
{

    public class MasterDetailPagePrincipalMenuItem
    {
        public MasterDetailPagePrincipalMenuItem()
        {
            TargetType = typeof(MasterDetailPagePrincipalDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}