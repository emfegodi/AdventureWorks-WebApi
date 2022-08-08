using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.Services;
using AdventureWorks.Data;

namespace AdventureWorks.Console
{
    internal class Program : IDisposable
    {
        static void Main(string[] args)
        {
            Currency currency = new Currency();            


            AdminCurency adm = new AdminCurency();
            
            List<Currency> list= adm.GetAll();

            currency.CurrencyCode = "COP";
            currency.Name = "Colombian Peso";
            adm.Update(currency);

            foreach (var item in list)
            {
               
              System.Console.WriteLine(item.Name);

            }
            System.Console.ReadLine();




        }

        void IDisposable.Dispose()
        {
            AdminCurency adm = null;
        }
    }
}
