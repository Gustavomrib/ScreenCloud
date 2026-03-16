using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

// Armazenamento das bandas dicionario
Dictionary<string, List<int>> registroBandas = new Dictionary<string, List<int>>();
bool exibirMenu = true;

// Função para padronizar os títulos ( eu refatorei esse codigo )
void ExibirTitulo(string titulo)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan; // Cor do título

    string linha = new string('═', titulo.Length + 4);
    Console.WriteLine(linha);
    Console.WriteLine($"  {titulo.ToUpper()}  ");
    Console.WriteLine(linha);

    Console.ResetColor(); // Volta para o padrão para não pintar o resto do código
    Console.WriteLine();
}
//m laço while
while (exibirMenu)
{
    ExibirTitulo("SCREEN SOUND - MENU PRINCIPAL");

    Console.WriteLine("Digite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;

    if (int.TryParse(opcaoEscolhida, out int numeroEscolhido))
    {
        switch (numeroEscolhido)
        {
            case 1:
                RegistrarBanda();
                break;
            case 2:
                ExibirBandas();
                break;
            case 3:
                AvaliarBanda();
                break;
            case -1:
                Console.WriteLine("Tchau tchau! Até a próxima.");
                exibirMenu = false; // Aqui encerramos o loop com segurança
                break;
            default:
                Console.WriteLine("Opção inválida!");
                Thread.Sleep(2000);
                break;
        }
    }
}

// --- Funções de Apoio ---

void RegistrarBanda()
{
    bool registrarMais = true;

    while (registrarMais)
    {
        ExibirTitulo("REGISTRO DE BANDAS");
        Console.Write("Digite o nome da banda: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (registroBandas.ContainsKey(nomeDaBanda))
        {
            Console.WriteLine($"\nErro: A banda '{nomeDaBanda}' já existe.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nBanda '{nomeDaBanda}' registrada com sucesso!");
            Console.ResetColor();
        }

        Console.Write("\nDeseja registrar outra banda? (S/N): ");
        string resposta = Console.ReadLine()!.ToUpper();

        if (resposta != "S")
        {
            registrarMais = false;
        }
    }

    Console.WriteLine("\nRetornando ao menu...");
    Thread.Sleep(1500);
}

void ExibirBandas()
{
    ExibirTitulo("LISTA DE BANDAS");
    foreach (var banda in registroBandas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite qualquer tecla para voltar...");
    Console.ReadKey();
}

void AvaliarBanda()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    ExibirTitulo("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string NomeBanda = Console.ReadLine()!;
    if (registroBandas.ContainsKey(NomeBanda))
    {

    }
    else
    {
        Console.WriteLine($"A banda {NomeBanda} não existe");
        Console.WriteLine("digite uma qualquer para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();""
    }
}