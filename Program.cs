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
        const int MAX_ARTICULOS = 15;
        const int TOTAL_VALORES = 4;
        const int MAX_PRODUCTOS_FACTURA = 10;


        static string[] nombresCampos = { "Cedula", "Nombre", "Apellido", "Telefono", "Dirección" };
        static string[,] usuarios = new string[MAX_USUARIOS, TOTAL_CAMPOS];
        static int cantidadUsuarios = 0;

        static string[] nombresValores = {"ID_articulo", "Nombre", "ValorUnitario", "Stock" };
        static string[,] articulos = new string[MAX_ARTICULOS, TOTAL_VALORES];
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
                        GestionVentas();
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
            if (cantidadArticulos == 0)
            {
                Console.WriteLine("No hay artículos registrados");
            }
            else
            {
                for (int i = 0; i < cantidadArticulos; i++)
                {
                    Console.WriteLine($"Artículo N° {i + 1}");
                    Console.WriteLine($"{nombresValores[0]}: {articulos[i, 0]}");
                    Console.WriteLine($"{nombresValores[1]}: {articulos[i, 1]}");
                    Console.WriteLine($"{nombresValores[2]}: {articulos[i, 2]}");
                    Console.WriteLine($"{nombresValores[3]}: {articulos[i, 3]}");
                    
                }
            }
            Console.WriteLine("\nPresione cualquier tecla para continuar");
            Console.ReadKey();


        }
        static void NuevoArticulo()
        {
            Console.Clear();
            Console.WriteLine("----NUEVO ARTÍCULO----");

            if (cantidadArticulos >= MAX_ARTICULOS)
            {
                Console.WriteLine("No se permiten crear artículos nuevos.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Ingreso de datos del articulo {cantidadArticulos + 1}");

            string idArticulo = (cantidadArticulos + 1000 ).ToString();
            Console.WriteLine($"{nombresValores[0]}: {idArticulo} (generado automáticamente)");

            Console.Write($"{nombresValores[1]}: ");
            string nombre = Console.ReadLine();

            Console.Write($"{nombresValores[2]}: ");
            string valorUnitario = Console.ReadLine();

            Console.Write($"{nombresValores[3]}: ");
            string cantidadStock = Console.ReadLine();


            articulos[cantidadArticulos, 0] = idArticulo;
            articulos[cantidadArticulos, 1] = nombre;
            articulos[cantidadArticulos, 2] = valorUnitario;
            articulos[cantidadArticulos, 3] = cantidadStock;

            cantidadArticulos++;
            Console.WriteLine("\nArtículo creado con éxito");
            Console.ReadKey();
        }
        static void EditarArticulo()
        {
            Console.Clear();
            Console.WriteLine("----EDITAR ARTÍCULO----");
            Console.WriteLine("Ingrese ID del artículo a buscar: ");
            String id = Console.ReadLine();

            int indice = -1;
            for (int i = 0; i < cantidadArticulos; i++)
            {
                if (articulos[i, 0] == id)
                {
                    indice = i;
                    break;
                }

            }
            if (indice == -1)
            {
                Console.WriteLine("Articulo no encontrado");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("\n--- Artículo encontrado ---");
            Console.WriteLine($"{nombresValores[0]}: {articulos[indice, 0]}");
            Console.WriteLine($"{nombresValores[1]}: {articulos[indice, 1]}");
            Console.WriteLine($"{nombresValores[2]}: {articulos[indice, 2]}");
            Console.WriteLine($"{nombresValores[3]}: {articulos[indice, 3]}");

            Console.WriteLine("Menu de edición");
            Console.WriteLine("\n¿Qué dato desea editar?");
            Console.WriteLine("1. Nombre\n2. Valor unitario\n3. Stock");
            Console.Write("Ingrese una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write($"Ingrese el nuevo {nombresValores[1]}: ");
                    articulos[indice, 1] = Console.ReadLine();
                    Console.WriteLine("Nombre actualizado exitosamente.");
                    break;
                case 2:
                    Console.Write($"Ingrese el nuevo {nombresValores[2]}: ");
                    articulos[indice, 2] = Console.ReadLine();
                    Console.WriteLine("Precio actualizado exitosamente.");
                    break;
                case 3:
                    Console.Write($"Ingrese el nuevo {nombresValores[3]}: ");
                    articulos[indice, 3] = Console.ReadLine();
                    Console.WriteLine("Stock actualizado exitosamente.");
                    break;
                
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            Console.ReadKey();

        }
        static void GestionVentas()
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("---------MENÚ GESTIÓN DE VENTAS---------");
                Console.WriteLine("1. Generar factura");
                Console.WriteLine("2. Salir de Gestión de ventas");
                Console.WriteLine("----------------------------------------");
                Console.Write("Ingrese una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        GenerarFactura();
                        break;
                    case 2:
                        Console.WriteLine("\nRegresando al menú principal...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 2);
        }
        static void GenerarFactura()
        {
            Console.Clear();
            Console.WriteLine("---------GENERAR FACTURA---------");


            if (cantidadUsuarios == 0)
            {
                Console.WriteLine("No hay usuarios registrados. Debe crear al menos un usuario.");
                Console.ReadKey();
                return;
            }

            if (cantidadArticulos == 0)
            {
                Console.WriteLine("No hay artículos registrados. Debe crear al menos un artículo.");
                Console.ReadKey();
                return;
            }


            Console.Write("\nIngrese la cédula del comprador: ");
            string cedulaComprador = Console.ReadLine();


            int indiceUsuario = -1;
            for (int i = 0; i < cantidadUsuarios; i++)
            {
                if (usuarios[i, 0] == cedulaComprador)
                {
                    indiceUsuario = i;
                    break;
                }
            }


            if (indiceUsuario == -1)
            {
                Console.WriteLine("Usuario no encontrado.");
                Console.ReadKey();
                return;
            }


            Console.WriteLine($"\nComprador: {usuarios[indiceUsuario, 1]} {usuarios[indiceUsuario, 2]}");


            string[,] productosFactura = new string[MAX_PRODUCTOS_FACTURA, 5];
            int cantidadProductosFactura = 0;
            string continuar = "s";

            while (continuar.ToLower() == "s" && cantidadProductosFactura < MAX_PRODUCTOS_FACTURA)
            {
                Console.WriteLine("\n--- Lista de artículos disponibles ---");


                for (int i = 0; i < cantidadArticulos; i++)
                {
                    Console.WriteLine($"{articulos[i, 0]} - {articulos[i, 1]} (Precio: ${articulos[i, 2]}, Stock: {articulos[i, 3]})");
                }

                Console.Write("\nIngrese el ID del producto a comprar: ");
                string idProducto = Console.ReadLine();


                int indiceProducto = -1;
                for (int i = 0; i < cantidadArticulos; i++)
                {
                    if (articulos[i, 0] == idProducto)
                    {
                        indiceProducto = i;
                        break;
                    }
                }

                if (indiceProducto == -1)
                {
                    Console.WriteLine("Producto no encontrado.");
                    Console.ReadKey();
                    continue;
                }


                Console.Write($"Ingrese la cantidad a comprar (Stock disponible: {articulos[indiceProducto, 3]}): ");
                int cantidad = int.Parse(Console.ReadLine());
                int stockDisponible = int.Parse(articulos[indiceProducto, 3]);


                if (cantidad > stockDisponible)
                {
                    Console.WriteLine("No hay stock suficiente.");
                    Console.ReadKey();
                    continue;
                }


                double precio = double.Parse(articulos[indiceProducto, 2]);
                double subtotal = precio * cantidad;


                productosFactura[cantidadProductosFactura, 0] = articulos[indiceProducto, 0]; // ID
                productosFactura[cantidadProductosFactura, 1] = articulos[indiceProducto, 1]; // Nombre
                productosFactura[cantidadProductosFactura, 2] = articulos[indiceProducto, 2]; // Precio
                productosFactura[cantidadProductosFactura, 3] = cantidad.ToString();           // Cantidad
                productosFactura[cantidadProductosFactura, 4] = subtotal.ToString();           // Subtotal


                articulos[indiceProducto, 3] = (stockDisponible - cantidad).ToString();

                cantidadProductosFactura++;

                Console.WriteLine("\n¡Producto agregado a la factura!");


                if (cantidadProductosFactura < MAX_PRODUCTOS_FACTURA)
                {
                    Console.Write("\n¿Desea agregar otro producto? (s/n): ");
                    continuar = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("\nSe alcanzó el límite de 10 productos por factura.");
                    Console.ReadKey();
                }
            }


            Console.Clear();
            Console.WriteLine("=============== FACTURA ===============");


            Console.WriteLine($"\nCliente: {usuarios[indiceUsuario, 1]} {usuarios[indiceUsuario, 2]}");
            Console.WriteLine($"Cédula: {usuarios[indiceUsuario, 0]}");

            Console.WriteLine("\n--- Productos ---");

            double total = 0;


            for (int i = 0; i < cantidadProductosFactura; i++)
            {
                Console.WriteLine($"\nID: {productosFactura[i, 0]}");
                Console.WriteLine($"Producto: {productosFactura[i, 1]}");
                Console.WriteLine($"Precio unitario: ${productosFactura[i, 2]}");
                Console.WriteLine($"Cantidad: {productosFactura[i, 3]}");
                Console.WriteLine($"Subtotal: ${productosFactura[i, 4]}");


                total += double.Parse(productosFactura[i, 4]);
            }


            Console.WriteLine("\n=======================================");
            Console.WriteLine($"TOTAL A PAGAR: ${total}");
            Console.WriteLine("=======================================");

            Console.WriteLine("\n¡Factura generada exitosamente!");
            Console.ReadKey();
        }
    }
}
