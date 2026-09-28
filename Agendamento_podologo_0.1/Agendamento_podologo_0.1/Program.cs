using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agendamento_Clinico

{

    internal class Program
    {/* Atividade Prática: Sistema de Agendamento para Clínica de Podologia (C# Console)
 
Objetivo
 
Mapear os requisitos de atendimento da clínica, implementar a estrutura de Funçãos com atributos específicos da podologia e construir uma interface via terminal (switch-case com do-while) para gerenciar clientes, profissionais, serviços e consultas.
 
Requisitos do Projeto: Estrutura de Campos
 
Crie uma Função para cada entidade do sistema com os devidos tipos de dados em C#:
 
*/
        public static class Variaveis
        {
            // Cliente
            public static int clienteId = 0;
            public static string NomePaciente;
            public static string cpf;
            public static string contato;
            public static string ObsClinica;
            public static DateTime IdadeHistorico;
            public static bool FatordRisco;

            // Podólogo
            public static int Polodoid = 0;
            public static int qtdPologo;
            public static string nomeMedico;
            public static string RegistroProfissional;
            public static string especialidade;
            public static string telefone;

            // Procedimento / Serviço
            public static int codigo_procedimento;
            public static DateTime TempoAtendimento;
            public static string NomeProcedimento;
            public static decimal ValorServico;

            // Agendamento
            public static int id;
            public static int procedimentoId;
            public static int clienteIdAgendamento;
            public static int podologoId;
            public static DateTime data;
            public static string status;

        }
        static void Main(string[] args)

        {

            int opcao = -1;

            while (opcao != 0)

            {

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("╔===================================================================================╗");
                Console.WriteLine(@"                                                                                   
                ███╗░░░███╗███████╗███╗░░██╗██╗░░░██╗	██████╗░███████╗                                               
                ████╗░████║██╔════╝████╗░██║██║░░░██║	██╔══██╗██╔════╝                                               
                ██╔████╔██║█████╗░░██╔██╗██║██║░░░██║	██║░░██║█████╗░░                                               
                ██║╚██╔╝██║██╔══╝░░██║╚████║██║░░░██║	██║░░██║██╔══╝░░                                               
                ██║░╚═╝░██║███████╗██║░╚███║╚██████╔╝	██████╔╝███████╗                                               
                ╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░╚═════╝░	╚═════╝░╚══════╝                                               
                                                                                                                          
                ░█████╗░░█████╗░██████╗░░█████╗░░██████╗████████╗██████╗░░█████╗░                                      
                ██║░░╚═╝███████║██║░░██║███████║╚█████╗░░░░██║░░░██████╔╝██║░░██║                                      
                ██║░░██╗██╔══██║██║░░██║██╔══██║░╚═══██╗░░░██║░░░██╔══██╗██║░░██║                                      
                ╚█████╔╝██║░░██║██████╔╝██║░░██║██████╔╝░░░██║░░░██║░░██║╚█████╔╝                                      
                ░╚════╝░╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░                                      
                                                                                                                       
                ██████╗░░█████╗░██████╗░░█████╗░██╗░░░░░░█████╗░░██████╗░░█████╗░                                      
                ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║░░░░░██╔══██╗██╔════╝░██╔══██╗                                      
                ██████╔╝██║░░██║██║░░██║██║░░██║██║░░░░░██║░░██║██║░░██╗░██║░░██║                                      
                ██╔═══╝░██║░░██║██║░░██║██║░░██║██║░░░░░██║░░██║██║░░╚██╗██║░░██║                                      
                ██║░░░░░╚█████╔╝██████╔╝╚█████╔╝███████╗╚█████╔╝╚██████╔╝╚█████╔╝                                      
                ╚═╝░░░░░░╚════╝░╚═════╝░░╚════╝░╚══════╝░╚════╝░░╚═════╝░░╚════╝░                                      
                    ░");                                                                  


                         Console.WriteLine("         1 - Cadastrar Cliente (Ficha Rápida ");

                         Console.WriteLine("         2 - Cadastrar Podólogo");

                         Console.WriteLine("         3 - Cadastrar Procedimento/Serviço");
                    
                         Console.WriteLine("         4 - Agendar Consulta ");

                         Console.WriteLine("         5 - Listar Agendamentos");

                         Console.WriteLine("         6 - Exibir Todos os Cadastros ");

                         Console.WriteLine("   0 - Sair ");

                Console.WriteLine("╚==================================================================================╝");
                opcao = int.Parse(Console.ReadLine());


                switch (opcao)

                {


                    case 1:

                        Cliente_Podologia();


                        break;

                    case 2:
                        Podologo();

                        break;

                    case 3:

                        Procedimento_Servico();


                        break;


                    case 4:

                        Agendamento();
                        break;


                    case 5:
                        ListarAgend();

                        break;

                    case 6:

                        Exibir_cadastro();

                        break;


                    case 0:

                        Console.Clear();

                        Console.WriteLine(" Finalizado Até a proxima !!! ");


                        break;

                }


            }


        }


        static void Cliente_Podologia()

        {






            Console.Clear();

            Console.WriteLine(@"
                    ░█████╗░░█████╗░██████╗░░█████╗░░██████╗████████╗██████╗░░█████╗░
                    ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝╚══██╔══╝██╔══██╗██╔══██╗
                    ██║░░╚═╝███████║██║░░██║███████║╚█████╗░░░░██║░░░██████╔╝██║░░██║
                    ██║░░██╗██╔══██║██║░░██║██╔══██║░╚═══██╗░░░██║░░░██╔══██╗██║░░██║
                    ╚█████╔╝██║░░██║██████╔╝██║░░██║██████╔╝░░░██║░░░██║░░██║╚█████╔╝
                    ░╚════╝░╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░
 
                    ░█████╗░██╗░░░░░██╗███████╗███╗░░██╗████████╗███████╗
                    ██╔══██╗██║░░░░░██║██╔════╝████╗░██║╚══██╔══╝██╔════╝
                    ██║░░╚═╝██║░░░░░██║█████╗░░██╔██╗██║░░░██║░░░█████╗░░
                    ██║░░██╗██║░░░░░██║██╔══╝░░██║╚████║░░░██║░░░██╔══╝░░
                    ╚█████╔╝███████╗██║███████╗██║░╚███║░░░██║░░░███████╗
                    ░╚════╝░╚══════╝╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░╚══════╝");


            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;


            Console.WriteLine(" Digite o id do paciente ");

            Variaveis.clienteId = int.Parse(Console.ReadLine());


            Console.WriteLine(" Digite o nome do paciente ");

            Variaveis.NomePaciente = Console.ReadLine();


            Console.WriteLine(" Digite o cpf do paciente ");

            Variaveis.cpf = Console.ReadLine();


            Console.WriteLine(" Digite o telefone de contato do paciente ");

            Variaveis.contato = Console.ReadLine();


            Console.WriteLine(" Digite a Observaçao Clinica do paciente ");

            Variaveis.ObsClinica = Console.ReadLine();


            Console.WriteLine(" Digite a data de nascimento do paciente / Hisorico ");

            Variaveis.IdadeHistorico = DateTime.Parse(Console.ReadLine());


            Console.WriteLine(" o paciente tem algum probelma cronico ");

            Variaveis.FatordRisco = bool.Parse(Console.ReadLine());


            Console.WriteLine("\n Cadastro Finalizado com Sucesso: !!!");




            Thread.Sleep(7000);


        }


        static void Procedimento_Servico()

        {




            Console.Clear();

            Console.WriteLine(@"
                ██████╗░██████╗░░█████╗░░█████╗░███████╗██████╗░██╗███╗░░░███╗███████╗███╗░░██╗████████╗░█████╗░
                ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗██║████╗░████║██╔════╝████╗░██║╚══██╔══╝██╔══██╗
                ██████╔╝██████╔╝██║░░██║██║░░╚═╝█████╗░░██║░░██║██║██╔████╔██║█████╗░░██╔██╗██║░░░██║░░░██║░░██║
                ██╔═══╝░██╔══██╗██║░░██║██║░░██╗██╔══╝░░██║░░██║██║██║╚██╔╝██║██╔══╝░░██║╚████║░░░██║░░░██║░░██║
                ██║░░░░░██║░░██║╚█████╔╝╚█████╔╝███████╗██████╔╝██║██║░╚═╝░██║███████╗██║░╚███║░░░██║░░░╚█████╔╝
                ╚═╝░░░░░╚═╝░░╚═╝░╚════╝░░╚════╝░╚══════╝╚═════╝░╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░░╚════╝░
 
                ░██████╗███████╗██████╗░██╗░░░██╗██╗░█████╗░░█████╗░
                ██╔════╝██╔════╝██╔══██╗██║░░░██║██║██╔══██╗██╔══██╗
                ╚█████╗░█████╗░░██████╔╝╚██╗░██╔╝██║██║░░╚═╝██║░░██║
                ░╚═══██╗██╔══╝░░██╔══██╗░╚████╔╝░██║██║░░██╗██║░░██║
                ██████╔╝███████╗██║░░██║░░╚██╔╝░░██║╚█████╔╝╚█████╔╝
                ╚═════╝░╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝░╚════╝░░╚════╝░");


            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;


            Console.WriteLine(" Digite o codigo do procedimento ");

            Variaveis.codigo_procedimento = int.Parse(Console.ReadLine());


            Console.WriteLine(" Digite o tempo estimado do atendimento ");

            Variaveis.TempoAtendimento = DateTime.Parse(Console.ReadLine());


            Console.WriteLine(" digite o nome do procedimento que sera usado ");

            Variaveis.NomeProcedimento = Console.ReadLine();


            Console.WriteLine(" Digite o Valor do serviço ");

            Variaveis.ValorServico = decimal.Parse(Console.ReadLine());


            Console.WriteLine("\n Procedimento Registrado com sucesso!!!");





            Thread.Sleep(7500);


        }

        static void Podologo()
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(@"
            ░█████╗░░█████╗░██████╗░░█████╗░░██████╗████████╗██████╗░░█████╗░
            ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝╚══██╔══╝██╔══██╗██╔══██╗
            ██║░░╚═╝███████║██║░░██║███████║╚█████╗░░░░██║░░░██████╔╝██║░░██║
            ██║░░██╗██╔══██║██║░░██║██╔══██║░╚═══██╗░░░██║░░░██╔══██╗██║░░██║
            ╚█████╔╝██║░░██║██████╔╝██║░░██║██████╔╝░░░██║░░░██║░░██║╚█████╔╝
            ░╚════╝░╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░

            ██████╗░░█████╗░██████╗░░█████╗░██╗░░░░░░█████╗░░██████╗░░█████╗░
            ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║░░░░░██╔══██╗██╔════╝░██╔══██╗
            ██████╔╝██║░░██║██║░░██║██║░░██║██║░░░░░██║░░██║██║░░██╗░██║░░██║
            ██╔═══╝░██║░░██║██║░░██║██║░░██║██║░░░░░██║░░██║██║░░╚██╗██║░░██║
            ██║░░░░░╚█████╔╝██████╔╝╚█████╔╝███████╗╚█████╔╝╚██████╔╝╚█████╔╝
            ╚═╝░░░░░░╚════╝░╚═════╝░░╚════╝░╚══════╝░╚════╝░░╚═════╝░░╚════╝░");

            Console.ResetColor();

            
            

           


                Console.WriteLine($"Digite o id do medico");
                Variaveis.Polodoid = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine($"Digite nome do médico");
                Variaveis.nomeMedico = Console.ReadLine();

                Console.WriteLine("Digite o Registro do profissional/CRM: ");
                Variaveis.RegistroProfissional = Console.ReadLine();

                Console.WriteLine("Digite a especialidade: ");
                Variaveis.especialidade = Console.ReadLine();

                Console.WriteLine("Digite o telefone: ");
                Variaveis.telefone = Console.ReadLine();


                Thread.Sleep(7500);
            }
        
        static void Agendamento()
        {

            Console.Clear();

            Console.WriteLine(@"
                ░█████╗░░██████╗░███████╗███╗░░██╗██████╗░░█████╗░███╗░░░███╗███████╗███╗░░██╗████████╗░█████╗░
                ██╔══██╗██╔════╝░██╔════╝████╗░██║██╔══██╗██╔══██╗████╗░████║██╔════╝████╗░██║╚══██╔══╝██╔══██╗
                ███████║██║░░██╗░█████╗░░██╔██╗██║██║░░██║███████║██╔████╔██║█████╗░░██╔██╗██║░░░██║░░░██║░░██║
                ██╔══██║██║░░╚██╗██╔══╝░░██║╚████║██║░░██║██╔══██║██║╚██╔╝██║██╔══╝░░██║╚████║░░░██║░░░██║░░██║
                ██║░░██║╚██████╔╝███████╗██║░╚███║██████╔╝██║░░██║██║░╚═╝░██║███████╗██║░╚███║░░░██║░░░╚█████╔╝
                ╚═╝░░╚═╝░╚═════╝░╚══════╝╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░░╚════╝░");

            Console.ResetColor();
            /* 
            Campo           Tipo em C#      Descrição
            Id              int             Código do agendamento
            ClienteId       int             Código do paciente cadastrado
            PodologoId      int             Código do profissional responsável
            ProcedimentoId  int             Código do procedimento a ser realizado
            DataHora        DateTime        Data e horário marcados
            Status          string          "Agendado", "Concluído", "Cancelado"
            */



            Console.WriteLine("Digite o id do procedimento: ");

            Variaveis.procedimentoId = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o status da consulta: [Agendado, Concluido, Cancelado]");
            Variaveis.status = Console.ReadLine();

            if (Variaveis.status == "cancelado")
            {
                Console.WriteLine("Consulta cancelada.....");
            }
            else
            {
                Console.WriteLine("Digite a data do agendamento (dd/mm/aaaa hh:mm): ");
                Variaveis.data = DateTime.Parse(Console.ReadLine());

                Console.WriteLine($"Consulta salva para {Variaveis.data:dd/MM/yyyy HH:mm}!");

            }



            Thread.Sleep(7500);


        }



    

    static void ListarAgend()
        {
            Console.Clear();

            Console.WriteLine(Variaveis.id);
            Console.WriteLine(Variaveis.clienteId);
            Console.WriteLine(Variaveis.podologoId);
            Console.WriteLine(Variaveis.procedimentoId);
            Console.WriteLine(Variaveis.data);
            Console.WriteLine(Variaveis.status);
            Thread.Sleep(7500);

        }

        static void Exibir_cadastro()
        {
            Console.Clear();

            Console.WriteLine(Variaveis.podologoId);
            Console.WriteLine(Variaveis.nomeMedico);
            Console.WriteLine(Variaveis.RegistroProfissional);
            Console.WriteLine(Variaveis.especialidade);
            Console.WriteLine(Variaveis.telefone);
            Console.WriteLine(Variaveis.clienteId);
            Console.WriteLine(Variaveis.codigo_procedimento);
            Console.WriteLine(Variaveis.TempoAtendimento);
            Console.WriteLine(Variaveis.NomeProcedimento);
            Console.WriteLine(Variaveis.ValorServico);

            Thread.Sleep(7500);





        }





















    } 

}