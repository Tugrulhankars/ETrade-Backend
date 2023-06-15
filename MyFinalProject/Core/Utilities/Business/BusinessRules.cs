using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {

        //params değişke sayıda parametre alabileceğini belirtir
        //logics kurallar kurala uymayan varsa uymayan kuralı döndür
        public static IResult Run(params IResult[] logics)
        {

            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
