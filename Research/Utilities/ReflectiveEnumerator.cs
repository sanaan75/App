using System.Reflection;
using Research.Abstractions;

namespace Entities.Utilities;

public static class ReflectiveEnumerator
{
    static ReflectiveEnumerator() { }

    public static IEnumerable<T> GetEnumerableOfType<T>() where T : IEntity
    {
        List<T> objects = new List<T>();
        foreach (Type type in Assembly.GetAssembly(typeof(T)).GetTypes()
                     .Where(myType => myType.IsClass &&  myType.IsSubclassOf(typeof(IEntity))))
        {
            objects.Add((T)Activator.CreateInstance(type));
        }
        objects.Sort();
        return objects;
    }
}