using System;
using System.Collections.Generic;
using NUnit.Framework;
using Tests.Editor.Fakes;

public class TicksTests
{
    [Test]
    public void TicksCount()
    {
        var manager = new FakeTickManager(new Type[] { });
        var consumer = new Consumer1();
        manager.AddConsumer(consumer);

        var ticksCount = 3;
        for (int i = 0; i < ticksCount; i++)
        {
            manager.ProcessTick();
        }

        Assert.True(consumer.TicksCount == ticksCount);
    }

    [Test]
    public void ConsumerRemove()
    {
        var manager = new FakeTickManager(new Type[] { });
        var consumer = new Consumer1();
        manager.AddConsumer(consumer);

        var ticksCount = 3;
        for (int i = 0; i < ticksCount; i++)
        {
            manager.ProcessTick();
        }

        manager.RemoveConsumer(consumer);

        for (int i = 0; i < ticksCount; i++)
        {
            manager.ProcessTick();
        }

        Assert.True(consumer.TicksCount == ticksCount);
    }
    
    [Test]
    public void ConsumersOrder()
    {
        var order = new Type[]
        {
            typeof(Consumer2),
            typeof(Consumer1),
            typeof(Consumer3),
        };
        var intList = new List<int>();
        var manager = new FakeTickManager(order);
        var consumer1 = new Consumer1();
        var consumer2 = new Consumer2();
        var consumer3 = new Consumer3();
        consumer1.IntList = intList;
        consumer2.IntList = intList;
        consumer3.IntList = intList;
        manager.AddConsumer(consumer1);
        manager.AddConsumer(consumer2);
        manager.AddConsumer(consumer3);

        manager.ProcessTick();
        
        Assert.True(intList[0] == 2);
        Assert.True(intList[1] == 1);
        Assert.True(intList[2] == 3);
    }
}