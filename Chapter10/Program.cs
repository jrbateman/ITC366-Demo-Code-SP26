	using System;

	namespace Chapter10
	{
		class Program
		{
			/* 
			 * Inheritance
			 * 
			 *	Inheritance is one of the fundamental attributes of object-oriented programming. 
				It allows you to define a child class that reuses (inherits), extends, or modifies the behavior of a parent class. 
				The class whose members are inherited is called the base class. 
				The class that inherits the members of the base class is called the derived class.
				https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance

			*/

			static void Main(string[] args)
			{
				// Extending Classes (Inheritance)

				var employee = new Employee();
				employee.DoWork();
				Console.WriteLine("");


				// Base Class = employee
				// Base Class = Parent Class = SuperClass
				// Extended Class SoftwareDeveloper
				// Entended Class = Child Class = Subclass

				var dev = new SoftwareDeveloper();
				dev.DoWork();
				dev.WriteCode();
				Console.WriteLine("");

				// Show WriteCode not available to base class
				// employee.Writecode();


				// ************************************* Part 2 *************************************** 

				/*Overriding Base Class Members
				  Automobile and Truck Classes
				  Introduce Two new Keywords
						Override -	The override modifier is required to extend or modify 
									the abstract or virtual implementation of an inherited method, 
									property, indexer, or event.
						Virtual  -	The virtual keyword is used to modify a method, property, indexer, or event declaration 
									and allow for it to be overridden in a derived class. 
									For example, this method can be overridden by any class that inherits it
									When a virtual method is invoked, 
									the run-time type of the object is checked for an overriding member

						You cannot override a non-virtual or static method. 
						The overridden base method must be virtual, abstract, or override.
				*/

				var auto = new Automobile
				{
					Make = "Ford",
					Model = "Taurus",
					Year = 2020,
				};

				auto.Drive();


				var truck = new Truck()
				{
					Make = "Ford",
					Model = "F150",
					Year = 2020,
					TowingCapacity = 1000
				};

				truck.Drive();
				//truck.Tow();


				Console.WriteLine("=================");

				DoDrive(auto);
				DoDrive(truck);


				Console.ReadLine();

			// ************************************* Part 3 *************************************** 

			// Creating and Using Abstract Classes

			/*
			  https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract
			  
			 Virtual methods have an implementation and provide the derived classes with the option of overriding it. 
			 Abstract methods do not provide an implementation and force the derived classes to override the method.

			 So, abstract methods have no actual code in them, and subclasses HAVE TO override the method. 

			 Virtual methods can have code, which is usually a default implementation of something, 
			 and any subclasses CAN override the method using the override modifier and provide a custom implementation.

			 */

			var cat = new Cat();
			cat.Walk();   // implementation in Cat Class
			cat.Feed();   // implementation in Base Class (Animal)

			var dog = new Dog();
			dog.Walk();      // implementation in Dog Class
			dog.Feed();		 // implementation in Base Class (Animal)


			// ************************************* Part 4 *************************************** 
			// Interfaces

			/*
			
				An interface defines a contract. 
				Any class or struct that implements that contract must provide 
					an implementation of the members defined in the interface.
				https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface

				Used For Dependency Injection (Advanced Topic)

				Used When you want two fundamentally differnt classes to act Polymorphically (share behavior)

			*/

			// Declare an interface instance.

			//ISampleInterface obj = new ImplementationClass();
			ImplementationClass obj = new ImplementationClass();

			// Call the member.
			obj.SampleMethod();


			// creating an instance of Bicycle  
			// doing some operations  
			Bicycle bicycle = new Bicycle();
			bicycle.changeGear(2);
			bicycle.speedUp(3);
			bicycle.applyBrakes(1);

			Console.WriteLine("Bicycle present state :");
			bicycle.printStates();

			// creating instance of bike. 
			Car car = new Car();
			car.changeGear(1);
			car.speedUp(4);
			car.applyBrakes(3);

			Console.WriteLine("Bike present state :");
			car.printStates();



			// ************************************* Part 5 *************************************** 
			// Diffference between Interfaces and Abstract Classes

			/*
				https://www.geeksforgeeks.org/difference-between-abstract-class-and-interface-in-c-sharp/

				An Abstract class is a way to achieve the abstraction in C#. 
				An Abstract class is never intended to be instantiated directly. 
				This class must contain at least one abstract method, which is marked by the keyword or modifier abstract in the class definition. 
				The Abstract classes are typically used to define a base class in the class hierarchy.

				Generally, we use abstract class at the time of inheritance.
					A user must use the override keyword before the method which is declared as abstract in child class, 
						the abstract class is used to inherit in the child class.
					It can contains constructors.
					It can implement functions with non-Abstract methods.      <---- Signifant difference
					It cannot support multiple inheritance.
					It can’t be static.

				Like a class, Interfaces can have methods, properties, events, and indexers as its members. 
				But interfaces will contain only the declaration of the members. 

				The implementation of interface’s members will be given by the class who implements the interface implicitly or explicitly.	
			
				Advantage of Interface:
					It is used to achieve loose coupling.
					It is used to achieve total abstraction.
					To achieve component-based programming
					To achieve multiple inheritance and abstraction.
					Interfaces add a plug and play like architecture into applications.

			*/

		}

		private static void DoDrive(Automobile a)
			{
				a.Drive();
			}


	}

	}


	class Employee
	{

		//don't make virtual the first time
		// make virtual to make availble to Software Developer

		public void DoWork()
		{
			Console.Write("Working");
		}
	}
	class SoftwareDeveloper : Employee
	{
		/* public override void DoWork()
		 {
			 base.DoWork();
			 Console.WriteLine("... on software development.");
		 }

		 */

		public void WriteCode()
		{
			Console.WriteLine("Writing C# code.....");

		}





	}
	class Automobile
	{
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }

		public virtual void Drive()
		{
			Console.WriteLine($"The {Year} {Make} {Model} is driving.");
		}
	}
	class Truck : Automobile
	{
		public int TowingCapacity { get; set; }
		public int CargoSize { get; set; }

		public override void Drive()
		{
			Console.WriteLine($"The TRUCK {Year} {Make} {Model} is hauling.");
		}

		public void Tow()
		{
			Console.WriteLine($"Now we're towing {TowingCapacity} pounds!");
		}
	}
	abstract class Animal
	{
		public abstract void Walk();
		public void Feed()
		{
		   Console.WriteLine("Time to feed the animals....");
		}


	}
	class Cat : Animal
	{
		public override void Walk()
		{
			Console.WriteLine("Cat is Walking...");
		}
	}
	class Dog: Animal
		{
			public override void Walk()
			{
				Console.WriteLine("Dog is Walking...");
			}
		}
	interface ISampleInterface
	{
		void SampleMethod();
	}
	class ImplementationClass : ISampleInterface
	{
		public void SampleMethod()
		{
			Console.WriteLine("Do some really cool Interface stuff...");
		}
	}
	interface IVehicle
	{
		void changeGear(int a);
		void speedUp(int a);
		void applyBrakes(int a);
		void washVehicle();
	}

	// class implements interface 
	class Bicycle : IVehicle
	{

		int speed;
		int gear;

		// to change gear 
		public void changeGear(int newGear)
		{

			gear = newGear;
		}

		// to increase speed 
		public void speedUp(int increment)
		{

			speed = speed + increment;
		}

		// to decrease speed 
		public void applyBrakes(int decrement)
		{

			speed = speed - decrement;
		}

		public void printStates()
		{
			Console.WriteLine("speed: " + speed +
							  " gear: " + gear);
		}

    public void washVehicle()
    {
        Console.WriteLine("Washing the Bike.....");
    }
}
	// class implements interface 
	class Car : IVehicle
	{

		int speed;
		int gear;

		// to change gear 
		public void changeGear(int newGear)
		{

			gear = newGear;
		}

		// to increase speed 
		public void speedUp(int increment)
		{

			speed = speed + increment;
		}

		// to decrease speed 
		public void applyBrakes(int decrement)
		{

			speed = speed - decrement;
		}

		public void printStates()
		{
			Console.WriteLine("speed: " + speed +
							  " gear: " + gear);
		}

    public void washVehicle()
    {
        Console.WriteLine("Washing the Car....");
    }
}







