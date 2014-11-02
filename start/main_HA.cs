using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main_HA
{
    /// <summary>
    /// ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ ¯\(o_°)/¯ 
    /// All data going in and out of the system goes through here
    /// Use this like the Model like a Model View Controller System
    /// </summary>
    public class main_HA
    {
   // public void main_HA() {
     //       Console.WriteLine("main_HA is here");
       // }
        public void write_black_box_socket(string socketString)
        {
            //take black box data and write to log
        }
        public DateTime write_current_time(string socketString)
        {
            //take black box data and write to log
            return DateTime.Now;
        }
        public void write_pre_game_survey()
        {
            //accept all the form arguments and write to log
        }
        public void write_post_game_survey()
        {
            //accept all the form arguments and write to log
        }
    }

}
