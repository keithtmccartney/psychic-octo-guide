using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using noobchain.Library;

namespace noobchain.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            Block genesisBlock = new Block("Hi im the first block", "0");
            Console.WriteLine("Hash for block 1 : " + genesisBlock.hash);

            Block secondBlock = new Block("Yo im the second block", genesisBlock.hash);
            Console.WriteLine("Hash for block 2 : " + secondBlock.hash);

            Block thirdBlock = new Block("Hey im the third block", secondBlock.hash);
            Console.WriteLine("Hash for block 3 : " + thirdBlock.hash);
        }
    }
}
