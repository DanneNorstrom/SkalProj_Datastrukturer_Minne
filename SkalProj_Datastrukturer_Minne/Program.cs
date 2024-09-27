using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        //Fråga 1: Svar: Stacken, som namnet föreslår, kan ses som en mängd boxar staplade på varandra. Där vi 
        //använder innehållet i den översta boxen och för att komma åt den undre måste den
        //ovanstående boxen först lyftas av.För att exemplifiera detta ytterligare kan stacken ses
        //som skolådor i en skobutik, där du för att komma åt de nedre lådorna måste flytta bort de övre.
        //Heapen är en form av struktur där alltär tillgängligt på en gång med enkel åtkomst.För att även verklighetsförankra denna
        //datastruktur går det att likna heapen med en hög med ren tvätt som ligger utspridd över
        //en säng: allt går att nå fort och enkelt bara vi vet vad vi vill ha.
        //Stacken har koll på vilka anrop och metoder som körs, när metoden är körd kastas den från
        //stacken och nästa körs.Stacken är alltså självunderhållande och behöver ingen hjälp med
        //minnet. Heapen däremot som håller stor del av informationen (men inte har någon koll på
        //exekveringsordning) behöver oroa sig för Garbage Collection.Alltså: skokartongerna
        //sköter sig själv medan tvätthögen måste rensas på smutsig tvätt ibland.

        //Fråga 2: Svar: Value Types är typer från System.ValueType som tex: 
        //bool, byte, char, decimal, double
        //Reference Types är typer som ärver från System.Object(eller är System.Object.object) som tex:
        //class, interface, object, delegate, string
        //En reference type lagras alltid på heapen.Medan Value types, lagras där de deklareras.
        //Alltså kan value types lagras både på stacken eller heapen.
        //Den huvudsakliga skillnaden mellan dessa två är att stacken rensar sig själv medans
        //data på heapen rensas bort a GC the garbage collector när den inte används mer.

        //Fråga 3 svar : Den andra metoden returnerar 4 pga att y = x gör så att även y objektet refererar till x objektet


        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        //CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //Svar 2: Listans kapacitet ökar när det femte namnet har lags till
            //3: Listans kapacitet ökar med 4
            //4: pga dom som skrivit koden för list har bestämt att kapaciteten skall öka med 4 varje gång fyra element har lagts till
            //5: nej
           

            List<string> theList = new List<string>();
            bool exit = false;

            do
            {
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Console.WriteLine(theList.Count);
                        Console.WriteLine(theList.Capacity);
                    break;

                    case '-':
                        theList.Remove(value);
                        Console.WriteLine(theList.Count);
                        Console.WriteLine(theList.Capacity);
                    break;

                    case '0':
                        exit = true;
                    break;

                    default:
                        Console.WriteLine("use only + or -");
                    break;
                }
            } while (!exit);
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */


            Queue<string> theQueue = new Queue<string>();  
            bool exit = false;

            do
            {
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case 'e':
                        theQueue.Enqueue(value);

                        foreach (var e in theQueue)
                        {
                            Console.WriteLine(e);
                        }

                    break;

                    case 'd':
                        theQueue.Dequeue();

                        foreach (var e in theQueue)
                        {
                            Console.WriteLine(e);
                        }
                    break;

                    case '0':
                        exit = true;
                    break;

                    default:
                        Console.WriteLine("use only e or d");
                    break;
                }
            } while (!exit);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            //Varför är det inte så smart att använda en stack i det här fallet?
            //Pga att i icakön vill vi ha ut det första elementet först och inte det sista som i en stack

            Stack<char> theStack = new Stack<char>();
            bool exit = false;

            do
            {
                string s = Console.ReadLine();

                switch (s[0])
                {
                    case '+':
                        string s2 = Console.ReadLine();
                        theStack.Push(s2[0]);
                        foreach (var e in theStack)
                        {
                            Console.WriteLine(e);
                        }

                    break;

                    case '-':
                        theStack.Pop();
                        foreach (var e in theStack)
                        {
                            Console.WriteLine(e);
                        }
                    break;

                    case 'r':
                        Console.WriteLine("Enter string to reverse");
                        string s3 = Console.ReadLine();
                        Reversetext(s3);
                    break;

                    case '0':
                        exit = true;
                    break;

                    default:
                        Console.WriteLine("use only + or - 0 or r");
                    break;
                }
            } while (!exit);
        }

        static void Reversetext(string s)
        {
            Stack<char> theStack = new Stack<char>();

            foreach (char c in s)
            {
                theStack.Push(c);
            }

            for (int cnt = 0; cnt < theStack.Count; cnt++)
            {


                Console.Write(theStack.Pop());
            }
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

