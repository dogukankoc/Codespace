using ToDoApp.Db.Entities;
using ToDoApp.Db;
using System.Linq;
using ToDoApp;


namespace ToDoApp.Services
{
    public class ToDoService
    {
        public static void GetToDo(int skip = 0)
        {
            Console.Clear();
            Console.WriteLine("Yapılacaklar\n-------------------------------------------\n");

            using (ToDoContext context = new())
            {
                
                var toDoList = context.ToDo.Skip(skip * 10).Take(10).ToList();

                foreach (var toDo in toDoList)
                {
                    Console.WriteLine($"{toDo.Id} - {toDo.TaskDescription}");
                }
            }

            Console.WriteLine("\n-------------------------------------------\n");
        }

        public static void AddToDo()
        {
            Console.Write("Görev tanımını giriniz:");

            string taskDescription = Console.ReadLine() ?? string.Empty;

            using (ToDoContext context = new())
            {
                var toDo = new ToDo
                {
                    TaskDescription = taskDescription
                };

                context.ToDo.Add(toDo);
                context.SaveChanges();
                GetToDo();
            }
        }

        public static void UpdateToDo()
        {
            while (true)
            {
                try
                {
                    Console.Write("Güncellenecek görev Id'sini giriniz:");
                    int taskId = Convert.ToInt32(Console.ReadLine());

                    using (ToDoContext context = new())
                    {
                        var toDoInDb = context.ToDo.FirstOrDefault(u => u.Id == taskId);
                        if (toDoInDb == null)
                        {
                            Console.WriteLine("Bu Id'e ait bir kayıt bulunamadı!!!");
                            continue;
                        }

                        Console.Write("Yeni görev tanımını girin:");

                        var newTaskDescription = Console.ReadLine() ?? string.Empty;
                        toDoInDb.TaskDescription = newTaskDescription;
                        toDoInDb.UpdatedAt = DateTime.Now;
                        context.SaveChanges();
                        GetToDo();
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Sayisal bir değer giriniz!!!");
                }
            }
        }

        public static void DeleteToDo()
        {
            while (true)
            {
                try
                {
                    Console.Write("Silinecek görev Id'sini giriniz:");
                    var toBeDeletedTaskId = Convert.ToInt32(Console.ReadLine());

                    using (ToDoContext context = new())
                    {
                        var toBeDeletedToDo = context.ToDo.FirstOrDefault(u => u.Id == toBeDeletedTaskId);
                        if (toBeDeletedToDo == null)
                        {
                            Console.WriteLine("Bu Id'e ait bir kayıt bulunamadı!!!");
                            continue;
                        }
                        context.ToDo.Remove(toBeDeletedToDo);
                        context.SaveChanges();
                        GetToDo();
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Sayisal bir değer giriniz!!!");
                }
            }

        }

        //public static void GetToDoNewPage()
        //{
        //    using (ToDoContext context = new())
        //    {
        //        int counter = 10;
        //        var toDoCount = context.ToDo.Count();
        //        for (int i = counter; i <= toDoCount; i += 10)
        //        {
                    
        //            var toDoList = context.ToDo.Skip(i).Take(10).ToList();
        //            foreach(var toDo in toDoList)
        //            {
        //                Console.WriteLine($"{toDo.Id} - {toDo.TaskDescription}");
        //            }
        //            counter += i;
        //            if(counter %10 == 0)
        //            {
        //                break;
        //            }
        //        }
        //    }
        //}
    }
}
