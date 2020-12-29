using System;
using System.Collections.Generic;

namespace ExerciciRestaurant
{
    class Program
    {
        /*public class Menu
        {
            public string Nom { get; set; }
            public int Preu { get; set; }
            public int ID { get; set; }*/
        class RestauranteThrow
        {
            static void SiNo(int x)
            {
                if ((x != 0) & (x != 1))
                {
                    throw new System.ArgumentOutOfRangeException("Introduce 1:Si o 0:No");
                }
            }
            static void PlatExisteix(int x, int numplats)
            {
                if ((x <= -1) || (x >= numplats))
                {
                    throw new System.IndexOutOfRangeException("Introduce un plato entre el 1 y el ");
                    throw new System.ArgumentOutOfRangeException("Introduce un plato entre el 1 y el ");
                }
            }

            static void Main(string[] args)
            {
                //fase1
                //int B5 = 5, B10 = 10, B20 = 20, B50 = 50, B100 = 100, B200 = 200, B500 = 500;
                int Total = 0;
                Console.WriteLine("---EXERCICI RESTAURANT---");
                Console.WriteLine("");
                Console.WriteLine("Quants plats vols que tingui el teu menú");
                int num_plats = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("---EXERCICI RESTAURANT---");
                Console.WriteLine("");
                string[] Plats = new string[num_plats];
                int[] Preus = new int[num_plats];
                //fase2. Introduir Menu
                for (int i = 0; i < num_plats; i++)
                {
                    Console.WriteLine("Introdueix el nom del plat {0}:", i + 1);
                    Plats[i] = Console.ReadLine();
                    Console.WriteLine("Introdueix el preu del plat {0} ({1}):", i + 1, Plats[i]);
                    Preus[i] = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("---EXERCICI RESTAURANT---");
                    Console.WriteLine("");
                }
                Dictionary<string, int> openWith = new Dictionary<string, int>();
                for (int i = 0; i < num_plats; i++)
                {
                    openWith.Add(Plats[i], Preus[i]);
                }
                Console.Clear();
                Console.WriteLine("---EXERCICI RESTAURANT---");
                Console.WriteLine("");
                //fase 2. Mostrar Menu i demanar plat
                int demanar = 1;
                int pedido = 0;
                int quants_demanats = 0;

                List<int> ListaPedido = new List<int>();
                while (demanar == 1)
                {
                    demanar = 0;
                    for (int i = 0; i < num_plats; i++)
                    {
                        Console.WriteLine("Nº{0}: {1} {2}E", i + 1, Plats[i], Preus[i]);
                    }
                    Again2:
                    Console.WriteLine("");
                    Console.WriteLine("Introdueix el numero del plat que vols demanar:");
                    pedido = Convert.ToInt32(Console.ReadLine()) - 1;
                    //if (pedido < 0 | pedido >= num_plats) { Console.WriteLine("Producte no existeix"); goto Again; }
                    
                    try
                    {
                        PlatExisteix(pedido, num_plats);

                    }
                    catch (System.ArgumentOutOfRangeException ex)
                    {
                        System.Console.WriteLine(ex.Message, num_plats);
                        goto Again2;
                    }
                    catch (System.IndexOutOfRangeException ex)
                    {
                        System.Console.WriteLine(ex.Message, num_plats);
                        goto Again2;
                    }
                    //Console.WriteLine(pedido);
                    //Console.ReadLine();
                    ListaPedido.Add(Preus[pedido]);

                    Console.WriteLine("Vols demanar un altre plat? 1:Si 0:No");
                    try
                    {
                        SiNo(demanar);
                    }
                    catch (System.ArgumentOutOfRangeException ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                    
                    demanar = Convert.ToInt32(Console.ReadLine());
                    quants_demanats++;
                }
                //fase3
                for (int x = 0; x < quants_demanats; x++)
                {
                    Total = Total + ListaPedido[x];

                }
                Console.WriteLine("El total de la comanda es: {0}", Total);


            }
        }
    }
}
