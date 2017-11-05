﻿using System;

namespace BookLogic.Predicates
{
    /// <summary>
    /// Interface of predicate that can be true or false
    /// </summary>
    public interface IPredicate<in T>
    {
        bool IsTrue(T book);
    }
}
