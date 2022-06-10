using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfnovo.Database;
using wpfnovo.Interface;

namespace wpfnovo.Models
{
    public class vehicles
    {
        private string id;
        private string modelo;
        private string ano;
        private string cor;

        public vehicles()
        {

        }
        public vehicles(string id, string modelo, string ano, string cor)
        {
            this.id = id;
            this.modelo = modelo;
            this.ano = ano;
            this.cor = cor;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }

        }

        public string Ano
        {
            get { return ano; }
            set { ano = value; }
        }

        public string Cor
        {
            get { return cor; }
            set { cor = value; }
        }
    }
}
