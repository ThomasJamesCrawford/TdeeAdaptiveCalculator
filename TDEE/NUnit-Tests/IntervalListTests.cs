using NUnit.Framework;
using System;
using System.Collections.Generic;
using TDEE;
using FluentAssertions;


namespace Tests
{
    public class IntervalListTests

    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldWorkWithRegularWeeks()
        {
            List<TodoItem> items = new List<TodoItem>(
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
                    // week
                    new TodoItem(90, 4000, new DateTime(2019, 1, 15)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 16)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 17)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 18)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 19)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 20)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 21)),
                });

            IntervalList IL = new IntervalList(7, items);

            LinkedList<IntervalGroupModel> intervals = new LinkedList<IntervalGroupModel>(
                new IntervalGroupModel[] {
                    new IntervalGroupModel()
                    {
                        Items = new List<TodoItem>(
                            new TodoItem[] {
                                new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                                new TodoItem(91, 4000, new DateTime(2019, 1, 2)),
                                new TodoItem(92, 4000, new DateTime(2019, 1, 3)),
                                new TodoItem(93, 4000, new DateTime(2019, 1, 4)),
                                new TodoItem(94, 4000, new DateTime(2019, 1, 5)),
                                new TodoItem(95, 4000, new DateTime(2019, 1, 6)),
                                new TodoItem(96, 4000, new DateTime(2019, 1, 7)),
                            }),

                        Start = new DateTime(2019, 1, 1)
                    },

                    new IntervalGroupModel()
                    {
                        Items = new List<TodoItem>(
                            new TodoItem[] {
                                new TodoItem(97, 4000, new DateTime(2019, 1, 8)),
                                new TodoItem(98, 4000, new DateTime(2019, 1, 9)),
                                new TodoItem(99, 4000, new DateTime(2019, 1, 10)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 11)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 12)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 13)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 14)),
                            }),

                        Start = new DateTime(2019, 1, 8)
                    },

                    new IntervalGroupModel()
                    {
                        Items = new List<TodoItem>(
                            new TodoItem[] {
                                new TodoItem(90, 4000, new DateTime(2019, 1, 15)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 16)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 17)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 18)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 19)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 20)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 21)),
                            }),

                        Start = new DateTime(2019, 1, 15)
                    },
                });

            IL.List.Should().BeEquivalentTo(intervals);
        }

        [Test]
        public void ShouldWorkWithMissingWeeks()
        {
            List<TodoItem> items = new List<TodoItem>(
                new TodoItem[] {
                    new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                    new TodoItem(91, 4000, new DateTime(2019, 1, 2)),
                    new TodoItem(92, 4000, new DateTime(2019, 1, 3)),
                    new TodoItem(93, 4000, new DateTime(2019, 1, 4)),
                    new TodoItem(94, 4000, new DateTime(2019, 1, 5)),
                    new TodoItem(95, 4000, new DateTime(2019, 1, 6)),
                    new TodoItem(96, 4000, new DateTime(2019, 1, 7)),
                    // week
                    //new TodoItem(97, 4000, new DateTime(2019, 1, 8)),
                    //new TodoItem(98, 4000, new DateTime(2019, 1, 9)),
                    //new TodoItem(99, 4000, new DateTime(2019, 1, 10)),
                    //new TodoItem(90, 4000, new DateTime(2019, 1, 11)),
                    //new TodoItem(90, 4000, new DateTime(2019, 1, 12)),
                    //new TodoItem(90, 4000, new DateTime(2019, 1, 13)),
                    //new TodoItem(90, 4000, new DateTime(2019, 1, 14)),
                    // week
                    new TodoItem(90, 4000, new DateTime(2019, 1, 15)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 16)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 17)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 18)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 19)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 20)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 21)),
    });

            IntervalList IL = new IntervalList(7, items);

            LinkedList<IntervalGroupModel> intervals = new LinkedList<IntervalGroupModel>(
                new IntervalGroupModel[] {
                    new IntervalGroupModel()
                    {
                        Items = new List<TodoItem>(
                            new TodoItem[] {
                                new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                                new TodoItem(91, 4000, new DateTime(2019, 1, 2)),
                                new TodoItem(92, 4000, new DateTime(2019, 1, 3)),
                                new TodoItem(93, 4000, new DateTime(2019, 1, 4)),
                                new TodoItem(94, 4000, new DateTime(2019, 1, 5)),
                                new TodoItem(95, 4000, new DateTime(2019, 1, 6)),
                                new TodoItem(96, 4000, new DateTime(2019, 1, 7)),
                            }),

                        Start = new DateTime(2019, 1, 1)
                    },

                    new IntervalGroupModel()
                    {
                        Items = new List<TodoItem>(
                            new TodoItem[] {
                                //new TodoItem(97, 4000, new DateTime(2019, 1, 8)),
                                //new TodoItem(98, 4000, new DateTime(2019, 1, 9)),
                                //new TodoItem(99, 4000, new DateTime(2019, 1, 10)),
                                //new TodoItem(90, 4000, new DateTime(2019, 1, 11)),
                                //new TodoItem(90, 4000, new DateTime(2019, 1, 12)),
                                //new TodoItem(90, 4000, new DateTime(2019, 1, 13)),
                                //new TodoItem(90, 4000, new DateTime(2019, 1, 14)),
                            }),
                    
                        Start = new DateTime(2019, 1, 8)
                    },

                    new IntervalGroupModel()
                    {
                        Items = new List<TodoItem>(
                            new TodoItem[] {
                                new TodoItem(90, 4000, new DateTime(2019, 1, 15)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 16)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 17)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 18)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 19)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 20)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 21)),
                            }),

                        Start = new DateTime(2019, 1, 15)
                    },
                });

            IL.List.Should().BeEquivalentTo(intervals);
        }

        [Test]
        public void ShouldWorkWithMissingDays()
        {
            List<TodoItem> items = new List<TodoItem>(
                new TodoItem[] {
                    new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                    new TodoItem(91, 4000, new DateTime(2019, 1, 2)),
                    //new TodoItem(92, 4000, new DateTime(2019, 1, 3)),
                    new TodoItem(93, 4000, new DateTime(2019, 1, 4)),
                    new TodoItem(94, 4000, new DateTime(2019, 1, 5)),
                    //new TodoItem(95, 4000, new DateTime(2019, 1, 6)),
                    new TodoItem(96, 4000, new DateTime(2019, 1, 7)),
                    // week
                    new TodoItem(97, 4000, new DateTime(2019, 1, 8)),
                    new TodoItem(98, 4000, new DateTime(2019, 1, 9)),
                    //new TodoItem(99, 4000, new DateTime(2019, 1, 10)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 11)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 12)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 13)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 14)),
                    // week
                    new TodoItem(90, 4000, new DateTime(2019, 1, 15)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 16)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 17)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 18)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 19)),
                    new TodoItem(90, 4000, new DateTime(2019, 1, 20)),
                    //new TodoItem(90, 4000, new DateTime(2019, 1, 21)),
                });

            IntervalList IL = new IntervalList(7, items);

            LinkedList<IntervalGroupModel> intervals = new LinkedList<IntervalGroupModel>(
                new IntervalGroupModel[] {
                    new IntervalGroupModel()
                    {
                        Items = new List<TodoItem>(
                            new TodoItem[] {
                                new TodoItem(90, 4000, new DateTime(2019, 1, 1)),
                                new TodoItem(91, 4000, new DateTime(2019, 1, 2)),
                                //new TodoItem(92, 4000, new DateTime(2019, 1, 3)),
                                new TodoItem(93, 4000, new DateTime(2019, 1, 4)),
                                new TodoItem(94, 4000, new DateTime(2019, 1, 5)),
                                //new TodoItem(95, 4000, new DateTime(2019, 1, 6)),
                                new TodoItem(96, 4000, new DateTime(2019, 1, 7)),
                            }),

                        Start = new DateTime(2019, 1, 1)
                    },

                    new IntervalGroupModel()
                    {
                        Items = new List<TodoItem>(
                            new TodoItem[] {
                                new TodoItem(97, 4000, new DateTime(2019, 1, 8)),
                                new TodoItem(98, 4000, new DateTime(2019, 1, 9)),
                                //new TodoItem(99, 4000, new DateTime(2019, 1, 10)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 11)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 12)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 13)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 14)),
                            }),

                        Start = new DateTime(2019, 1, 8)
                    },

                    new IntervalGroupModel()
                    {
                        Items = new List<TodoItem>(
                            new TodoItem[] {
                                new TodoItem(90, 4000, new DateTime(2019, 1, 15)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 16)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 17)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 18)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 19)),
                                new TodoItem(90, 4000, new DateTime(2019, 1, 20)),
                                //new TodoItem(90, 4000, new DateTime(2019, 1, 21)),
                            }),

                        Start = new DateTime(2019, 1, 15)
                    },
                });

            IL.List.Should().BeEquivalentTo(intervals);
        }

        [Test]
        public void ShouldWorkWithNullValues()
        {
            List<TodoItem> items = new List<TodoItem>();

            IntervalList il = new IntervalList(7, items);

            Assert.True(il.List.Count == 0);

            il = new IntervalList(7, null);

            Assert.True(il.List.Count == 0);

            il = new IntervalList(-500, null);

            Assert.True(il.List.Count == 0);
        }
    }
}