﻿// -----------------------------------------------------------------------
//  <copyright file="ListExtensions.cs" company="DangerDan9631">
//      Copyright (c) 2017 Dan Garvey. All rights reserved.
//      Licensed under the MIT License. 
//      See https://github.com/Dangerdan9631/DangrLib/blob/master/LICENSE for full license information.
//  </copyright>
//  <dateCreated>2017-04-24</dateCreated>
//  <dateModified>2017-06-20</dateModified>
//  <lastModifiedBy>Dan Garvey</lastModifiedBy>
// -----------------------------------------------------------------------

namespace Dangr.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Provides extended functionality to the List class.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Pushes a value on to the end of a list.
        /// </summary>
        /// <typeparam name="T">The type stored in the list.</typeparam>
        /// <param name="list">The list to push onto.</param>
        /// <param name="obj">The object to push onto the list.</param>
        public static void Push<T>(this List<T> list, T obj)
        {
            list.Add(obj);
        }

        /// <summary>
        /// Removes and returns the value at the end of the list.
        /// </summary>
        /// <typeparam name="T">The type stored in the list.</typeparam>
        /// <param name="list">The list to pop an object from.</param>
        /// <returns>The object popped from the list.</returns>
        public static T Pop<T>(this List<T> list)
        {
            if (list.IsEmpty())
            {
                throw new IndexOutOfRangeException("Cannot pop an empty List.");
            }

            T pop = list[list.Count - 1];
            list.Remove(pop);

            return pop;
        }

        /// <summary>
        /// Returns the value from the end of the <paramref name="list" /> without removing it.
        /// </summary>
        /// <typeparam name="T">The type stored in the list.</typeparam>
        /// <param name="list">The list to peek an object from.</param>
        /// <returns>The object peeked from the list.</returns>
        public static T Peek<T>(this List<T> list)
        {
            if (list.IsEmpty())
            {
                throw new IndexOutOfRangeException("Cannot peek an empty List.");
            }

            return list[list.Count - 1];
        }

        /// <summary>
        /// Enqueues a value into the end of a list.
        /// </summary>
        /// <typeparam name="T">The type stored in the list.</typeparam>
        /// <param name="list">The list to enqueue into.</param>
        /// <param name="obj">The object to enqueue into the list.</param>
        public static void Enqueue<T>(this List<T> list, T obj)
        {
            list.Add(obj);
        }

        /// <summary>
        /// Removes and returns the value at the beginning of the list.
        /// </summary>
        /// <typeparam name="T">The type stored in the list.</typeparam>
        /// <param name="list">The list to dequeue an object from.</param>
        /// <returns>The object dequeued from the list.</returns>
        public static T Dequeue<T>(this List<T> list)
        {
            if (list.IsEmpty())
            {
                throw new IndexOutOfRangeException("Cannot dequeue an empty List.");
            }

            T item = list[0];
            list.Remove(item);

            return item;
        }

        /// <summary>
        /// Gets whether the <paramref name="list" /> is empty.
        /// </summary>
        /// <param name="list">The list to check.</param>
        /// <returns>True if there are no elements left in the list.</returns>
        public static bool IsEmpty(this IList list)
        {
            return list.Count == 0;
        }
    }
}