/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Create a queue with an invalid maximum size and verify that it defaults to 10.
        // Expected Result: max_size must be 10 and size must be 0.
        Console.WriteLine("Test 1");
        var cs = new CustomerService(0);
        Console.WriteLine(cs);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Attempt to serve a customer when the queue is completely empty.
        // Expected Result: It should display an error message indicating that there are no customers in the queue.
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(3);
        cs2.ServeCustomer();
        Console.WriteLine(cs2);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Add more customers than the allowed maximum size to verify that it blocks new entries when full.
        // Expected Result: When attempting to add a customer while the queue is at maximum capacity, it should display "Maximum Number of Customers in Queue."
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(1);
        /* cs3.AddNewCustomer(); */
        Console.WriteLine(cs3);
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // Correction 2 and 3: Validate first if the queue is empty before extracting anything, 
        // thus avoiding the "ArgumentOutOfRangeException" error.
        if (_queue.Count == 0) {
            Console.WriteLine("There are no customers in the queue.");
            return;
        }

        var customer = _queue[0];
        Console.WriteLine(customer);
        _queue.RemoveAt(0);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}