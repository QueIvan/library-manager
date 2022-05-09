using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LibraryConsoleManager
{
    internal class ReadObjects
    { 
        /// <summary>
        /// Ogólna logika która po przyjęciu Typu na którego podstawie stworzy auto-formularz, zwraca stworzony obiekt wybranego typu
        /// </summary>
        /// <returns>
        /// Obiekt typu podanego w parametrze Target
        /// </returns>
        private static Object ObjectReadLogic(Type Target)
        {
            ParameterInfo[] Parameters = null;
            List<Object> Arguments = new List<Object>();

            /* Picking right constructor to use */

            if (Target.GetConstructors().Length > 1)
            {
                ConstructorInfo[] constructors = Target.GetConstructors();
                foreach (ConstructorInfo ci in constructors)
                {
                    if (ci.GetCustomAttributes().Count() > 0)
                    {
                        foreach (Object at in ci.GetCustomAttributes())
                            if (at as DefaultConstructorAttribute != null) Parameters = ci.GetParameters();
                        if (Parameters != null) break;
                    }
                }
            }
            if (Parameters == null) Parameters = Target.GetConstructors()[0].GetParameters();

            Console.WriteLine("\nPodaj wymagane pola, aby stworzyć obiekt");

            if (Parameters != null)
            {
                foreach (ParameterInfo pi in Parameters)
                {
                    Type ParamType = pi.ParameterType;
                    string ParamName = "";
                    if (pi.GetCustomAttributes().Count() > 0)
                    {
                        foreach (Object at in pi.GetCustomAttributes())
                        {
                            if (at as DisplayNameAttribute != null)
                            {
                                DisplayNameAttribute dn = (DisplayNameAttribute)at;
                                ParamName = dn.GetDisplayName();
                            }
                        }
                    }
                    else
                    {
                        ParamName = pi.Name;
                    }
                    Console.Write($"   Podaj {ParamName}:  ");
                    Arguments.Add(Convert.ChangeType(Console.ReadLine(), ParamType));
                }
            }
            return Activator.CreateInstance(Target, Arguments.ToArray());
        }

        /// <summary>
        /// Metoda do stworzenia auto-formularza używając parametru ogólnego
        /// </summary>
        /// <returns>
        /// Obiekt typu podanego w T
        /// </returns>
        public static T Read<T>()
        {
            Type Target = typeof(T);
            return (T)ObjectReadLogic(Target);
        }

        /// <summary>
        /// Metoda do stworzenia auto-formularza używając parametru ObjectType
        /// </summary>
        /// <returns>
        /// Obiekt typu podanego w ObjectType
        /// </returns>
        public static Object Read(Type ObjectType)
        {
            return ObjectReadLogic(ObjectType);
        }

    }

}
