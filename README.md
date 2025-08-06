# Sistema_De_Hospedagem
# Sistema de Hospedagem - Hotel Cama, Café e Confusão

Este projeto é uma aplicação de console desenvolvida em C# que simula um sistema de gerenciamento de hospedagem de um hotel. O sistema realiza operações como check-in, cadastro de hóspedes, seleção de suítes, cálculo de diárias e checkout.

## Funcionalidades

- Cadastro de hóspede e acompanhantes
- Consulta de suítes disponíveis via API (JSON Server)
- Seleção e reserva de suítes
- Cálculo do valor total da hospedagem, com desconto de 10% para estadias de 10 dias ou mais
- Atualização do status do quarto (ocupado/disponível)
- Checkout com liberação do quarto e remoção do hóspede da lista
- Visualização da lista de hóspedes e status dos quartos

## Tecnologias utilizadas

- C# (.NET)
- JSON Server (API local)
- Programação orientada a objetos

## Como executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git

2. Instale o Json Server (caso não tenha ainda):
   npm install -g json-server
   
3. Inicie o Json Server com o arquivo db.json:
   json-server --watch db.json

4. Compile e execute o projeto no VS Code ou usando o terminal:
   dotnet run

## Organização do projeto

-Program.cs: ponto de entrada da aplicação

-Menu.cs: exibe o menu principal e redireciona para as opções

-Reserva.cs: gerencia check-in, cálculo de diárias, seleção de suítes e checkout

-Pessoa.cs: representa o hóspede e seus dados

-Suite.cs: lida com a exibição e controle dos quartos

-APIServer.cs: responsável pelas chamadas HTTP para a API de quartos

-db.json: arquivo com os dados simulados da API (suítes)

## Observações
O projeto simula um sistema simples e didático de hospedagem, voltado para estudos de C# com foco em orientação a objetos e integração com API REST fake


