using ToDoApp.Services;

namespace ToDoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    ToDoService.GetToDo();
                    Console.Write("Görev Ekle:1 - Görev Düzenle:2 - Görev Sil:3 >>> ");
                    var taskType = Convert.ToInt32(Console.ReadLine());

                    switch (taskType)
                    {
                        case 1:
                            ToDoService.AddToDo();
                            break;

                        case 2:
                            ToDoService.UpdateToDo();
                            break;

                        case 3:
                            ToDoService.DeleteToDo();
                            break;

                    }
                }
                catch (Exception)
                {
                    
                }
                
            }

        }
    }


}
