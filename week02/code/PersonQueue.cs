/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    public void Enqueue(Person person)
    {
        // Add to the back (end) of the queue
        _queue.Add(person);
    }

    public Person Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Queue is empty.");

        // Remove from the front of the queue
        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
