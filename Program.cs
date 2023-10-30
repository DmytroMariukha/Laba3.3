using System;

class Parent
{
    protected int Pole1; // Всього місць
    public int Pole2; // Зайнято
    protected int Pole3; // Вільно

    public Parent(int totalSeats)
    {
        Pole1 = totalSeats;
        Pole2 = 0;
        Pole3 = totalSeats;
    }

    public void Print()
    {
        Console.WriteLine($"Total Seats: {Pole1}");
        Console.WriteLine($"Occupied Seats: {Pole2}");
        Console.WriteLine($"Available Seats: {Pole3}");
    }

    public bool Metod1()
    {
        if (Pole3 > 0)
        {
            Pole2++;
            Pole3--;
            return true;
        }
        return false;
    }

    public bool Metod2()
    {
        if (Pole2 > 0)
        {
            Pole2--;
            Pole3++;
            return true;
        }
        return false;
    }
}

class Child : Parent
{
    private int Pole4; // Кількість зупинок судна

    public int CruiseStops
    {
        get { return Pole4; }
        set { Pole4 = value; }
    }

    public Child(int totalSeats, int cruiseStops) : base(totalSeats)
    {
        Pole4 = cruiseStops;
    }

    public new void Print()
    {
        base.Print();
        Console.WriteLine($"Cruise Stops: {Pole4}");
    }
}

class Program
{
    static void Main()
    {
        // Створимо готель на 5 місць
        Parent hotel = new Parent(5);
        Console.WriteLine("Hotel:");
        hotel.Print();

        Random random = new Random();
        int guestsArrived = random.Next(1, 6);

        for (int i = 0; i < guestsArrived; i++)
        {
            bool checkIn = hotel.Metod1();
            if (checkIn)
            {
                Console.WriteLine("Guest checked in.");
            }
            else
            {
                Console.WriteLine("No available seats for more guests.");
                break;
            }
        }

        Console.WriteLine("Hotel after guests checked in:");
        hotel.Print();

        int guestsDeparted = random.Next(0, hotel.Pole2);

        for (int i = 0; i < guestsDeparted; i++)
        {
            bool checkOut = hotel.Metod2();
            if (checkOut)
            {
                Console.WriteLine("Guest checked out.");
            }
            else
            {
                Console.WriteLine("No more guests to check out.");
                break;
            }
        }

        Console.WriteLine("Hotel after guests checked out:");
        hotel.Print();

        // Створимо круїз на 7 місць з 2 зупинками
        Child cruise = new Child(7, 2);
        Console.WriteLine("Cruise:");
        cruise.Print();

        int passengersToBoard = random.Next(1, 8);

        for (int i = 0; i < passengersToBoard; i++)
        {
            bool boarded = cruise.Metod1();
            if (boarded)
            {
                Console.WriteLine("Passenger boarded the cruise.");
            }
            else
            {
                Console.WriteLine("No available seats on the cruise.");
                break;
            }
        }

        Console.WriteLine("Cruise after passengers boarded:");
        cruise.Print();

        while (cruise.CruiseStops > 0)
        {
            int passengersToDisembark = random.Next(0, cruise.Pole2);
            for (int i = 0; i < passengersToDisembark; i++)
            {
                bool disembarked = cruise.Metod2();
                if (disembarked)
                {
                    Console.WriteLine("Passenger disembarked at a cruise stop.");
                }
                else
                {
                    Console.WriteLine("No more passengers to disembark at this stop.");
                    break;
                }
            }
            cruise.CruiseStops--;
            Console.WriteLine($"Cruise stop {2 - cruise.CruiseStops}:");
            cruise.Print();
        }
    }
}
