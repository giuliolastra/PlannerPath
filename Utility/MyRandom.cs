﻿/*
 * Typical usage: int rand = MyRandom().Next(1,10);
 */
using System;

namespace PlannerPath.Utility
{
    class MyRandom
    {
        //returns a random int, from 0 to max
        public int Next(int max)
        {
            return Next(0, max);
        }

        //return a random int, from min to max
        public int Next(int min, int max)
        {
            int res = (int)(DateTime.Now.Millisecond % max);
            if (res < min)
                res += min;
            if (res > max)
                res = max;
            return res;
        }
    }
}
