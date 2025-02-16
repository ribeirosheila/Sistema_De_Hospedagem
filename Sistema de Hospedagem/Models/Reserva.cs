using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_de_Hospedagem.Models
{
    public class Reserva
    {
        public void FazerChekin()
        {
            Pessoa checkin = new Pessoa();
            checkin.ObtainInfoDeHospede();

            Thread.Sleep(2000);

            checkin.QuantidadeDeAcompanhantes();

            Suite escolherQuartos = new Suite();
            escolherQuartos.SelecionarSuite();

            Thread.Sleep(2000);
        }
        public void Hospedes()
        {
            Pessoa listaDePessoas = new Pessoa();
            listaDePessoas.Apresentar();

            Thread.Sleep(3000);
        }
        
        
    }
}