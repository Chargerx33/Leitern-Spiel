using System;
using System.Collections.Generic;

namespace Leitern_Spiel
{
    internal class Program
    {
        


        static void Main(string[] args)
        {
            Move(3);
            Console.WriteLine();
            Move(4);
            Console.WriteLine();
            Move(5);
            Console.WriteLine();
            Move(6);
            Console.ReadLine();
        }
        static void Move(int moves)
        {
            
            int currentPosition = 0;
            int movedYet = 0;
            bool loopFound = false;
            List<int> fieldsBefore = new List<int>();
            List<int> fieldsBefore2 = new List<int>();
            bool finishlineReached = false;
            bool run = true;
            int oldPosition;

            while (run)
            {
                currentPosition += moves;
                movedYet += 1;

                if (fieldsBefore.Contains(currentPosition))
                {
                    if (fieldsBefore2.Contains(currentPosition)) {
                        if (!loopFound) //Wenn 1. wiederholon weiter laufen lassen. wenn 2. wiederholung auswerten
                            loopFound = true;
                        else if (loopFound)
                        {
                            whatsThePoint(fieldsBefore, finishlineReached, moves, movedYet);
                            run = false;
                        }
                    }
                    else
                    {
                        fieldsBefore2.Add(currentPosition);
                    }
                }
                fieldsBefore.Add(currentPosition);
                
                oldPosition = currentPosition;
                if (currentPosition > 100)
                {
                    currentPosition = (200 - currentPosition);
                
                }
                if (currentPosition != oldPosition)
                    fieldsBefore.Add(currentPosition);
                oldPosition = currentPosition;
                currentPosition = Lader(currentPosition);
                if (currentPosition != oldPosition)
                    fieldsBefore.Add(currentPosition);
                
                
                if (currentPosition == 100)
                {
                    finishlineReached = true;
                    whatsThePoint(fieldsBefore, finishlineReached, moves, movedYet);
                    run = false;
                }

            }
        }
        public static int Lader(int currentPosition)
        {
            
            switch (currentPosition)
            {
                case 6: currentPosition = 27; break;
                case 27: currentPosition = 6; break;
                case 14: currentPosition = 19; break;
                case 19: currentPosition = 14; break;
                case 21: currentPosition = 53; break;
                case 53: currentPosition = 21; break;
                case 31: currentPosition = 42; break;
                case 42: currentPosition = 31; break;
                case 33: currentPosition = 38; break;
                case 38: currentPosition = 33; break;
                case 46: currentPosition = 62; break;
                case 62: currentPosition = 46; break;
                case 51: currentPosition = 59; break;
                case 59: currentPosition = 51; break;
                case 57: currentPosition = 96; break;
                case 96: currentPosition = 57; break;
                case 65: currentPosition = 85; break;
                case 85: currentPosition = 65; break;
                case 68: currentPosition = 80; break;
                case 80: currentPosition = 68; break;
                case 70: currentPosition = 76; break;
                case 76: currentPosition = 70; break;
                case 92: currentPosition = 98; break;
                case 98: currentPosition = 92; break;
                
                    default: break;
            }
            
            return currentPosition;
        }
        public static void whatsThePoint(List<int> fields, bool finish, int moves, int movedYet)
        {
            Console.WriteLine($"Es wird jetzt immer die Zahl {moves} gewürfelt.");
            if (finish)
                Console.WriteLine($"Das Ziel kann erreicht werden.\nDas Ziel wird nach {movedYet} Zügen erreicht.");
                
            else
                Console.WriteLine("Die Züge enden in einer Endlosschleife.");

            Console.WriteLine("Es wurde folgender Pfad gleaufen:");
            Console.Write("[Start] ");
            int loopEnd = -1;
            int loopStart = -1;
            if (!finish) 
            {
                loopEnd = fields[fields.Count - 2];
                loopStart = fields[fields.Count - 1];
                fields.RemoveAt(fields.Count - 1); 
            }
            int forCount = 0;
            int[] LaderUp = { 6, 14, 21, 31, 33, 46, 51, 57, 65, 68, 70, 92 };
            int[] LaderDown = { 27, 19, 53, 42, 38, 62, 59, 96, 85, 80, 76, 98 };
            bool LaderLock = true;
            bool LaderLock2 = true;
            bool LoopLock = false;
            foreach (int field in fields)
            {
                forCount++;
                if (!finish)
                {
                    if (field == loopStart)
                        Console.Write("[Anfang der Endlosschleife]");

                }
                
                if (Array.IndexOf(LaderDown, field) != -1 && LaderLock && LaderLock2)
                {
                    Console.Write($"({field}) [Leiter abwärts] ");
                    LaderLock = false; 
                    LaderLock2 = false;
                }
                else if (Array.IndexOf(LaderUp, field) != -1 && LaderLock && LaderLock2)
                {
                    Console.Write($"({field}) [Leiter aufwärts] ");
                    LaderLock = false;
                    LaderLock2 = false;
                }
                else
                {
                    Console.Write($"{field} ");
                    if (LaderLock)
                        LaderLock2 = true;
                    LaderLock = true;
                    
                }
                if (field == 100)
                    Console.Write("[Ziel]");

                if (field == loopEnd)
                {
                    if (LoopLock)
                    {
                        Console.WriteLine("[Ende der Endlosschleife]");
                        break;
                    }
                    else
                    {
                        LoopLock = true;
                    }
                }
            }
        }
    }
}

