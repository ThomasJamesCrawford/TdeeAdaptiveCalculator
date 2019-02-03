using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TDEE;

namespace Tests
{
    public class WeightListTests
    {
        List<TodoItem> items;

        [SetUp]
        public void Setup()
        {
            items = new List<TodoItem>(
               new TodoItem[] {
                    new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                    new TodoItem(91, 4000, new DateTime(2019, 1, 2)),
                    new TodoItem(92, 4000, new DateTime(2019, 1, 3)),
                    new TodoItem(93, 4000, new DateTime(2019, 1, 4)),
                    new TodoItem(94, 4000, new DateTime(2019, 1, 5)),
                    new TodoItem(95, 4000, new DateTime(2019, 1, 6)),
                    new TodoItem(96, 4000, new DateTime(2019, 1, 7)),
                    // week
                    new TodoItem(97, 4000, new DateTime(2019, 1, 8)),
                    new TodoItem(98, 4000, new DateTime(2019, 1, 9)),
                    new TodoItem(99, 4000, new DateTime(2019, 1, 10)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 11)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 12)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 13)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 14)),
               });
       }

        [Test]
        public void BasicTest()
        {
            WeightList wl = new WeightList(items, new DateTime(2019, 1, 8));

            List<TodoItem> expected = new List<TodoItem>(
              new TodoItem[] {
                    new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                    new TodoItem(91, 4000, new DateTime(2019, 1, 2)),
                    new TodoItem(92, 4000, new DateTime(2019, 1, 3)),
                    new TodoItem(93, 4000, new DateTime(2019, 1, 4)),
                    new TodoItem(94, 4000, new DateTime(2019, 1, 5)),
                    new TodoItem(95, 4000, new DateTime(2019, 1, 6)),
                    new TodoItem(96, 4000, new DateTime(2019, 1, 7)),
              });

            wl.List.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void SevenDayAvgTest()
        {
            WeightList wl = new WeightList(items);

            Assert.AreEqual(93.42857142, wl.SevenDayAvg(), 0.01);

            List<TodoItem> item1 = new List<TodoItem>(
               new TodoItem[] {

                    new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                    new TodoItem(92, 4000, new DateTime(2019, 1, 3)),
                    new TodoItem(95, 4000, new DateTime(2019, 1, 6)),
                    new TodoItem(96, 4000, new DateTime(2019, 1, 7)),
                    // week
                    new TodoItem(97, 4000, new DateTime(2019, 1, 8)),
                    new TodoItem(99, 4000, new DateTime(2019, 1, 10)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 11)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 12)),

               });

            wl = new WeightList(item1);

            Assert.AreEqual(94.5, wl.SevenDayAvg(), 0.01);


        }
    }
}