using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakeRootCore;

namespace CoreAPITest
{
    class Program
    {
        static void Main(string[] args)
        {
            CoreAPI api = new CoreAPI();
            api.init();
            /*api.playSong(@"C:\Users\Milos\Desktop\Led Zepplin - Stairway to Heaven.mp3");*/
            String[] strings = api.getLyrics("Korn", "falling away from me");
            Console.WriteLine(strings[1]);
            Console.ReadLine();
        }
    }
}
