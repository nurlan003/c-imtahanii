using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Imtahan_C_
{
    public class Worker
    {
        public Guid ID { set; get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Sheher { set; get; }
        public string Phone { set; get; }
        public string Age { set; get; }
        public CV[] cv { set; get; }
        public string[] Notification { set; get; }

        public Worker(Guid ıD, string username, string password, string name, string surname, string sheher, string phone, string age, CV[] cv, string[] notification)
        {
            ID=ıD;
            Username=username;
            Password=password;
            Name=name;
            Surname=surname;
            Sheher=sheher;
            Phone=phone;
            Age=age;
            this.cv=cv;
            Notification=notification;


        }



    }
}