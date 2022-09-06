namespace dk.itu.game.msc.cgol.GameEvents
{
    public static class ListDeconstructor
    {
        public static void Deconstruct<T>(this T[] items, out T var1, out T var2)
        {
            var1 = items[0];
            var2 = items[1];
        }
    }
}
