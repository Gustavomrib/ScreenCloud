using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

// Armazenamento das bandas (Dicionário)
Dictionary<string, List<int>> registroBandas = new Dictionary<string, List<int>>();
bool exibirMenu = true;

// Função para padronizar os títulos
void ExibirTitulo(string titulo)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;

    string linha = new string('═', titulo.Length + 4);
    Console.WriteLine(linha);
    Console.WriteLine($"  {titulo.ToUpper()}  ");
    Console.WriteLine(linha);

    Console.ResetColor();
    Console.WriteLine();
}

// Laço Principal
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
            case 4:
                ExibirMedia();
                break;
            case -1:
                Console.WriteLine("\nTchau tchau! Até a próxima.");
                exibirMenu = false;
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
            // CORREÇÃO: Adicionando a banda ao dicionário com uma lista de notas vazia
            registroBandas.Add(nomeDaBanda, new List<int>());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nBanda '{nomeDaBanda}' registrada com sucesso!");
            Console.ResetColor();
        }

        Console.Write("\nDeseja registrar outra banda? (S/N): ");
        string resposta = Console.ReadLine()!.ToUpper();
        if (resposta != "S") registrarMais = false;
    }

    Console.WriteLine("\nRetornando ao menu...");
    Thread.Sleep(1000);
}

void ExibirBandas()
{
    ExibirTitulo("LISTA DE BANDAS");

    if (registroBandas.Count == 0)
    {
        Console.WriteLine("Nenhuma banda registrada no momento.");
    }
    else
    {
        foreach (var banda in registroBandas.Keys)
        {
            Console.WriteLine($"* {banda}");
        }
    }

    Console.WriteLine("\nRetornando ao menu...");
    Thread.Sleep(1000);
}

void AvaliarBanda()
{
    ExibirTitulo("AVALIAR BANDA");
    
    bool RegistrarMais = true;

    while (RegistrarMais)
    {
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeBanda = Console.ReadLine()!;

        if (registroBandas.ContainsKey(nomeBanda))
        {
            Console.Write($"\nDigite a nota para {nomeBanda}: ");
            if (int.TryParse(Console.ReadLine(), out int nota))
            {
                registroBandas[nomeBanda].Add(nota);
                Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeBanda}!");
            }
            else
            {
                Console.WriteLine("\nNota inválida! Use apenas números.");
            }
        }
        else
        {
            Console.WriteLine($"\nA banda '{nomeBanda}' não foi encontrada.");
            Console.WriteLine("Tente digitar o nome novamente.");
            continue;
        }

        Console.Write("\nDeseja registrar outra nota? (S/N): ");
        string resposta = Console.ReadLine()!.ToUpper();
        if (resposta != "S") RegistrarMais = false;
    }
    Console.WriteLine("\nRetornando ao menu...");
    Thread.Sleep(1000);

}

    void ExibirMedia()
{
    ExibirTitulo("MÉDIA DA BANDA");
    Console.Write("Digite o nome da banda: ");
    string nomeBanda = Console.ReadLine()!;

    if (registroBandas.ContainsKey(nomeBanda))
    {
        List<int> notas = registroBandas[nomeBanda];
        if (notas.Count > 0)
        {
            double media = notas.Average(); // Usando System.Linq
            Console.WriteLine($"\nA média da banda {nomeBanda} é: {media:F1}");
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeBanda} ainda não possui notas registradas.");
        }
    }
    else
    {
        Console.WriteLine($"\nA banda '{nomeBanda}' não existe.");
    }

    Console.WriteLine("\nRetornando ao menu...");
    Thread.Sleep(1000);
}