using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManager
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager car = new CarManager();
            Boolean loop = true;
            // weeeeeeeeeeeeee
            Car c;

            while (loop)
            {
                Console.WriteLine("1. Add car");
                Console.WriteLine("2. Edit car");
                Console.WriteLine("3. Delete car");
                Console.WriteLine("4. Show all car");
                Console.WriteLine("5. Order by speed");
                Console.WriteLine("6: Order by plate");
                Console.WriteLine("7: Exit");
                int menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        c = new Car();
                        c.input();
                        car.AddCar(c);
                        break;
                    case 2:
                        c = new Car();
                        c.input();
                        car.UpdateCar(c);
                        break;
                    case 3:
                        c = new Car();
                        c.input();
                        car.RemoveCar(c);
                        break;
                    case 4:
                        car.ShowAll();
                        break;
                    case 5:
                        car.ShowOrderBySpeed();
                        break;
                    case 6:
                        car.ShowOrderByPlate();
                        break;
                    default:
                        loop = false;
                        break;
                }
            }
        }  
    }

    class Car : IComparable<Car>
    {
        #region Attributes
        string _Plate;
        string _Engine;
        int _Speed;
        int _Capacity;
        #endregion

        #region Properties
        public string Plate
        {
            get { return _Plate; }
            set { _Plate = value; }
        }

        public string Engine
        {
            get { return _Engine; }
            set { _Engine = value; }
        }

        public int Speed
        {
            get { return _Speed; }
            set { _Speed = value; }
        }

        public int Capacity
        {
            get { return _Capacity; }
            set { _Capacity = value; }
        }
        #endregion

        #region Constructors
        public Car() { }

        public Car(string Plate, string Engine, int Speed, int Capacity)
        {
            _Plate = Plate;
            _Engine = Engine;
            _Speed = Speed;
            _Capacity = Capacity;
        } 
        #endregion

        public void input()
        {
            Console.WriteLine("Enter Plate: ");
            _Plate = Console.ReadLine();
            Console.WriteLine("Enter Engine: ");
            _Engine = Console.ReadLine();
            Console.WriteLine("Enter Speed: ");
            _Speed = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Capacity: ");
            _Capacity = int.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            string str = string.Format("{0}, {1}, {2}, {3}", _Plate, _Engine, _Speed, _Capacity);
            return str;
        }

        public override bool Equals(object obj)
        {
            Car another = (Car)obj;
            return this._Plate == another._Plate;
        }

        int IComparable<Car>.CompareTo(Car other)
        {
            return this.Speed.CompareTo(other.Speed);
        }
    }

    class CarManager
    {
        List<Car> list = new List<Car>();

        public void AddCar(Car c)
        {
            if (!list.Contains(c))
            {
                list.Add(c);
            }
            else
            {
                Console.WriteLine("Car existed");
            }
        }

        public void UpdateCar(Car c)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Equals(c))
                {
                    list[i] = c;
                }
            }
        }

        public void RemoveCar(Car c)
        {
            list.Remove(c);
        }

        public Car SearchByPlate(string Plate)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Plate == Plate)
                {
                    return list[i];
                }
            }

            return null;
        }

        public void ShowAll()
        {
            foreach (Car c in list)
            {
                Console.WriteLine(c);
            }
        }

        public void ShowOrderBySpeed()
        {
            list.Sort();
            ShowAll();
        }

        public void ShowOrderByPlate()
        {
            IComparer<Car> comparer = new PlateComparer();
            list.Sort(comparer);
            ShowAll();
        }
    }

    class PlateComparer : IComparer<Car>
    {
        int IComparer<Car>.Compare(Car x, Car y)
        {
            return x.Plate.CompareTo(y.Plate);
        }
    }
}
