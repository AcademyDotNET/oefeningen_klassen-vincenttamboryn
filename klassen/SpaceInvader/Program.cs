using System;
using System.Collections.Generic;
namespace SpaceInvader
{
    class Program
    {//niet af
        static void Main(string[] args)
        {
            List<Block> allBlocks = new List<Block>();
            Console.CursorVisible = false;
            Console.WindowHeight = 20;
            Console.WindowWidth = 30;
            allBlocks.Add( new Block(5, 5));

            Playership player = new Playership(10, 10,3);
            while (true)
            {
                //Blocks
                foreach (var item in allBlocks)
                {
                    item.Draw();
                }

                //Spelership
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    player.Update(key);
                }

                player.Draw();

                //Check collisions++++ list all bullets, foreach
                foreach (Bullet bullets in player.bulletfired)
                {
                    bullets.Draw();
                    foreach (var blocks in allBlocks)
                    {
                        if (blocks.CheckHit(blocks, bullets))
                        {
                            blocks.Delete();
                        }
                    }
                    bullets.update();

                }
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}
