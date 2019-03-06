using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleIoC
{
    public class DIContainer
    {
        private static readonly Dictionary<Type, object> RegisterContainer = new Dictionary<Type, object>();

        public static void Register<TInterface, TImplement>()
        {
            Set(typeof(TInterface), typeof(TImplement));
        }

        public static T Resolve<T>()
        {
            return (T)Get(typeof(T));
        }


        private static void Set(Type interfaceName, Type implementName)
        {
            if (!interfaceName.IsAssignableFrom(implementName))
            {
                throw new Exception("Wrong type");
            }

            // get contructor of the implement
            var contructor = implementName.GetConstructors()[0];
            object implementInstance = null;
            // create the instance of implement by contructor
            if (!contructor.GetParameters().Any())
            {
                // case contructor no parameter
                implementInstance = contructor.Invoke(null);
            }
            else
            {
                // case contructor have parameter
                var contructorParameters = contructor.GetParameters();
                var dependencies = new List<object>();
                foreach (var parameter in contructorParameters)
                {
                    var dependency = Get(parameter.ParameterType);
                    dependencies.Add(dependency);
                }

                implementInstance = contructor.Invoke(dependencies.ToArray());
            }

            RegisterContainer.Add(interfaceName, implementInstance);
        }


        private static object Get(Type interfaceName)
        {
            if (RegisterContainer.ContainsKey(interfaceName))
            {
                return RegisterContainer[interfaceName];
            }

            throw new Exception("not found");
        }
    }
}
