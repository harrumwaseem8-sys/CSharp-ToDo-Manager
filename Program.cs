using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_do_list
{
    class Task
    {
        public int id;
        public int id_add;
        public int id_remove;

        public bool condition;
        public bool final_condition;

        public string task_descprition;
        public string task_descprition_add;

        public int DURATION;
        public int end_DURATION = 0;




        public void Task_starter()
        {

            Console.WriteLine("ENTER YOUR TASK ID :");
            this.id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ENTER THE DESCRIPTION OF TASK :");
            this.task_descprition = Console.ReadLine();
            Console.WriteLine("ENTER TASK DURATION :");
            this.DURATION = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("YOUR TASK STATUS IS NOW ACTIVATED :");
            this.condition = false;
            if (this.condition == false)
            {
                Console.WriteLine("TASK IS NOT DONE YET");
            }
        }
        public void task_add()
        {
            Console.WriteLine("ENTER YOUR TASK ID :");
            this.id_add = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ENTER THE DESCRIPTION OF TASK :");
            this.task_descprition_add = Console.ReadLine();

        }
        public void TASK_remover()
        {

            Console.WriteLine("ENTER THE ID OF THE TASK TO REMOVE :");
            this.id_remove = Convert.ToInt32(Console.ReadLine());
        }
        public void TASK_Condition()
        {
            Console.WriteLine("ENTER THE ID OF THE TASK TO CHECK STATUS :");
            if (this.condition == false)
            {
                Console.WriteLine("TASK IS NOT DONE YET");
            }
            else
            {
                Console.WriteLine("TASK IS DONE");
            }


        }
        class TASK_MANAGER : Task
        {
            List<Task> tasks = new List<Task>();
            Task task = new Task();
            public void Add_Task()
            {
                task.task_add();
                tasks.Add(task);
            }
            public void Remove_Task()
            {
                task.TASK_remover();
                tasks.Remove(task);
            }
            public void TASK_Status_CONTROL()
            {
                task.TASK_Condition();
                while ((end_DURATION <= DURATION)&& (end_DURATION == DURATION))
                {
                    Console.WriteLine("TASK NOT DONE YET");
                }
                if ((condition == true) && (end_DURATION == DURATION))
                {

                    Console.WriteLine("TASK DONE 'VERY WELL'");
                }
                else
                {

                    Console.WriteLine("TASK NOT DONE YET");
                }
            }

            public void write_in_file()
            {
                string path = @"D\doomsday\to_do_list.txt";
                using (StreamReader sr = new StreamReader(path))
                {


                    using (StreamWriter sw = new StreamWriter(path, true))
                    {

                        sw.WriteLine("id is :" + this.id);
                        sw.WriteLine("description is :" + this.task_descprition);
                        sw.WriteLine("duration is :" + this.DURATION);
                        sw.WriteLine("condition is :" + this.condition);
                        sw.WriteLine("task ADD" + id_add + task_descprition_add);
                        sw.WriteLine("task REMOVED" + id_remove);
                        sw.WriteLine(" condition" + condition);
                        sw.WriteLine($"{DateTime.Now}");
                    }


                }
            }





             class Program
            {
                static void Main(string[] args)
                {
                    Console.WriteLine("ENTER YOUR TASK INFO :");
                    Task task_main = new Task();
                    task_main.Task_starter();
                    int number_illetrations;
                    int i = 0;
                    Task task_manager = new TASK_MANAGER();
                    Console.WriteLine("for further update in task manager like want to add (a) or remove (r) tasks");
                    string want = Console.ReadLine();
                    Console.WriteLine("Enter the number of tasks you want to add :");
                    number_illetrations = Convert.ToInt32(Console.ReadLine());
                    while (i < number_illetrations)
                    {
                        if ((want == "a") || (want == "A"))
                        {
                            Console.WriteLine("as you want  to add some task in list :");
                            task_manager.task_add();
                        }
                        else if ((want == "r") || (want == "R"))
                        {
                            Console.WriteLine("as you want  to remove some task in list :");
                            task_manager.TASK_remover();
                        }
                        else
                        {
                            Console.WriteLine("you entered wrong input");
                        }

                        Console.WriteLine("want to check task status (s) ?");
                        string check = Console.ReadLine();
                        if ((check == "s") || (check == "S"))
                        {
                            task_manager.TASK_Condition();                                          
                        }
                        else
                        {
                            Console.WriteLine("you entered wrong input");
                        }

                    }
                }
            }
        }
    }
}
