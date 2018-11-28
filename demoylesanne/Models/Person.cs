using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace demoylesanne.Models
{
    public class Person
    {
        static List<Person> _People = new List<Person>
        {
            new Person
            {
            firstName = "Miki",
            lastName = "Hiir",
            socialSecurityId = 310123456L
            },
            new Person
            {
            firstName = "Hagar",
        lastName = "Hirmus",
            socialSecurityId = 340123456L
            
            },
            new Person
            {
            firstName = "Lady",
        lastName = "Gaga",
            socialSecurityId = 480123456L
            }
        };


        public string firstName { get; set; }
        public string lastName { get; set; }
        public long socialSecurityId { get; set; }

        public static IEnumerable<Person> People => _People.AsEnumerable();

        // tuli mõlemad FindById ja FindByFirstName IEnumerabliks muuta, muidu ei saaks neid GET meetodis läbi käia
        public static IEnumerable<Person> FindById(long SocialSecurityId)
        => People.Where(x => x.socialSecurityId == SocialSecurityId);

        public static IEnumerable<Person> FindByFirstName(string FirstName)
        => People.Where(x => x.firstName == FirstName);

        public void Add() => _People.Add(this);


        public Person Edit(Person uus)
        {
            // saab muuta vaid ees- ja perekonnanime
            this.firstName = (uus.firstName?.Length > 0) ? uus.firstName : firstName;
            this.lastName = (uus.lastName?.Length > 0) ? uus.lastName : lastName;
            return this;
        }

    }
}