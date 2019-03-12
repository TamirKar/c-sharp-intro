using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        //Use a List to store the Delegates to the functions.
        private LinkedList<CalcDelegate> calcDelegates;

        //Properties.
        public string Name { get; }

        public string Type { get; }

        //Constructor.
        public ComposedMission(string name)
        {
            this.Name = name;
            this.Type = "Composed";
            calcDelegates = new LinkedList<CalcDelegate>();
        }

        //Add a function and return a refrence to the object.
        public ComposedMission Add(CalcDelegate calc)
        {
            calcDelegates.AddLast(calc);
            return this;
        }

        // An Event of when a mission is activated
        public event EventHandler<double> OnCalculate;

        //Calculate the value using the functions from the list.
        public double Calculate(double value)

        {
            foreach (CalcDelegate c in calcDelegates)
            {
                value = c(value);
            }
            //notify all those who are subscribed to the event.s
            OnCalculate?.Invoke(this, value);
            return value;
        }
    }
}