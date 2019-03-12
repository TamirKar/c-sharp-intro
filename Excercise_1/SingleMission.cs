using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        //Use a Delegate to store the function for the calculation.
        private CalcDelegate calcDelegate;

        //Properties.
        public string Name { get; }

        public string Type { get; }

        //Constructor.
        public SingleMission(CalcDelegate calc, string name)
        {
            this.Name = name;
            this.Type = "Single";
            this.calcDelegate = calc;
        }

        // An Event of when a mission is activated.
        public event EventHandler<double> OnCalculate;

        //Calculate the value using a single function.
        public double Calculate(double value)
        {
            value = calcDelegate(value);
            //notify all those who are subscribed to the event.
            OnCalculate?.Invoke(this, value);
            return value;
        }
    }
}