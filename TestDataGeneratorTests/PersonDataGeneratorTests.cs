﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PersonDataGeneratorLibrary;

namespace PersonDataGeneratorTests
{
    public class PersonDataGeneratorTests
    {
        public PersonDataGenerator testDataGenerator;
        private static string[] testNamesArray = { "Heikki", "Pertti", "Jaakkima", "Kalevi" };
        [SetUp]
        public void SetUp()
        {
            testDataGenerator = new PersonDataGenerator();
           
        }
        [Test]
        public void TestDataGeneratorBasicTest()
        {

           PersonDataGenerator tdg = new PersonDataGenerator();
            Assert.IsNotNull(tdg);
        }
        [Test]
        public void GenerateRandomPersonTest()
        {
            Person person = testDataGenerator.GenerateRandomPerson();
            TestContext.WriteLine("Name : " + person.firstName);
            Assert.IsTrue(person != null && person.firstName != null);
 
        }

        [Test]
        public void GenerateRandomPersonInsertedNameTest()
        {
            Person person = testDataGenerator.GenerateRandomPerson("JulleTestiNimi");
            TestContext.WriteLine("Name : " + person.firstName);
            Assert.IsTrue(person != null && person.firstName != null);
        }

        [Test]

        public void GenerateRandomPersonInsertedLastNameTest()
        {
            List<Person> people = new List<Person>();
            Person person;
            for (int i = 0; i < 50; i++)
            {
                person = testDataGenerator.GenerateRandomPerson(lastName: "TestLastName");
                people.Add(person);
                TestHelpper.PrintPersonData(person);
            }
            Assert.IsTrue(people.Count == 50);
        }

        [Test]
        public void GenerateNumerOfRandomPersons()
        {
            Person person;
            for (int i = 0; i < 100; i++)
            {
                person = testDataGenerator.GenerateRandomPerson();
                TestHelpper.PrintPersonData(person);
            }
            Assert.Pass();
        }

        [Test]
        public void GenerateListOfPersons()
        {
            List<Person> people = testDataGenerator.GetListOfRandomPersons(100);
            foreach (Person person in people)
            {
                TestHelpper.PrintPersonData(person);
            }

            Assert.IsTrue(people.Count == 100);
        }

        [Test]
        public void GenerateRandomPersonWithGenderMale()
        {
            Person person;
            
            TestContext.WriteLine("Randomized sex");
            for (int i = 0; i < 10; i++)
            {
                person = testDataGenerator.GenerateRandomPerson(sex : Person.Sex.Randomize);
                TestHelpper.PrintPersonData(person);
            }

            TestContext.WriteLine("\nMales");
            for (int i = 0; i < 10; i++)
            {
                person = testDataGenerator.GenerateRandomPerson(sex: Person.Sex.Male);
                TestHelpper.PrintPersonData(person);
            }

            TestContext.WriteLine("\n Females");
            for (int i = 0; i < 10; i++)
            {
                person = testDataGenerator.GenerateRandomPerson(sex: Person.Sex.Female);
                TestHelpper.PrintPersonData(person);
            }
        }


        [Test]
        public void GetRandomFromICollectionListTest()
        {
            List<Person> people = testDataGenerator.GetListOfRandomPersons(100);
            Person rndPerson = PersonDataGenerator.GetRandomFromCollection(people);
            TestHelpper.PrintPersonData(rndPerson);

            Assert.IsTrue(rndPerson != null && people.Count == 100);
        }

        [Test]
        public void GetRandomFromICollectionArrayTest()
        {
           
            string name = PersonDataGenerator.GetRandomFromCollection(testNamesArray);
            TestContext.WriteLine("name was : " + name);
            Assert.IsTrue(name != null);
        }

        [Test]
        public void GetRandomPersonWithRandomAge()
        {
            Person rndPerson = testDataGenerator.GenerateRandomPerson(age:0);
            TestHelpper.PrintPersonData(rndPerson);
            Assert.IsTrue(rndPerson.age > 0);
        }

        public void GetRandomPersonWithAge()
        {
            Person rndPerson = testDataGenerator.GenerateRandomPerson(age: 66);
            TestHelpper.PrintPersonData(rndPerson);
            Assert.IsTrue(rndPerson.age == 66);
        }


    }
}
