using System;
using System.Collections.Generic;

// Абстрактний клас Vehicle
public abstract class Vehicle
{
    public int Speed { get; set; }
    public int Capacity { get; set; }

    public abstract void Move();
}

// Клас Human
public class Human
{
    public int Speed { get; set; }

    public void Move()
    {
        Console.WriteLine("Human is moving on foot.");
    }
}

// Похідні класи транспортних засобів
public class Car : Vehicle
{
    public Car()
    {
        Speed = 100;
        Capacity = 4;
    }

    public override void Move()
    {
        Console.WriteLine("Car is driving.");
    }
}

public class Bus : Vehicle
{
    public Bus()
    {
        Speed = 60;
        Capacity = 30;
    }

    public override void Move()
    {
        Console.WriteLine("Bus is driving.");
    }
}

public class Train : Vehicle
{
    public Train()
    {
        Speed = 120;
        Capacity = 200;
    }

    public override void Move()
    {
        Console.WriteLine("Train is moving on rails.");
    }
}

// Клас Route з точками початку та кінця маршруту
public class Route
{
    public string StartPoint { get; set; }
    public string EndPoint { get; set; }

    public Route(string start, string end)
    {
        StartPoint = start;
        EndPoint = end;
    }
}

// Клас TransportNetwork, який управляє транспортом
public class TransportNetwork
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void MoveAllVehicles()
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();
        }
    }

    public string CalculateOptimalRoute(Route route, Vehicle vehicle)
    {
        // Логіку розрахунку оптимального маршруту залежно від виду транспорту
        return $"Optimal route from {route.StartPoint} to {route.EndPoint} for {vehicle.GetType().Name} is calculated.";
    }

    public void LoadPassengers(int numPassengers, Vehicle vehicle)
    {
        // Логіка посадки пасажирів
        Console.WriteLine($"{numPassengers} passengers are loaded onto the {vehicle.GetType().Name}.");
    }

    public void UnloadPassengers(int numPassengers, Vehicle vehicle)
    {
        // Логіка висадки пасажирів
        Console.WriteLine($"{numPassengers} passengers are unloaded from the {vehicle.GetType().Name}.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        TransportNetwork network = new TransportNetwork();

        Car car = new Car();
        Bus bus = new Bus();
        Train train = new Train();

        network.AddVehicle(car);
        network.AddVehicle(bus);
        network.AddVehicle(train);

        network.MoveAllVehicles();

        Route route = new Route("City A", "City B");

        Console.WriteLine(network.CalculateOptimalRoute(route, car));
        network.LoadPassengers(3, car);
        network.UnloadPassengers(2, car);
    }
}
