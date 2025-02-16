using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Sistema_de_Hospedagem.Models
{
    public class Suite
    {
           public static Dictionary<string, bool> suites = new Dictionary<string, bool>();
           public Suite()
           {
                if (suites.Count == 0)
                AddSuite();
           }

           public void AddSuite()
           {
                suites["Single Room"] = true;
                suites["Twin Room"] = true;
                suites["Standard"] = true;
                suites["Master"] = true;
                suites["Deluxe"] = true;
           }
            public void SuitesStatus()
            {

                Thread.Sleep(2000);

                Console.WriteLine("\nStatus das suítes:");
                foreach (var suite in suites)
                {
                    string status = suite.Value ? "Disponível" : "Ocupado";
                    Console.WriteLine($"{suite.Key}: {status}");
                }
            }
            public void SelecionarSuite()
            {

                SuitesStatus();

                Console.WriteLine("\nDigite o nome da suíte que deseja ocupar:");
                string suiteSelecionada = Console.ReadLine();

                if (suites.ContainsKey(suiteSelecionada))
                {
                    if (suites[suiteSelecionada])
                    {
                        suites[suiteSelecionada] = false;
                        Console.WriteLine($"A suíte {suiteSelecionada} foi reservada.");
                    }
                    else
                    {
                        Console.WriteLine("Essa suíte já está ocupada.");
                    }
                }
                else
                {
                    Console.WriteLine("Suíte não encontrada.");
                }
            }
    }
}