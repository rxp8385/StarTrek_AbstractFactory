using System;
using System.Collections.Generic;
namespace DesignPatterns.GangOfFour.Creational.AbstractFactory
{
    /// <summary>
    /// Abstract Factory Design Pattern.
    /// Definition: Provide an interface for creating families of related 
    /// or dependent objects without specifying their concrete classes.
    /// </summary>
    class Program
    {
     
        public static void Main()
        {
            // Create Planet Vulcan and run the simulation...
            var planetVulcan = new AlphaQuadrant<VulcanPlanet>();
            planetVulcan.RunSimulation();

            // Create Planet Earth run the simulation
            var planetEarth = new AlphaQuadrant<EarthPlanet>();
            planetEarth.RunSimulation();

            // User input ends the program
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'AbstractFactory' interface. 
    /// </summary>
    interface IPlanetFactory
    {
        IFederationMember CreateFederationMember();
        INonFederationMember CreateNonFederationMember();
    }

    /// <summary>
    /// The first Concrete Factory class.
    /// </summary>
    class VulcanPlanet : IPlanetFactory
    {
        public IFederationMember CreateFederationMember()
        {
            return new Vulcan();
        }

        public INonFederationMember CreateNonFederationMember()
        {
            return new Romulan();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory2' class.
    /// </summary>
    class EarthPlanet : IPlanetFactory
    {
        public IFederationMember CreateFederationMember()
        {
            return new Human();
        }

        public INonFederationMember CreateNonFederationMember()
        {
            return new Borg();
        }
    }

    /// <summary>
    /// The 'AbstractProductA' interface
    /// </summary>
    interface IFederationMember
    {
    }

    /// <summary>
    /// The 'AbstractProductB' interface
    /// </summary>
    interface INonFederationMember
    {
        void attack(IFederationMember h);
    }

    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    class Vulcan : IFederationMember
    {
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class Romulan : INonFederationMember
    {
        public void attack(IFederationMember h)
        {
            // attack Vulcan
            Console.WriteLine(this.GetType().Name +
                " attacks " + h.GetType().Name);
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    class Human : IFederationMember
    {
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    class Borg : INonFederationMember
    {
        public void attack(IFederationMember h)
        {
            // attack Human
            Console.WriteLine(this.GetType().Name +
                " attacks " + h.GetType().Name);
        }
    }

    /// <summary>
    /// The 'Client' interface
    /// </summary>
    interface IGalaxyQuadrant
    {
        void RunSimulation();
    }

    /// <summary>
    /// The 'Client' class
    /// </summary>
    class AlphaQuadrant<T> : IGalaxyQuadrant where T : IPlanetFactory, new()
    {
        IFederationMember federationMember;
        INonFederationMember nonFederationMember;
        T factory;

        /// <summary>
        /// Contructor of AlphaQuadrant
        /// </summary>
        public AlphaQuadrant()
        {
            // Create new IPlanetFactory
            factory = new T();

            // Factory creates fedrationMembers and nonFederationMembers
            nonFederationMember = factory.CreateNonFederationMember();
            federationMember = factory.CreateFederationMember();
        }

        /// <summary>
        /// Runs the simulation where nonFederationMembers attack FederationMembers
        /// </summary>
        public void RunSimulation()
        {
            nonFederationMember.attack(federationMember);
        }
    }
}
