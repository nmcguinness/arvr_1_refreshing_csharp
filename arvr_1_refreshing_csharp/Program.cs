using System;
using System.Runtime.InteropServices;

/// <summary>
/// Demonstrates core C# concepts useful when programming in Unity
/// </summary>
namespace ARVR
{
    //why have an integer (4 bytes) and has a range 
    //int the max = 2^(N-1) - 1
    //byte the max = 2^(8-1) - 1 => -127 => 0 => 127
    public enum AbilityType : sbyte //signed byte (0 -> 255)
    {
        Fire,  //0
        Water, //1
        Air    //2
    }

    public enum LerpSpeedType
    {
        Slow = 1,
        Medium = 4,
        Fast = 10
    }

    //a really simple struct used to store 3 floatint-point values with no properties, constructor or other methods (unlike TestStruct)
    struct Vector3
    {
        public float x, y, z;
    }


    struct TestStruct
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        //can we have a constructor? Yes but not parameterless (...)
        public TestStruct(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        //other methods
        public bool Equals(TestStruct other)
        {
            return X == other.X;
        }
    }

    //so why do we like structs? 
    public struct DummyUselessStruct  //expect to be 8 bytes, actually 12
    {
        public byte a;   //1
        public int b;    //4
        public short c;  //2
        public byte d;
    }

    public struct DummyUselessStructPacked  //expect to be 8 bytes
    {
        public int b;    //4
        public short c;  //2
        public byte a;   //1
        public byte d;
    }

    class TestClass
    {
        public float x, y, z;
        public float sx, sy, sz;
    }

    class Program
    {
       
        static void Main(string[] args)
        {
            Program app = new Program();
            app.Start();
        }

        private void Start()
        {
            //demos
            Console.WriteLine("********************** DemoEnum **********************");
            DemoEnum();

            Console.WriteLine("********************** DemoStruct **********************");
            DemoStruct();

            Console.WriteLine("********************** DemoClass **********************");
            DemoClass();

            Console.WriteLine("********************** DemoNamespace **********************");
            DemoNamespace();

            Console.WriteLine("********************** DemoStatic **********************");
            DemoStatic();

            Console.WriteLine("********************** DemoInterface **********************");
            DemoInterface();

            Console.WriteLine("********************** DemoAbstract **********************");
            DemoAbstract();

            Console.WriteLine("********************** DemoDataStructures **********************");
            DemoDataStructures();

            Console.WriteLine("********************** DemoPredicate **********************");
            DemoPredicate();

            Console.WriteLine("********************** DemoFunc **********************");
            DemoFunc();

            Console.WriteLine("********************** DemoDelegate **********************");
            DemoDelegate();

            Console.WriteLine("********************** DemoAction **********************");
            DemoAction();

            Console.WriteLine("********************** DemoLinq **********************");
            DemoLinq();

            Console.WriteLine("********************** DemoGeneric **********************");
            DemoGeneric();


            //demo end
        }

        //demo howe to pass an enum to a method and access inside the method
        public void ApplyDamage(AbilityType type, int damage)
        {
            //we can access using enum name and (.) operator to use in an if() or a switch() statement
            if (type == AbilityType.Water)
                Console.WriteLine("water ability does X damage");

            switch (type)
            {
                case AbilityType.Fire:
                    Console.WriteLine("water ability does X damage");
                    break;
                default:
                    break;
            }
        }

        //demo how to return an emum from a method
        public AbilityType RandomizeAbility()
        {
            return AbilityType.Water;
        }
        private void DemoEnum()
        {
            ApplyDamage(AbilityType.Fire, 10);
            AbilityType type = RandomizeAbility();

            Console.WriteLine(sizeof(AbilityType));
            Console.WriteLine((int)LerpSpeedType.Medium);
        }

        private void DemoStruct()
        {
            //instanciate - we can declare the variable like a standard data type
            Vector3 v1;
            v1.x = 3.5f;
            v1.y = 5.67f;
            v1.z = 12.1f;

            //or we can use a constructor
            TestStruct t1 = new TestStruct();
            t1.X = 3.5f;
            t1.Y = 4.67f;

            //so how big is this struct?
            DummyUselessStruct dummy1 = new DummyUselessStruct();
            Console.WriteLine("DummyUselessStruct is " + Marshal.SizeOf(dummy1) + " bytes");

            //now how big is the struct? did re-organisation change it?
            DummyUselessStructPacked dummy2 = new DummyUselessStructPacked();
            //lets play around with String.Format() - https://dzone.com/articles/java-string-format-examples
            Console.WriteLine(String.Format("DummyUselessStructPacked is {0} bytes", Marshal.SizeOf(dummy2)));
        }


        private void DemoClass()
        {

        }

        private void DemoStatic()
        {
            // throw new NotImplementedException();
        }


        private void DemoInterface()
        {

        }

        private void DemoAbstract()
        {

        }

        private void DemoGeneric()
        {

        }

        private void DemoNamespace()
        {

        }

        private void DemoPredicate()
        {

        }

        private void DemoFunc()
        {

        }

        private void DemoDelegate()
        {

        }

        private void DemoAction()
        {

        }

        private void DemoDataStructures()
        {
           
        }

        private void DemoLinq()
        {

        }
    }
}