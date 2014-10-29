using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace gui_and_visualization
{
    class custom_button_class
    {
    }
    public class custom_button : System.Windows.Forms.Button
    {
         public static void main_button() {
         int x; //button x position
         int y; //button y position
         bool has_dot; //pattern
         bool has_dot_above;
         bool has_dot_left;
         bool has_dot_right;
         bool has_dot_below;
         Random r = new Random();
         int random = r.Next(1, 2);       
            if (random == 1)
            {
                has_dot = true;
            }
            else { has_dot = false; }
        
        }



        public List<string> GetAllPropertyValues()
        {
            List<string> values = new List<string>();
            foreach (var pi in typeof(custom_button).GetProperties())
            {
                values.Add(pi.GetValue(this, null).ToString());
            }

            return values;
        }
    }
}
