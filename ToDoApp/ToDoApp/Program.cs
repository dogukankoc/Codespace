using ToDoApp.Db;
using ToDoApp.Db.Entities;
using ToDoApp.Services;


namespace ToDoApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            User appUser = new User();
            int skipCount = 0;
            appUser = AuthService.MainScreen();

            while (true)
            {
                try
                {
                    if(skipCount<0)
                    {
                        skipCount = 0;
                    }
                    ToDoService.GetToDo(appUser,skipCount);
                    Console.Write("Görev Ekle:1 - Görev Düzenle:2 - Görev Sil:3 - Sonraki Sayfa:4 - Önceki Sayfa: 5 >>> ");
                    var taskType = Convert.ToInt32(Console.ReadLine());

                    switch (taskType)
                    {
                        case 1:
                            ToDoService.AddToDo(appUser);
                            break;

                        case 2:
                            ToDoService.UpdateToDo(appUser);
                            break;

                        case 3:
                            ToDoService.DeleteToDo(appUser);
                            break;

                        case 4:
                            skipCount++;
                            ToDoService.GetToDo(appUser);
                            break;
                        case 5:
                            skipCount--;
                            ToDoService.GetToDo(appUser);
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
