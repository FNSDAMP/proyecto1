using System;

namespace SimuladorStreaming
{
    class Program
    {
        // 1.Contadores para las estadisticas
        static int totalEvaluados = 0;
        static int publicados = 0;
        static int publicadosConAjustes = 0;
        static int rechazados = 0;
        static int enRevision = 0;

        // Funcion principal
        static void Main()
        {
            int opcion = 0;

            // 2. Ciclo do-while que mantiene el menu repitiendose hasta que se elija salir
            do
            {
                Console.Clear(); //Este comando limpia la pantalla, en este caso el menu cada vez que se vuelve a repetir el ciclo.
                Console.WriteLine("   SISTEMA DE PLATAFORMA DE STREAMING");
                Console.WriteLine("1. Evaluar nuevo contenido");
                Console.WriteLine("2.Mostrar reglas del sistema");
                Console.WriteLine("3.Ver estadisticas");
                Console.WriteLine("4.Salir");
                Console.Write("\n----Ingrese una opcion----");

                // Esto es una validacion directa que si no es número se va volver a pedir
                while (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.Write("Error: Ingresa un numero valido: ");
                }

                // 3. El ciclo while valida que la opción no sea un numero fuera del rango
                while (opcion < 1 || opcion > 4)
                {
                    Console.Write("Error. Ingrese un numero del 1 al 5.");
                    while (!int.TryParse(Console.ReadLine(), out opcion)) //Mientras no se pueda convertir lo que el usuario escribio en un número entero, se va a repetir el ciclo. 
                    {                                                     //Basicamente si el usuario escribe un numero valido lo gaurada en la opcion,
                                                                          //"!" hace que si el TryParse falló (false) porque escribieron letras o no escribieron nada,
                                                                          //lo convierte en true y el ciclo se repite, mostrando el mensaje de dato invalido
                        Console.Write("Error: Ingresa un numero valido.");
                    }
                }

                // 4. switch verifica las opciones del menu
                switch (opcion)
                { 
                    //Aqui van a ir las funciones del menu
                }

             } while (opcion != 4) ;
            
        }
    }
}
