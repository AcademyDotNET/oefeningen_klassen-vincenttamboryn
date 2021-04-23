﻿using System;

namespace BallGame
{
    class Program
    {
        static void Main(string[] args)
        {
            double time = 0;
            Console.CursorVisible = false;
            Console.WindowHeight = 30;
            Console.WindowWidth = 60;

            int howManyBalls = 5;

            Ball[] thisManyBalls = new Ball[howManyBalls];
            thisManyBalls[0] = new Ball(25, 25, 1, 1);
            thisManyBalls[1] = new Ball(20, 10, 1, 1);
            thisManyBalls[2] = new Ball(5, 20, 1, 2);
            thisManyBalls[3] = new Ball(10, 18, 2, 1);
            thisManyBalls[4] = new CirculatingBall(12, 3, 2, 2);
            PlayerBall player = new PlayerBall(10, 10, 0, 0);
            FollowingBall follower = new FollowingBall(8, 5, 1, 1);
            while (true)
            {
                int ballsleft = 0;
                //Ball
                foreach (var item in thisManyBalls)
                {
                    item.Update();
                    item.Draw();
                }
                follower.UpdateFollow(player.X,player.Y);
                follower.Draw();

                //SpelerBall
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    player.ChangeVelocity(key);
                }

                player.Update();
                player.Draw();
                //Check collisions
                foreach (var item in thisManyBalls)
                {
                    ballsleft += item.BallLeft();
                    if (Ball.CheckHit(item, player))
                    {
                        item.Clear();
                    }
                    foreach (var item2 in thisManyBalls)
                    {
                        if (!(item.Equals(item2)))
                        {
                            if (Ball.CheckHit(item, item2))
                            {
                                item.Bounce();
                                item2.Bounce();
                            }
                        }
                    }
                }
                if (Ball.CheckHit(follower, player))
                {
                    Console.Clear();
                    Console.WriteLine($"You lost! The purple enemy hit you after {time.ToString("F2")} seconds");
                    Console.ReadLine();
                }
                if (ballsleft == 0)
                {
                    Console.Clear();
                    Console.WriteLine($"You won! It only took you {time.ToString("F2")} seconds");
                    Console.ReadLine();
                }
                System.Threading.Thread.Sleep(100);
                time += 0.1;
                Console.SetCursorPosition(Console.WindowWidth-5, 0);
                Console.Write(time);
            }
        }
    }
}
