using System;
using System.Threading;
using System.Diagnostics;

int cantidadPrimos = 0;

void calcularPrimos(int inicio, int fin)
{
    for(int i= inicio; i<= fin; i++)
    {

        int div_ent = 0;
        for (int j = 1; j <= i ; j++)
        {
            if (i % j == 0)
            {//cuento la cantidad de veces que al dividir el numero i por j , da 0 
                div_ent++;
            }
            if(div_ent > 2)
            {
                break; // me detengo si encuentro 3 divisores de un numero y continuo con el siguiente
            }
        }
        if (div_ent == 2) { cantidadPrimos++; }// si es divisible por si mismo y por 1 sumo 1 a la variable compartida
    }
}

Stopwatch reloj = Stopwatch.StartNew();

Thread hilo1 = new Thread(()=> calcularPrimos(1,1000000));
hilo1.Start();
hilo1.Join();

reloj.Stop();

Console.WriteLine($"LA CANTIDAD DE PRIMOS EN EL INTERVALO [1;1000000] ES : " + cantidadPrimos.ToString());
Console.WriteLine($"TIEMPO EN SEGUNDOS: " + (reloj.ElapsedMilliseconds / 1000));

