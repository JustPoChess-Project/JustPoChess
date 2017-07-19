using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustPoChess.Core.Engine;
using JustPoChess.Entities;
using JustPoChess.Entities.Pieces.Knight;

namespace JustPoChess
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();

            engine.Start();
        }
    }
}
