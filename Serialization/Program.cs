using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            //Player p = new Player(100, "Player 1", true);
            //Console.WriteLine(p.name + "'s health: " + p.health);
            //p.Serialize();
            //Console.ReadLine();

            Player p = Player.Deserialize("Player 1");
            Console.WriteLine(p.name + "'s health: " + p.health);
            Console.ReadLine();
        }
    }

    public class Player
    {
        //Only public fields get serialized
        public int health;
        public string name;
        protected bool isAlive;
        public Player()
        {
        }
        public Player(int health, string name, bool isAlive)
        {
            Console.WriteLine("Constructing");
            this.health = health;
            this.name = name;
            this.isAlive = isAlive;
        }
        public void Serialize()
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(Player));
            StreamWriter streamWriter = new StreamWriter(name + ".xml");
            mySerializer.Serialize(streamWriter, this);
            streamWriter.Close();
        }

        public static Player Deserialize(string name)
        {
            XmlSerializer mySerializer = new
            XmlSerializer(typeof(Player));
            StreamReader streamReader = new StreamReader(name + ".xml");
            Player p = mySerializer.Deserialize(streamReader) as Player;
            streamReader.Close();
            return p;
        }
    }
}
