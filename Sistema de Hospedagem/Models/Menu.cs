using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sistema_de_Hospedagem.Models;

namespace Sistema_de_Hospedagem
{
    public class Menu
    {   
        public void Titulo()
        {
            Console.WriteLine("***************************");
            Console.WriteLine(@"𝐇𝐨𝐭𝐞𝐥 𝐂𝐚𝐦𝐚, 𝐂𝐚𝐟𝐞́ 𝐞 𝐂𝐨𝐧𝐟𝐮𝐬𝐚̃𝐨");
            Console.WriteLine("***************************");
        }
        public void MenuDeSelecao()
        {
            Console. Clear();

            Titulo();

            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("1- Realizar checkin");
            Console.WriteLine("2- Verificar lista de quartos disponíveis");
            Console.WriteLine("3- Verificar lista de hóspedes");
            Console.WriteLine("4- Realizar checkout");
            Console.WriteLine("5- Sair");
            
            int selecao = int.Parse(Console.ReadLine());

            switch(selecao)
            {
                case 1: 
                {
                    Titulo();

                    Reserva novoCheckin = new Reserva();
                    novoCheckin.FazerChekin();

                    VoltarAoMenu();

                    break;
                }
                case 2:
                {
                    Console.Clear();

                    Titulo();

                    Suite listaDeQuartos = new Suite();
                    listaDeQuartos.SuitesStatus();

                    VoltarAoMenu();

                    break;
                }
                case 3: 
                {
                    Console.Clear();

                    Titulo();

                    Reserva listHospedes = new Reserva();
                    listHospedes.Hospedes();

                    VoltarAoMenu();
                    
                    break;
                }
            }
            
        }
        public void VoltarAoMenu()
        {
            Console.WriteLine("\nDigite 0 para retornar ao menu: ");
            int voltar = int.Parse(Console.ReadLine());

            if(voltar == 0)
            {
                MenuDeSelecao();
            }

            
        }

    }
}