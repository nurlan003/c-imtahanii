using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imtahan_C_
{
    public class Vacancy
    {
        public string Title { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public Vacancy(string title, string position, string company, string description, string Usernamee)
        {
            Title=title;
            Position=position;
            Company=company;
            Description=description;
            Username =Usernamee;
        }
        public void ShowVacancy()
        {
            Console.WriteLine($"Title:{Title}\nPosition:{Position}\nCompany:{Company}\nDescription:{Description}\nUsername:{Username}\n");

        }


    }
}


