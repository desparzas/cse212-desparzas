using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in order of highest priority first
    // Defect(s) Found: Loop condition was wrong (< _queue.Count - 1), priority comparison used >= instead of >, and items weren't actually removed from queue
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);
        
        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority and dequeue them (FIFO for same priority)
    // Expected Result: Items with same priority should be dequeued in the order they were added
    // Defect(s) Found: Priority comparison used >= instead of >, causing later items to be preferred over earlier ones with same priority
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 5);
        
        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix of different and same priorities
    // Expected Result: Higher priority items come first, FIFO within same priority
    // Defect(s) Found: Same issues as above - loop condition, priority comparison, and missing item removal
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 2);
        
        Assert.AreEqual("A", priorityQueue.Dequeue()); // First item with priority 3
        Assert.AreEqual("C", priorityQueue.Dequeue()); // Second item with priority 3
        Assert.AreEqual("D", priorityQueue.Dequeue()); // Item with priority 2
        Assert.AreEqual("B", priorityQueue.Dequeue()); // Item with priority 1
    }

    [TestMethod]
    // Scenario: Try to dequeue from empty queue
    // Expected Result: Exception should be thrown
    // Defect(s) Found: None - exception handling worked correctly
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                               e.GetType(), e.Message)
            );
        }
    }

}