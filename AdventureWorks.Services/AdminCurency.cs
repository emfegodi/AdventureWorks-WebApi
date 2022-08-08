using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using AdventureWorks.Data;

namespace AdventureWorks.Services
{
    public class AdminCurency
    {
        Currency cur = new Currency();
        AdventureWorksModel2 db = new AdventureWorksModel2();
        public void AdminCurrency()
        {
            cur.Name = "COP";
            cur.CurrencyCode = "001";

        }
        public List<Currency> GetAll() 
        {
        List<Currency> list = new List<Currency>();
            return  db.Currencies.ToList();        
        }
        public Currency Add(Currency currency)
        {
            try
            {
               var _currency= db.Currencies.Add(cur);
                db.SaveChanges();
                return _currency;
            }
            catch (Exception e )
            {
                Console.WriteLine("{0} Ocurrió un error al guardar. ", e);
                return null;
            }

        }
        public bool Delete (Currency currency) 
        {
            Currency _currency = null;
            try
            {
                if (CheckIfExistsCurrency(currency.CurrencyCode))
                {
                    db.Entry<Currency>(_currency).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Ocurrió un error al Eliminar. ", e);
                return false;
               
            }
        }
        public bool Update(Currency currency)
        {
            Currency _currency = null;
            try
            {
                if (CheckIfExists2(currency.CurrencyCode))
                {
                    _currency.CurrencyRates = currency.CurrencyRates;
                    _currency.CurrencyRates1 = currency.CurrencyRates1;                    

                    db.Entry<Currency>(_currency).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                Console.WriteLine("{0} Ocurrió un error al Actualizar. ", e);
                return false;
            }
        }
        public bool CheckIfExistsCurrency(string code)
        {
            bool result = false;
            try
            {
                var exists = db.Currencies
                    .Where(c => c.CurrencyCode == code)
                    .FirstOrDefault();
                if (exists != null)
                {
                    return true;
                }

                return result;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool CheckIfExists2(string code)
        {
           
            try
            {
                var count = db.Currencies.Where(c => c.CurrencyCode == code).Count();
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}
