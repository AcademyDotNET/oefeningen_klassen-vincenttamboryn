using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class MapElementFactory
    {
        public static IMapObjects Build(string classname, Object[] constructorArguments)
        {
            var objectType = Type.GetType($"Game.{classname}");
            IMapObjects mapItem = (IMapObjects)Activator.CreateInstance(objectType, constructorArguments);
            return mapItem;
        }
    }
}
