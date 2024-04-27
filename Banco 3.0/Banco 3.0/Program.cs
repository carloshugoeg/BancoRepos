
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;

int bandera = 0;
int[] numAhorro = new int[]{};
int[] numMonetaria = new int[]{};
string[] nombreAhorro = new string[]{};
string[] nombreMonetaria = new string[]{};
string[] resumenAhorro = new string[]{};
string[] resumenMonetaria = new string[]{};
double[] dineroAhorro = new double[]{};
double[] dineroMonetaria = new double[]{};
double[] deudaAhorro = new double[]{};
double[] deudaMonetaria = new double[]{};

void Apertura(){
    Console.Clear();
    Console.WriteLine("----APERTURA DE CUENTAS------");
    bandera++;
    Main();
}
void Credito(){
    Console.Clear();
    Console.WriteLine("----PRESTAMOS------");
}
void Depositos(){
    Console.Clear();
    Console.WriteLine("----DEPOSITOS------");
}
void Retiros(){
    Console.Clear();
    Console.WriteLine("----RETIROS------");
}
void Estadisticas(){
    Console.Clear();
    Console.WriteLine("----ESTADISTICAS------");
}

void Main()
{
    Console.WriteLine("----BANCO DE GUATEMALA------");
    Console.WriteLine("");
    if (bandera == 0){
        Console.WriteLine("DEBE TENER MINIMO UNA CUENTA PARA ACCEDER, SERA REDIRIGIDO A APERTURAS DE CUENTA");
        Console.WriteLine("PRESIONE ENTER PARA CONTINUAR");
        Console.ReadLine();
        Apertura();
    }

    else{
        Console.WriteLine("----SELECCIONE UNA OPCION------");
        Console.WriteLine("1. Apertura de Cuenta");
        Console.WriteLine("2. Credito");
        Console.WriteLine("3. Depositos");
        Console.WriteLine("4. Retiros");
        Console.WriteLine("5. Estadisticas");
        Console.WriteLine("6. Salir");
        do{
            string a = Console.ReadLine();
            switch(a){
            case "1":
                Apertura();
                break;
            case "2":
                Credito();
                break;
            case "3":
                Depositos();
                break;
            case "4":
                Retiros();
                break;
            case "5":
                Estadisticas();
                break;
            case "6":
                Console.WriteLine("Estudiantes: Carlos Hugo Escobar Gomez y Ronaldo Emilio Mendez Mayorga");
                Console.WriteLine("Carnet: 1563824 y 1563224");
                Console.WriteLine("Presione ENTER para salir");
                Console.ReadKey();
                Environment.Exit(0);
                break;
            }
        }while(true);
        
    }
    
}
Main();