using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            FeedBackDataContext db = new FeedBackDataContext();
            int Chose =0 ;
            do
            {
                Console.WriteLine("\n 1- Показать \n2- Добавить \n3- удалить \n0- Выход");

                try
                {
                    Chose = Convert.ToInt32(Console.ReadLine());
                    switch (Chose)
                    { 
                        case 1:
                            var list = (from f in db.Feedbacks select f).ToList();
                            foreach(Feedback f in list)
                            {
                                Console.WriteLine(String.Format("{0} {1} \"{2}\": {3} ", f.DateAdd, f.Author, f.Title, f.Content));
                            }
                            break;
                        case 2:
                            Feedback fb = new Feedback();
                            //fb.Id = 4;//(from f in db.Feedbacks select f.Id).Max() + 1;
                            fb.DateAdd = DateTime.Now;
                            fb.Author = "ya";
                            fb.Title = "Test";
                            fb.Content = "Content";
                            
                            db.Feedbacks.Add(fb);
                            db.SaveChanges();
                            break;
                        case 3:
                            db.Feedbacks.Remove( db.Feedbacks.First() );
                            db.SaveChanges();
                            break;
                        default:
                            Chose = 0;
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Chose = 0;
                }
            } while (Chose != 0);

            //var list = (from f in db.Feedbacks select f).ToList();
            //foreach(Feedback f in list)
            //{
            //    Console.WriteLine(String.Format("{0} {1} \"{2}\": {3} ", f.DateAdd, f.Author, f.Title, f.Content));
            //}
        }

    }
}
