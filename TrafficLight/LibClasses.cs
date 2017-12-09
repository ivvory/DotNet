using System;

namespace TrafficLight
{
    public abstract class TrafficLight
    {
        protected string color;
        
        public TrafficLight()
        {
            color = "red";
        }

        public virtual void Run(int switchTime)
        {
            // start to switch states periodically 
        }

        public string getState()
        {
            return color;
        }
        
    }
    
    class AutoTrafficLight : TrafficLight
    {
        public override void Run(int switchTime)
        {
            color = "red";
        }
    }
    
    class TrainTrafficLight : TrafficLight
    {
        public override void Run(int switchTime)
        {
            color = "green";
        }
    }

    public class Vehicle
    {
        public Vehicle()
        {
        }

        public virtual bool moveAllowed(TrafficLight v)
        {
            return false;
        }
    }
    
    class Auto : Vehicle
    {
        public override bool moveAllowed(TrafficLight v)
        {
            // ...
            return false;
        }
    }
    
    class Train : Vehicle
    {
        public override bool moveAllowed(TrafficLight v)
        {
            // ...
            return false;
        }
    }
}