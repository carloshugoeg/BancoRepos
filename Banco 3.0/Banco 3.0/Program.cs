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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------ESTADISTICAS------"); Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine($"Estado de cuenta para la cuenta: {NumeroCuenta}");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Fecha\t\t\tTipo\t\tMonto");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
            int cantidadDepositos = 0;
            int cantidadRetiros = 0;

            foreach (var transaccion in Transacciones)
            {
                Console.WriteLine($"{transaccion.Fecha}\t{transaccion.Tipo}\t\t{transaccion.Monto:C}");
                if (transaccion.Tipo == "Deposito")
                {
                    cantidadDepositos++;
                }
                else if (transaccion.Tipo == "Retiro")
                {
                    cantidadRetiros++;
                }
            }
            Console.WriteLine("\nResumen de transacciones:");
            Console.WriteLine($"Cantidad de Depositos: {cantidadDepositos}");
            Console.WriteLine($"Cantidad de Retiros: {cantidadRetiros}");

            int maxBarLength = 50; // Longitud máxima de la barra
            int maxTransacciones = Math.Max(cantidadDepositos, cantidadRetiros);

            int depositoBarLength = (int)((double)cantidadDepositos / maxTransacciones * maxBarLength);
            int retiroBarLength = (int)((double)cantidadRetiros / maxTransacciones * maxBarLength);

            Console.WriteLine("\nGrafico de Barras:");
            Console.WriteLine("Depositos:");
            Console.WriteLine(new string('█', depositoBarLength));
            Console.WriteLine("Retiros:");
            Console.WriteLine(new string('█', retiroBarLength));

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($"Saldo Actual: Q." + Saldo);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Presione ENTER para continuar");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("------ESTADISTICAS------");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");
            
            Console.WriteLine($"Estado de cuenta para la cuenta: {NumeroCuenta}");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("{0,-20} {1,-20} {2,10}", "Fecha", "Tipo", "Monto");
            Console.ForegroundColor = ConsoleColor.White;
            int cantidadDepositos = 0;
            int cantidadRetiros = 0;

            foreach (var transaccion in Transacciones)
            {
                Console.WriteLine($"{transaccion.Fecha}\t{transaccion.Tipo}\t\t{transaccion.Monto:C}");
                if (transaccion.Tipo == "Deposito")
                {
                    cantidadDepositos++;
                }
                else if (transaccion.Tipo == "Retiro")
                {
                    cantidadRetiros++;
                }
            }
            Console.WriteLine("\nResumen de transacciones:");
            Console.WriteLine($"Cantidad de Depositos: {cantidadDepositos}");
            Console.WriteLine($"Cantidad de Retiros: {cantidadRetiros}");

            int maxBarLength = 50; // Longitud máxima de la barra
            int maxTransacciones = Math.Max(cantidadDepositos, cantidadRetiros);

            int depositoBarLength = (int)((double)cantidadDepositos / maxTransacciones * maxBarLength);
            int retiroBarLength = (int)((double)cantidadRetiros / maxTransacciones * maxBarLength);

            Console.WriteLine("\nGrafico de Barras:");
            Console.WriteLine("Depositos:");
            Console.WriteLine(new string('█', depositoBarLength));
            Console.WriteLine("Retiros:");
            Console.WriteLine(new string('█', retiroBarLength));

            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine($"Saldo Actual: Q." + Saldo);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Presione ENTER para continuar");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
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
            Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------BANCO DE GUATEMALA------"); Console.ForegroundColor = ConsoleColor.White;
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
                Console.Clear();
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
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    string a = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (a)
                    {
                        case "1":
                            Apertura(cuentaAhorro, cuentaMonetaria);
                            break;
                        case "2":
                            Depositos(cuentaAhorro, cuentaMonetaria, creditos);
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
                    Console.WriteLine("");
                    cuentaAhorro.MostrarEstadoDeCuenta();
                }
                else if (cuentaMonetaria != null)
                {
                    Console.WriteLine("");
                    cuentaMonetaria.MostrarEstadoDeCuenta();
                }
                else
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cuenta no encontrada.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            void Apertura(List<CuentaAhorro> cuentaAhorro, List<CuentaMonetaria> cuentaMonetaria)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------APERTURA DE CUENTAS------"); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"------SELECCIONE UNA OPCION------ ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("1. Ahorro");
                    Console.WriteLine("2. Monetaria");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    string op = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
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
                                if (depo < 200)
                                {
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("MONTO INSUFICIENTE. VUELVA A INTENTARLO");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("");
                                }
                                } while (depo < 200);
                           
                            
                            num = IngresarNumeroCuenta(cuentaAhorro);
                            Console.Write("Ingrese a nombre de quien se aperturara la cuenta: ");
                            n = Console.ReadLine();
                            cuentaAhorro.Add(new CuentaAhorro(n, num, depo));
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Cuenta Ahorro Creada de forma correta"); Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
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
                                if (depo < 200)
                                {
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("MONTO INSUFICIENTE. VUELVA A INTENTARLO");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("");
                                }
                            } while (depo < 200);
                            num = IngresarNumCuenta(cuentaMonetaria);

                            Console.Write("Ingrese a nombre de quien se aperturara la cuenta: ");
                            n = Console.ReadLine();
                            Console.WriteLine("");
                            cuentaMonetaria.Add(new CuentaMonetaria(n, num, depo));
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("Cuenta Monetaria Creada de forma correta"); Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
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
                Console.Clear();
            }
            void Depositos(List<CuentaAhorro> cuentaAhorro, List<CuentaMonetaria> cuentaMonetaria, List<Creditos> creditos)
            {
                string no;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------DEPOSITOS------"); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                do
                {
                    int cuenta = 0;
                    double monto;
                    bool b = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"------SELECCIONE UNA OPCION------ ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("1. Cuenta Ahorro ");
                    Console.WriteLine("2. Cuenta Monetario");
                    Console.WriteLine("3. Abonar a Crédito");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    string a = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (a)
                    {
                        case "1":
                            {
                                Console.WriteLine("");
                                Console.Write("Ingrese el numero de cuenta al cual depositar: ");
                                no = Console.ReadLine();
                                //Poner el nombre del usuario
                            
                                if (no.Length == 4)
                                {

                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"------DEPOSITO CUENTA AHORRO------ ");
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
                                      
                                        Console.WriteLine("BIENVENID@ " + cuentaAhorro[cuenta].Nombre);

                                        Console.Write("Ingrese el monto a depositar: Q.");
                                        monto = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                                    } while (monto <= 0);
                                    Console.WriteLine("");
                                    cuentaAhorro[cuenta].Transaccion(monto);
                                    Console.WriteLine("Saldo actual: Q" + cuentaAhorro[cuenta].Saldo);
                                }
                                else
                                {
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("FORMATO DE CUENTA INVALIDO"); Console.ForegroundColor = ConsoleColor.White;
                                }
      
                               
                            }
                            break;

                        case "2":
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"------DEPOSITO CUENTA MONETARIA------ ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            Console.Write("Ingrese el numero de cuenta al cual depositar: ");
                            no = Console.ReadLine();
                            Console.WriteLine("");
                            if (no.Length == 5)
                            {
                                

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

                                    Console.WriteLine("BIENVENID@ " + cuentaMonetaria[cuenta].Nombre);
                                    Console.Write("Ingrese el monto a depositar: Q.");
                                    
                                    
                                    //Se descompone con letras
                                    monto = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                                } while (monto <= 0);
                                Console.WriteLine("");
                                cuentaMonetaria[cuenta].Transaccion(monto);
                                Console.WriteLine("Saldo actual: Q." + cuentaMonetaria[cuenta].Saldo);
                                
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("FORMATO DE CUENTA INVALIDO");
                                Console.ForegroundColor = ConsoleColor.White;
                               
                            }
                            break;

                        case "3":
                            double monto1 = 0;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("------ABONO A CREDITO------");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            Console.Write("Ingrese el numero de DPI: ");
                            no = Console.ReadLine();
                            Console.WriteLine("");
                            if (no.Length == 13)
                            {

                                foreach (Creditos credito in creditos)
                                {
                                    b = Equals(no, credito.DPI.ToString());
                                    if (b) { break; }
                                    else { cuenta++; }
                                }
                                if (!b)
                                {
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("No se encontro dicho DPI");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("");
                                    break;
                                }
                                do
                                {

                                    Console.WriteLine("Bienvenid@ " + creditos[cuenta].Nombre);
                                    Console.Write("Ingrese el monto a abonar: Q.");
                                creditos[cuenta].Deuda -= monto1;

                                    monto1 = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                                } while (monto1 <= 0);
                                if (creditos[cuenta].Deuda >= monto1)
                                {
                                    creditos[cuenta].Deuda -= monto1;

                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("PAGO DE PRESTAMO"); Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("");
                                    Console.WriteLine($"Nombre del cliente: {creditos[cuenta].Nombre}");
                                    Console.WriteLine($"Número de DPI     : {creditos[cuenta].DPI}");
                                    Console.WriteLine("");
                                    Console.WriteLine("-------------------------------------------------");
                                    Console.WriteLine($"Monto abonado:  Q.{monto1:F2}");
                                    Console.WriteLine("-------------------------------------------------");
                                    Console.WriteLine("Deuda restante:  Q." + Math.Round(creditos[cuenta].Deuda, 2));

                                    Console.WriteLine("");
                                    if (creditos[cuenta].Deuda == 0)
                                    {
                                        Console.WriteLine("");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("FELICIDADES!!! ");
                                        Console.WriteLine("Usted ha saldado su deuda con el banco");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        creditos.RemoveAt(cuenta);
                                    }
                                    Console.WriteLine("");
                                }
                                else if (creditos[cuenta].Deuda < monto1)
                                {
                                    double sobra = monto1 - creditos[cuenta].Deuda;
                                    creditos[cuenta].Deuda = 0;
                                    monto1 = 0;
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("PAGO DE PRESTAMO"); Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("");

                                    Console.WriteLine($"Nombre del cliente: {creditos[cuenta].Nombre}");
                                    Console.WriteLine($"Numero de DPI     : {creditos[cuenta].DPI}");
                                    Console.WriteLine("");
                                    Console.WriteLine("-------------------------------------------------");
                                    Console.WriteLine($"Monto abonado:                        Q. {monto1 + sobra:F2}");
                                    Console.WriteLine($"Monto aceptado para cancelar deuda:   Q. {sobra:F2}");
                                    Console.WriteLine($"El resto se le devolverá en efectivo: Q. {sobra:F2}");
                                    Console.WriteLine("-------------------------------------------------");
                                    Console.WriteLine("Deuda restante:                        Q. 0.00");

                                }
                                if (creditos[cuenta].Deuda == 0)
                                {
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("FELICIDADES!!! ");
                                    Console.WriteLine("Usted ha saldado su deuda con el banco");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    creditos.RemoveAt(cuenta);
                                }
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Formato de DPI invalido");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("");
                            }
                            break;

                    }
                    break;
                } while (true);
                Console.WriteLine(""); Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Presione ENTER para salir");
                Console.WriteLine("");
                Console.ReadKey();
                Console.Clear();
            }
          
            void Retiros(List<CuentaAhorro> cuentaAhorro, List<CuentaMonetaria> cuentaMonetaria)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------RETIROS------"); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
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
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("CUENTA DE AHORRO DETECTADA");
                        Console.WriteLine("");
                        Console.WriteLine("NOTA:");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Para poder hacer retiros con cheque, solicite una cuenta monetaria");
                        break;
                    }
                    else if (no.Length == 5)
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"------RETIRO MONETARIO------ ");
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
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("No se ha encontrado el número de cuenta");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            break;
                        }
                        do
                        {
                            Console.WriteLine("BIENVENID@ " + cuentaMonetaria[cuenta].Nombre);
                            Console.Write("Ingrese el monto a retirar: Q.");
                            monto = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                        } while (monto <= 0);
                        if (monto > cuentaMonetaria[cuenta].Saldo)
                        {
                            cuentaMonetaria[cuenta].Saldo -= 150;
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("NOTA: ");
                            Console.WriteLine("- Usted efectuó un cheque sin fondos");
                            Console.WriteLine("- Se le hará una MULTA de Q150.00");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            Console.WriteLine("Ahora su saldo actual es Q. " + cuentaMonetaria[cuenta].Saldo);
                            if (cuentaMonetaria[cuenta].Saldo < 0)
                            {
                                Console.WriteLine($"Tiene una deuda de Q.{Math.Abs(cuentaMonetaria[cuenta].Saldo)}" + " .Esta cantidad se le retendra en su proximo deposito");
                            }
                            
                        }
                        else
                            cuentaMonetaria[cuenta].Transaccion(monto * -1);
                        Console.WriteLine("Saldo actual: Q." + cuentaMonetaria[cuenta].Saldo);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Formato de cuenta invalido");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");

                    }
               
                } while (true);
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Presione ENTER para salir");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.ReadKey();
                Console.Clear();
            }
            void Credit(List<Creditos> creditos)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------CREDITO------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                string no;
                do
                {
                    int cuenta = 0;
                    double monto = 0;
                    double depo;
                    string n;
                    bool b = false;
                    int DeudaReondeada;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"------SELECCIONE UNA OPCION------ ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("1. Solicitud de Credito: ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    string p = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    switch (p)
                    {
                        case "1":
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
                                        Console.Write("Ingrese la cantidad de años para su prestamo de plazo fijo (Min 1 / Max 60): ");
                                        anos = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                                    } while (anos < 1 || anos > 60);
                                   
                                    double deuda = Math.Round(depo * (Math.Pow((1 + 0.12), anos)), 2);

                            creditos.Add(new Creditos(n, dpi, deuda, depo));
                            

                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("PRESTAMO ACREDITADO"); Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("");
                                    Console.WriteLine("  Prestamo por:      Q." + depo);
                                    Console.WriteLine("+ Interes generado:  Q." + (deuda - depo),8);
                                    Console.WriteLine("-------------------------------------------------");
                                    Console.WriteLine("  Deuda con interes: Q." + deuda);
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("DETALLES DEL PRESTAMO"); Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("");

                                    Console.WriteLine("-------------------------------------------------");
                                    Console.WriteLine("Nombre:     " + n);
                                    Console.WriteLine("DPI:        " + dpi);
                                     Console.WriteLine("Interes:    12% anual");
                                     Console.WriteLine("Tiempo:     " +  anos+ " años");
                                    Console.WriteLine("Prestamo:   Q." + depo);
                                    Console.WriteLine("Interes Generado: Q." + (deuda - depo),8);
                                    Console.WriteLine("Deuda total: Q." + deuda);
                                    Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("NOTA:");
                            Console.WriteLine("- Interes es del 12%");
                            Console.WriteLine("- Se aplicará el interés en base a la cantidad de años");
                            Console.WriteLine("- Se mantendrá sin importar el plazo con el que se termine pagando al final."); Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");

                            break;
                        


                    }
                    break;
                } while (true);
                Console.WriteLine(""); Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Presione ENTER para salir");
                Console.WriteLine("");
                Console.ReadKey();
                Console.Clear();
            }

            void Estadisticas()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine("------ESTADISTICAS------"); Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
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
                       
                        if (inputNumeroCuenta.Length == 4)
                        {
                          
                            cuentaExistente = cuentas.Any(cuenta => cuenta.NumeroCuenta == numeroCuenta);

                            if (!cuentaExistente)
                            {
                                numeroValido = true;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El número de cuenta ya existe. Intente de nuevo.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El número de cuenta debe tener 4 dígitos. Intente de nuevo.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor ingresado no es un número válido. Intente de nuevo.");
                        Console.ForegroundColor = ConsoleColor.White;
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
                        if (inputNumeroCuenta.Length == 5)
                        { 
                            cuentaExistente = cuentas.Any(cuenta => cuenta.NumeroCuenta == numeroCuenta);

                            if (!cuentaExistente)
                            {
                                numeroValido = true;
                            }
                            else
                            {
                                Console.WriteLine("");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El número de cuenta ya existe. Intente de nuevo.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El número de cuenta debe tener 5 dígitos. Intente de nuevo.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor ingresado no es un número válido. Intente de nuevo.");
                        Console.ForegroundColor = ConsoleColor.White;
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
                    Console.Write("Ingrese su numero de DPI (13 dígitos): ");
                    string inputNumeroCuenta = Console.ReadLine();
                    if (ulong.TryParse(inputNumeroCuenta, out numeroDPI))
                    {
                      
                        if (inputNumeroCuenta.Length == 13)
                        {
                            
                            cuentaExistente = creditos.Any(cuenta => cuenta.DPI == numeroDPI);

                            if (!cuentaExistente)
                            {
                                numeroValido = true;
                            }
                            else
                            {

                                Console.WriteLine("");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("No se puede tener mas de 1 credito por cliente.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("");
                            }
                        }
                        else
                        {

                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Numero de DPI invalido. Intente de nuevo.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                        }
                    }
                    else
                    {

                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El valor ingresado no es un número válido. Intente de nuevo.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                    }
                } while (!numeroValido);

                return numeroDPI;
            }
        }


    }
}
