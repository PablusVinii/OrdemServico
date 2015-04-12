using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRS.Apoio
{
    public class Meses
    {
        protected static Dictionary<int, string> meses = null;

        protected static void CarregarMeses()
        {
            meses = new Dictionary<int, string>();
            meses.Add(1, "Janeiro");
            meses.Add(2, "Fevereiro");
            meses.Add(3, "Março");
            meses.Add(4, "Abril");
            meses.Add(5, "Maio");
            meses.Add(6, "Junho");
            meses.Add(7, "Julho");
            meses.Add(8, "Agosto");
            meses.Add(9, "Setembro");
            meses.Add(10, "Outubro");
            meses.Add(11, "Novembro");
            meses.Add(12, "Dezembro");
        }

        public static Dictionary<int, string> PegarMeses()
        {
            if (meses == null)
            {
                CarregarMeses();    
            }

            return meses;
        }

        public static string PegarMes(int numMes)
        {
            if (meses == null)
            {
                CarregarMeses();
            }

            return meses[numMes];
        }
    }
}
