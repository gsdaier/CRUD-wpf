using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using wpfnovo.Database;
using wpfnovo.Interface;

namespace wpfnovo.Models
{
    public class vehicles : INotifyPropertyChanged
    {
        private int id;
        private string modelo;
        private string ano;
        private string cor;

        public vehicles()
        {

        }
        public vehicles(int id, string modelo, string ano, string cor)
        {
            this.id = id;
            this.modelo = modelo;
            this.ano = ano;
            this.cor = cor;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { if (modelo != value)
                {
                  modelo = value;
                  Notifica("Modelo");
                }  
            }
        }

        public string Ano
        {
            get { return ano; }
            set
            {
                if (ano != value)
                {
                    ano = value;
                    Notifica("Ano");
                }
            }
        }

        public string Cor
        {
            get { return cor; }
            set
            {
                if (cor != value)
                {
                    cor = value;
                    Notifica("Cor");
                }
            }
        }
        public vehicles DeepCopy()
        {
            return new vehicles(this.Id, this.Modelo, this.Ano, this.Cor);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notifica(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
