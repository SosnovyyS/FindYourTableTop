using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class ViewSearcher
    {
        public int CountPlayers { get; set; }
        public String SearchingSystem { get; set; }
        public List<Form> Players;

        public IEnumerable<Test.Models.Form> FindSomePlayers()
        {
            Players = new List<Form> { };
            for (int i = 0; i < CountPlayers; i++) { 

            };
            return Players;
        }
        //IEnumerable<EFDataApp.Models.User>
       
    }
}
