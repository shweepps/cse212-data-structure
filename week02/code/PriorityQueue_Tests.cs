using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue once.
    // Expected Result: The item with the highest priority is returned.
    // Defect(s) Found: Dequeue did not remove the returned item from the queue.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("low", 1);
        pq.Enqueue("high", 10);
        pq.Enqueue("mid", 5);

        var value = pq.Dequeue();
        Assert.AreEqual("high", value);

        // If "high" was removed properly, it should not still be in the queue.
        Assert.AreEqual("[low (Pri:1), mid (Pri:5)]", pq.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority.
    // Expected Result: The FIRST (closest to front) among the highest priority items is returned (FIFO tie-break).
    // Defect(s) Found: Tie-breaking selected the LAST highest-priority item because of >= comparison.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 10);
        pq.Enqueue("C", 10);
        pq.Enqueue("D", 1);

        // Highest priority is 10; FIFO says "B" should come out before "C"
        var value = pq.Dequeue();
        Assert.AreEqual("B", value);

        Assert.AreEqual("[A (Pri:5), C (Pri:10), D (Pri:1)]", pq.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None (if exception + message are correct).
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}