using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Hospedagem.Models
{
    /// <summary>
    /// Representa uma pessoa (hóspede) no sistema de hospedagem, com nome, idade e informações de acompanhamento.
    /// </summary>
    public class Pessoa
    {
        public Pessoa() { }

        public Pessoa(string nome, string sobrenome, string acompanhado, int idade)
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
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O nome não pode ser vazio");
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
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O sobrenome não pode ser vazio");
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
                    throw new ArgumentException("A idade não pode ser menor que zero");
                _idade = value;
            }
        }

        public string Acompanhado
        {
            get => _acompanhado;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Acompanhado não pode ser vazio");
                _acompanhado = value;
            }
        }

        /// <summary>
        /// Guarda o ID do quarto reservado por este hóspede.
        /// </summary>
        public string QuartoReservado { get; set; }

        /// <summary>
        /// Lista de hóspedes ativos no sistema.
        /// </summary>
        public static List<Pessoa> listaDeHospedes = new List<Pessoa>();

        /// <summary>
        /// Adiciona a pessoa atual à lista de hóspedes, evitando duplicações.
        /// </summary>
        public void AddHospedes()
        {
            bool jaExiste = listaDeHospedes.Any(p => 
                p.NomeCompleto == this.NomeCompleto && 
                p.Idade == this.Idade && 
                p.QuartoReservado == this.QuartoReservado);

            if (!jaExiste)
                listaDeHospedes.Add(this);
        }

        /// <summary>
        /// Exibe todos os hóspedes da lista.
        /// </summary>
        public void Apresentar()
        {
            if (listaDeHospedes.Count == 0)
            {
                Console.WriteLine("Nenhum hóspede registrado ainda.");
                return;
            }

            foreach (Pessoa hospede in listaDeHospedes)
            {
                Console.WriteLine($"{hospede.NomeCompleto}, {hospede.Idade} anos | id: {hospede.QuartoReservado}");
            }
        }

        /// <summary>
        /// Solicita os dados de um hóspede via console e adiciona na lista.
        /// </summary>
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

        /// <summary>
        /// Pergunta se está acompanhado e coleta dados dos acompanhantes.
        /// </summary>
        public void QuantidadeDeAcompanhantes()
        {
            Console.WriteLine("\nEstá acompanhado? s/n ");
            Acompanhado = Console.ReadLine();

            if (Acompanhado == "s")
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

                    Pessoa acompanhante = new Pessoa();
                    acompanhante.ObtainInfoDeHospede();
                    acompanhante.QuartoReservado = this.QuartoReservado;
                    acompanhante.AddHospedes();
                }
            }
        }

        /// <summary>
        /// Remove todos os hóspedes associados a um determinado quarto.
        /// </summary>
        public static void RemoverHospedesDoQuarto(string idQuarto)
        {
            listaDeHospedes.RemoveAll(p => p.QuartoReservado == idQuarto);
        }
    }
}
