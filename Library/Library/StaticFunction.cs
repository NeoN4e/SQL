using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Library
{
    public class StaticFunction
    {
         
        /// <summary>
        /// Строковое Представление Объектов БД (ToString)
        /// </summary>
        /// <param name="valueItem">Объект БД Либрару</param>
        /// <returns></returns>
        static public string GetStringValue(object valueItem)
        { 
  
            try
            {
                //object valueItem = property.GetValue(obj);

                if (valueItem is Authors)
                {
                    string FName = valueItem.GetType().GetProperty("FirstName").GetValue(valueItem).ToString();
                    string LName = valueItem.GetType().GetProperty("LastName").GetValue(valueItem).ToString();
                        
                    return String.Format("{0} {1}", FName, LName);
                }
                else
                    return valueItem.GetType().GetProperty("Name").GetValue(valueItem).ToString();
            }
            catch (NullReferenceException)
            { 
                //Если нет Name
                return valueItem.ToString();
            }
           
        }

    }
}
