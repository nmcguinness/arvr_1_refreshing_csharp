using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


/// <summary>
/// Demonstrates core C# concepts useful when programming in Unity
/// </summary>
namespace ARVR
{
    #region Demo Enum
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
    #endregion

    #region Demo Struct
    //a really simple struct used to store 3 floatint-point values with no properties, constructor or other methods (unlike TestStruct)
    struct Vector3
    {
        public float x, y, z;
    }

    class Vector3AsClass
    {
        public float x, y, z;
    }


    struct TestStruct
    {
        //events, indexers

        //properties
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
    #endregion

    #region Demo Struct - Struct Packing
    //so why do we like structs? 
    public struct DummyUselessStruct  //expect to be 8 bytes, actually 12
    {
        public byte a;   //1
        public int b;    //4
        public short c;  //2
        public byte d;
    }

   // Marshal.SizeOf(rifle)
    public struct DummyUselessStructPacked  //expect to be 8 bytes
    {
        public int b;    //4
        public short c;  //2
        public byte a;   //1
        public byte d;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct DummyUselessStructSequential  //expect to be 8 bytes
    {
        [FieldOffset(0)]
        public int b;  
        //4 bytes[4,5,6,7]
        [FieldOffset(8)]
        public short c;
        //4 bytes
        [FieldOffset(10)]
        public byte a;
        //4 bytes
        [FieldOffset(14)]
        public byte d;
    }
    #endregion

    #region Demo Class 
    class TestClass
    {
        public float x, y, z;
        public float sx, sy, sz;

        public TestClass()
        {
            x = 0;
            //set to default...
        }
    }

    class Something
    {
        private Vector3 position; //struct - inside a class => treated as a reference type
    }

    class Player
    {
        public static int count;
        public int id;
        public Player()
        {
            count++;
        }
        public static int getCount()
        {
            return count;
        }
    }
    #endregion

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

        /*
         Value-types:
             - char, byte, bool, int, float, short, long, double, struct(*)
         Reference-types:
             - array, Vector, List, Student, Person, Player

          */
        //structs are treated as VALUE types
        public void Process(DummyUselessStruct theDummy)
        {
            theDummy.a = 125;
        }

        //REFERENCE types can be changed inside the method
        public void Process(TestClass theClass)
        {
            theClass.sx = 123;
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

        public abstract class CharacterType
        {
            //abstract methods
            public string Type { get; }
        }

        public class HunterType : CharacterType
        {
            public new string Type => "Hunter";

            public string defaultModel; //"hunter_1"
            public string alternateModel; //"hunter_1_upgraded"

            public float aggressionRadius;
            public float restoreRate; 

            public HunterType(string dm, string am, float ar, float rr)
            {
                defaultModel = dm;
                restoreRate = rr;
            }
        }


        private void DemoDataStructures()
        {
            /*
             1) Why and when its used?
             2) How to add/remove
             3) How to iterate
             4) How to get size
             5) -------
             */

            //Array => | null | Address  |
            CharacterType[] characterTypes = new CharacterType[2];
            characterTypes[0] = new HunterType("h1", "ah1", 10, 5);
            characterTypes[1] = new HunterType("xh1", "xah1", 60, 25);
            characterTypes[0] = null;

            foreach(CharacterType c in characterTypes)
            {
                HunterType h = c as HunterType;
                Console.WriteLine(h.defaultModel);
            }

            for(int i = 0; i < characterTypes.Length; i++)
            {
                HunterType h = characterTypes[i] as HunterType;
                Console.WriteLine(h.defaultModel);

                if(h.alternateModel.Equals("h1"))
                {

                }
            }

            //List
            List<int> numberList = new List<int>();
            numberList.Add(12);
            numberList.Add(120);
            numberList.Add(1200);
            numberList.Remove(1); //120
            numberList.RemoveRange(0, 2);
           // numberList.Count;

            foreach(var x in numberList)
            {
                Console.WriteLine(x);
            }

            //Stack
            Stack<string> comsumables = new Stack<string>(); //LIFO (last in, first out)
            comsumables.Push("a");
            comsumables.Push("d");
            comsumables.Push("c");
            comsumables.Push("d");
            Console.WriteLine(comsumables.Pop()); //d => list now has a, b, c
            Console.WriteLine(comsumables.Peek()); //c => list still has a, b, c
            //comsumables.Count;
            foreach (string s in comsumables)
            {
                Console.WriteLine(s);
            }

            //Queue
            Queue<double> doubleQueue = new Queue<double>(); //FIFO
            doubleQueue.Enqueue(3.14);
            doubleQueue.Enqueue(2.81);
            doubleQueue.Enqueue(2.99792458);

            double value = doubleQueue.Dequeue(); //3.14
            Console.WriteLine(doubleQueue.Count);

            foreach (double d in doubleQueue)
            {
                Console.WriteLine(d);
            }


            //Set
            HashSet<String> shopping = new HashSet<string>();
            shopping.Add("kiwi");
            shopping.Add("milk");
            shopping.Add("meat");
            shopping.Add("orange");
            shopping.Add("kiwi");

            if (shopping.Add("milk"))
            {
                Console.WriteLine("Already added this!!!");
            }



            //Dictionary
        }






        private void DemoLinq()
        {

        }
    }
}