int opcionMenu = 0;

while (opcionMenu != 3) 
{
    Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
    Console.WriteLine("1. Mostrar mensaje");
    Console.WriteLine("2. Pedir número y mostrar doble");
    Console.WriteLine("3. Salir");
    Console.Write("Seleccione una opción: ");

    try
    {
        opcionMenu = int.Parse(Console.ReadLine());

        switch (opcionMenu)
        {
            case 1:
                Console.WriteLine("Este es un mensaje default");
                break;

            case 2:
                bool numeroCorrecto = false;
                while (!numeroCorrecto) 
                {
                    try
                    {
                        Console.Write("Ingrese un numero: ");
                        int num = int.Parse(Console.ReadLine());
                        Console.WriteLine("El doble es: " + (num * 2));
                        numeroCorrecto = true; 
                    }
                    catch
                    {
                        Console.WriteLine("Error: Debe ingresar un número válido.");
                    }
                }
                break;

            case 3:
                Console.WriteLine("Saliendo del programa...");
                break;

            default:
                Console.WriteLine("Opción no válida. Intente con 1, 2 o 3.");
                break;
        }
    }
    catch
    {
        Console.WriteLine("Error: Ingrese un número para elegir la opción del menú.");
    }
}