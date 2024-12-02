using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Hospedagem.Models
{
    public class Pessoa
    {
        public Pessoa() // construtor que está sendo utilizado
        {

        }
        public Pessoa (string nome, string sobrenome, int idade) //só para teste
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Idade = idade;
        }

        private string _nome;
        private string _sobrenome;
        private int _idade;
        public string Nome 
        { 
            get
            {
                if (!string.IsNullOrEmpty(_nome))
                    return char.ToUpper(_nome[0]) + _nome.Substring(1);
                return _nome;
            } 
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("O nome não poder ser vazio");
                }

                _nome = value;
            } 
        }
        public string Sobrenome 
        { 
            get
            {
                if (!string.IsNullOrEmpty(_sobrenome))
                    return char.ToUpper(_sobrenome[0]) + _sobrenome.Substring(1);
                return _sobrenome;
            } 
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("O nome não poder ser vazio");
                }

                _sobrenome = value;
            } 
        }
        public string NomeCompleto => $"{Nome} {Sobrenome}";
        public int Idade 
        { 
            get => _idade;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("A idade não pode ser menor que zero");
                }

                _idade = value;
            }
        }
        public void Apresentar()
        {
            foreach ( string hospede in listaDeHospedes)
            {
                Console.WriteLine(hospede);
            }
        }

        public void ObtainInfoDeHospede() 
        {
            Console.WriteLine("Digite seu nome: ");
            Nome = Console.ReadLine();

            Console.WriteLine("Digite seu sobrenome: ");
            Sobrenome = Console.ReadLine();

            Console.WriteLine("Digite sua idade:");
            Idade = int.Parse(Console.ReadLine());
        }
        public List<string> listaDeHospedes = new List<string>();
        public void AddHospedes()
        {
             listaDeHospedes.Add(NomeCompleto);
        }
        
    }

}