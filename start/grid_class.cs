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
        public void main_grid()
        {

        }

        public void GenerateDotSSTM()
        {
            /*
               //Copyright to Lee-xieng yang, 29/06/2009
               //This program will generate a mat file containing the dot stimuli to be
               //used in SSTM program. The stimuli include 2 practice and 30 test items.
               //The dots of the 30 test items each are from 2 to 6. for ( each dot
               //number, there are 3 items for ( the near condition and 3 for ( the far
               //condition. The near condition means the inter-dot distance is not
               //larger than 2 and otherwise does the far condition.
   
               //Generate a dot pool of 100 = 10 x 10 dots on a 2-D space
               //Dots on margins are included
               */
            int y;
            int x;
            for (int i = 0; i <= grid_size; i++)
            {
                custom_button button = new custom_button();
                //button.main_button();
            }
            // make an array
            // make an array of all zeros
            //Set up the maximum distance between dots in the near condition
            //The first two stimuli are practice stimuli
            ////Generate the stimuli of from 2 to 6 dots
            // //Generate the stimuli in the far condition
            //  //DotIndex=GetFarStimuli(DotsPosition,n);

            //Generate the stimuli in the near condition
            //Sample out the sutiable near items from the temporary pool

            //Compute the distance matrix between any two dots

            //The inter-distance between any two stimuli must not be larger
            //than spotsize

        }
        public void ComputeDist(int empDots)
        {

        }
        public void GetNearDotsPool(int DotsPosition)
        {
            //function TempDots=GetNearDotsPool(DotsPosition,tempsamplesize,spotsize)
            //Set up a vector containing one value of 1 and others of 0 for ( picking
            //up one dot from the 100-dots pool
            //Set up a matrix for ( storing the items to be sampled out as stimuli
            //Generate the temporary pool for ( samping out the suitable stimuli
            //Randomly sample n items from dot pool without replacement
        }
        public void GetFarStimuli(int DtPos)
        {
            //function [iterations DotIndex]=GetFarStimuli(DtPos,n)

        }
        public void inter_dot_dist(int D)
        {
            //function SeqDist=InterDotDist(D)
        }
    }
}

