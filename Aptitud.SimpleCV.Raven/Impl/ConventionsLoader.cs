using System;
using System.Linq;
using System.Reflection;
using Raven.Client.Document;

namespace Aptitud.SimpleCV.Raven.Impl
{
    public class ConventionsLoader
    {
        public static void Register(DocumentConvention convention, Assembly assembly)
        {
            try
            {
                var types = assembly.GetTypes();

                foreach (var conventionType in types)
                {
                    if (typeof (IConvention).IsAssignableFrom(conventionType) == false)
                        continue;

                    if(conventionType == typeof(IConvention))
                        continue;

                    var conventionInstance = Activator.CreateInstance(conventionType);

                    ((IConvention)conventionInstance).Register(convention);
                }
            }
            catch (TypeLoadException exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}