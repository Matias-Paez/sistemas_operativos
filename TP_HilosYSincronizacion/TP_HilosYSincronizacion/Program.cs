//Ejercicio 01- Estiamndo el valor de PI
using System;
using System.Threading;
using System.Diagnostics;

Decimal PI = 0; // variable global

//funcion para estimar el valor de Pi
void estimarPi(long inicio,long fin )
{
    Decimal estimacion = 0m; //acumulador
    Decimal delta = (1m / 1000000000m); //anchura del intervalo
    for (long i = inicio; i < fin; i++)
    {
        Decimal Xi =(i+0.5m)*delta; // calculo del x sub i 
        
        //sumatoria
        Decimal sumaparcial = (4m/(1m+(Xi*Xi)))*delta; //Calculado la potencia al cuadrado como una multiplicacion por el timo de dato empleado

        //acumulo los valores
        estimacion += sumaparcial;
    } 
    PI+= estimacion;
}


Console.WriteLine("---INICIANDO ESTIMACION DE PI---");


/*
1 hilo
Thread hilo1 = new Thread(() => estimarPi(0, 500000000));
hilo1.Start();
hilo1.Join();

2 hilos 
Thread hilo1 = new Thread(() => estimarPi(0, 500000000));
Thread hilo2 = new Thread(() => estimarPi(500000000, 1000000000));

hilo1.Start();
hilo2.Start();
hilo1.Join();
hilo2.Join();

4 hilos

Thread hilo1 = new Thread(() => estimarPi(0, 250000000));
Thread hilo2 = new Thread(() => estimarPi(250000000, 500000000));
Thread hilo3 = new Thread(() => estimarPi(500000000, 750000000));
Thread hilo4 = new Thread(() => estimarPi(750000000, 1000000000));

hilo1.Start();
hilo2.Start();
hilo3.Start();
hilo4.Start();

hilo1.Join();
hilo2.Join();
hilo3.Join();
hilo4.Join();

8 hilos

Thread hilo1 = new Thread(() => estimarPi(0, 125000000));
Thread hilo2 = new Thread(() => estimarPi(125000000, 250000000));
Thread hilo3 = new Thread(() => estimarPi(250000000, 375000000));
Thread hilo4 = new Thread(() => estimarPi(375000000, 500000000));
Thread hilo5 = new Thread(() => estimarPi(500000000, 625000000));
Thread hilo6 = new Thread(() => estimarPi(625000000, 750000000));
Thread hilo7 = new Thread(() => estimarPi(750000000, 875000000));
Thread hilo8 = new Thread(() => estimarPi(875000000, 1000000000));

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

16 hilos 

Thread hilo1 = new Thread(() => estimarPi(0, 62500000));
Thread hilo2 = new Thread(() => estimarPi(62500000, 125000000));
Thread hilo3 = new Thread(() => estimarPi(125000000, 187500000));
Thread hilo4 = new Thread(() => estimarPi(187500000, 250000000));
Thread hilo5 = new Thread(() => estimarPi(250000000, 312500000));
Thread hilo6 = new Thread(() => estimarPi(312500000, 375000000));
Thread hilo7 = new Thread(() => estimarPi(375000000, 437500000));
Thread hilo8 = new Thread(() => estimarPi(437500000, 500000000));
Thread hilo9 = new Thread(() => estimarPi(500000000, 562500000));
Thread hilo10 = new Thread(() => estimarPi(562500000, 625000000));
Thread hilo11 = new Thread(() => estimarPi(625000000, 687500000));
Thread hilo12 = new Thread(() => estimarPi(687500000, 750000000));
Thread hilo13 = new Thread(() => estimarPi(750000000, 812500000));
Thread hilo14 = new Thread(() => estimarPi(812500000, 875000000));
Thread hilo15 = new Thread(() => estimarPi(875000000, 937500000));
Thread hilo16 = new Thread(() => estimarPi(937500000, 1000000000));

hilo1.Start();
hilo2.Start();
hilo3.Start();
hilo4.Start();
hilo5.Start();
hilo6.Start();
hilo7.Start();
hilo8.Start();
hilo9.Start();
hilo10.Start();
hilo11.Start();
hilo12.Start();
hilo13.Start();
hilo14.Start();
hilo15.Start();
hilo16.Start();

hilo1.Join();
hilo2.Join();
hilo3.Join();
hilo4.Join();
hilo5.Join();
hilo6.Join();
hilo7.Join();
hilo8.Join();
hilo9.Join();
hilo10.Join();
hilo11.Join();
hilo12.Join();
hilo13.Join();
hilo14.Join();
hilo15.Join();
hilo16.Join();

32 hilos

Thread hilo1 = new Thread(() => estimarPi(0, 31250000));
Thread hilo2 = new Thread(() => estimarPi(31250000, 62500000));
Thread hilo3 = new Thread(() => estimarPi(62500000, 93750000));
Thread hilo4 = new Thread(() => estimarPi(93750000, 125000000));
Thread hilo5 = new Thread(() => estimarPi(125000000, 156250000));
Thread hilo6 = new Thread(() => estimarPi(156250000, 187500000));
Thread hilo7 = new Thread(() => estimarPi(187500000, 218750000));
Thread hilo8 = new Thread(() => estimarPi(218750000, 250000000));
Thread hilo9 = new Thread(() => estimarPi(250000000, 281250000));
Thread hilo10 = new Thread(() => estimarPi(281250000, 312500000));
Thread hilo11 = new Thread(() => estimarPi(312500000, 343750000));
Thread hilo12 = new Thread(() => estimarPi(343750000, 375000000));
Thread hilo13 = new Thread(() => estimarPi(375000000, 406250000));
Thread hilo14 = new Thread(() => estimarPi(406250000, 437500000));
Thread hilo15 = new Thread(() => estimarPi(437500000, 468750000));
Thread hilo16 = new Thread(() => estimarPi(468750000, 500000000));
Thread hilo17 = new Thread(() => estimarPi(500000000, 531250000));
Thread hilo18 = new Thread(() => estimarPi(531250000, 562500000));
Thread hilo19 = new Thread(() => estimarPi(562500000, 593750000));
Thread hilo20 = new Thread(() => estimarPi(593750000, 625000000));
Thread hilo21 = new Thread(() => estimarPi(625000000, 656250000));
Thread hilo22 = new Thread(() => estimarPi(656250000, 687500000));
Thread hilo23 = new Thread(() => estimarPi(687500000, 718750000));
Thread hilo24 = new Thread(() => estimarPi(718750000, 750000000));
Thread hilo25 = new Thread(() => estimarPi(750000000, 781250000));
Thread hilo26 = new Thread(() => estimarPi(781250000, 812500000));
Thread hilo27 = new Thread(() => estimarPi(812500000, 843750000));
Thread hilo28 = new Thread(() => estimarPi(843750000, 875000000));
Thread hilo29 = new Thread(() => estimarPi(875000000, 906250000));
Thread hilo30 = new Thread(() => estimarPi(906250000, 937500000));
Thread hilo31 = new Thread(() => estimarPi(937500000, 968750000));
Thread hilo32 = new Thread(() => estimarPi(968750000, 1000000000));

hilo1.Start();
hilo2.Start();
hilo3.Start();
hilo4.Start();
hilo5.Start();
hilo6.Start();
hilo7.Start();
hilo8.Start();
hilo9.Start();
hilo10.Start();
hilo11.Start();
hilo12.Start();
hilo13.Start();
hilo14.Start();
hilo15.Start();
hilo16.Start();
hilo17.Start();
hilo18.Start();
hilo19.Start();
hilo20.Start();
hilo21.Start();
hilo22.Start();
hilo23.Start();
hilo24.Start();
hilo25.Start();
hilo26.Start();
hilo27.Start();
hilo28.Start();
hilo29.Start();
hilo30.Start();
hilo31.Start();
hilo32.Start();

hilo1.Join();
hilo2.Join();
hilo3.Join();
hilo4.Join();
hilo5.Join();
hilo6.Join();
hilo7.Join();
hilo8.Join();
hilo9.Join();
hilo10.Join();
hilo11.Join();
hilo12.Join();
hilo13.Join();
hilo14.Join();
hilo15.Join();
hilo16.Join();
hilo17.Join();
hilo18.Join();
hilo19.Join();
hilo20.Join();
hilo21.Join();
hilo22.Join();
hilo23.Join();
hilo24.Join();
hilo25.Join();
hilo26.Join();
hilo27.Join();
hilo28.Join();
hilo29.Join();
hilo30.Join();
hilo31.Join();
hilo32.Join();

 */

Stopwatch reloj = Stopwatch.StartNew(); ///comienzo a tomar el tiempo


Thread hilo1 = new Thread(() => estimarPi(0, 15625000));
Thread hilo2 = new Thread(() => estimarPi(15625000, 31250000));
Thread hilo3 = new Thread(() => estimarPi(31250000, 46875000));
Thread hilo4 = new Thread(() => estimarPi(46875000, 62500000));
Thread hilo5 = new Thread(() => estimarPi(62500000, 78125000));
Thread hilo6 = new Thread(() => estimarPi(78125000, 93750000));
Thread hilo7 = new Thread(() => estimarPi(93750000, 109375000));
Thread hilo8 = new Thread(() => estimarPi(109375000, 125000000));
Thread hilo9 = new Thread(() => estimarPi(125000000, 140625000));
Thread hilo10 = new Thread(() => estimarPi(140625000, 156250000));
Thread hilo11 = new Thread(() => estimarPi(156250000, 171875000));
Thread hilo12 = new Thread(() => estimarPi(171875000, 187500000));
Thread hilo13 = new Thread(() => estimarPi(187500000, 203125000));
Thread hilo14 = new Thread(() => estimarPi(203125000, 218750000));
Thread hilo15 = new Thread(() => estimarPi(218750000, 234375000));
Thread hilo16 = new Thread(() => estimarPi(234375000, 250000000));
Thread hilo17 = new Thread(() => estimarPi(250000000, 265625000));
Thread hilo18 = new Thread(() => estimarPi(265625000, 281250000));
Thread hilo19 = new Thread(() => estimarPi(281250000, 296875000));
Thread hilo20 = new Thread(() => estimarPi(296875000, 312500000));
Thread hilo21 = new Thread(() => estimarPi(312500000, 328125000));
Thread hilo22 = new Thread(() => estimarPi(328125000, 343750000));
Thread hilo23 = new Thread(() => estimarPi(343750000, 359375000));
Thread hilo24 = new Thread(() => estimarPi(359375000, 375000000));
Thread hilo25 = new Thread(() => estimarPi(375000000, 390625000));
Thread hilo26 = new Thread(() => estimarPi(390625000, 406250000));
Thread hilo27 = new Thread(() => estimarPi(406250000, 421875000));
Thread hilo28 = new Thread(() => estimarPi(421875000, 437500000));
Thread hilo29 = new Thread(() => estimarPi(437500000, 453125000));
Thread hilo30 = new Thread(() => estimarPi(453125000, 468750000));
Thread hilo31 = new Thread(() => estimarPi(468750000, 484375000));
Thread hilo32 = new Thread(() => estimarPi(484375000, 500000000));
Thread hilo33 = new Thread(() => estimarPi(500000000, 515625000));
Thread hilo34 = new Thread(() => estimarPi(515625000, 531250000));
Thread hilo35 = new Thread(() => estimarPi(531250000, 546875000));
Thread hilo36 = new Thread(() => estimarPi(546875000, 562500000));
Thread hilo37 = new Thread(() => estimarPi(562500000, 578125000));
Thread hilo38 = new Thread(() => estimarPi(578125000, 593750000));
Thread hilo39 = new Thread(() => estimarPi(593750000, 609375000));
Thread hilo40 = new Thread(() => estimarPi(609375000, 625000000));
Thread hilo41 = new Thread(() => estimarPi(625000000, 640625000));
Thread hilo42 = new Thread(() => estimarPi(640625000, 656250000));
Thread hilo43 = new Thread(() => estimarPi(656250000, 671875000));
Thread hilo44 = new Thread(() => estimarPi(671875000, 687500000));
Thread hilo45 = new Thread(() => estimarPi(687500000, 703125000));
Thread hilo46 = new Thread(() => estimarPi(703125000, 718750000));
Thread hilo47 = new Thread(() => estimarPi(718750000, 734375000));
Thread hilo48 = new Thread(() => estimarPi(734375000, 750000000));
Thread hilo49 = new Thread(() => estimarPi(750000000, 765625000));
Thread hilo50 = new Thread(() => estimarPi(765625000, 781250000));
Thread hilo51 = new Thread(() => estimarPi(781250000, 796875000));
Thread hilo52 = new Thread(() => estimarPi(796875000, 812500000));
Thread hilo53 = new Thread(() => estimarPi(812500000, 828125000));
Thread hilo54 = new Thread(() => estimarPi(828125000, 843750000));
Thread hilo55 = new Thread(() => estimarPi(843750000, 859375000));
Thread hilo56 = new Thread(() => estimarPi(859375000, 875000000));
Thread hilo57 = new Thread(() => estimarPi(875000000, 890625000));
Thread hilo58 = new Thread(() => estimarPi(890625000, 906250000));
Thread hilo59 = new Thread(() => estimarPi(906250000, 921875000));
Thread hilo60 = new Thread(() => estimarPi(921875000, 937500000));
Thread hilo61 = new Thread(() => estimarPi(937500000, 953125000));
Thread hilo62 = new Thread(() => estimarPi(953125000, 968750000));
Thread hilo63 = new Thread(() => estimarPi(968750000, 984375000));
Thread hilo64 = new Thread(() => estimarPi(984375000, 1000000000));

// Iniciar los 64 hilos
hilo1.Start();
hilo2.Start();
hilo3.Start();
hilo4.Start();
hilo5.Start();
hilo6.Start();
hilo7.Start();
hilo8.Start();
hilo9.Start();
hilo10.Start();
hilo11.Start();
hilo12.Start();
hilo13.Start();
hilo14.Start();
hilo15.Start();
hilo16.Start();
hilo17.Start();
hilo18.Start();
hilo19.Start();
hilo20.Start();
hilo21.Start();
hilo22.Start();
hilo23.Start();
hilo24.Start();
hilo25.Start();
hilo26.Start();
hilo27.Start();
hilo28.Start();
hilo29.Start();
hilo30.Start();
hilo31.Start();
hilo32.Start();
hilo33.Start();
hilo34.Start();
hilo35.Start();
hilo36.Start();
hilo37.Start();
hilo38.Start();
hilo39.Start();
hilo40.Start();
hilo41.Start();
hilo42.Start();
hilo43.Start();
hilo44.Start();
hilo45.Start();
hilo46.Start();
hilo47.Start();
hilo48.Start();
hilo49.Start();
hilo50.Start();
hilo51.Start();
hilo52.Start();
hilo53.Start();
hilo54.Start();
hilo55.Start();
hilo56.Start();
hilo57.Start();
hilo58.Start();
hilo59.Start();
hilo60.Start();
hilo61.Start();
hilo62.Start();
hilo63.Start();
hilo64.Start();

// Esperar a que terminen todos los hilos
hilo1.Join();
hilo2.Join();
hilo3.Join();
hilo4.Join();
hilo5.Join();
hilo6.Join();
hilo7.Join();
hilo8.Join();
hilo9.Join();
hilo10.Join();
hilo11.Join();
hilo12.Join();
hilo13.Join();
hilo14.Join();
hilo15.Join();
hilo16.Join();
hilo17.Join();
hilo18.Join();
hilo19.Join();
hilo20.Join();
hilo21.Join();
hilo22.Join();
hilo23.Join();
hilo24.Join();
hilo25.Join();
hilo26.Join();
hilo27.Join();
hilo28.Join();
hilo29.Join();
hilo30.Join();
hilo31.Join();
hilo32.Join();
hilo33.Join();
hilo34.Join();
hilo35.Join();
hilo36.Join();
hilo37.Join();
hilo38.Join();
hilo39.Join();
hilo40.Join();
hilo41.Join();
hilo42.Join();
hilo43.Join();
hilo44.Join();
hilo45.Join();
hilo46.Join();
hilo47.Join();
hilo48.Join();
hilo49.Join();
hilo50.Join();
hilo51.Join();
hilo52.Join();
hilo53.Join();
hilo54.Join();
hilo55.Join();
hilo56.Join();
hilo57.Join();
hilo58.Join();
hilo59.Join();
hilo60.Join();
hilo61.Join();
hilo62.Join();
hilo63.Join();
hilo64.Join();

reloj.Stop();// dejo de tomar el tiempo


Console.WriteLine("El tiempo trancurrido en "+ (reloj.ElapsedMilliseconds/1000)); // mostramos en segundos
Console.WriteLine("La estimacion de PI es : " + PI.ToString());