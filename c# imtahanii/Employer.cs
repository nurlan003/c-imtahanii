using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Imtahan_C_
{
    public class Employer
    {
        public Guid ID { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public string? sheher { get; set; }
        public string? phone { get; set; }
        public string? age { get; set; }
        public Vacancy[]? vacancies { get; set; }
        public string[]? Notification { get; set; }

        public Employer(Guid ıD, string username, string password, string name, string surname, string sheher, string phone, string age, Vacancy[] vacancies, string[] notification)
        {
            ID=ıD;
            Username=username;
            Password=password;
            this.name=name;
            this.surname=surname;
            this.sheher=sheher;
            this.phone=phone;
            this.age=age;
            this.vacancies=vacancies;
            Notification=notification;
        }


    }
}
