using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class CoordinateFactory
    {
        public static ICoordinates Build(string classname, Object[] constructorArguments)
        {
            var objectType = Type.GetType($"Game.{classname}");
            ICoordinates coordinate = (ICoordinates)Activator.CreateInstance(objectType, constructorArguments);
            return coordinate;
        }
    }
}
