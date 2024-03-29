﻿using MediatorDesignPattern.Abstract;
using MediatorDesignPattern.Concrete;

namespace MediatorDesignPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Mediator cm = new();

            User user1 = new("John");
            User user2 = new("Sam");

            cm.SignIn(user1);
            cm.SignIn(user2);

            user1.SendMessage(user2.Name, "Hi");
            user2.SendMessage(user1.Name, "Hello");
        }
    }
}
