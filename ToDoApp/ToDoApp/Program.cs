using ToDoApp.Db;
using ToDoApp.Services;

namespace ToDoApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            ToDoService.GetToDo();
            int skipCount = 0;
            while (true)
            {
                try
                {
                    Console.Write("Görev Ekle:1 - Görev Düzenle:2 - Görev Sil:3 - Sonraki Sayfa:4 - Önceki Sayfa: 5 >>> ");
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

                        case 4:
                            skipCount++;
                            ToDoService.GetToDo(skipCount);
                            break;
                        case 5:
                            skipCount--;
                            ToDoService.GetToDo(skipCount);
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
