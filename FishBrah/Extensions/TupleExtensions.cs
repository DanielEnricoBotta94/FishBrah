using FishBrah.Models;

namespace FishBrah.Extensions;

public static class TupleExtensions
{
   private const int Min = ushort.MinValue;
   private const int Max = ushort.MaxValue;
   
   public static (int, int) MapToUShortTuple(this (int width, int height) tuple, Rectangle original)
   {
      return(
         (int)((double)tuple.width * Max / original.Width - 1),
         (int)((double)tuple.height * Max / original.Height - 1)
      );
   }
}