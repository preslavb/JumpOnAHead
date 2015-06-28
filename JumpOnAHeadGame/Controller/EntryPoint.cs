namespace JumpOnAHeadGame.Controller
{
    using System;
    public static class EntryPoint
    {
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
