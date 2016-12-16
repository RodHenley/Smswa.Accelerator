using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace smswa.accelerator.service.contract.Infrastructure
{
    internal static class KnownTypesHelper
    {
        private static IEnumerable<Type> GetTypesInThisAssembly()
        {
            return typeof(KnownTypesHelper).GetTypeInfo().Assembly.GetTypes();
        }

        internal static IEnumerable<Type> AllServiceTypes()
        {
            return MessageTypes().Union(ExceptionTypes());
        }

        internal static IEnumerable<Type> MessageTypes()
        {
            var requestTypes = GetTypesInThisAssembly()
              .Where(t => typeof(IRequest).IsAssignableFrom(t))
              .ToList();

            var responseTypes = GetTypesInThisAssembly()
              .Where(t => typeof(IResponse).IsAssignableFrom(t))
              .ToList();

            return requestTypes
              .Union(responseTypes);
        }

        internal static IEnumerable<Type> ExceptionTypes()
        {
            var exceptionTypes = GetTypesInThisAssembly()
              .Where(t => typeof(Exception).IsAssignableFrom(t))
              .ToArray();

            return exceptionTypes;
        }
    }
}

