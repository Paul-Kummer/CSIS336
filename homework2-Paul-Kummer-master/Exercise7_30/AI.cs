using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AI
{
    public static int GuessNumber(int highRange=1000, int lowRange=1)
    {
        int newGuess, delta;
        delta = (highRange - lowRange) == 1? 2: (highRange - lowRange);
        newGuess = (delta / 2) + lowRange;

        return newGuess;
    }
}

