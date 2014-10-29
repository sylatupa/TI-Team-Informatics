using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui_and_visualization
{
    class grid_class
    {
        public static int grid_size = 10;
        //List<string> values = new List<string>();
        custom_button[,] buttonArray = new custom_button[grid_size, grid_size]; //{ { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };


        public void main_grid () {

            // 1) Build Grid using custom button class and setting the pattern
            for (int i = 0; i <= grid_size; i++)
            {
                custom_button button = new custom_button();
                //button.main_button();
            }

        }

    }
}
