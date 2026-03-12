using System.Linq;

List<string> bandList = new List<string> { "Mamonas assasinas", "quero quero", "bent ti vi"};
void displayMenu()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine("\nSeja bem vindo");


    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("\nDigite 2 para mostrar todas as bandas registradas");
    Console.WriteLine("\nDigite 3 para fazer algo uma banda");
    Console.WriteLine("\nDigite 4 para fazer algo 2 uma banda");
    Console.WriteLine("\nDigite -1 para para sair");
    Console.Write("\nDigite sua opçao: ");
    string ChosenOption = Console.ReadLine(); // receber o numero que foi digitado 

    if (int.TryParse(ChosenOption, out int ChosenNumber))
    {


        switch (ChosenNumber)
        {

            case 1:
                bandRegistration();
                break;

            case 2:
                displayBand();
                break;

            case 3:
                Console.WriteLine("você digitou " + ChosenNumber);
                break;

            case 4:
                Console.WriteLine("você digitou " + ChosenNumber);
                break;

            case -1:
                bye();
                break;




        }

    }
    else
    {
        Console.Clear();
        Console.WriteLine(@"
███████╗██████╗░██████╗░░█████╗░██████╗░
██╔════╝██╔══██╗██╔══██╗██╔══██╗██╔══██╗
█████╗░░██████╔╝██████╔╝██║░░██║██████╔╝
██╔══╝░░██╔══██╗██╔══██╗██║░░██║██╔══██╗
███████╗██║░░██║██║░░██║╚█████╔╝██║░░██║
╚══════╝╚═╝░░╚═╝╚═╝░░╚═╝░╚════╝░╚═╝░░╚═╝");
        Console.WriteLine("\nDigite um numero valido !!");
        Thread.Sleep(3000);
        Console.Clear();
        displayMenu();
    }


    void bandRegistration()
    {

        bool registerMore = true; // variavel de controle

        do
        {
            Console.Clear();
            Console.WriteLine(@"
██████╗░███████╗░██████╗░██╗░██████╗████████╗██████╗░░█████╗░  ██████╗░███████╗
██╔══██╗██╔════╝██╔════╝░██║██╔════╝╚══██╔══╝██╔══██╗██╔══██╗  ██╔══██╗██╔════╝
██████╔╝█████╗░░██║░░██╗░██║╚█████╗░░░░██║░░░██████╔╝██║░░██║  ██║░░██║█████╗░░
██╔══██╗██╔══╝░░██║░░╚██╗██║░╚═══██╗░░░██║░░░██╔══██╗██║░░██║  ██║░░██║██╔══╝░░
██║░░██║███████╗╚██████╔╝██║██████╔╝░░░██║░░░██║░░██║╚█████╔╝  ██████╔╝███████╗
╚═╝░░╚═╝╚══════╝░╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░  ╚═════╝░╚══════╝

██████╗░░█████╗░███╗░░██╗██████╗░░█████╗░░██████╗
██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔════╝
██████╦╝███████║██╔██╗██║██║░░██║███████║╚█████╗░
██╔══██╗██╔══██║██║╚████║██║░░██║██╔══██║░╚═══██╗
██████╦╝██║░░██║██║░╚███║██████╔╝██║░░██║██████╔╝
╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝╚═════╝░");
            Console.Write("\n Digite o nome da banda: ");
            string bandName = Console.ReadLine()!;

            if (bandList.Any(b => b.Equals(bandName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"\n Erro: A banda '{bandName}' já foi cadastrada anteriormente!");
            }

            else
            {
                bandList.Add(bandName);
                Console.WriteLine($"A banda:{bandName} foi registrada com sucesso");
            }
            
            Console.WriteLine("\nDeseja registrar mais alguma banda ? (S/N)");
            string response = Console.ReadLine()!.ToUpper();

            if (response != "S")
            {
                registerMore = false; // se a resposta for diferente de S o codigo encerra ( quebra o laço de repetição )
            }
        } while (registerMore);
        Console.Clear();
        Console.WriteLine("retornando ao menu principal....");
        Thread.Sleep(2000);
        Console.Clear();

        displayMenu();


    }

    void displayBand()
    {
        Console.Clear();
        Console.WriteLine(@"
██████╗░░█████╗░███╗░░██╗██████╗░░█████╗░░██████╗
██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔════╝
██████╦╝███████║██╔██╗██║██║░░██║███████║╚█████╗░
██╔══██╗██╔══██║██║╚████║██║░░██║██╔══██║░╚═══██╗
██████╦╝██║░░██║██║░╚███║██████╔╝██║░░██║██████╔╝
╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝╚═════╝░\n");
        foreach (string band in bandList)
        {
            Console.WriteLine($"\nBanda: {band}");
        }


        Console.WriteLine("\ndigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        displayMenu();
    }

    void bye()
    {
        Console.Clear();
        Console.Write("avalie esse programa de 1 a 5: ");
        string feedback = Console.ReadLine();
        if (int.TryParse(feedback, out int feedbackNumber))
        {
            Console.Clear();
            Console.WriteLine("\nobriado pela avaliaçao !");
            Console.WriteLine(@"
██████╗░██╗░░░██╗███████╗
██╔══██╗╚██╗░██╔╝██╔════╝
██████╦╝░╚████╔╝░█████╗░░
██╔══██╗░░╚██╔╝░░██╔══╝░░
██████╦╝░░░██║░░░███████╗
╚═════╝░░░░╚═╝░░░╚══════╝");
            Thread.Sleep(4000);



        }
        else
        {
            Console.WriteLine("digite um numero valido");
        }


    }






}

displayMenu();