using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Collections.Generic;
int bandera = 0; string a;
List<string> numAhorro = new List<string>();
List<string> numMonetaria = new List<string>();
List<string> nombreAhorro = new List<string>();
List<string> nombreMonetaria = new List<string>();
List<string> resumenAhorro = new List<string>();
List<string> resumenMonetaria = new List<string>();
List<double> dineroAhorro = new List<double>();
List<double> dineroMonetaria = new List<double>();
List<double> deudaAhorro = new List<double>();
List<double> deudaMonetaria = new List<double>();
void Apertura(){
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------APERTURA DE CUENTAS------"); Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("");
    do{

        Console.WriteLine("Escoja una opcion: ");
        Console.WriteLine("1. Ahorro");
        Console.WriteLine("2. Monetaria");
        string op = Console.ReadLine();
        string cuenta;
        double depo;
        string n;
        bool b = false;
        switch (op){
            case "1":
                Console.WriteLine("-----CREACION DE CUENTA DE AHORRO-----");
                do{
                    Console.Write("Ingrese el monto inicial (min Q200.00): Q.");
                    depo = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                }while(depo < 200);
                dineroAhorro.Add(depo);
                do{
                    Console.Write("Ingrese un numero de cuenta de 4 digitos: ");
                    cuenta = Console.ReadLine();
                    foreach (string num in numAhorro){
                        b = string.Equals(num, cuenta);
                        if (b) { Console.WriteLine("Ya existe ese numero de cuenta"); break; }
                    }
                } while (cuenta.Length != 4 || b == true);
                numAhorro.Add(cuenta);
                Console.Write("Ingrese a nombre de quien se aperturara la cuenta: ");
                n = Console.ReadLine();
                nombreAhorro.Add(n);
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Cuenta Ahorro Creada de forma correta"); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Nombre: " + n);
                Console.WriteLine("Saldo: Q." + depo);
                Console.WriteLine("Numero de cuenta: " + cuenta);
                resumenAhorro.Add("Se aperturo la cuenta con un deposito inicial de Q." + depo);
                break;
            case "2":

                Console.WriteLine("-----CREACION DE CUENTA DE MONETARIA-----");
                do
                {
                    Console.Write("Ingrese el monto inicial (min Q200.00): Q.");
                    depo = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                } while (depo < 200);
                dineroMonetaria.Add(depo);
                do
                {
                    Console.Write("Ingrese un numero de cuenta de 5 digitos: ");
                    cuenta = Console.ReadLine();
                    foreach (string num in numMonetaria)
                    {
                        b = string.Equals(num, cuenta);
                        if (b) { Console.WriteLine("Ya existe ese numero de cuenta"); break; }
                    }
                } while (cuenta.Length != 5 || b == true);
                numMonetaria.Add(cuenta);
                Console.Write("Ingrese a nombre de quien se aperturara la cuenta: ");
                n = Console.ReadLine();
                nombreMonetaria.Add(n);
                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Cuenta Monetaria Creada de forma correta"); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Nombre: " + n);
                Console.WriteLine("Saldo: Q." + depo);
                Console.WriteLine("Numero de cuenta: " + cuenta);
                break;
        }
        break;
    }while(true);
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
    bandera++;
    Main();
}
void Credito(){
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------PRESTAMOS------"); Console.ForegroundColor = ConsoleColor.White;
}
void Depositos(){
    string no;
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------DEPOSITOS------"); Console.ForegroundColor = ConsoleColor.White;
    do{
        int cuenta = 0;
        double monto;
        Console.Write("Ingrese el numero de cuenta al cual depositar: ");
        no = Console.ReadLine();
        if(no.Length == 4){
            Console.WriteLine("------DEPOSITO AHORRO------");
            foreach (string num in numAhorro){
                bool b = string.Equals(no, num);
                if (b){break;}
                else{cuenta ++;}
            }
            do{
                Console.Write("Ingrese el monto a depositar: ");
                monto = Math.Abs(Convert.ToDouble(Console.ReadLine()));
            }while(monto <= 0);
            dineroAhorro[cuenta] += monto;
            Console.ForegroundColor = ConsoleColor.Green;Console.WriteLine("TRANSACCION REALIZADA CORRECTAMENTE"); Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Saldo actual: "+ dineroAhorro[cuenta]);
            break;
        }
        else if (no.Length == 5) {
            Console.WriteLine("------DEPOSITO MONETARIO------");
            foreach (string num in numMonetaria)
            {
                bool b = string.Equals(no, num);
                if (b) { break; }
                else { cuenta++; }
            }
            do
            {
                Console.Write("Ingrese el monto a depositar: ");
                monto = Math.Abs(Convert.ToDouble(Console.ReadLine()));
            } while (monto <= 0);
            dineroMonetaria[cuenta] += monto;
            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("TRANSACCION REALIZADA CORRECTAMENTE"); Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Saldo actual: " + dineroMonetaria[cuenta]);
            break;
        }
    }while(true);
    Console.WriteLine("Presione ENTER para continuar");
    Console.ReadLine();
    Main();
}
void Retiros(){
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------RETIROS------"); Console.ForegroundColor = ConsoleColor.White;
}
void Estadisticas(){
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------ESTADISTICAS------"); Console.ForegroundColor = ConsoleColor.White;
}

void Main()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------BANCO DE GUATEMALA------"); Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("");
    if (bandera == 0){
        Console.WriteLine("DEBE TENER MINIMO UNA CUENTA PARA ACCEDER, SERA REDIRIGIDO A APERTURAS DE CUENTA");
        Console.WriteLine("PRESIONE ENTER PARA CONTINUAR");
        Console.ReadLine();
        Apertura();
    }

    else{
        Console.WriteLine("------SELECCIONE UNA OPCION------");
        Console.WriteLine("1. Apertura de Cuenta");
        Console.WriteLine("2. Credito");
        Console.WriteLine("3. Depositos");
        Console.WriteLine("4. Retiros");
        Console.WriteLine("5. Estadisticas");
        Console.WriteLine("6. Salir");
        do{
            a = Console.ReadLine();
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