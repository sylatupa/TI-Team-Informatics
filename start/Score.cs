//using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Working_Memory_Battery_and_Sensor_Input
{
    public class Vector2
    {
        public int X;
        public int Y;
    }
    public class Score
    {
        List<float> distances = new List<float>();
        public float rowbasedMinEuclideanDistance(List<Vector2> answers, List<Vector2> selections)
        {
            List<List<Vector2>> answerPairing = new List<List<Vector2>>();
            float minimumDistance = distances[0];
            int selectionIndex = 0;
            if (answers.Count == 0)
            {
                return 0;
            }
            foreach (Vector2 selection in selections)
            {
                List<Vector2> answerPair = new List<Vector2>();
                answerPair.Add(answers[0]);
                answerPair.Add(selection);
                answerPairing.Add(answerPair);
            }
            foreach (List<Vector2> pair in answerPairing)
            {
                distances.Add(computeEuclideanDistance(pair[0], pair[1]));
            }
            for (int i = 0; i < distances.Count; i++)
            {
                if (distances[i] < minimumDistance)
                {
                    minimumDistance = distances[i];
                    selectionIndex = i;
                }
            }
            answers.RemoveAt(0);
            selections.RemoveAt(selectionIndex);
            return minimumDistance + rowbasedMinEuclideanDistance(answers, selections);
        }
        public int rowbasedMinManhattanDistance(List<Vector2> answers, List<Vector2> selections)
        {
            int minimumDistance = Convert.ToInt32(distances[0]);
            int selectionIndex = 0;
            List<List<Vector2>> answerPairing = new List<List<Vector2>>();
            if (answers.Count == 0)
            {
                return 0;
            }
            foreach (Vector2 selection in selections)
            {
                List<Vector2> answerPair = new List<Vector2>();
                answerPair.Add(answers[0]);
                answerPair.Add(selection);
                answerPairing.Add(answerPair);
            }
            foreach (List<Vector2> pair in answerPairing)
            {
                distances.Add(computeManhattanDistance(pair[0], pair[1]));
            }
            for (int i = 0; i < distances.Count; i++)
            {
                if (distances[i] < minimumDistance)
                {
                    minimumDistance = Convert.ToInt32(distances[i]);
                    selectionIndex = i;
                }
            }
            answers.RemoveAt(0);
            selections.RemoveAt(selectionIndex);
            return minimumDistance + rowbasedMinManhattanDistance(answers, selections);
        }
        public float computeEuclideanDistance(Vector2 answer, Vector2 selection)
        {
            int xDist = (int)(Math.Abs(selection.X - answer.X));
            int yDist = (int)(Math.Abs(selection.Y - answer.Y));
            float hypotenuse = (float)(Math.Sqrt(Math.Pow(xDist, 2) + Math.Pow(yDist, 2)));
            return hypotenuse;
        }
        public int computeManhattanDistance(Vector2 answer, Vector2 selection)
        {
            int xDist = (int)(Math.Abs(selection.X - answer.X));
            int yDist = (int)(Math.Abs(selection.Y - answer.Y));
            return xDist + yDist;
        }
    }
}