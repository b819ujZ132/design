using System.Collections.Generic;
using System.Linq;

namespace design.extensions
{

  public static class Extensions
  {
    public static void Push<T>(this List<T> l, T t)
    {
      l.Add(t);
    }

    public static T Pop<T>(this List<T> l)
    {
      var t = l.Last();
      l.RemoveAt(l.Count - 1);
      return t;
    }
  }
}