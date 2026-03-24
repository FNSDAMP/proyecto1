using System;

namespace SimuladorDeStreaming
{
    class Program
    {
        // 1.Contadores para las estadisticas
        static int totalEvaluados = 0;
        static int publicados = 0;
        static int publicadosConAjustes = 0;
        static int rechazados = 0;
        static int enRevision = 0;

        static int impactoBajo = 0;
        static int impactoMedio = 0;
        static int impactoAlto = 0;

        // Funcion principal
        static void Main()
        {
            int opcion = 0;

            // 2. Ciclo do-while que mantiene el menu repitiendose hasta que se elija salir
            do
            {
                Console.Clear(); //Este comando limpia la pantalla, en este caso el menu cada vez que se vuelve a repetir el ciclo.
                DibujarLinea(); //Función con for
                Console.WriteLine("   SISTEMA DE PLATAFORMA DE STREAMING");
                DibujarLinea();
                Console.WriteLine("1-------Evaluar nuevo contenido");
                Console.WriteLine("2-------Mostrar reglas del sistema");
                Console.WriteLine("3-------Ver estadisticas");
                Console.WriteLine("4-------Salir");
                Console.Write("\n----Selecciona una opcion----");

                // Esto es una validacion directa que si no es número se va volver a pedir
                while (!int.TryParse(Console.ReadLine(), out opcion)) //basicamente puse este while porque sin el, el programa se crasheaba al poner una letra o un dato invalido
                {
                    Console.Write("Error: Ingresa un numero valido: ");
                }

                // 3. El ciclo while valida que la opción no sea un numero fuera del rango
                while (opcion < 1 || opcion > 4)
                {
                    Console.Write("Error. Ingrese un numero del 1 al 4: ");
                    while (!int.TryParse(Console.ReadLine(), out opcion)) //Mientras no se pueda convertir lo que el usuario escribio en un número entero, se va a repetir el ciclo. 
                    {                                                     //Basicamente si el usuario escribe un numero valido lo gaurada en la opcion,
                                                                          //"!" hace que si el TryParse falló (false) porque escribieron letras o dejaron un vacio,
                                                                          //lo convierte en true y el ciclo se repite, mostrando el mensaje de "Dato inválido"
                        Console.Write("Error: Ingresa un numero válido: ");
                    }
                }

                // 4. switch verifica las opciones del menu
                switch (opcion)
                {
                    case 1:
                        EvaluarContenido();
                        break;
                    case 2:
                        MostrarReglas();
                        break;
                    case 3:
                        MostrarEstadisticas();
                        break;
                    case 4:
                        Console.WriteLine("\nCerrando el sistema...");
                        break;
                }
                if (opcion != 4)
                {
                    Console.WriteLine("\nPresione ENTER para continuar...");
                    Console.ReadLine();
                }
                
                //Mientras que la opcion sea diferente que 4 se ejecutara 
            } while (opcion != 4);
        }
        // 5. Este ciclo for solo va a diujar una linea que es para decoracion en el menu
        static void DibujarLinea()
        {
            for (int i = 0; i < 45; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        // 6. Esta funcion va a evaluar las opciones
        static void EvaluarContenido()
        {
            Console.Clear();
            Console.WriteLine("--- EVALUAR CONTENIDO ---");

            // Aqui se pedira al usuario que seleccione una opcion de manera sencilla, con numeros
            Console.Write("Tipo ---->       1----Pelicula  |  2----Serie  |  3----Documental  |  4----En vivo ");
            int tipo;
            while (!int.TryParse(Console.ReadLine(), out tipo))
            {
                Console.Write("Dato invalido. Ingrese el número del tipo: ");
            }

            Console.Write("Duracion en minutos: ");
            int duracion;
            while (!int.TryParse(Console.ReadLine(), out duracion))
            {
                Console.Write("Dato invalido. Ingrese la duracion en numeros. ");
            }

            Console.Write("Clasificacion ---->      1----Todo publico  |  2---- +13  |  3---- +18 ");
            int clasificacion;
            while (!int.TryParse(Console.ReadLine(), out clasificacion))
            {
                Console.Write("Dato invalido. Ingrese el número de la clasificacion. ");
            }

            Console.Write("Hora de programación (0 a 23): ");
            int hora;
            while (!int.TryParse(Console.ReadLine(), out hora))
            {
                Console.Write("Dato inválido. Ingrese la hora en numeros. ");
            }

            Console.Write("Nivel de producción ---->     1---- Baja  |  2---- Media  |  3---- Alta ");
            int produccion;
            while (!int.TryParse(Console.ReadLine(), out produccion))
            {
                Console.Write("Dato invalido. Ingrese el número de la produccion. ");
            }

            totalEvaluados++;
            bool esValido = true;
            string motivoRechazo = "";



            // 7. Uso de if anidados. Aqui van a estar las condiciones para validar el horario segun la clasificacion
            if (clasificacion == 2)
            {
                if (hora < 6 || hora > 22)
                {
                    esValido = false;
                    motivoRechazo = "El horario para +13 es solo de 6 a 22 hrs.";
                }
            }
            else if (clasificacion == 3)
            {
                if (hora > 5 && hora < 22)
                {
                    esValido = false;
                    motivoRechazo = "El horario para +18 es solo de 22 a 5 hrs.";
                }
            }

            // 8. Uso de if anidados. Aqui se va a validar la duración según el tipo
            if (tipo == 1 && (duracion < 60 || duracion > 180))
            {
                esValido = false;
                motivoRechazo = "Duracion de pelicula incorrecta. Debe ser 60-180 min.";
            }
            else if (tipo == 2 && (duracion < 20 || duracion > 90))
            {
                esValido = false;
                motivoRechazo = "Duracion de serie incorrecta. Debe ser 20-90 min.";
            }
            else if (tipo == 3 && (duracion < 30 || duracion > 120))
            {
                esValido = false;
                motivoRechazo = "Duracion de documental incorrecta. Debe ser 30-120 min.";
            }
            else if (tipo == 4 && (duracion < 30 || duracion > 240))
            {
                esValido = false;
                motivoRechazo = "Duracion de evento en vivo incorrecta. Debe ser 30-240 min.";
            }

            // Validar produccion
            if (produccion == 1 && clasificacion == 3)
            {
                esValido = false;
                motivoRechazo = "Produccion baja no permitida para clasificacion +18.";
            }

            // Decision final
            if (esValido == false)
            {
                Console.WriteLine("\n>>> RESULTADO: RECHAZADO");
                Console.WriteLine("Motivo: " + motivoRechazo);
                rechazados++;
            }
            else
            {
                // Calcular el nivel de impacto si fue aprobado tecnicamente
                int nivelImpacto = 1;

                if (produccion == 1 && duracion < 60)
                {
                    nivelImpacto = 1; // Bajo
                }
                if (produccion == 2 || (duracion >= 60 && duracion <= 120))
                {
                    nivelImpacto = 2; // Medio
                }
                if (produccion == 3 || duracion > 120 || hora >= 20)
                {
                    nivelImpacto = 3; // Alto
                }

                // Contadores para guardar para las estadisticas
                if (nivelImpacto == 1) impactoBajo++;
                if (nivelImpacto == 2) impactoMedio++;
                if (nivelImpacto == 3) impactoAlto++;

                Console.WriteLine("\nEl contenido cumple las reglas tecnicas.");

                // Decision según el impacto
                if (nivelImpacto == 3)
                {
                    Console.WriteLine("Resultado: Enviar a revision");
                    Console.WriteLine("Motivo: Cumple reglas tecnicas, pero el contenido tiene un impacto alto.");
                    enRevision++;
                }
                else if (nivelImpacto == 2 && produccion == 2)
                {
                    Console.WriteLine("Resultado: Publicar con ajustes");
                    Console.WriteLine("Motivo: Impacto medio, pero requiere de ajustes en produccion.");
                    publicados++;
                    publicadosConAjustes++;
                }
                else
                {
                    Console.WriteLine("Resultado: Publicar");
                    Console.WriteLine("Motivo: Cumple todas las reglas tecnicas y su impacto es bajo o medio.");
                    publicados++;
                }
            }
        }


        // Funciones que muestran informacion
        static void MostrarReglas()
        {
            Console.Clear();
            DibujarLinea();
            Console.WriteLine("--- REGLAS DEL SISTEMA ---");
            DibujarLinea();
            Console.WriteLine("1---- HORARIOS ----");
            Console.WriteLine("   Todo publico: Cualquier hora.");
            Console.WriteLine("   +13: De 6 a 22 hrs.");
            Console.WriteLine("   +18: De 22 a 5 hrs.");
            Console.WriteLine("2---- PRODUCCION ----:");
            Console.WriteLine("   Baja: No permitida para +18.");
        }

        static void MostrarEstadisticas()
        {
            Console.Clear();
            DibujarLinea();
            Console.WriteLine("---- ESTADISTICAS DE HOY ----");
            DibujarLinea();
            Console.WriteLine("Total evaluados: " + totalEvaluados);
            Console.WriteLine("Publicados: " + publicados);
            Console.WriteLine("Publicados con ajustes: " + publicadosConAjustes);
            Console.WriteLine("Rechazados: " + rechazados);
            Console.WriteLine("En Revision: " + enRevision);

            if (totalEvaluados > 0)
            {
                // Calcular impacto predominante
                string predominante = "Empate";
                if (impactoBajo > impactoMedio && impactoBajo > impactoAlto) predominante = "Bajo";
                if (impactoMedio > impactoBajo && impactoMedio > impactoAlto) predominante = "Medio";
                if (impactoAlto > impactoBajo && impactoAlto > impactoMedio) predominante = "Alto";

                Console.WriteLine("Impacto predominante: " + predominante);
            }
            else
            {
                Console.WriteLine("Aun no hay datos para mostrar.");
            }
        }
    }
}