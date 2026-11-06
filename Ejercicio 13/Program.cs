using System;

Console.WriteLine("SISTEMA DE CONTROL DE MOTORES");
Console.WriteLine();

// --- 1. MOTOR CD ---
Console.WriteLine("--- Configuración de Motor CD ---");
MotorCD motorCD1 = new MotorCD();
Console.Write("Ingrese el identificador del motor CD: ");
motorCD1.Identificador = Console.ReadLine() ?? "Sin identificador";
Console.Write("Ingrese la temperatura del motor: ");
motorCD1.Temperatura = Convert.ToDouble(Console.ReadLine());
Console.Write("Ingrese la corriente del motor: ");
motorCD1.Corriente = Convert.ToDouble(Console.ReadLine());
Console.Write("Ingrese la velocidad del motor en rpm: ");
motorCD1.Velocidad = Convert.ToDouble(Console.ReadLine());
Console.Write("Ingrese el voltaje del motor: ");
motorCD1.Voltaje = Convert.ToDouble(Console.ReadLine());


// --- 2. MOTOR AC ---
Console.WriteLine("\n--- Configuración de Motor AC ---");
MotorAC motorAC1 = new MotorAC();
Console.Write("Ingrese el identificador del motor AC: ");
motorAC1.Identificador = Console.ReadLine() ?? "Sin identificador";
Console.Write("Ingrese la temperatura del motor: ");
motorAC1.Temperatura = Convert.ToDouble(Console.ReadLine());
Console.Write("Ingrese la corriente del motor: ");
motorAC1.Corriente = Convert.ToDouble(Console.ReadLine());
Console.Write("Ingrese la velocidad del motor en rpm: ");
motorAC1.Velocidad = Convert.ToDouble(Console.ReadLine());
Console.Write("Ingrese las fases de operación (ej. Monofásico / Trifásico): ");
motorAC1.FasesOperacion = Console.ReadLine() ?? "Desconocido";


// --- 3. SERVOMOTOR ---
Console.WriteLine("\n--- Configuración de Servomotor ---");
Servomotor servo1 = new Servomotor();
Console.Write("Ingrese el identificador del servomotor: ");
servo1.Identificador = Console.ReadLine() ?? "Sin identificador";
Console.Write("Ingrese la temperatura del motor: ");
servo1.Temperatura = Convert.ToDouble(Console.ReadLine());
Console.Write("Ingrese la corriente del motor: ");
servo1.Corriente = Convert.ToDouble(Console.ReadLine());
Console.Write("Ingrese la velocidad del motor en rpm: ");
servo1.Velocidad = Convert.ToDouble(Console.ReadLine());
Console.Write("Ingrese la posición angular (grados): ");
servo1.PosicionAngular = Convert.ToDouble(Console.ReadLine());


// --- MOSTRAR RESULTADOS ---
Console.WriteLine("\n========================================");
Console.WriteLine("          DATOS DE LOS MOTORES          ");
Console.WriteLine("========================================");

// Resultados Motor CD
Console.WriteLine("\n[Motor CD]");
Console.WriteLine($"Motor: {motorCD1.Identificador}");
Console.WriteLine($"Temperatura: {motorCD1.Temperatura} °C");
Console.WriteLine($"Corriente: {motorCD1.Corriente} A");
Console.WriteLine($"Velocidad: {motorCD1.Velocidad} rpm");
Console.WriteLine($"Voltaje: {motorCD1.Voltaje} V");
Console.WriteLine($"Estado: {motorCD1.ObtenerEstado()}");
Console.WriteLine($"Revisión de temperatura: {motorCD1.RevisarTemperatura()}");

// Resultados Motor AC
Console.WriteLine("\n[Motor AC]");
Console.WriteLine($"Motor: {motorAC1.Identificador}");
Console.WriteLine($"Temperatura: {motorAC1.Temperatura} °C");
Console.WriteLine($"Corriente: {motorAC1.Corriente} A");
Console.WriteLine($"Velocidad: {motorAC1.Velocidad} rpm");
Console.WriteLine($"Fases de operación: {motorAC1.FasesOperacion}");
Console.WriteLine($"Estado: {motorAC1.ObtenerEstado()}");
Console.WriteLine($"Revisión de temperatura: {motorAC1.RevisarTemperatura()}");

// Resultados Servomotor
Console.WriteLine("\n[Servomotor]");
Console.WriteLine($"Motor: {servo1.Identificador}");
Console.WriteLine($"Temperatura: {servo1.Temperatura} °C");
Console.WriteLine($"Corriente: {servo1.Corriente} A");
Console.WriteLine($"Velocidad: {servo1.Velocidad} rpm");
Console.WriteLine($"Posición angular: {servo1.PosicionAngular} °");
Console.WriteLine($"Estado: {servo1.ObtenerEstado()}");
Console.WriteLine($"Revisión de temperatura: {servo1.RevisarTemperatura()}");


// CLASE BASE
class Motor
{
    // Propiedades comunes heredadas por todas las clases derivadas
    public string Identificador { get; set; } = "";
    public double Temperatura { get; set; }
    public double Corriente { get; set; }
    public double Velocidad { get; set; }

    // Método para determinar el estado
    public string ObtenerEstado()
    {
        if (Velocidad > 0)
            return "Motor en marcha";
        else
            return "Motor detenido";
    }

    // Método para revisar la temperatura
    public string RevisarTemperatura()
    {
        if (Temperatura > 70)
            return "ALERTA: Temperatura elevada";

        return "Temperatura normal";
    }
}

// CLASE DERIVADA 1: MotorCD
class MotorCD : Motor
{
    // Propiedad propia de MotorCD
    public double Voltaje { get; set; }
}

// CLASE DERIVADA 2: MotorAC
class MotorAC : Motor
{
    // Propiedad propia de MotorAC
    public string FasesOperacion { get; set; } = "";
}

// CLASE DERIVADA 3: Servomotor
class Servomotor : Motor
{
    // Propiedad propia de Servomotor
    public double PosicionAngular { get; set; }
}