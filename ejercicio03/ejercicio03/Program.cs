using System;
using System.Threading;
using System.Diagnostics;

int cantidadPrimos = 0; //ESTA ES NUESTRA VARIABLE GLOBAL
object locker = new object(); // la utilizamos para manejar el bloqueo

void calcularPrimos(int inicio, int fin)
{
    for (int i = inicio; i <= fin; i++)
    {

        int div_ent = 0;
        for (int j = 1; j <= i; j++)
        {
            if (i % j == 0)
            {//cuento la cantidad de veces que al dividir el numero i por j , da 0 
                div_ent++;
            }
            if (div_ent > 2)
            {
                break; // me detengo si encuentro 3 divisores de un numero y continuo con el siguiente
            }
        }
        if (div_ent == 2) 
        {// si es divisible por si mismo y por 1 sumo 1 a la variable compartida
            lock (locker)
            {
                cantidadPrimos++; //debo lograr la mutua exclusion aquii 
            }
        }
    }
}

Stopwatch reloj = Stopwatch.StartNew();

Thread hilo1 = new Thread(() => calcularPrimos(1, 125000));
Thread hilo2 = new Thread(() => calcularPrimos(125001, 250000));
Thread hilo3 = new Thread(() => calcularPrimos(250001, 375000));
Thread hilo4 = new Thread(() => calcularPrimos(375001, 500000));
Thread hilo5 = new Thread(() => calcularPrimos(500001, 625000));
Thread hilo6 = new Thread(() => calcularPrimos(625001, 750000));
Thread hilo7 = new Thread(() => calcularPrimos(750001, 875000));
Thread hilo8 = new Thread(() => calcularPrimos(875001, 1000000));

hilo1.Start();
hilo2.Start();
hilo3.Start();
hilo4.Start();
hilo5.Start();
hilo6.Start();
hilo7.Start();
hilo8.Start();

hilo1.Join();
hilo2.Join();
hilo3.Join();
hilo4.Join();
hilo5.Join();
hilo6.Join();
hilo7.Join();
hilo8.Join();

reloj.Stop();

Console.WriteLine($"LA CANTIDAD DE PRIMOS EN EL INTERVALO [1;1000000] ES : " + cantidadPrimos.ToString());
Console.WriteLine($"TIEMPO EN SEGUNDOS: " + (reloj.ElapsedMilliseconds / 1000));