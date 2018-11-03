using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Locabem.Xamarin.Model
{
    [Table("Bem")]
    public class Bem
    {
        [Column("Id"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("Nome")]
        public string Nome { get; set; }
        [Column("Marca")]
        public string Marca { get; set; }

        [Column("Alugado")]
        public bool IsAlugado { get; set; }

        public String TextoAlugado
        {
            get
            {
                return (this.IsAlugado) ? "Alugado" : "Disponível";
            }
        }
    }
}
