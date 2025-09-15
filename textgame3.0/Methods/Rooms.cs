using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Methods;

namespace Methods
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Room(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }
        public void Enter()
        {
            Console.Clear();
            Console.WriteLine($"You enter: {Name}");
            Console.WriteLine(Description);
        }
    }
}
