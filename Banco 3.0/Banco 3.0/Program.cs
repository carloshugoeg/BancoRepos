using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Collections.Generic;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Transactions;
using System.Runtime.CompilerServices;

namespace Banco
{
    public class Transaccion
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public double Monto { get; set; }
        

        public Transaccion(string tipo, double monto)
        {
            Fecha = DateTime.Now;
            Tipo = tipo;
            Monto = monto;
        }
    }

    public class CuentaAhorro
    {
        public string Nombre { get; set; }
        public int NumeroCuenta { get; set; }
        public double Saldo { get; set; }
        public List<Transaccion> Transacciones { get; set; } = new List<Transaccion>();

        public CuentaAhorro(string nombre, int numeroCuenta, double saldo)
        {
            Nombre = nombre;
            NumeroCuenta = numeroCuenta;
            Saldo = saldo;
        }
        public void Transaccion(double monto)
        {
            Saldo += monto;
            string tipo = monto >= 0 ? "Deposito" : "Retiro";
            Transacciones.Add(new Transaccion(tipo, monto));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("TRANSACCION REALIZADA CORRECTAMENTE");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void MostrarInformacion(List<CuentaAhorro> cuentas)
        {
            int nameLength = 0;
            int numeroLength = "Numero de cuenta".Length;
            int saldoLength = "Saldo".Length;
            foreach (var cuenta in cuentas)
            {
                nameLength = Math.Max(nameLength, cuenta.Nombre.Length);
                numeroLength = Math.Max(numeroLength, cuenta.NumeroCuenta.ToString().Length);
                saldoLength = Math.Max(numeroLength, cuenta.Saldo.ToString().Length);
            }
            Console.WriteLine("{0,-" + nameLength + "} | {1,-" + numeroLength + "} | {2,-" + numeroLength + "} | {3,-" + saldoLength + "}", "Nombre", "Numero de cuenta", "Saldo");
            Console.WriteLine(new string('-', nameLength + numeroLength + saldoLength + 6));

            foreach (var cuenta in cuentas)
            {
                Console.WriteLine("{0,-" + nameLength + "} | {1,-" + numeroLength + "} | {2,-" + saldoLength + "}", cuenta.Nombre, cuenta.NumeroCuenta, cuenta.Saldo);
            }
        }
        public void MostrarEstadoDeCuenta()
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Estado de cuenta para la cuenta: {NumeroCuenta}");
            Console.WriteLine("Fecha\t\t\tTipo\t\tMonto");
            Console.WriteLine("-------------------------------------------------");

            foreach (var transaccion in Transacciones)
            {
                Console.WriteLine($"{transaccion.Fecha}\t{transaccion.Tipo}\t\t{transaccion.Monto:C}");
            }
            Console.WriteLine("Presione ENTER para continuar");
            Console.ReadKey();
        }
    }
    public class CuentaMonetaria
    {
        public string Nombre { get; set; }
        public int NumeroCuenta { get; set; }
        public double Saldo { get; set; }
        public List<Transaccion> Transacciones { get; set; } = new List<Transaccion>();

        public CuentaMonetaria(string nombre, int numeroCuenta, double saldo)
        {
            Nombre = nombre;
            NumeroCuenta = numeroCuenta;
            Saldo = saldo;
        }
        public void MostrarInformacion(List<CuentaMonetaria> cuentas)
        {
            int nameLength = 0;
            int numeroLength = "Numero de cuenta".Length;
            int saldoLength = "Saldo".Length;
            int deudaLength = "Deuda".Length;
            foreach (var cuenta in cuentas)
            {
                nameLength = Math.Max(nameLength, cuenta.Nombre.Length);
                numeroLength = Math.Max(numeroLength, cuenta.NumeroCuenta.ToString().Length);
                saldoLength = Math.Max(numeroLength, cuenta.Saldo.ToString().Length);
            }
            Console.WriteLine("{0,-" + nameLength + "} | {1,-" + numeroLength + "} | {2,-" + numeroLength + "} | {3,-" + saldoLength + "}", "Nombre", "Numero de cuenta", "Saldo");
            Console.WriteLine(new string('-', nameLength + numeroLength + saldoLength + deudaLength + 6));

            foreach (var cuenta in cuentas)
            {
                Console.WriteLine("{0,-" + nameLength + "} | {1,-" + numeroLength + "} | {2,-" + saldoLength + "}", cuenta.Nombre, cuenta.NumeroCuenta, cuenta.Saldo);
            }
        }
        public void Transaccion(double monto)
        {
            Saldo += monto;
            string tipo = monto >= 0 ? "Deposito" : "Retiro";
            Transacciones.Add(new Transaccion(tipo, monto));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("TRANSACCION REALIZADA CORRECTAMENTE");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void MostrarEstadoDeCuenta()
        {
            Console.WriteLine($"Estado de cuenta para la cuenta: {NumeroCuenta}");
            Console.WriteLine("Fecha\t\t\tTipo\t\tMonto");
            Console.WriteLine("-------------------------------------------------");

            foreach (var transaccion in Transacciones)
            {
                Console.WriteLine($"{transaccion.Fecha}\t{transaccion.Tipo}\t\t{transaccion.Monto:C}");
            }
        }
    }
    public class Creditos
    {
        public string Nombre { get; set; }
        public ulong DPI { get; set; }
        public double Deuda { get; set; }
        public double Monto { get; set; }
        public Creditos(string nombre, ulong dpi, double deuda, double monto)
        {
            Nombre = nombre;
            DPI = dpi;
            Deuda = deuda;
            Monto = monto;
        }
        public void MostrarInformacion(List<Creditos> cuentas)
        {
            int nameLength = 0;
            int dpiLength = "DPI".Length;
            int montoLength = "Monto".Length;
            int deudaLength = "Deuda".Length;
            foreach (var cuenta in cuentas)
            {
                nameLength = Math.Max(nameLength, cuenta.Nombre.Length);
                dpiLength = Math.Max(dpiLength, cuenta.DPI.ToString().Length);
                montoLength = Math.Max(dpiLength, cuenta.Monto.ToString().Length);
                deudaLength = Math.Max(deudaLength, cuenta.Deuda.ToString().Length);
            }
            Console.WriteLine("{0,-" + nameLength + "} | {1,-" + dpiLength + "} | {2,-" + dpiLength + "} | {3,-" + montoLength + "}", "Nombre", "DPI", "Monto", "Deuda");
            Console.WriteLine(new string('-', nameLength + dpiLength + montoLength + deudaLength + 6));

            foreach (var cuenta in cuentas)
            {
                Console.WriteLine("{0,-" + nameLength + "} | {1,-" + dpiLength + "} | {2,-" + montoLength + "} | {3,-" + deudaLength + "}", cuenta.Nombre, cuenta.DPI, cuenta.Monto, cuenta.Deuda);
            }
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<CuentaAhorro> cuentaAhorro = new List<CuentaAhorro>();
            List<CuentaMonetaria> cuentaMonetaria = new List<CuentaMonetaria>();
            List<Creditos> creditos = new List<Creditos>();
            List<Creditos> credit = new List<Creditos>();


            int bandera = 0;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue; Console.WriteLine("------BANCO DE GUATEMALA------"); Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            if (bandera == 0)
            {
                Console.WriteLine("DEBE TENER MINIMO UNA CUENTA PARA ACCEDER, SERA REDIRIGIDO A APERTURAS DE CUENTA");
                Console.WriteLine("");

                Console.WriteLine("PRESIONE ENTER PARA CONTINUAR");
                Console.ReadLine();
                Apertura(cuentaAhorro, cuentaMonetaria);
            }
            do
            {
                Menu();
            } while (true);

            void Menu()
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"------SELECCIONE UNA OPCION------ ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("1. Apertura de Cuenta");
                    Console.WriteLine("2. Depositos");
                    Console.WriteLine("3. Retiros");
                    Console.WriteLine("4. Créditos");
                    Console.WriteLine("5. Estados de cuenta");
                    Console.WriteLine("6. Salir");

                    string a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            Apertura(cuentaAhorro, cuentaMonetaria);
                            break;
                        case "2":
                            Depositos(cuentaAhorro, cuentaMonetaria);
                            break;

                        case "3":
                            Retiros(cuentaAhorro, cuentaMonetaria);
                            break;
                        case "4":
                            Credit(creditos);
                            break;

                        case "5":
                            Console.WriteLine("Ingrese el número de cuenta para ver el estado de cuenta:");
                            int numeroCuenta = int.Parse(Console.ReadLine());

                            MostrarEstadoDeCuenta(numeroCuenta, cuentaAhorro, cuentaMonetaria);
                            break;
                        case "6":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"------ESTUDIANTES------ ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            Console.WriteLine("- Carlos Hugo Escobar Gomez 1563824");
                            Console.WriteLine("- Ronaldo Emilio Méndez Mayorga 1563224");
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Presione ENTER para salir");
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                    }
                } while (true);
            }
            static void MostrarEstadoDeCuenta(int numeroCuenta, List<CuentaAhorro> cuentasAhorro, List<CuentaMonetaria> cuentasMonetarias)
            {
                var cuentaAhorro = cuentasAhorro.Find(c => c.NumeroCuenta == numeroCuenta);
                var cuentaMonetaria = cuentasMonetarias.Find(c => c.NumeroCuenta == numeroCuenta);

                if (cuentaAhorro != null)
                {
                    cuentaAhorro.MostrarEstadoDeCuenta();
                }
                else if (cuentaMonetaria != null)
                {
                    cuentaMonetaria.MostrarEstadoDeCuenta();
                }
                else
                {
                    Console.WriteLine("Cuenta no encontrada.");
                }
            }
            void Apertura(List<CuentaAhorro> cuentaAhorro, List<CuentaMonetaria> cuentaMonetaria)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue; Console.WriteLine("------APERTURA DE CUENTAS------"); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"------SELECCIONE UNA OPCION------ ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("1. Ahorro");
                    Console.WriteLine("2. Monetaria");
                    //Console.WriteLine("3. Credito");
                    string op = Console.ReadLine();
                    int num;
                    double depo;
                    string n;
                    bool b = false;
                    switch (op)
                    {
                        case "1":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"------CREACIÓN DE CUENTA DE AHORRO------ ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");

                            do
                            {
                                Console.Write("Ingrese el monto inicial (min Q200.00): Q.");
                                depo = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                            } while (depo < 200);
                            num = IngresarNumeroCuenta(cuentaAhorro);
                            Console.Write("Ingrese a nombre de quien se aperturara la cuenta: ");
                            n = Console.ReadLine();
                            cuentaAhorro.Add(new CuentaAhorro(n, num, depo));
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Cuenta Ahorro Creada de forma correta"); Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Nombre: " + n);
                            Console.WriteLine("Saldo: Q." + depo);
                            Console.WriteLine("Numero de cuenta: " + num);
                            break;
                        case "2":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"------CREACION DE CUENTA MONETARIA------ ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");


                            do
                            {
                                Console.Write("Ingrese el monto inicial (min Q200.00): Q.");
                                depo = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                            } while (depo < 200);
                            num = IngresarNumCuenta(cuentaMonetaria);
                            Console.Write("Ingrese a nombre de quien se aperturara la cuenta: ");
                            n = Console.ReadLine();
                            cuentaMonetaria.Add(new CuentaMonetaria(n, num, depo));
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Cuenta Monetaria Creada de forma correta"); Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Nombre: " + n);
                            Console.WriteLine("Saldo: Q." + depo);
                            Console.WriteLine("Numero de cuenta: " + num);
                            break;

                    }
                    break;
                } while (true);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Presione ENTER para salir");
                Console.WriteLine("");
                bandera++;
                Console.ReadKey();
            }
            void Depositos(List<CuentaAhorro> cuentaAhorro, List<CuentaMonetaria> cuentaMonetaria)
            {
                string no;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------DEPOSITOS------"); Console.ForegroundColor = ConsoleColor.White;
                do
                {
                    int cuenta = 0;
                    double monto;
                    bool b = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"------SELECCIONE UNA OPCION------ ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.Write("1. Cuenta Ahorro: ");
                    Console.Write("2. Cuenta Monetario: ");
                    string a = Console.ReadLine();
                    switch (a)
                    {
                        case "1":
                            {
                                Console.Write("Ingrese el numero de cuenta al cual depositar: ");
                                no = Console.ReadLine();
                                if (no.Length == 4)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"------DEPOSITO AHORRO------ ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("");

                                    foreach (CuentaAhorro cuentas in cuentaAhorro)
                                    {
                                        b = Equals(no, cuentas.NumeroCuenta.ToString());
                                        if (b) { break; }
                                        else { cuenta++; }
                                    }
                                    do
                                    {
                                        Console.Write("Ingrese el monto a depositar: ");
                                        monto = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                                    } while (monto <= 0);

                                    cuentaAhorro[cuenta].Transaccion(monto);
                                    Console.WriteLine("Saldo actual: Q" + cuentaAhorro[cuenta].Saldo);
                                }
                                else Console.WriteLine("Formato de cuenta invalido");
                            }               
                            break;

                        case "2":
                            Console.Write("Ingrese el numero de cuenta al cual depositar: ");
                            no = Console.ReadLine();
                            if (no.Length == 5)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"------DEPOSITO MONETARIO------ ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("");

                                do
                                {
                                    foreach (CuentaMonetaria numero in cuentaMonetaria)
                                    {
                                        b = string.Equals(no, numero.NumeroCuenta.ToString());
                                        if (b) { break; }
                                        else { cuenta++; }
                                    }
                                } while (!b);

                                do
                                {
                                    Console.Write("Ingrese el monto a depositar: ");
                                    monto = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                                } while (monto <= 0);

                                cuentaMonetaria[cuenta].Transaccion(monto);
                                Console.WriteLine("Saldo actual: Q." + cuentaMonetaria[cuenta].Saldo);
                            }
                            else Console.WriteLine("Formato de cuenta invalido");
                            break;
                    }
                    break;
                } while (true);
                        Console.WriteLine(""); Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Presione ENTER para salir");
                Console.WriteLine("");
                Console.ReadKey();
            }
            void Credit(List<Creditos> creditos)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------CREDITO------");
                string no;
                do
                {
                    int cuenta = 0;
                    double monto = 0;
                    bool V = true;
                    bool F = false;

                    double depo;
                    string n;
                    bool b = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"------SELECCIONE UNA OPCION------ ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.Write("1. Solicitud de Credito: ");
                    Console.Write("2. Abono a Credito: ");
                    string p = Console.ReadLine();
                    switch (p)
                    {
                        case "1":
                            {
                                double anos = 0;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"------SOLICITUD CREDITO PLAZO FIJO------ ");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("");

                                ulong dpi = IngresarNumDPI(creditos);
                                Console.Write("Ingrese a nombre de quien se acreditara el prestamo: ");
                                n = Console.ReadLine();
                                do
                                {
                                    Console.Write("Ingrese el monto del credito (min Q.100 y max Q.999,999,999.99): Q.");
                                    depo = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                                } while (depo < 100 || depo > 999999999.99);
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("NOTA: prestamo de plazo fijo, se le aplicara el interes en base a la cantidad de años con un interes del 12%");
                                    Console.WriteLine("      y este se mantendra sin importar el plazo con el que se termine pagando al final."); Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("");
                                    Console.Write("Ingrese la cantidad de años para su prestamo de plazo fijo (min 1 y max 60): ");
                                    anos = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                                } while (anos < 1 || anos > 60);
                                double deuda = Math.Round(depo * (Math.Pow((1 + 0.12), anos)), 2);
                                creditos.Add(new Creditos(n, dpi, deuda, depo));
                                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Prestamo acreditado de forma correta"); Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Nombre: " + n);
                                Console.WriteLine("Prestamo por Q." + depo);
                                Console.WriteLine("DPI: " + dpi);
                                Console.WriteLine("Deuda con interes: Q" + deuda);

                            }
                            break;

                        case "2":
                            {
                                Console.Clear();
                                Console.Write("Ingrese el numero de DPI: ");
                                no = Console.ReadLine();
                                if (no.Length == 13)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"------ABONO DE CREDITO------ ");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("");

                                    foreach (Creditos credito in creditos)
                                    {
                                        b = Equals(no, credito.DPI.ToString());
                                        if (b) { break; }
                                        else { cuenta++; }
                                    }
                                    if (!b)
                                    {
                                        Console.WriteLine("No se encontro dicho DPI");
                                        break;
                                    }  
                                    do
                                    {
                                        Console.WriteLine("Bienvenid@ " + creditos[cuenta].Nombre);
                                        Console.Write("Ingrese el monto a abonar: Q.");
                                        monto = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                                    } while (monto <= 0);
                                    if (creditos[cuenta].Deuda >= monto)
                                    {
                                        creditos[cuenta].Deuda -= monto;
                                        Console.WriteLine("Deuda restante: Q" + Math.Round(creditos[cuenta].Deuda, 2));
                                    }
                                    else if (creditos[cuenta].Deuda < monto)
                                    {
                                        Console.WriteLine($"Solamente se aceptaron Q.{creditos[cuenta].Deuda}, el resto se le devolvera en efectivo");
                                    }
                                    if (creditos[cuenta].Deuda == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("FELICIDADES!!! Usted ha saldado su deuda con el banco");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        creditos.RemoveAt(cuenta);
                                    }
                                }
                                else Console.WriteLine("Formato de DPI invalido");
                                break;
                            }

                    }
                    break;
                } while (true);
                Console.WriteLine(""); Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Presione ENTER para salir");
                Console.WriteLine("");
                Console.ReadKey();
            }
            void Retiros(List<CuentaAhorro> cuentaAhorro, List<CuentaMonetaria> cuentaMonetaria)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------RETIROS------"); Console.ForegroundColor = ConsoleColor.White;
                string no;
                do
                {
                    int cuenta = 0;
                    double monto;
                    bool b = false;
                    Console.Write("Ingrese el numero de cuenta al cual retirar: ");
                    no = Console.ReadLine();
                    if (no.Length == 4)
                    {
                        Console.WriteLine("CUENTA DE AHORRO DETECTADA");
                        Console.WriteLine("Para poder hacer retiros con cheque, porfavor solicite una cuenta monetaria");
                        break;
                        //Console.ForegroundColor = ConsoleColor.Yellow;
                        //Console.WriteLine($"------RETIRO AHORRO------ ");
                        //Console.ForegroundColor = ConsoleColor.White;
                        //Console.WriteLine("");
                        //foreach (CuentaAhorro cuentas in cuentaAhorro)
                        //{
                        //    b = Equals(no, cuentas.NumeroCuenta.ToString());
                        //    if (b) { break; }
                        //    else { cuenta++; }
                        //}
                        //do
                        //{
                        //    Console.Write("Ingrese el monto a depositar: ");
                        //    monto = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                        //} while (monto <= 0);
                        //cuentaAhorro[cuenta].Transaccion(monto);
                        //Console.WriteLine("Saldo actual: Q" + cuentaAhorro[cuenta].Saldo);
                        //break;
                    }
                    else if (no.Length == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"------DEPOSTIO MONETARIO------ ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");

                        foreach (CuentaMonetaria monetaria in cuentaMonetaria)
                        {
                            b = Equals(no, monetaria.NumeroCuenta.ToString());
                            if (b) { break; }
                            else { cuenta++; }
                        }
                        if (!b)
                        {
                            Console.WriteLine("No se encontro dicho DPI");
                            break;
                        }

                        do
                        {
                            Console.Write("Ingrese el monto a retirar: ");
                            monto = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                        } while (monto <= 0);
                        if(monto > cuentaMonetaria[cuenta].Saldo)
                        {
                            cuentaMonetaria[cuenta].Saldo -= 150;
                            Console.WriteLine("Usted efectuó un cheque sin fondos, se le hara una multa de Q150.00");
                            Console.WriteLine("Ahora su saldo actual es Q. " + cuentaMonetaria[cuenta].Saldo);
                            if (cuentaMonetaria[cuenta].Saldo < 0)
                            {
                                Console.WriteLine($"NOTA: usted tiene una deuda de Q.{Math.Abs(cuentaMonetaria[cuenta].Saldo)}. Esta cantidad se le retendra en su proximo deposito");
                            }
                        }
                        else
                        cuentaMonetaria[cuenta].Transaccion(monto * -1);
                        Console.WriteLine("Saldo actual: Q." + cuentaMonetaria[cuenta].Saldo);
                        break;
                    }
                    else Console.WriteLine("Formato de cuenta invalido");
                } while (true);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Presione ENTER para salir");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.ReadKey();
            }
              
            void Estadisticas()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------ESTADISTICAS------"); Console.ForegroundColor = ConsoleColor.White;
            }
            int IngresarNumeroCuenta(List<CuentaAhorro> cuentas)
            {
                int numeroCuenta;
                bool numeroValido = false;
                bool cuentaExistente = false;

                do
                {
                    Console.Write("Ingrese un número de cuenta de 4 dígitos: ");
                    string inputNumeroCuenta = Console.ReadLine();
                    if (int.TryParse(inputNumeroCuenta, out numeroCuenta))
                    {
                        // Check if the number has the correct size (4 digits)
                        if (inputNumeroCuenta.Length == 4)
                        {
                            // Check if the number already exists in the list
                            cuentaExistente = cuentas.Any(cuenta => cuenta.NumeroCuenta == numeroCuenta);

                            if (!cuentaExistente)
                            {
                                numeroValido = true;
                            }
                            else
                            {
                                Console.WriteLine("El número de cuenta ya existe. Intente de nuevo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El número de cuenta debe tener 4 dígitos. Intente de nuevo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El valor ingresado no es un número válido. Intente de nuevo.");
                    }
                } while (!numeroValido);

                return numeroCuenta;
            }
            int IngresarNumCuenta(List<CuentaMonetaria> cuentas)
            {
                int numeroCuenta;
                bool numeroValido = false;
                bool cuentaExistente = false;

                do
                {
                    Console.Write("Ingrese un número de cuenta de 5 dígitos: ");
                    string inputNumeroCuenta = Console.ReadLine();
                    if (int.TryParse(inputNumeroCuenta, out numeroCuenta))
                    {
                        // Check if the number has the correct size (4 digits)
                        if (inputNumeroCuenta.Length == 5)
                        {
                            // Check if the number already exists in the list
                            cuentaExistente = cuentas.Any(cuenta => cuenta.NumeroCuenta == numeroCuenta);

                            if (!cuentaExistente)
                            {
                                numeroValido = true;
                            }
                            else
                            {
                                Console.WriteLine("El número de cuenta ya existe. Intente de nuevo.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("El número de cuenta debe tener 5 dígitos. Intente de nuevo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El valor ingresado no es un número válido. Intente de nuevo.");
                    }
                } while (!numeroValido);

                return numeroCuenta;
            }
            ulong IngresarNumDPI(List<Creditos> creditos)
            {
                ulong numeroDPI;
                bool numeroValido = false;
                bool cuentaExistente = false;

                do
                {
                    Console.Write("Ingrese su numero de DPI: ");
                    string inputNumeroCuenta = Console.ReadLine();
                    if (ulong.TryParse(inputNumeroCuenta, out numeroDPI))
                    {
                        // Check if the number has the correct size (4 digits)
                        if (inputNumeroCuenta.Length == 13)
                        {
                            // Check if the number already exists in the list
                            cuentaExistente = creditos.Any(cuenta => cuenta.DPI == numeroDPI);

                            if (!cuentaExistente)
                            {
                                numeroValido = true;
                            }
                            else
                            {
                                Console.WriteLine("No se puede tener mas de 1 credito por cliente.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Numero de DPI invalido. Intente de nuevo.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("El valor ingresado no es un número válido. Intente de nuevo.");
                    }
                } while (!numeroValido);

                return numeroDPI;
            }
        }

        
    }
}
