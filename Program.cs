using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Security.Cryptography.X509Certificates;

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


        public int id1=1;
        public int durTation1;
        


        public Stopwatch timer=new Stopwatch();
        public void start_timer()
        {
            timer.Start();
            Console.WriteLine("The Timer is startred");
        }   
        public void stop_timer()
        {
            timer.Stop();
            Console.WriteLine("The Timer is stopped");
            Console.WriteLine($"{timer.Elapsed.Seconds}");
            end_DURATION = timer.Elapsed.Seconds;
        }   




        public void Task_starter()
        {

            Console.WriteLine("ENTER YOUR TASK ID :");
            this.id = int.TryParse(Console.ReadLine(), out  id1) ? id1 : 0;
            Console.WriteLine("ENTER THE DESCRIPTION OF TASK :");
            this.task_descprition = Console.ReadLine();
            Console.WriteLine("ENTER TASK DURATION :");
            this.DURATION = int.TryParse(Console.ReadLine(), out durTation1) ? durTation1 : 0;
            Console.WriteLine("YOUR TASK STATUS IS NOW ACTIVATED :");
            this.condition = false;
            if (this.condition == false)
            {
                Console.WriteLine("TASK IS NOT DONE YET");
            }
        }
        public void add_task()
        {
            Console.WriteLine("ENTER YOUR TASK ID :");
            this.id_add = int.TryParse(Console.ReadLine(), out id1) ? id1 : 0;
            Console.WriteLine("ENTER THE DESCRIPTION OF TASK :");
            this.task_descprition_add = Console.ReadLine();

        }
        public void remover_task()
        {

            Console.WriteLine("ENTER THE ID OF THE TASK TO REMOVE :");
            this.id_remove = int.TryParse(Console.ReadLine(), out id1) ? id1 : 0;

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

       


    }
    class TASK_MANAGER :Task
        {
            List<Task> tasks = new List<Task>();
            Task task = new Task();

           
            public void Addition_Task()
            {
                Task task_a = new Task();
                task_a.add_task();
                tasks.Add(task_a);
            }
          
            public void Remove_Task()
            {
                Task task_r = new Task();
                task_r.remover_task();
                tasks.Remove(task_r);
            }
           
            public void TASK_Status_CONTROL()
            {
                Task task_check = new Task();
                task_check.TASK_Condition();
                while ((end_DURATION <= DURATION) && (end_DURATION == DURATION))
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
                string path = @"D:\doomsday\to_do_list.txt";
               
                


                    using (StreamWriter sw = new StreamWriter(path, true))
                    {

                        sw.WriteLine("id is :" + this.id);
                        sw.WriteLine("description is :" + this.task_descprition);
                        sw.WriteLine("duration is :" + this.DURATION);
                        sw.WriteLine("condition is :" + this.condition);
                        sw.WriteLine("task ADD" + id_add + task_descprition_add);
                        sw.WriteLine("task REMOVED" + id_remove);
                        sw.WriteLine(" condition" + condition);
                foreach (Task t in tasks)
                {
                    // We use 't' to get the data for EACH specific task in the list
                    sw.WriteLine("ID: " + t.id_add);
                    sw.WriteLine("Description: " + t.task_descprition_add);
                    sw.WriteLine("-----------------------");
                }
                sw.WriteLine($"{DateTime.Now}");
                    }


                
            }

        class call
        {

            TASK_MANAGER tASK = new TASK_MANAGER();
            public void ADD_TASK()
            {
            
                tASK.Addition_Task();
            }
            public void REM_TASK() {
            
                tASK.Remove_Task();

            }
            public void CHECK_TASK() {
             
                tASK.TASK_Status_CONTROL(); 
            }
            Task task_work = new Task();
            public void time_control_start() {
             
                task_work.start_timer();
            }
                public void time_control_stop() {
                
                    task_work.stop_timer();
            }   
            public void write_file() {
               
                tASK.write_in_file();
            }
        }



            class Program
            {
                static void Main(string[] args)
                {
                Task task_main = new Task();
                call call_main = new call();

                Console.WriteLine(" : WELCOME TO TASK TRACKER : ");
                task_main.Task_starter();
                Console.WriteLine();
                Console.WriteLine("only five time operate able ");
                int i = 0;
                while (0 < 5)
                {
                    char want;
                    Console.WriteLine("WHAT DO YOU WANT TO TRACK :");
                    Console.WriteLine();
                    Console.WriteLine("PRESS a FOR ADD a TASK :");
                    Console.WriteLine();
                    Console.WriteLine("PRESS r FOR Removing a TASK :");
                    Console.WriteLine();
                    Console.WriteLine("PRESS s FOR checking the status of a TASK :");
                    Console.WriteLine();
                    Console.WriteLine("PRESS q FOR quit a TASK :");
                    Console.WriteLine();

                    want = char.Parse(Console.ReadLine());

                    switch (want)
                    {

                        case 'a':
                            call_main.ADD_TASK();
                            Console.WriteLine("task added timer start :");
                            call_main.time_control_start();
                            break;
                        case 'A':
                            call_main.ADD_TASK();
                            Console.WriteLine("task added timer start :");
                            call_main.time_control_start();
                            break;
                        case 'r':
                            call_main.REM_TASK();
                            Console.WriteLine("The task is removed : ");
                            break;
                        case 'R':
                            call_main.REM_TASK();
                            Console.WriteLine("The task is removed : ");
                            break;
                        case 's':
                            call_main.CHECK_TASK();
                            break;
                        case 'S':
                            call_main.CHECK_TASK();
                            break;
                        case 'q':
                            call_main.time_control_stop();
                            break;
                        case 'Q':
                            call_main.time_control_stop();
                            break;
                        default: break;
                          
                    }
                    Console.WriteLine("___________________________");
                    i++;
                }

                call_main.write_file();



            }

            }
            }
        
    }  
   
