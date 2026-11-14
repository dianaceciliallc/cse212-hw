using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: I enqueued A (priority 1), B (priority 2) and C (priority 9) so the highest priority
    // item is the last one in the queue. Then I dequeued three times.
    // Expected Result: C, B, A
    // Defect(s) Found: The first Dequeue returned B instead of C. The for loop stopped at
    // "index < _queue.Count - 1", so it never looked at the last item. I fixed it by changing the
    // condition to "index < _queue.Count".
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 2);
        priorityQueue.Enqueue("C", 9);

        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: I enqueued A (priority 9), B (priority 1) and C (priority 2) so the highest priority
    // item is the first one in the queue. Then I dequeued three times.
    // Expected Result: A, C, B
    // Defect(s) Found: The first Dequeue returned A correctly, but the second one returned A again
    // instead of C. The code found the highest priority item and returned its value, but it never
    // removed the item from the list. I fixed it by adding _queue.RemoveAt(highPriorityIndex)
    // before returning the value.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 9);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 2);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: I enqueued A (priority 5), B (priority 5) and C (priority 1). Two items tie for the
    // highest priority. Then I dequeued three times.
    // Expected Result: A, B, C. A is closer to the front, so it has to come out before B.
    // Defect(s) Found: The first Dequeue returned B instead of A. The code used ">=" so a later item
    // with the same priority replaced the earlier one. I changed it to ">" so the item closest to the
    // front wins the tie (FIFO).
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 5);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: I called Dequeue on a brand new queue that has nothing in it.
    // Expected Result: An InvalidOperationException with the message "The queue is empty."
    // Defect(s) Found: None. The original code already threw the right exception with the right message.
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
                 string.Format("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message)
            );
        }
    }
}