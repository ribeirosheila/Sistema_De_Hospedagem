using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Hospedagem.Models
{
    public class Pessoa
    {
        public Pessoa() // construtor que está sendo utilizado
        {

        }
        public Pessoa (string nome, string sobrenome, string acompanhado, int idade) //só para teste
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Idade = idade;
            Acompanhado = acompanhado;
        }

        private string _nome;
        private string _sobrenome;
        private int _idade;
        private string _acompanhado;

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
                    throw new ArgumentException("O sobrenome não poder ser vazio");
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
        
        public string Acompanhado 
        {
            get => _acompanhado;

            set
            {
                if (value == "")
                        {
                            throw new ArgumentException("Acompanado não poder ser vazio");
                        }

                        _acompanhado = value;
            }
        }
        public void Apresentar()
        {
            if(listaDeHospedes.Count == 0)
            {
                
                Console.WriteLine("Nenhum hóspede registrado ainda.");
                return;
                
            }
            foreach ( string hospede in listaDeHospedes)
            {
                Console.WriteLine(hospede);
            }
        }

        public void ObtainInfoDeHospede() 
        {
            Console.Clear();
            Menu titulo = new Menu();
            titulo.Titulo();
            Console.WriteLine("\nDigite o nome do hóspede: ");
            Nome = Console.ReadLine();

            Console.WriteLine("\nDigite o sobrenome do hóspede: ");
            Sobrenome = Console.ReadLine();

            Console.WriteLine("\nDigite a idade do hóspede:");
            Idade = int.Parse(Console.ReadLine());

            AddHospedes();

        }
        public static List<string> listaDeHospedes = new List<string>();
        public void AddHospedes()
        {
             listaDeHospedes.Add(NomeCompleto + ", " + Idade + " anos");
        }

        public void QuantidadeDeAcompanhantes()
        {
            Console.WriteLine("\nEstá acompanhado? Y/n ");
            Acompanhado = Console.ReadLine();

            if(Acompanhado == "Y")
            {   
                Console.Clear();

                Menu titulo = new Menu();
                titulo.Titulo();

                Console.WriteLine("\nDigite a quantidade de acompanhantes: ");
                int qtdDeAcompanhantes = int.Parse(Console.ReadLine());

                for (int i = 0; i < qtdDeAcompanhantes; i++)
                {   
                    Console.Clear();

                    Menu titulo1 = new Menu();
                    titulo1.Titulo();

                    Console.WriteLine($"Digite as informações do acompanhante {i + 1}\n");
                    Thread.Sleep(2500);
                    ObtainInfoDeHospede();
                }
            }
            

        }
        
    }

}