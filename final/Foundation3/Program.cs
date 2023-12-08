using System;

// Address class to represent event addresses
class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public override string ToString()
    {
        return $"{Street}, {City}, {State} {ZipCode}";
    }
}

// Base Event class
class Event
{
    private string eventName;
    private DateTime eventDate;
    private Address eventAddress;

    public Event(string name, DateTime date, Address address)
    {
        eventName = name;
        eventDate = date;
        eventAddress = address;
    }

    public string GetEventInfo()
    {
        return $"{eventName} on {eventDate} at {eventAddress}";
    }
}

// Derived class for Conference Event
class ConferenceEvent : Event
{
    private string speaker;

    public ConferenceEvent(string name, DateTime date, Address address, string speaker)
        : base(name, date, address)
    {
        this.speaker = speaker;
    }

    public string GetConferenceInfo()
    {
        return $"Conference featuring {speaker}";
    }
}

// Derived class for Concert Event
class ConcertEvent : Event
{
    private string artist;

    public ConcertEvent(string name, DateTime date, Address address, string artist)
        : base(name, date, address)
    {
        this.artist = artist;
    }

    public string GetConcertInfo()
    {
        return $"Concert featuring {artist}";
    }
}

// Derived class for Wedding Event
class WeddingEvent : Event
{
    private string bride;
    private string groom;

    public WeddingEvent(string name, DateTime date, Address address, string bride, string groom)
        : base(name, date, address)
    {
        this.bride = bride;
        this.groom = groom;
    }

    public string GetWeddingInfo()
    {
        return $"Wedding of {bride} and {groom}";
    }
}

class Program
{
    static void Main()
    {
        // Create address
        Address eventAddress = new Address
        {
            Street = "123 Main St",
            City = "Cityville",
            State = "CA",
            ZipCode = "12345"
        };

        // Create events
        ConferenceEvent conferenceEvent = new ConferenceEvent("Tech Conference", DateTime.Now.AddDays(30), eventAddress, "John Doe");
        ConcertEvent concertEvent = new ConcertEvent("Rock Concert", DateTime.Now.AddDays(45), eventAddress, "Rock Band");
        WeddingEvent weddingEvent = new WeddingEvent("Jane & John's Wedding", DateTime.Now.AddDays(60), eventAddress, "Jane", "John");

        // Output event information
        Console.WriteLine(conferenceEvent.GetEventInfo());
        Console.WriteLine(conferenceEvent.GetConferenceInfo());
        Console.WriteLine();

        Console.WriteLine(concertEvent.GetEventInfo());
        Console.WriteLine(concertEvent.GetConcertInfo());
        Console.WriteLine();

        Console.WriteLine(weddingEvent.GetEventInfo());
        Console.WriteLine(weddingEvent.GetWeddingInfo());
    }
}
