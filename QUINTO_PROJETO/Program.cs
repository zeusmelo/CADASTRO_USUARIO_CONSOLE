using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QUINTO_PROJETO
{
    internal class Program
    {
        public static void msg(string msg)
        {
            Console.WriteLine(msg);
        }
      public enum Direcao_e { sucesso, sair, execao }
       public struct DadosCadastrais{
           public string nome;
          public  string endereco;
           public DateTime nasc;
          public  UInt32 numcasa;
            }

        public static Direcao_e PegaString(ref string minhaopc, string msg)
        {
            Direcao_e retorno;
            Console.WriteLine(msg);
            string temp = Console.ReadLine().ToLower();
            if (temp == "s" )
            {
                retorno = Direcao_e.sair;
            }else
            {
                minhaopc = temp;
                retorno = Direcao_e.sucesso; 
            }
            Console.Clear();
            return retorno;
        }

        public static Direcao_e PegaUint(ref UInt32 minhaopc, string msg)
        {
            Direcao_e retorno;
            do
            {
                try
                {
                    Console.WriteLine(msg);
                    string temp = Console.ReadLine();
                    if (temp == "s")
                    {
                        retorno = Direcao_e.sair;
                    }else
                    {
                       UInt32 tempnum = Convert.ToUInt32(temp);
                        minhaopc = tempnum;
                        retorno = Direcao_e.sucesso;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    retorno = Direcao_e.execao;
                }

            } while (retorno == Direcao_e.execao);
            Console.Clear();
            return retorno;
        }

        public static Direcao_e PegaDate(ref DateTime minhaopc, string msg)
        {
            Direcao_e retorno;
            do
            {
                try
                {
                    Console.WriteLine(msg);
                    string temp = Console.ReadLine();
                    if (temp == "s")
                    {
                        retorno = Direcao_e.sair;
                    }
                    else
                    {
                        DateTime tempnum= Convert.ToDateTime(temp);
                        retorno = Direcao_e.sucesso;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    retorno = Direcao_e.execao;
                }

            } while (retorno == Direcao_e.execao);
            Console.Clear();
            return retorno;
        }

        public static void cadastro(ref List<DadosCadastrais> listadados)
        {
            DadosCadastrais preencher;
            preencher.nome = "";
            preencher.endereco = "";
            preencher.nasc = new DateTime();
            preencher.numcasa = 0;

            if (PegaString(ref preencher.nome, "Digite seu nome ou s para sair") != Direcao_e.sucesso) { return; }
            if (PegaString(ref preencher.endereco, "Digite seu endereço ou s para sair") != Direcao_e.sucesso) { return; }
            if (PegaDate(ref preencher.nasc, "Digite sua data de nasc. ou s para sair") != Direcao_e.sucesso) { return; }
            if (PegaUint(ref preencher.numcasa, "Digite o numero da sua casa ou s para sair") != Direcao_e.sucesso) { return; }
            listadados.Add(preencher);
        }

        public static void Main(string[] args)
        {
            string opcao = "";
            List<DadosCadastrais> listdados = new List<DadosCadastrais>();
            do
            {
                Console.WriteLine("Digite C para registrar um novo usuario ou S para sair");
                 opcao = Console.ReadKey(true).KeyChar.ToString();

                if (opcao == "c")
                {
                    cadastro(ref listdados);

                } else if (opcao == "s")
                {
                    msg("Encerrando o programa");
                } else
                {
                    Console.Clear();
                }

            } while (opcao != "s");


            Console.Clear();
            Console.WriteLine("Digite qualquer tecla para sair: ");
            Console.ReadKey();
        }
    }
}
