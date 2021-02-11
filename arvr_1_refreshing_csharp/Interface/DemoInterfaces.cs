namespace ARVR
{
    public interface IHaveHealth
    {
        //properties
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        
        //methods
        public int Reset();

        //events
    }

    public interface IHandleInput
    {
        public float Horizontal { get; }
        public float Vertical { get;}
    }

    public class KeyboardInput : IHandleInput
    {
        public float Horizontal{
            get
            {
                return -1; // Input.GetHorizontal();   //A, D
            }
        }

        public float Vertical {
            get
            {
                return -1; // Input.GetVertical();   //W, S
            }
        }
    }

    public class GameControllerInput : IHandleInput
    {
        public float Horizontal
        {
            get
            {
                return -1; // Input.GetThumbstickHorizontal();   //L, R
            }
        }

        public float Vertical
        {
            get
            {
                return -1; // Input.GetThumbstickVertical();   //U, D
            }
        }
    }

    public class AIRandomInput : IHandleInput
    {
        public float Horizontal
        {
            get
            {
                return -1; // Random.Range(-1, 1);  
            }
        }

        public float Vertical
        {
            get
            {
                return -1; // Random.Range(-1, 1);   
            }
        }
    }




    class NewAmazingPlayer : IHaveHealth
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public IHandleInput handleInput;


        public void Update()
        {
            transform.Move(handleInput.Vertical, handleInput.Horizontal, 0);
        }

        public int Reset()
        {
      //      throw new System.NotImplementedException();
        }
    }








    //health, move, damage, buff
    class PlayerAdvanced
    {
        public int Health { get; set; }
        private string up = "W"; //KeyCode.W
        private string down = "S";
        private string[] keys;  //["W", "S"];
        private float moveSpeed, rotateSpeed;

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void AddBuff(int buff)
        {
            Health += buff;
        }
    }

    //health, restore
    class Elf
    {
        public int Health { get; set; }
        public void Restore()
        {

        }
    }
    //health
    class Pickup
    {
        public int Health { get; set; }
        //private string name;
        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        value = value.Trim(); //"  Dr Octopus   "
        //        name = value.Length != 0 ? value : "Default";
        //    }
        //}

        //public int Age { get => age; set => age = value; }
        //private int age;
    }

  
}
