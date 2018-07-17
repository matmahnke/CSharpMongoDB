using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NancyConsole.Models.Utils
{
    public static class Mapper<T, W>
    {
        public static T Map(W w)
        {
            T t = Activator.CreateInstance<T>();
            PropertyInfo[] propriedades = typeof(W).GetProperties();
            foreach (var item in propriedades)
            {
                try
                {
                    object data = item.GetValue(w);
                    typeof(T).GetProperty(item.Name).SetValue(t, data);
                }
                catch
                {
                    //Apenas captura a exceção
                }
            }
            return t;
        }

    }
}
