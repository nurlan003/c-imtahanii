using System.Text.Json;

namespace Imtahan_C_
{


    public static class mainFunctions
    {
        public static List<Vacancy> empVacancies = new List<Vacancy> { };
        public static List<Vacancy> CommonVacancies = new List<Vacancy> { };


        public static Employer defaultEmpAdmin = new Employer(Guid.NewGuid(), "Nurlan003", "12345678", "Nurlan", "Cavadzade", "Baku", "0775885115", "23", new Vacancy[] { }, new string[] { });
        public static List<Employer> employers = new List<Employer> { };


        public static Worker worker1 = new Worker(Guid.NewGuid(), "Elvin005", "12345678", "Elvin", "Cavadov", "Baku", "0777777777", "19", new CV[] { }, new string[] { });
        public static List<Worker> workers = new List<Worker> { };


        public static void signUpEmployer()
        {
            bool d = true;
            while (d)
            {
                Console.Clear();
                Vacancy[] empSingUpVacancies = new Vacancy[] { };
                Console.WriteLine("Name:");
                string empSignUpName = Console.ReadLine();
                Console.WriteLine("Surname:");
                string empSignUpSurname = Console.ReadLine();
                Console.WriteLine("City:");
                string empSignUCity = Console.ReadLine();
                Console.WriteLine("Phone Number:");
                string empSignUpPhoneNum = Console.ReadLine();
                Console.WriteLine("Age:");
                string empSignUpAge = Console.ReadLine();
                int b = 0;
                for (int i = 0; i < employers.Count; i++)
                {
                    if (employers[i].phone==empSignUpPhoneNum)
                    {
                        Console.WriteLine("This number is already registered. If you don't mind, please log in");
                        b++;
                        Thread.Sleep(1000);

                    }


                }
                if (b==0)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Username:");
                        string empSignUpUsername = Console.ReadLine();
                        Console.WriteLine("Password:");
                        string empSignUpPassword = Console.ReadLine();
                        int c = 0;
                        for (int i = 0; i < employers.Count; i++)
                        {
                            if (employers[i].Username==empSignUpUsername)
                            {
                                Console.WriteLine("This username is  already registered. Please enter new Username");
                                Thread.Sleep(1000);
                                c++;
                            }
                        }
                        if (c==0)
                        {
                            Employer newEmp = new Employer(Guid.NewGuid(), empSignUpUsername, empSignUpPassword, empSignUpName, empSignUpSurname, empSignUCity, empSignUpPhoneNum, empSignUpAge, empSingUpVacancies, new string[] { });
                            employers.Add(newEmp);
                            Console.WriteLine("Account successfully created. Please Sing In");

                            string filePath2 = "C:\\Users\\Lenova\\Source\\Repos\\c# imtahanii\\c# imtahanii\\Employers.json";
                            File.WriteAllText(filePath2, "{}");

                            string json4 = System.Text.Json.JsonSerializer.Serialize(employers, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText("C:\\Users\\Lenova\\Source\\Repos\\c# imtahanii\\c# imtahanii\\Employers.json", json4);
                            Thread.Sleep(1000);
                            d=false;
                            break;
                        }
                    }
                }
            }
        }
        public static void signInEmployer()
        {
            Console.WriteLine("Username:");
            string empSignInUsername = Console.ReadLine();
            Console.WriteLine("Password:");
            string empSignInPassword = Console.ReadLine();
            int a = 0;

            for (int i = 0; i < employers.Count; i++)
            {
                if (employers[i].Username==empSignInUsername && employers[i].Password==empSignInPassword)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Hesabiniza giris edildi!!!");
                    a++;
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine("1-Give vacancy");
                        Console.WriteLine("2-Notification");
                        Console.WriteLine("3-Your vacancies");
                        Console.WriteLine("4-Exit");
                        Console.WriteLine(">>>");
                        string empSecim = Console.ReadLine();
                        if (empSecim=="1")
                        {
                            Console.WriteLine("Enter your Vacancy Title:");
                            string newVacansyTitle = Console.ReadLine();
                            Console.WriteLine("Enter Position:");
                            string newVacansyPosition = Console.ReadLine();
                            Console.WriteLine("Enter your Company:");
                            string newVacansyCompany = Console.ReadLine();
                            Console.WriteLine("Enter Description:");
                            string newVacansyDescription = Console.ReadLine();

                            Vacancy empnewVacancy = new Vacancy(newVacansyTitle, newVacansyPosition, newVacansyCompany, newVacansyDescription, employers[i].Username);
                            empVacancies.Add(empnewVacancy);
                            CommonVacancies.Add(empnewVacancy);
                            Console.WriteLine("Creat Vacancy!!!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            string filePath3 = "C:\\Users\\Lenova\\Source\\Repos\\c# imtahanii\\c# imtahanii\\Vacancies.json";
                            File.WriteAllText(filePath3, "{}");
                            string json5 = System.Text.Json.JsonSerializer.Serialize(CommonVacancies, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText("C:\\Users\\Lenova\\Source\\Repos\\c# imtahanii\\c# imtahanii\\Vacancies.json", json5);



                        }
                        else if (empSecim=="2")
                        {
                            Console.Clear();
                            if (employers[i].Notification.Length==0)
                            {
                                Console.WriteLine("You have no notifications");
                            }
                            else
                            {
                                for (int s = 0; s < employers[i].Notification.Length; s++)
                                {
                                    Console.WriteLine(employers[i].Notification[s]);
                                }

                            }
                        }
                        else if (empSecim=="3")
                        {
                            Console.Clear();
                            if (empVacancies.Count==0)
                            {
                                Console.WriteLine("You have no vacancy");
                            }
                            else
                            {
                                for (int h = 0; h< empVacancies.Count; h++)
                                {
                                    Console.WriteLine($"Vacancy{h+1}:");
                                    empVacancies[h].ShowVacancy();
                                }

                            }

                        }
                        else if (empSecim=="4")
                        {
                            break;
                        }
                    }

                }
            }

            if (a==0)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password ve ya Username in yanlisdir!!!");
                Thread.Sleep(1000);
                Console.ResetColor();
            }

        }


        public static void signInWorker()
        {
            Console.WriteLine("Username:");
            string worSignInUsername = Console.ReadLine();
            Console.WriteLine("Password:");
            string worSignInPassword = Console.ReadLine();

            int a = 0;
            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].Username==worSignInUsername && workers[i].Password==worSignInPassword)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Hesabiniza giris edildi!!!");
                    a++;
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine("1-Notification");
                        Console.WriteLine("2-Vacancies");
                        Console.WriteLine("3-Exit");
                        Console.WriteLine(">>>");
                        string worSecim = Console.ReadLine();
                        if (worSecim=="1")
                        {

                            if (workers[i].Notification.Length==0)
                            {
                                Console.WriteLine("You have no notification");
                            }
                            else
                            {
                                for (int d = 0; d < workers[i].Notification.Length; d++)
                                {
                                    Console.WriteLine(workers[i].Notification[d]);

                                }

                            }
                        }
                        else if (worSecim=="2")
                        {

                            if (CommonVacancies.Count==0)
                            {
                                Console.WriteLine("There isn't vacancy");
                            }
                            else
                            {
                                for (int k = 0; k < CommonVacancies.Count; k++)
                                {
                                    CommonVacancies[k].ShowVacancy();
                                }

                            }

                        }
                        else if (worSecim=="3")
                        {
                            break;

                        }

                    }

                }


            }

            if (a==0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password ve ya Username in yanlisdir!!!");
                Thread.Sleep(1000);
                Console.ResetColor();

            }

        }

        public static void signUpWorker()
        {
            bool d = true;
            while (d)
            {
                Console.WriteLine("Name:");
                string worSignUpName = Console.ReadLine();
                Console.WriteLine("Surname:");
                string worSignUpSurname = Console.ReadLine();
                Console.WriteLine("City:");
                string worSignUpCity = Console.ReadLine();
                Console.WriteLine("Phone:");
                string worSignUpPhone = Console.ReadLine();
                Console.WriteLine("Age:");
                string worSignUpAge = Console.ReadLine();

                int b = 0;
                for (int i = 0; i < workers.Count; i++)
                {
                    if (workers[i].Phone==worSignUpPhone)
                    {
                        Console.WriteLine("This number is already registered. If you don't mind, please log in");
                        b++;
                        Thread.Sleep(1000);

                    }


                }
                if (b==0)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Username:");
                        string worSignUpUsername = Console.ReadLine();
                        Console.WriteLine("Password:");
                        string empSignUpPassword = Console.ReadLine();
                        int c = 0;
                        for (int i = 0; i < workers.Count; i++)
                        {
                            if (workers[i].Username==worSignUpUsername)
                            {
                                Console.WriteLine("This username is  already registered. Please enter new Username");
                                Thread.Sleep(1000);
                                c++;
                            }
                        }
                        if (c==0)
                        {
                            Worker newWor = new Worker(Guid.NewGuid(), worSignUpUsername, empSignUpPassword, worSignUpName, worSignUpSurname, worSignUpCity, worSignUpPhone, worSignUpAge, new CV[] { }, new string[] { });
                            workers.Add(newWor);
                            Console.WriteLine("Account successfully created. Please Sing In");
                            string filePath = "C:\\Users\\Lenova\\Source\\Repos\\c# imtahanii\\c# imtahanii\\Workers.json";
                            File.WriteAllText(filePath, "{}");
                            string json9 = System.Text.Json.JsonSerializer.Serialize(workers, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText("C:\\Users\\Lenova\\Source\\Repos\\c# imtahanii\\c# imtahanii\\Workers.json", json9);

                            Thread.Sleep(1000);
                            d=false;
                            break;
                        }
                    }
                }
                string json = System.Text.Json.JsonSerializer.Serialize(workers, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText("C:\\Users\\Lenova\\Source\\Repos\\c# imtahanii\\c# imtahanii\\Workers.json", json);
            }
        }


        public static void enterEmployer()
        {
            while (true)
            {
                Console.Clear();


                Console.WriteLine("1-Sign in");
                Console.WriteLine("2-Sign up");
                Console.WriteLine("3-Exit Menu");

                Console.Write(">>>");
                string signinupempSecim = Console.ReadLine();

                if (signinupempSecim=="1")
                {
                    signInEmployer();
                }


                else if (signinupempSecim=="2")
                {
                    signUpEmployer();
                }
                else if (signinupempSecim=="3")
                {
                    break;
                }

            }
        }
        public static void enterWorker()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1-Sign in");
                Console.WriteLine("2-Sign up");
                Console.WriteLine("3-Exit Menu");
                Console.Write(">>>");
                string signinupworSecim = Console.ReadLine();

                if (signinupworSecim=="1")
                {
                    signInWorker();
                }
                else if (signinupworSecim=="2")
                {
                    signUpWorker();
                }
                else if (signinupworSecim=="3")
                {
                    break;
                }
            }

        }





        public static void BOSSAz()
        {
            while (true)
            {
                employers.Add(defaultEmpAdmin);
                workers.Add(worker1);
                string filePath = "C:\\Users\\Lenova\\Source\\Repos\\c# imtahanii\\c# imtahanii\\Workers.json";
                string filePath2 = "C:\\Users\\Lenova\\Source\\Repos\\c# imtahanii\\c# imtahanii\\Vacancies.json";
                string filePath3 = "C:\\Users\\Lenova\\Source\\Repos\\c# imtahanii\\c# imtahanii\\Employers.json";
                File.WriteAllText(filePath, "{}");
                File.WriteAllText(filePath2, "{}");
                File.WriteAllText(filePath3, "{}");
                string json = System.Text.Json.JsonSerializer.Serialize(workers, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("C:\\Users\\Lenova\\Source\\Repos\\c# imtahanii\\c# imtahanii\\Workers.json", json);
                string json2 = System.Text.Json.JsonSerializer.Serialize(employers, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("C:\\Users\\Lenova\\Source\\Repos\\c# imtahanii\\c# imtahanii\\Employers.json", json2);

                Console.Clear();
                Console.WriteLine("1-Employer\n2-Worker\n3-Exit");
                Console.Write(">>>");
                string empworSecim = Console.ReadLine();
                Console.Clear();
                //=>Employer
                if (empworSecim=="1")
                {
                    enterEmployer();
                }
                //=>Worker
                else if (empworSecim=="2")
                {
                    enterWorker();

                }
                else if (empworSecim=="3")
                {
                    Console.WriteLine("Exited the program");
                    break;
                }

            }

        }
    }
}


