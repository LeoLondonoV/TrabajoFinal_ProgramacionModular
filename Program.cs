using Microsoft.VisualBasic;
using System.Globalization;

namespace pruebaDeFuncionalidad
{
    internal class Program
    {
        const String usuarioDefecto = "administrador";
        const string contrasenaDefecto = "1234";
        const int MAX_USUARIOS = 15;
        const int TOTAL_CAMPOS = 5;
        
        static string[] nombresCampos = { "Cedula", "Nombre", "Apellido", "Telefono", "Dirección" };
        static string[,] usuarios = new string[MAX_USUARIOS, TOTAL_CAMPOS];
        static int cantidadUsuarios = 0;

        
        static int cantidadArticulos = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                if (Autenticacion())
                {
                    MenuPrincipal();
                }
            }
        }


        //-------------------------------------------------------------------------
        static bool Autenticacion()
        {
            Console.WriteLine("===== AUTENTICACIÓN =====");

            Console.Write("Ingrese su usuario: ");
            string usuario = Console.ReadLine();

            Console.Write("Ingrese su contraseña: ");
            string contrasena = Console.ReadLine();

            if (usuario == usuarioDefecto && contrasena == contrasenaDefecto)
            {
                Console.WriteLine("Ingreso exitoso.");
                Console.ReadKey();
                return true;
            }

            Console.WriteLine("Usuario o contraseña incorrectos.");
            Console.ReadKey();
            return false;

        }

        //----------------------------------------------------------------------------
        static void MenuPrincipal()
        {
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("---------MENÚ---------");
                Console.WriteLine("1. Gestión de usuarios\n2. Gestion de artículos\n3. Gestión de ventas\n4. Salir del programa");
                Console.WriteLine("----------------------");
                Console.Write("Ingrese una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        GestionUsuarios();
                        break;
                    case 2:
                        GestionArticulos();
                        break;
                    case 3:
                        //GestionVentas();
                        break;
                    case 4:
                        Console.WriteLine("Fuera del programa.");
                        break;
                    default:
                        Console.WriteLine("\nOpción no valida.");
                        Console.ReadKey();
                        break;
                }                
            } while (opcion != 4);
        }
        //---------------------------------------------------------------------------------------------------------
        static void GestionUsuarios()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("---------GESTIÓN DE USUARIOS---------");
                Console.WriteLine("1. Ver lista de usuarios\n2. Nuevo usuario\n3. Editar información de usuario\n4. Salir de gestión de usuarios");
                Console.WriteLine("-------------------------------------");
                Console.Write("Ingrese una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        VerListaUsuarios();
                        break;
                    case 2:
                        NuevoUsuario();
                        break;
                    case 3:
                        EditarUsuario();
                        break;
                    case 4:
                        Console.WriteLine("\nRegresando al menú principal");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 4);

        }
        static void VerListaUsuarios()
        {
            Console.Clear();
            Console.WriteLine("---LISTA DE USUARIOS---");
            if (cantidadUsuarios == 0 )
            {
                Console.WriteLine("No hay usuarios registrados");
            }
            else
            {               
                for (int i = 0; i < cantidadUsuarios; i++) 
                {
                    Console.WriteLine($"Usuario N° {i+1}");
                    Console.WriteLine($"{nombresCampos[0]}: {usuarios[i, 0]}");                    
                    Console.WriteLine($"{nombresCampos[1]}: {usuarios[i, 1]}");
                    Console.WriteLine($"{nombresCampos[2]}: {usuarios[i, 2]}");
                    Console.WriteLine($"{nombresCampos[3]}: {usuarios[i, 3]}");
                    Console.WriteLine($"{nombresCampos[4]}: {usuarios[i, 4]}");    
                }
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar");
            Console.ReadKey();
        }

        static void NuevoUsuario()
        {
            Console.Clear();
            Console.WriteLine("----NUEVO USUARIO----");

            if (cantidadUsuarios >= MAX_USUARIOS)
            { 
                Console.WriteLine("No se permiten crear usuarios nuevos.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine($"\nIngreso de datos del usuario {cantidadUsuarios + 1}");

            Console.Write($"{nombresCampos[0]}: ");
            string cedula = Console.ReadLine();

            Console.Write($"{nombresCampos[1]}: ");
            string nombre = Console.ReadLine();

            Console.Write($"{nombresCampos[2]}: ");
            string apellido = Console.ReadLine();

            Console.Write($"{nombresCampos[3]}: ");
            string telefono = Console.ReadLine();

            Console.Write($"{nombresCampos[4]}: ");
            string direccion = Console.ReadLine();

            usuarios[cantidadUsuarios, 0] = cedula;
            usuarios[cantidadUsuarios, 1] = nombre;
            usuarios[cantidadUsuarios, 2] = apellido;
            usuarios[cantidadUsuarios, 3] = telefono;
            usuarios[cantidadUsuarios, 4] = direccion;

            cantidadUsuarios++;
            Console.WriteLine("Usuario creado con exito");
        }
        static void EditarUsuario()
        { 
            Console.Clear();
            Console.WriteLine("----EDITAR USUARIO----");
            Console.WriteLine("Ingrese cedula del usuario a buscar: ");
            String cc = Console.ReadLine();

            int indice = -1;
            for (int i = 0; i < cantidadUsuarios; i++)
            {
                if (usuarios[i, 0] == cc)
                {
                    indice = i;
                    break; 
                }

            }
            if (indice == -1)
            { 
                Console.WriteLine("Usuario no encontrado");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("\n--- Usuario encontrado ---"); 
            Console.WriteLine($"{nombresCampos[0]}: {usuarios[indice, 0]}"); 
            Console.WriteLine($"{nombresCampos[1]}: {usuarios[indice, 1]}"); 
            Console.WriteLine($"{nombresCampos[2]}: {usuarios[indice, 2]}"); 
            Console.WriteLine($"{nombresCampos[3]}: {usuarios[indice, 3]}"); 
            Console.WriteLine($"{nombresCampos[4]}: {usuarios[indice, 4]}"); 

            Console.WriteLine("Menu de edición");
            Console.WriteLine("\n¿Qué dato desea editar?");            
            Console.WriteLine("1. Nombre\n2. Apellido\n3. Teléfono\n4. Dirección");            
            Console.Write("Ingrese una opción: ");            
            int opcion = int.Parse(Console.ReadLine());            
            
            switch (opcion)            
            {                
                case 1:                    
                    Console.Write($"Ingrese el nuevo {nombresCampos[1]}: ");                    
                    usuarios[indice, 1] = Console.ReadLine();                    
                    Console.WriteLine("Nombre actualizado exitosamente.");                    
                    break;                
                case 2:                    
                    Console.Write($"Ingrese el nuevo {nombresCampos[2]}: ");                    
                    usuarios[indice, 2] = Console.ReadLine();                    
                    Console.WriteLine("Apellido actualizado exitosamente.");                    
                    break;                
                case 3:                    
                    Console.Write($"Ingrese el nuevo {nombresCampos[3]}: ");                    
                    usuarios[indice, 3] = Console.ReadLine();                    
                    Console.WriteLine("Teléfono actualizado exitosamente.");                    
                    break;                
                case 4:                    
                    Console.Write($"Ingrese la nueva {nombresCampos[4]}: ");                    
                    usuarios[indice, 4] = Console.ReadLine();                    
                    Console.WriteLine("Dirección actualizada exitosamente.");                    
                    break;              
                default:                    
                    Console.WriteLine("Opción no válida.");                    
                    break;            
            }            Console.ReadKey();        
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        static void GestionArticulos()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("---------GESTIÓN DE ARTÍCULOS---------");
                Console.WriteLine("1. Ver lista de artículos\n2. Nuevo artículo\n3. Editar información de artículo (buscar por ID)\n4. Salir de gestión de artículos");
                Console.WriteLine("-------------------------------------");
                Console.Write("Ingrese una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        VerListaArticulos();
                        break;
                    case 2:
                        NuevoArticulo();
                        break;
                    case 3:
                        EditarArticulo();
                        break;
                    case 4:
                        Console.WriteLine("\nRegresando al menú principal");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 4);

        }
        static void VerListaArticulos()
        {
            Console.Clear();
            Console.WriteLine("---LISTA DE ARTÍCULOS---");
            if (cantidadUsuarios == 0)
            {
                Console.WriteLine("No hay usuarios registrados");
            }
            else
            {
                for (int i = 0; i < cantidadUsuarios; i++)
                {
                    Console.WriteLine($"Usuario N° {i + 1}");
                    Console.WriteLine($"{nombresCampos[0]}: {usuarios[i, 0]}");
                    Console.WriteLine($"{nombresCampos[1]}: {usuarios[i, 1]}");
                    Console.WriteLine($"{nombresCampos[2]}: {usuarios[i, 2]}");
                    Console.WriteLine($"{nombresCampos[3]}: {usuarios[i, 3]}");
                    Console.WriteLine($"{nombresCampos[4]}: {usuarios[i, 4]}");
                }
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar");
            Console.ReadKey();


        }
        static void NuevoArticulo()
        { 
        
        
        
        }
        static void EditarArticulo()
        { 
        
        
        
        }

    }
}
