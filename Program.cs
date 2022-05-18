// See https://aka.ms/new-console-template for more information

// Per verificare la velocità di una parte del codice
/*
double microseconds = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("microseconds: {0}", microseconds);
*/

//var start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
//codice
//codice
//codice
//var end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
//end-start => numero di microsecondi impiegati per eseguire il codice

/* Assegnazione
 - Costruire una lista (li) di 1000 numeri casuali compresi tra 0 e 999 incluso
 - Costruire un SortedSet (ssi) contenente i numeri già presenti in lista
 - Costruire un vettore di booleani (vb), lungo 1000, che per ogni intero n 
    presente in lista vale vb[n]=true

 - calcolare quanto tempo impiegate per eseguire il seguente codice
     - per 10000 volte
        - genera n, numero casuale tra 0 e 999
        - verifica se n è presente nel vettore vb (quindi if vb[n] == true). Non dovete stampare nulla

 - calcolare quanto tempo impiegate per eseguire il seguente codice
     - per 10000 volte
        - genera n, numero casuale tra 0 e 999
        - verifica se n è presente nella lista li (quindi li.find...). Non dovete stampare nulla

 - calcolare quanto tempo impiegate per eseguire il seguente codice
     - per 10000 volte
        - genera n, numero casuale tra 0 e 999
        - verifica se n è presente nell'insieme ordinato ssi (quindi ssi.find...). Non dovete stampare nulla

Infine, stampare i tre tempi in secondi

Opzionale: stampare il numero di ricerche/secondo.
stampare i tempi di costruzione dei singoli elementi(vettore, lista, sortedset)
(cioè quanto tempo impiegate a inserire i dati nella struttura dati)

 * */


Random randomNum = new Random();

List<int> li_base = new List<int>();
var start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
for (int n = 0; n < 1000; n++)
{
    li_base.Add(randomNum.Next(0, 1000));
}
var end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);

start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
List<int> li = new List<int>();
foreach (int n in li_base)
{
    li.Add(n);
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di insert in una lista(in ms): {0}", end - start);


int trovati = 0;
int nonTrovati = 0;
start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
for (int i = 0; i < 10000; ++i)
{
    foreach (int n in li_base)
    {
        if (li.Contains(n))
            trovati++;
        else
            nonTrovati++;
    }
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di 10000 ricerche di 1000 elementi in una lista(in ms): {0}", end - start);
Console.WriteLine("Elementi trovati: {0}", trovati);

Console.WriteLine("--------------------");

start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
SortedSet<int> ssi = new SortedSet<int>();
foreach (int n in li_base)
{
    ssi.Add(n);
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di insert in un ss: {0}", end - start);

trovati = 0;
nonTrovati = 0;
start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
for (int i = 0; i < 10000; ++i)
{
    foreach (int n in li_base)
    {
        if (ssi.Contains(n))
            trovati++;
        else
            nonTrovati++;
    }
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di 10000 ricerche di 1000 elementi in un Sorted set(in ms): {0}", end - start);
Console.WriteLine("Elementi trovati: {0}", trovati);

Console.WriteLine("--------------------");

start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
bool[] vb = new bool[1000];

foreach (int n in li_base)
{
    vb[n] = true;
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di insert in un vettore(in ms): {0}", end - start);

trovati = 0;
nonTrovati = 0;
start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
for (int i = 0; i < 10000; ++i)
{
    foreach (int n in li_base)
    {
        if (vb[n])
            trovati++;
        else
            nonTrovati++;
    }
}
end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("Tempo di 10000 ricerche di 1000 elementi in un vettore booleno: {0}", end - start);
Console.WriteLine("Trovati: {0}", trovati);