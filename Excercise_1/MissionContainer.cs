using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public delegate double CalcDelegate(double x);

    public class FunctionsContainer
    {
        //Use dictionary to store the functions and their keys.
        private Dictionary<string, CalcDelegate> dict = new Dictionary<string, CalcDelegate>();

        //Indexer.
        public CalcDelegate this[string index]
        {
            get
            {
                //Default return value if not found in the dictionary.
                if (!(dict.ContainsKey(index)))
                {
                    return val => val;
                }

                return dict[index];
            }
            set { dict[index] = value; }
        }

        //Get the missions.
        public List<string> getAllMissions()
        {
            return new List<string>(this.dict.Keys);
        }
    }
}