using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Internacao_Hospitalar
{
    internal class Program
    { /* Modelar a estrutura de dados e fluxos de controle de um ambiente hospitalar, 
        praticando encapsulamento, listas ligadas/referências simples por ID, manipulate 
        de tipos DateTime 
        para controle de permanência e tratamento de estados de leitos (Livre / Ocupado).
        Requisitos do Projeto: Estrutura de Campos
        Crie uma Função para cada uma das entidades listadas abaixo:
*/
        public static class Variaveis
        {  // Paciente
            public static int idpaciente;
            public static string NomePaciente, cpf, Tiposanguineo, Alergias, contatoEmergencia;
            public static DateTime DataNascimento;

            // Medico
            public static int idMedico;
            public static string nome, CRM, especialidade, telefone;
            


            //Leito
            public static int identifiQuarto;
            public static string NumeroQuarto, tipoDequarto;
            public static bool estado_ocupado_livre;

            // internação
            public static int id;
            public static DateTime? DataEntrada, dataAlta = null;
            public static string DiagnosticoEntrada, Status;


            
        }

        static void Main(string[] args)
        {
            int opcao = -1;
            while (opcao != 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"
            ██╗███╗░░██╗████████╗███████╗██████╗░███╗░░██╗░█████╗░░█████╗░░█████╗░░█████╗░
            ██║████╗░██║╚══██╔══╝██╔════╝██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗
            ██║██╔██╗██║░░░██║░░░█████╗░░██████╔╝██╔██╗██║███████║██║░░╚═╝███████║██║░░██║
            ██║██║╚████║░░░██║░░░██╔══╝░░██╔══██╗██║╚████║██╔══██║██║░░██╗██╔══██║██║░░██║
            ██║██║░╚███║░░░██║░░░███████╗██║░░██║██║░╚███║██║░░██║╚█████╔╝██║░░██║╚█████╔╝
            ╚═╝╚═╝░░╚══╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝░╚════╝░

            ██╗░░██╗░█████╗░░██████╗██████╗░██╗████████╗░█████╗░██╗░░░░░░█████╗░██████╗░
            ██║░░██║██╔══██╗██╔════╝██╔══██╗██║╚══██╔══╝██╔══██╗██║░░░░░██╔══██╗██╔══██╗
            ███████║██║░░██║╚█████╗░██████╔╝██║░░░██║░░░███████║██║░░░░░███████║██████╔╝
            ██╔══██║██║░░██║░╚═══██╗██╔═══╝░██║░░░██║░░░██╔══██║██║░░░░░██╔══██║██╔══██╗
            ██║░░██║╚█████╔╝██████╔╝██║░░░░░██║░░░██║░░░██║░░██║███████╗██║░░██║██║░░██║
            ╚═╝░░╚═╝░╚════╝░╚═════╝░╚═╝░░░░░╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝");

                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("1 - Cadastrar Paciente ");
                Console.WriteLine("2 - Cadastrar Médico ");
                Console.WriteLine("3 - Cadastrar Leito ");
                Console.WriteLine("4 - Registrar Internação (Admissão) ");
                Console.WriteLine("5 - Dar Alta Hospitalar ");
                Console.WriteLine("6 - - Listar Pacientes Internados ");
                Console.WriteLine("7 - Exibir Relatório Geral do Hospital ");
                Console.WriteLine("0 -  Sair ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Paciente();
                        break;
                    case 2:
                        Medico();
                        break;
                       
                    case 3:
                        Quarto_do_paciente();
                        break;

                    case 4:
                        Internacao();
                        break;

                    case 5:
                        Dar_Alta();
                        break;

                    case 6:
                        Pacientes_internados();
                        break;

                    case 7:
                        Registro_Geral();
                        break;

                    case 0:
                        Console.Clear();
                        Console.WriteLine(" Programa finalizado !!!");
                        break;
                }

            }


        }
        static void Paciente()
        {
           
            Console.Clear();
            Console.WriteLine(@"
        ░█████╗░░█████╗░██████╗░░█████╗░░██████╗████████╗██████╗░░█████╗░
        ██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝╚══██╔══╝██╔══██╗██╔══██╗
        ██║░░╚═╝███████║██║░░██║███████║╚█████╗░░░░██║░░░██████╔╝██║░░██║
        ██║░░██╗██╔══██║██║░░██║██╔══██║░╚═══██╗░░░██║░░░██╔══██╗██║░░██║
        ╚█████╔╝██║░░██║██████╔╝██║░░██║██████╔╝░░░██║░░░██║░░██║╚█████╔╝
        ░╚════╝░╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░

        ██████╗░░█████╗░░█████╗░██╗███████╗███╗░░██╗████████╗███████╗
        ██╔══██╗██╔══██╗██╔══██╗██║██╔════╝████╗░██║╚══██╔══╝██╔════╝
        ██████╔╝███████║██║░░╚═╝██║█████╗░░██╔██╗██║░░░██║░░░█████╗░░
        ██╔═══╝░██╔══██║██║░░██╗██║██╔══╝░░██║╚████║░░░██║░░░██╔══╝░░
        ██║░░░░░██║░░██║╚█████╔╝██║███████╗██║░╚███║░░░██║░░░███████╗
        ╚═╝░░░░░╚═╝░░╚═╝░╚════╝░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░╚══════╝");

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(" Digite o codigo de Identificação do paciente");
            Variaveis.idpaciente = int.Parse(Console.ReadLine());

            Console.WriteLine(" Digite o nome completo do paciente ");
            Variaveis.NomePaciente = Console.ReadLine();

            Console.WriteLine(" Digite o CPF do paciente");
            Variaveis.cpf = Console.ReadLine();

            Console.WriteLine(" Digite o tipo sanguineo do paciente ");
            Variaveis.Tiposanguineo = Console.ReadLine();

            Console.WriteLine(" Digite Se O Paciente é alergico a algum medicamento ");
            Variaveis.Alergias = Console.ReadLine();

            Console.WriteLine(" Digite um contato de Emergencia ");
            Variaveis.contatoEmergencia = Console.ReadLine();

            Console.WriteLine(" Digite a Data De nascimento Do Paciente ");
            Variaveis.DataNascimento = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\n Prontuario Registrado com sucesso: !!!");

          /*  Console.WriteLine("\n" + Id);
            Console.WriteLine("\n" + NomePaciente);
            Console.WriteLine("\n" + cpf);
            Console.WriteLine("\n" + Tiposanguineo);
            Console.WriteLine("\n" + Alergias);
            Console.WriteLine("\n" + contatoEmergencia);
            Console.WriteLine("\n" + DataNascimento);
           
            Thread.Sleep(7000);*/

        }

        static void Quarto_do_paciente()
        {
            



           Console.Clear();
            Console.WriteLine(@"
            ██╗░░░░░███████╗██╗████████╗░█████╗░
            ██║░░░░░██╔════╝██║╚══██╔══╝██╔══██╗
            ██║░░░░░█████╗░░██║░░░██║░░░██║░░██║
            ██║░░░░░██╔══╝░░██║░░░██║░░░██║░░██║
            ███████╗███████╗██║░░░██║░░░╚█████╔╝
            ╚══════╝╚══════╝╚═╝░░░╚═╝░░░░╚════╝░

            ██╗███╗░░██╗████████╗███████╗██████╗░███╗░░██╗░█████╗░░█████╗░░█████╗░░█████╗░
            ██║████╗░██║╚══██╔══╝██╔════╝██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗
            ██║██╔██╗██║░░░██║░░░█████╗░░██████╔╝██╔██╗██║███████║██║░░╚═╝███████║██║░░██║
            ██║██║╚████║░░░██║░░░██╔══╝░░██╔══██╗██║╚████║██╔══██║██║░░██╗██╔══██║██║░░██║
            ██║██║░╚███║░░░██║░░░███████╗██║░░██║██║░╚███║██║░░██║╚█████╔╝██║░░██║╚█████╔╝
            ╚═╝╚═╝░░╚══╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝░╚════╝░");

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(" Digite o id Identificador do leito ");
            Variaveis.identifiQuarto = int.Parse(Console.ReadLine());

            Console.WriteLine(" Digite o numero do quarto ");
            Variaveis.NumeroQuarto = Console.ReadLine();

            Console.WriteLine(" Digite o tipo de quarto ");
            Variaveis.tipoDequarto = Console.ReadLine();

            Console.WriteLine(" informe se o leito esta ocupado ou livre[ Digite: True ou False]");
            Variaveis.estado_ocupado_livre = bool.Parse(Console.ReadLine());

            if (Variaveis.estado_ocupado_livre == true)
            {
                Console.WriteLine("\n O leito Esta livre: ");
                /*
                Console.WriteLine("\n" + identifiQuarto);
                Console.WriteLine("\n" + NumeroQuarto);
                Console.WriteLine("\n" + tipoDequarto);
                Console.WriteLine("\n" + estado_ocupado_livre);
                */
                Thread.Sleep(7500);
            }
            else 
            {
                Console.WriteLine(" O Leito esta ocupado ");
            }
                 Thread.Sleep(7000);

        }

        static void Medico()

        {


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
░█████╗░░█████╗░██████╗░░█████╗░░██████╗████████╗██████╗░░█████╗░  ███╗░░░███╗███████╗██████╗░██╗░█████╗░░█████╗░
██╔══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝╚══██╔══╝██╔══██╗██╔══██╗  ████╗░████║██╔════╝██╔══██╗██║██╔══██╗██╔══██╗
██║░░╚═╝███████║██║░░██║███████║╚█████╗░░░░██║░░░██████╔╝██║░░██║  ██╔████╔██║█████╗░░██║░░██║██║██║░░╚═╝██║░░██║
██║░░██╗██╔══██║██║░░██║██╔══██║░╚═══██╗░░░██║░░░██╔══██╗██║░░██║  ██║╚██╔╝██║██╔══╝░░██║░░██║██║██║░░██╗██║░░██║
╚█████╔╝██║░░██║██████╔╝██║░░██║██████╔╝░░░██║░░░██║░░██║╚█████╔╝  ██║░╚═╝░██║███████╗██████╔╝██║╚█████╔╝╚█████╔╝
░╚════╝░╚═╝░░╚═╝╚═════╝░╚═╝░░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░  ╚═╝░░░░░╚═╝╚══════╝╚═════╝░╚═╝░╚════╝░░╚════╝░");


            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;






            Console.WriteLine("Digite o nome do medico: ");

            Variaveis.nome = Console.ReadLine();


                Console.WriteLine("Digite o CRM do medico: ");

            Variaveis.CRM = Console.ReadLine();


                Console.WriteLine("Digite a especialidade do médico: ");

            Variaveis.especialidade = Console.ReadLine();


                Console.WriteLine("Digite o telefone do médico (DDD) --------");

            Variaveis.telefone = Console.ReadLine();


            }


        



        static void Internacao()

        {

            /*Id int Código do registro de internação


                    PacienteId int Código do paciente


                    MedicoResponsavelId int Código do médico responsável


                    LeitoId int Código do leito alocado


                    DataEntrada DateTime Data e hora da admissão


                    DataAlta DateTime? Data e hora da alta(nulo enquanto internado)


                    DiagnosticoEntrada string Motivo/ quadro na admissão


                    Status string "Em Internação", "Alta Concluída", "Transferido"*/





            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
██╗███╗░░██╗████████╗███████╗██████╗░███╗░░██╗░█████╗░░█████╗░░█████╗░░█████╗░
██║████╗░██║╚══██╔══╝██╔════╝██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗
██║██╔██╗██║░░░██║░░░█████╗░░██████╔╝██╔██╗██║███████║██║░░╚═╝███████║██║░░██║
██║██║╚████║░░░██║░░░██╔══╝░░██╔══██╗██║╚████║██╔══██║██║░░██╗██╔══██║██║░░██║
██║██║░╚███║░░░██║░░░███████╗██║░░██║██║░╚███║██║░░██║╚█████╔╝██║░░██║╚█████╔╝
╚═╝╚═╝░░╚══╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝░╚════╝░");


            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Digite o id da internação: ");

            Variaveis.id = int.Parse(Console.ReadLine());


                
                Console.WriteLine("Digite a data de entrada: ");

            Variaveis.DataEntrada = DateTime.Parse(Console.ReadLine());





                Console.WriteLine("Digite o Diagnostico de Entrada: ");

            Variaveis.DiagnosticoEntrada = Console.ReadLine();


                Console.WriteLine($"Digite o status da internação: [Em Internação, Alta Concluída, Transferido '] ");

            Variaveis.Status = Console.ReadLine();


                if (Variaveis.Status != "Em Internação" || Variaveis.Status == "Transferido")

                {
                Variaveis.dataAlta = DateTime.Now.AddDays(2);
                    Console.WriteLine("Digite a data da alta (dd/mm/aaaa): ");

                    Variaveis.dataAlta = DateTime.Parse(Console.ReadLine());


                }

                else

                {
                    Console.WriteLine("Digite a data da alta (dd/mm/aaaa): ");

                    Variaveis.dataAlta = DateTime.Parse(Console.ReadLine());


                }


                Console.WriteLine("\nInternações processadas com sucesso!");


           



        }
        static void Dar_Alta()

        {
            if (Variaveis.Status == null)
            {
                Console.WriteLine("Não existe nenhuma internação cadastrada.");
            }
            else if (Variaveis.Status.Trim().Equals("Em Internação", StringComparison.OrdinalIgnoreCase))
            {
                Variaveis.dataAlta = DateTime.Now;
                Variaveis.Status = "Alta Concluída";

                Console.WriteLine("Alta hospitalar realizada com sucesso!");
                Console.WriteLine($"Data da alta: {Variaveis.dataAlta}");
            }
            else
            {
                Console.WriteLine("O paciente não está internado.");
                Console.WriteLine($"Status atual: {Variaveis.Status}");
            }

            Thread.Sleep(3000);
        }
        
        static void Pacientes_internados()

        {
            Console.Clear();

            /*  Console.WriteLine($" Identificação do paciente {Variaveis.idpaciente}  ");
              Console.WriteLine($" Nome do Paciente {Variaveis.NomePaciente}");
              Console.WriteLine($"Tipo sanguineo do paciente {Variaveis.Tiposanguineo}");
              Console.WriteLine($" Alergias do paciente{Variaveis.Alergias}");
              Console.WriteLine($"Contato De emergencia {Variaveis.contatoEmergencia}");
              Console.WriteLine($" Identificação do quarto {Variaveis.identifiQuarto}");*/
            if (Variaveis.Status != null &&  Variaveis.Status == "em internação")
            {
                Console.WriteLine($"Identificação do paciente: {Variaveis.idpaciente}");
                Console.WriteLine($"Nome do Paciente: {Variaveis.NomePaciente}");
                Console.WriteLine($"Tipo sanguíneo: {Variaveis.Tiposanguineo}");
                Console.WriteLine($"Alergias: {Variaveis.Alergias}");
                Console.WriteLine($"Contato de emergência: {Variaveis.contatoEmergencia}");
                Console.WriteLine($"Identificação do quarto: {Variaveis.identifiQuarto}");
                Console.WriteLine($"Status: {Variaveis.Status}");
            }
            else
            {
                Console.WriteLine("Não existem pacientes internados.");
            }
            Thread.Sleep(3000);


        }
        static void Registro_Geral()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@" 
                        █▀█ ▄▀█ █▀▀ █ █▀▀ █▄░█ ▀█▀ █▀▀
                        █▀▀ █▀█ █▄▄ █ ██▄ █░▀█ ░█░ ██▄");

            Console.ResetColor();
            Console.WriteLine($" idpaciente {Variaveis.idpaciente}");
            Console.WriteLine($" Nome do Paciente {Variaveis.NomePaciente}");
            Console.WriteLine($" CPF Do Paciente {Variaveis.cpf}");
            Console.WriteLine($" Tipo Sanguineo do paciente {Variaveis.Tiposanguineo}");
            Console.WriteLine($" Alergias Do Paciente {Variaveis.Alergias}");
            Console.WriteLine($" Contato De Emergencia {Variaveis.contatoEmergencia}");
            Console.WriteLine($" Data de Nascimento {Variaveis.DataNascimento}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"
                        █▀▄▀█ █▀▀ █▀▄ █ █▀▀ █▀█
                        █░▀░█ ██▄ █▄▀ █ █▄▄ █▄█ ");

            Console.ResetColor();
            Console.WriteLine($" Id Identificaçao do medico {Variaveis.idMedico}");
            Console.WriteLine($" Nome do Medico {Variaveis.nome}");
            Console.WriteLine($" Registro Do conselho medico CRM {Variaveis.CRM}");
            Console.WriteLine($" Especialidade Do Medico {Variaveis.especialidade}");
            Console.WriteLine($" Telefone do medico {Variaveis.telefone}");
            Console.WriteLine($" Identificação do quarto {Variaveis.identifiQuarto}");
            Console.WriteLine($" Numero Do Quarto {Variaveis.NumeroQuarto}");
            Console.WriteLine($" Tipo Do Quarto {Variaveis.tipoDequarto}");
            Console.WriteLine($" Estado do Quarto {Variaveis.estado_ocupado_livre}");

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(7000);

        }

        /*public static int idpaciente;
            public static string NomePaciente, cpf, Tiposanguineo, Alergias, contatoEmergencia;
            public static DateTime DataNascimento;

            // Medico
            public static int idMedico;
            public static string nome, CRM, especialidade, telefone;
            


            //Leito
            public static int identifiQuarto;
            public static string NumeroQuarto, tipoDequarto;
            public static bool estado_ocupado_livre;*/
    }
}
