using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Locabem.Xamarin.Droid.FileHelper))]
namespace Locabem.Xamarin.Droid
{
    public class FileHelper : IFileHelper
    {
        public FileHelper()
        {
        }

        public string GetCaminho()
        {
            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(caminho, "bancoDados.db3");
        }
    }
}
