using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Version_2._0_Proyecto
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Random random = new Random();
            bool alarmaActiva = false;
            int opcion;

            // Sensores
            double s1 = 0, s2 = 0, s3 = 0, s4 = 0;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("═══════════════════════════════════════════════════════════");
                Console.WriteLine("       SISTEMA CONTRA INCENDIOS INTELIGENTE - SCI          ");
                Console.WriteLine("═══════════════════════════════════════════════════════════");
                Console.ResetColor();
                Console.WriteLine("[1] Mostrar zonas de sensores");
                Console.WriteLine("[2] Ejecutar monitoreo de temperatura");
                Console.WriteLine("[3] Estado del sistema");
                Console.WriteLine("[4] Restablecer sistema");
                Console.WriteLine("[0] Salir");
                Console.Write("\nSeleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                // Procesar opción seleccionada
                switch (opcion)
                {
                    case 1:
                        MostrarMapaSensores();
                        break;

                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("=== MONITOREO EN TIEMPO REAL ===\n");
                        Console.ResetColor();

                        s1 = random.Next(25, 101);
                        s2 = random.Next(25, 101);
                        s3 = random.Next(25, 101);
                        s4 = random.Next(25, 101);

                        Console.WriteLine($"🌡 Zona A - Generador: {s1}°C");
                        Console.WriteLine($"🌡 Zona B - Sala de control: {s2}°C");
                        Console.WriteLine($"🌡 Zona C - Almacén combustible: {s3}°C");
                        Console.WriteLine($"🌡 Zona D - Transformadores: {s4}°C");

                        int peligros = 0;
                        if (s1 >= 70) peligros++;
                        if (s2 >= 70) peligros++;
                        if (s3 >= 70) peligros++;
                        if (s4 >= 70) peligros++;

                        Console.WriteLine("\n═════════════════════════════════════════");

                        if (peligros >= 2)
                        {
                            alarmaActiva = true;
                            EmergenciaFuego(s1, s2, s3, s4);
                        }
                        else if (peligros == 1)
                        {
                            alarmaActiva = true;
                            AlertaSobrecalentamiento(s1, s2, s3, s4);
                        }
                        else
                        {
                            alarmaActiva = false;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("✅ Sistema estable. Todas las zonas seguras.");
                            Console.ResetColor();
                        }

                        Console.WriteLine("═════════════════════════════════════════");
                        Console.WriteLine("\nPresione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                    case 3:
                        EstadoSistema(alarmaActiva);
                        break;

                    case 4:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("🔄 Restableciendo sistema...");
                        alarmaActiva = false;
                        Thread.Sleep(1200);
                        Console.WriteLine("✅ Sistema restablecido con éxito.");
                        Console.ResetColor();
                        Thread.Sleep(800);
                        break;

                    case 0:
                        Console.WriteLine("\n👋 Cerrando el sistema...");
                        Thread.Sleep(800);
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("❌ Opción inválida. Intente nuevamente.");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                        break;
                }

            } while (opcion != 0);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nGracias por confiar en SCI Systems 🏢 – España 🇪🇸");
            Console.WriteLine("Protegiendo instalaciones con tecnología inteligente 🔥");
            Console.ResetColor();
        }

        // 🔹 Mostrar mapa de sensores
        static void MostrarMapaSensores()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== UBICACIÓN DE SENSORES ===\n");
            Console.ResetColor();
            Console.WriteLine("📍 Sensor 1 → Zona A: Generador principal");
            Console.WriteLine("📍 Sensor 2 → Zona B: Sala de control");
            Console.WriteLine("📍 Sensor 3 → Zona C: Almacén de combustible");
            Console.WriteLine("📍 Sensor 4 → Zona D: Área de transformadores");
            Console.WriteLine("\n💡 Todos los sensores activos y operativos.");
            Console.WriteLine("\nPresione ENTER para volver al menú...");
            Console.ReadLine();
        }

        // 🔹 Animación de emergencia de incendio
        static void EmergenciaFuego(double s1, double s2, double s3, double s4)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("🔥🔥🔥 ¡EMERGENCIA! INCENDIO DETECTADO 🔥🔥🔥");
            Console.ResetColor();

            MostrarZonasCriticas(s1, s2, s3, s4);
            SonidoAlarma();
            AnimarFuego();
            AnimarLlamada();
            AnimarBomberos();
        }

        // 🔹 Animación de sobrecalentamiento
        static void AlertaSobrecalentamiento(double s1, double s2, double s3, double s4)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠ ALERTA: Sobrecalentamiento detectado ⚠");
            Console.ResetColor();

            MostrarZonasCriticas(s1, s2, s3, s4);
            Console.Beep(700, 400);
            Thread.Sleep(500);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n🧰 Enviando alerta a mantenimiento técnico...");
            Thread.Sleep(1500);
            Console.WriteLine("✅ Revisión técnica urgente programada.");
            Console.ResetColor();
        }

        // 🔹 Muestra zonas afectadas
        static void MostrarZonasCriticas(double s1, double s2, double s3, double s4)
        {
            if (s1 >= 70) Console.WriteLine("🚨 Zona A (Generador principal) crítica!");
            if (s2 >= 70) Console.WriteLine("🚨 Zona B (Sala de control) crítica!");
            if (s3 >= 70) Console.WriteLine("🚨 Zona C (Almacén combustible) crítica!");
            if (s4 >= 70) Console.WriteLine("🚨 Zona D (Transformadores) crítica!");
        }

        // 🔹 Sonido de alarma
        static void SonidoAlarma()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Beep(900, 250);
                Console.Beep(1200, 250);
                Thread.Sleep(200);
            }
        }

        // 🔹 Animación de fuego en consola
        static void AnimarFuego()
        {
            string[] fuego = { "🔥", "🔥🔥", "🔥🔥🔥", "🔥🔥🔥🔥", "🔥🔥🔥🔥🔥" };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            for (int i = 0; i < fuego.Length; i++)
            {
                Console.WriteLine(fuego[i]);
                Thread.Sleep(250);
            }
            Console.WriteLine("💦 Rociadores ACTIVADOS 💦");
            Console.ResetColor();
        }

        // 🔹 Animación de llamada telefónica
        static void AnimarLlamada()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string[] frames = { "📱📶 Llamando.", "📱📶 Llamando..", "📱📶 Llamando..." };
            for (int i = 0; i < 2; i++)
            {
                foreach (string frame in frames)
                {
                    Console.Write("\r" + frame);
                    Console.Beep(600, 150);
                    Thread.Sleep(300);
                }
            }
            Console.WriteLine("\r📞 Conectado con bomberos...");
            Thread.Sleep(800);
            Console.ResetColor();
        }

        // 🔹 Animación del camión de bomberos
        static void AnimarBomberos()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string[] frames = { "🚒", "🚒💨", "🚒💨💨", "🚒💨💨💨", "🚒💨💨💨💨" };
            Console.WriteLine();
            foreach (var frame in frames)
            {
                Console.Write("\r" + frame);
                Thread.Sleep(400);
            }
            Console.WriteLine("\r🚒 Los bomberos han llegado al sitio. ✅");
            Thread.Sleep(1200);
            Console.ResetColor();
        }

        // 🔹 Estado general del sistema
        static void EstadoSistema(bool alarmaActiva)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("=== ESTADO DEL SISTEMA ===\n");
            Console.ResetColor();

            if (alarmaActiva)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("🚨 ALARMA: ACTIVADA");
                Console.WriteLine("💡 Luces de emergencia: ENCENDIDAS");
                Console.WriteLine("💦 Rociadores: ACTIVOS");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Sistema operativo y sin alertas.");
                Console.WriteLine("💡 Luces de emergencia: APAGADAS");
                Console.WriteLine("💦 Rociadores: EN ESPERA");
                Console.ResetColor();
            }

            Console.WriteLine("\nPresione ENTER para volver...");
            Console.ReadLine();
        }
    }
}