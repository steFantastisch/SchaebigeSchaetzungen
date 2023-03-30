using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchaebigeSchaetzungen.Model
{
    public interface IPointsCalculator
    {
        int[] CalculateMultiplayerPoints(int P1guess, int P2guess, int Views);
        string SingleplayerPts(int Playerguess, int Views);
    }
}
