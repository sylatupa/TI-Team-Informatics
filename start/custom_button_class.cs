using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace gui_and_visualization
{
    public class custom_button : System.Windows.Controls.Button 
    {
        public int x; //button x position
        public int y; //button y position
        public bool has_dot; //pattern
        public bool has_dot_above;
        public bool has_dot_left;
        public bool has_dot_right;
        public bool has_dot_below;
        public void main_button()
        {
        x = 0; //button x position
         y = 0; //button y position
         has_dot = false; //pattern
        has_dot_above = false;
        has_dot_left = false;  
        has_dot_right = false; 
        has_dot_below= false;
            
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
